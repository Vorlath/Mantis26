using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Descriptors;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Extensions
{
    public static class EntityFactoryExtensions
    {
        private static uint _entityId = uint.MinValue;

        public static EntityInitializer BuildPlayer(this IEntityFactory entityFactory, Point position)
        {
            EntityInitializer initilaizer = entityFactory.BuildEntity<PlayerDescriptor>(_entityId++, ExclusiveGroups.Players);
            initilaizer.Init<Position2D>(new Position2D() { Value = position, Origin = position, Delta = 0f, Moving = false, Display = position.ToVector2() });
            initilaizer.Init<Controllable>(new Controllable());

            return initilaizer;
        }

        public static EntityInitializer BuildRock(this IEntityFactory entityFactory, Point position)
        {
            EntityInitializer initilaizer = entityFactory.BuildEntity<RockDescriptor>(_entityId++, ExclusiveGroups.Rocks);
            initilaizer.Init<Position2D>(new Position2D() { Value = position, Origin = position, Delta = 0f, Moving = false, Display = position.ToVector2() });

            return initilaizer;
        }

        public static EntityInitializer BuildWall(this IEntityFactory entityFactory, Point position)
        {
            EntityInitializer initilaizer = entityFactory.BuildEntity<WallDescriptor>(_entityId++, ExclusiveGroups.Walls);
            initilaizer.Init<Position2D>(new Position2D() { Value = position, Origin = position, Delta = 0f, Moving = false, Display = position.ToVector2() });

            return initilaizer;
        }
    }
}
