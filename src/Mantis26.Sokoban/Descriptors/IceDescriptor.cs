using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Enums;
using Svelto.ECS;

namespace Mantis26.Sokoban.Descriptors
{
    public class IceDescriptor : IEntityDescriptor
    {
        public IComponentBuilder[] componentsToBuild => _compoentsToBuild;
        private static IComponentBuilder[] _compoentsToBuild = [
            new ComponentBuilder<EntityType>(EntityType<IceDescriptor>.Instance),
            new ComponentBuilder<Position2D>(),
            new ComponentBuilder<Spritable>(new Spritable(SpriteEnum.Ice)),
            new ComponentBuilder<Collidable>(new Collidable() {
                IsLocked = false,
                IsSolid = true
            })
        ];
    }
}
