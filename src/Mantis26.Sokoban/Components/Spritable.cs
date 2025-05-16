using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Enums;
using Svelto.ECS;

namespace Mantis26.Sokoban.Components
{
    public struct Spritable(SpriteEnum sprite) : IEntityComponent
    {
        public readonly SpriteEnum Sprite = sprite;
    }
}
