using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svelto.ECS;

namespace Mantis26.Sokoban
{
    public static class ExclusiveGroups
    {
        public static readonly ExclusiveGroup Players = new();
        public static readonly ExclusiveGroup Rocks = new();
        public static readonly ExclusiveGroup Walls = new();
    }
}
