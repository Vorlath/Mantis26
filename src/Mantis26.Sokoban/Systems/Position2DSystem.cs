using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis.Core.Common.Attributes;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Mantis26.Sokoban.Components;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Systems
{
    public class Position2DSystem(
        EntitiesDB entitiesDb
    ) : ISceneSystem, IUpdateSystem
    {
        private readonly EntitiesDB _entitiesDB = entitiesDb;

        [SequenceGroup<UpdateSequenceGroupEnum>(UpdateSequenceGroupEnum.PreUpdate)]
        public void Update(GameTime gameTime)
        {
            var groups = this._entitiesDB.FindGroups<Position2D>();

            foreach (var ((positions, count), _) in this._entitiesDB.QueryEntities<Position2D>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref Position2D position = ref positions[i];

                    if(position.Moving == false)
                    {
                        continue;
                    }

                    position.Delta += (float)gameTime.ElapsedGameTime.TotalSeconds * (1000f / 75f);
                    if (position.Delta >= 1)
                    {
                        position.Delta = 0;
                        position.Display = position.Value.ToVector2();
                        position.Origin = position.Value;
                        position.Moving = false;
                    }
                    else
                    {
                        position.Display = Vector2.Lerp(position.Origin.ToVector2(), position.Value.ToVector2(), position.Delta);
                    }
                }
            }
        }
    }
}
