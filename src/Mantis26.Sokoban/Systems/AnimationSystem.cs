using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis.Core.Common.Attributes;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Svelto.ECS;
using Mantis26.Sokoban.Components;
using Mantis.Core.MonoGame.Common.Extensions;
using Mantis26.Sokoban.Utilities;

namespace Mantis26.Sokoban.Systems
{
    public class AnimationSystem(SpriteBatch spriteBatch, EntitiesDB entitiesDb, Camera camera) : IDrawSystem, ISceneSystem
    {
        private readonly SpriteBatch _spriteBatch = spriteBatch;
        private readonly EntitiesDB _entitiesDb = entitiesDb;
        private readonly Camera _camera = camera;

        public void Ready()
        {
            //    throw new NotImplementedException();
        }

        [SequenceGroup<DrawSequenceGroupEnum>(DrawSequenceGroupEnum.Draw)]
        public void Draw(GameTime gameTime)
        {
            var groups = this._entitiesDb.FindGroups<Animatable, Position2D>();

            this._spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, this._camera.WorldViewProjection);

            foreach (var ((animatables, positions, count), _) in this._entitiesDb.QueryEntities<Animatable, Position2D>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    ref Animatable animatable = ref animatables[i];
                    ref Position2D position = ref positions[i];

                    this._spriteBatch.Draw(
                        gameTime,
                        ref animatable.Animation,
                        position.Display,
                        Color.White,
                        0f,
                        Vector2.Zero,
                        1 / 32f);
                }
            }

            this._spriteBatch.End();
        }
    }
}
