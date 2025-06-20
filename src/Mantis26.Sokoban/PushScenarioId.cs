using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;

namespace Mantis26.Sokoban
{
    public struct PushScenarioId(EntityType sourceEntityType, EntityType destinationEntityType)
    {
        public readonly EntityType SourceEntityType = sourceEntityType;
        public readonly EntityType DestinationEntityType = destinationEntityType;

        public override bool Equals(object? obj)
        {
            return obj is PushScenarioId id &&
                   EqualityComparer<EntityType>.Default.Equals(SourceEntityType, id.SourceEntityType) &&
                   EqualityComparer<EntityType>.Default.Equals(DestinationEntityType, id.DestinationEntityType);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SourceEntityType, DestinationEntityType);
        }

        public static PushScenarioId Create<TSourceDescriptor, TTargetDescriptor>()
        {
            return new PushScenarioId(EntityType<TSourceDescriptor>.Instance, EntityType<TTargetDescriptor>.Instance);
        }
    }
}
