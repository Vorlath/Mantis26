using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mantis.Core.Common.Attributes;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Enums;
using Mantis26.Sokoban.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Svelto.ECS;

namespace Mantis26.Sokoban.Systems
{
    public class ControllableSystem(
        EntitiesDB entitiesDb
    ) : ISceneSystem, IUpdateSystem
    {
        private readonly EntitiesDB _entitiesDB = entitiesDb;
        private InputEnum _lastInput = InputEnum.None;

        [SequenceGroup<UpdateSequenceGroupEnum>(UpdateSequenceGroupEnum.PreUpdate)]
        public void Update(GameTime gameTime)
        {
            var groups = this._entitiesDB.FindGroups<Controllable, Position2D>();
            InputEnum input = Keyboard.GetState().GetCurrentInput();
            InputEnum deltas = ~_lastInput & input;
            _lastInput = input;

            foreach (var ((controllables, positions, count), _) in this._entitiesDB.QueryEntities<Controllable, Position2D>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref Controllable controllable = ref controllables[i];
                    ref Position2D position = ref positions[i];

                    if (position.Moving == true)
                    {
                        continue;
                    }

                    if(deltas.HasFlag(InputEnum.Up))
                    {
                        position.Value = position.Value + new Point(0, -1);
                        position.Moving = true;
                        continue;
                    }

                    if (deltas.HasFlag(InputEnum.Left))
                    {
                        position.Value = position.Value + new Point(-1, 0);
                        position.Moving = true;
                        continue;
                    }

                    if (deltas.HasFlag(InputEnum.Down))
                    {
                        position.Value = position.Value + new Point(0, 1);
                        position.Moving = true;
                        continue;
                    }

                    if (deltas.HasFlag(InputEnum.Right))
                    {
                        position.Value = position.Value + new Point(1, 0);
                        position.Moving = true;
                        continue;
                    }
                }
            }
        }
    }
}
