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
    public class PlayerDescriptor : IEntityDescriptor
    {
        public IComponentBuilder[] componentsToBuild => _compoentsToBuild;
        private static IComponentBuilder[] _compoentsToBuild = [
            new ComponentBuilder<Position2D>(),
            new ComponentBuilder<Controllable>(),
            new ComponentBuilder<Spritable>(new Spritable(SpriteEnum.Player))
        ];
    }
}
