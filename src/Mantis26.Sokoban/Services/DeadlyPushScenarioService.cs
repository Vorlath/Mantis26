using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Descriptors;
using Mantis26.Sokoban.Enums;
using Svelto.ECS;

namespace Mantis26.Sokoban.Services
{
    public class DeadlyPushScenarioService(EntitiesDB entitiesDb, IEntityFunctions entityFunctions) : IPushScenarioService
    {
        private readonly EntitiesDB _entitiesDB = entitiesDb;
        private readonly IEntityFunctions _entityFunctions = entityFunctions;

        public bool CanHandleScenario(PushScenario scenario)
        {
            if(scenario.sourceType != EntityType<PlayerDescriptor>.Instance)
            {
                return false;
            }

            if(_entitiesDB.HasAny<Deadly>(scenario.targetEGID.groupID) == false)
            {
                return false;
            }

            return true;
        }

        public bool HandleScenario(PushScenario scenario)
        {
            var controllables = _entitiesDB.QueryEntitiesAndIndex<Controllable>(scenario.sourceEGID, out uint index);
            var (spriteables, _) = _entitiesDB.QueryEntities<Spritable>(scenario.sourceEGID.groupID);

            ref Controllable controllable = ref controllables[index];
            ref Spritable spritable = ref spriteables[index];

            controllable.Disabled = true;
            spritable.Sprite = SpriteEnum.PlayerDead;

            return true;
        }
    }
}
