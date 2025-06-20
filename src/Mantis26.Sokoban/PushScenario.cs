using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban
{
    public struct PushScenario(EntityType sourceType, EGID sourceEGID, Point sourcePosition, EntityType targetType, EGID targetEGID, Point targetPosition, Point direction)
    {
        public readonly EntityType sourceType = sourceType;
        public readonly EGID sourceEGID = sourceEGID;
        public readonly Point sourcePosition = sourcePosition;
        public readonly EntityType targetType = targetType;
        public readonly EGID targetEGID = targetEGID;
        public readonly Point targetPosition = targetPosition;
        public readonly Point direction = direction;
    }
}
