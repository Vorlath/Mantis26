using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis.Core.Common.Attributes;
using Mantis.Core.MonoGame.Common.Extensions;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Mantis26.Sokoban.Extensions;
using Mantis26.Sokoban.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mantis26.Sokoban.Systems
{
    public class WorldSystem(ContentManager content, SpriteBatch spriteBatch, GraphicsDevice graphics, Camera camera) : ISceneSystem, IDrawSystem
    {
        private readonly Texture2D _floor = content.Load<Texture2D>("Sprites/floor");
        private readonly SpriteBatch _spriteBatch = spriteBatch;
        private readonly GraphicsDevice _graphics = graphics;
        private readonly Camera _camera = camera;
        private Vector2 _position;


        [SequenceGroup<DrawSequenceGroupEnum>(DrawSequenceGroupEnum.PreDraw)]
        public void Draw(GameTime gameTime)
        {
            Vector2 center = _camera.ToScreen(_camera.Position);
            Vector2 topRight = Vector2.Zero.ToWorld(_camera).ToFloor().ToScreen(_camera);
            Vector2 bottomLeft = _graphics.Viewport.Bounds.ToVector2Bounds().ToWorld(_camera).ToCeiling().ToScreen(_camera);
            Rectangle sourceBounds = new Rectangle(Point.Zero, (bottomLeft - topRight).ToPoint());

            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Opaque, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullNone);
            _spriteBatch.Draw(_floor, topRight, sourceBounds, Color.White, 0, Vector2.Zero, new Vector2(_camera.Zoom / _floor.Width, _camera.Zoom / _floor.Height), SpriteEffects.None, 0);
            _spriteBatch.End();
        }
    }
}
