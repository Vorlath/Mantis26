using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis.Core.Common.Attributes;
using Mantis.Core.MonoGame.Common.Extensions;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Enums;
using Mantis26.Sokoban.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Svelto.ECS;

namespace Mantis26.Sokoban.Systems
{
    public class SpriteSystem(
        SpriteBatch spriteBatch,
        ContentManager contentManager,
        EntitiesDB entitiesDb,
        Camera camera) : ISceneSystem
    {
        private readonly Camera _camera = camera;
        private readonly EntitiesDB _entitiesDB = entitiesDb;
        private readonly SpriteBatch _spriteBatch = spriteBatch;
        private readonly Dictionary<SpriteEnum, Texture2D> _sprites = new() {
            { SpriteEnum.Player, contentManager.Load<Texture2D>("Sprites/player") },
            { SpriteEnum.Rock, contentManager.Load<Texture2D>("Sprites/rock") },
            { SpriteEnum.Wall, contentManager.Load<Texture2D>("Sprites/wall") },
        };

        [SequenceGroup<DrawSequenceGroupEnum>(DrawSequenceGroupEnum.Draw)]
        public void Draw(GameTime gameTime)
        {
            var groups = this._entitiesDB.FindGroups<Spritable, Position2D>();

            this._spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, this._camera.World * this._camera.View * this._camera.Projection);

            foreach (var ((spritables, positions, count), _) in this._entitiesDB.QueryEntities<Spritable, Position2D>(groups))
            {
                for (int i = 0; i < count; i++)
                {
                    Spritable spritable = spritables[i];
                    Position2D position = positions[i];

                    this._spriteBatch.Draw(
                        this._sprites[spritable.Sprite],
                        position.Display,
                        this._sprites[spritable.Sprite].Bounds,
                        Color.White,
                        0f,
                        Vector2.Zero,
                        1 / _camera.Zoom,
                        SpriteEffects.None,
                        0);
                }
            }

            this._spriteBatch.End();
        }
    }
}
