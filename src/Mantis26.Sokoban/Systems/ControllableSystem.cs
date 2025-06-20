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
using Mantis26.Sokoban.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Svelto.ECS;

namespace Mantis26.Sokoban.Systems
{
    public class ControllableSystem(
        EntitiesDB entitiesDb,
        PushService pushService,
        Camera camera
    ) : ISceneSystem, IUpdateSystem, IDrawSystem
    {
        private readonly EntitiesDB _entitiesDB = entitiesDb;
        private readonly PushService _pushService = pushService;
        private readonly Camera _camera = camera;
        private InputEnum _lastInput = InputEnum.None;

        [SequenceGroup<DrawSequenceGroupEnum>(DrawSequenceGroupEnum.PreDraw)]
        [Sequence<DrawSequenceGroupEnum>(-100)]
        public void Draw(GameTime gameTime)
        {
            var groups = this._entitiesDB.FindGroups<Controllable, Position2D>();

            foreach (var ((controllables, positions, count), _) in this._entitiesDB.QueryEntities<Controllable, Position2D>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref Controllable controllable = ref controllables[i];
                    ref Position2D position = ref positions[i];

                    _camera.Position = Vector2.Lerp(_camera.Position, position.Display, (float)gameTime.ElapsedGameTime.TotalSeconds*(1000f / 250f));
                    if(float.IsNaN(_camera.Position.X) || float.IsNaN(_camera.Position.Y))
                    {
                        _camera.Position = position.Display;
                    }

                    return;
                }
            }
        }

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

            foreach (var ((types, controllables, positions, nativeIds, count), group) in this._entitiesDB.QueryEntities<EntityType, Controllable, Position2D>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    EntityType type = types[i];
                    ref Controllable controllable = ref controllables[i];
                    ref Position2D position = ref positions[i];

                    if(controllable.Disabled == true)
                    {
                        continue;
                    }

                    if(position.Moving == true)
                    {
                        continue;
                    }

                    Point target = position.Value + direction;
                    if(this._pushService.TryPush(type, nativeIds.GetEGID(i, group), position.Value, target, direction) == true)
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
