using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svelto.ECS;

namespace Mantis26.Sokoban.Utilities
{
    public class ExclusiveGroupManager<TDescriptor>
        where TDescriptor : IEntityDescriptor
    {
        public static readonly ExclusiveGroup ExclusiveGroup = new();
    }
}
