using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Services
{
    public class PushService(EntitiesDB entitiesDb)
    {
        private readonly EntitiesDB _entitiesDB = entitiesDb;

        public bool TryPush(Point target, Point direction)
        {
            var groups = this._entitiesDB.FindGroups<Position2D, Collidable>();

            foreach (var ((positions, collidables, count), _) in this._entitiesDB.QueryEntities<Position2D, Collidable>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref Position2D position = ref positions[i];
                    ref Collidable collidable = ref collidables[i];

                    if(position.Value != target)
                    {
                        continue;
                    }

                    if(collidable.Static == true)
                    {
                        return false;
                    }

                    if(this.TryPush(target + direction, direction) == false)
                    {
                        return false;
                    }

                    position.Value = target + direction;
                    position.Moving = true;
                }
            }

            return true;
        }
    }
}
