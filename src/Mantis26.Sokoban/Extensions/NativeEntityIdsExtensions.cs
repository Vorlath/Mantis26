using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svelto.ECS;
using Svelto.ECS.Internal;

namespace Mantis26.Sokoban.Extensions
{
    public static class NativeEntityIdsExtensions
    {
        public static EGID GetEGID(this NativeEntityIDs nativeIds, int index, ExclusiveGroupStruct group)
        {
            return new EGID(nativeIds[index], group);
        }
    }
}
