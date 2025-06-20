using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Descriptors;
using Mantis26.Sokoban.Enums;
using Mantis26.Sokoban.Extensions;
using Svelto.ECS;

namespace Mantis26.Sokoban.Services
{
    public class IceFirePushScenarioService(EntitiesDB entitiesDb, IEntityFunctions entityFunctions, IEntityFactory entityFactory) : IPushScenarioService
    {
        private readonly EntitiesDB _entitiesDB = entitiesDb;
        private readonly IEntityFunctions _entityFunctions = entityFunctions;
        private readonly IEntityFactory _entityFactory = entityFactory;

        public bool CanHandleScenario(PushScenario scenario)
        {
            return (scenario.targetType.Is<FireDescriptor>() && scenario.sourceType.Is<IceDescriptor>());
        }

        public bool HandleScenario(PushScenario scenario)
        {
            _entityFunctions.RemoveEntity<FireDescriptor>(scenario.targetEGID);
            _entityFunctions.RemoveEntity<IceDescriptor>(scenario.sourceEGID);

            _entityFactory.BuildObject<WaterDescriptor>(scenario.targetPosition);

            return true;
        }
    }
}
