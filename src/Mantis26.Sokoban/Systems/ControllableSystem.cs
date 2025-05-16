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
using Mantis26.Sokoban.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Svelto.ECS;

namespace Mantis26.Sokoban.Systems
{
    public class ControllableSystem(
        EntitiesDB entitiesDb,
        PushService pushService
    ) : ISceneSystem, IUpdateSystem
    {
        private readonly EntitiesDB _entitiesDB = entitiesDb;
        private readonly PushService _pushService = pushService;
        private InputEnum _lastInput = InputEnum.None;

        [SequenceGroup<UpdateSequenceGroupEnum>(UpdateSequenceGroupEnum.PreUpdate)]
        public void Update(GameTime gameTime)
        {
            var groups = this._entitiesDB.FindGroups<Controllable, Position2D>();
            InputEnum input = Keyboard.GetState().GetCurrentInput();
            InputEnum deltas = ~_lastInput & input;
            _lastInput = input;

            if (this.ShouldMove(deltas, out Point direction) == false)
            {
                return;
            }

            foreach (var ((controllables, positions, count), _) in this._entitiesDB.QueryEntities<Controllable, Position2D>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref Controllable controllable = ref controllables[i];
                    ref Position2D position = ref positions[i];

                    Point target = position.Value + direction;
                    if(this._pushService.TryPush(target, direction) == true)
                    {
                        position.Value = target;
                        position.Moving = true;
                    }
                }
            }
        }

        private bool ShouldMove(InputEnum deltas, out Point direction)
        {
            if (deltas.HasFlag(InputEnum.Up))
            {
                direction = new Point(0, -1);
                return true;
            }

            if (deltas.HasFlag(InputEnum.Left))
            {
                direction = new Point(-1, 0);
                return true;
            }

            if (deltas.HasFlag(InputEnum.Down))
            {
                direction = new Point(0, 1);
                return true;
            }

            if (deltas.HasFlag(InputEnum.Right))
            {
                direction = new Point(1, 0);
                return true;
            }

            direction = default;
            return false;
        }
    }
}
