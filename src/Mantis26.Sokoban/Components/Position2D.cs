using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Components
{
    public struct Position2D : IEntityComponent
    {
        public Point Value { get; set; }
        public Point Origin { get; set; }
        public float Delta { get; set; }
        public Vector2 Display { get; set; }
        public bool Moving { get; set; }
    }
}
