using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Extensions;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Services
{
    public class PushService(EntitiesDB entitiesDb, IEnumerable<IPushScenarioService> pushScenarioServices)
    {
        private readonly EntitiesDB _entitiesDB = entitiesDb;
        private IPushScenarioService[] _scenarios = [.. pushScenarioServices];

        public bool TryPush(EntityType sourceType, EGID sourceEGID, Point sourcePosition, Point targetPosition, Point direction)
        {
            var groups = this._entitiesDB.FindGroups<EntityType, Position2D, Collidable>();

            foreach (var ((types, positions, collidables, nativeIds, count), group) in this._entitiesDB.QueryEntities<EntityType, Position2D, Collidable>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref EntityType targetType = ref types[i];
                    ref Position2D position = ref positions[i];
                    ref Collidable collidable = ref collidables[i];

                    if(position.Value != targetPosition)
                    {
                        continue;
                    }

                    PushScenario scenario = new PushScenario(sourceType, sourceEGID, sourcePosition, targetType, nativeIds.GetEGID(i, group), targetPosition, direction);
                    foreach(IPushScenarioService pushScenarioService in this._scenarios)
                    {
                        if(pushScenarioService.CanHandleScenario(scenario) == true)
                        {
                            return pushScenarioService.HandleScenario(scenario);
                        }
                    }

                    if(collidable.IsSolid == false)
                    {
                        return true;
                    }

                    if (collidable.IsLocked || this.TryPush(targetType, nativeIds.GetEGID(i, group), targetPosition, targetPosition + direction, direction) == false)
                    {
                        return false;
                    }

                    position.Value = targetPosition + direction;
                    position.Moving = true;
                }
            }

            return true;
        }
    }
}
