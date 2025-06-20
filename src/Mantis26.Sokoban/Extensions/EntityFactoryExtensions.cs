using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Descriptors;
using Mantis26.Sokoban.Utilities;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Extensions
{
    public static class EntityFactoryExtensions
    {
        private static uint _entityId = uint.MinValue;

        public static EntityInitializer BuildPlayer(this IEntityFactory entityFactory, Point position)
        {
            EntityInitializer initilaizer = entityFactory.BuildEntity<PlayerDescriptor>(_entityId++, ExclusiveGroupManager<PlayerDescriptor>.ExclusiveGroup);
            initilaizer.Init<Position2D>(new Position2D() { Value = position, Origin = position, Delta = 0f, Moving = false, Display = position.ToVector2() });
            initilaizer.Init<Controllable>(new Controllable());

            return initilaizer;
        }

        public static EntityInitializer BuildObject<TDescriptor>(this IEntityFactory entityFactory, Point position)
            where TDescriptor : IEntityDescriptor, new()
        {
            EntityInitializer initilaizer = entityFactory.BuildEntity<TDescriptor>(_entityId++, ExclusiveGroupManager<TDescriptor>.ExclusiveGroup);
            initilaizer.Init<Position2D>(new Position2D() { Value = position, Origin = position, Delta = 0f, Moving = false, Display = position.ToVector2() });

            return initilaizer;
        }

        public static EntityInitializer BuildWall(this IEntityFactory entityFactory, Point position)
        {
            EntityInitializer initilaizer = entityFactory.BuildEntity<WallDescriptor>(_entityId++, ExclusiveGroupManager<WallDescriptor>.ExclusiveGroup);
            initilaizer.Init<Position2D>(new Position2D() { Value = position, Origin = position, Delta = 0f, Moving = false, Display = position.ToVector2() });

            return initilaizer;
        }
    }
}
