using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svelto.ECS;

namespace Mantis26.Sokoban.Components
{
    public struct Collidable : IEntityComponent
    {
        public bool Static { get; set; }
    }
}
