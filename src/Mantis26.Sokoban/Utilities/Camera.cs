using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mantis26.Sokoban.Utilities
{
    public class Camera(GraphicsDevice graphics)
    {
        private GraphicsDevice _graphics = graphics;

        public Vector2 Position { get; set; }
        public float Zoom { get; set; } = 32;

        public Matrix World => Matrix.CreateTranslation(-this.Position.X, -this.Position.Y, 0);
        public Matrix View => Matrix.CreateScale(this.Zoom, this.Zoom, 1);
        public Matrix Projection => Matrix.CreateTranslation(this._graphics.Viewport.Bounds.Width / 2f, this._graphics.Viewport.Bounds.Height / 2f, 0f);

        public virtual Vector2 ToScreen(Vector2 world)
        {
            return Vector2.Transform(world, this.World * this.View * this.Projection);
        }

        public virtual Vector2 ToWorld(Vector2 screen)
        {
            Matrix inverse = Matrix.Invert(this.World * this.View * this.Projection);
            return Vector2.Transform(screen, inverse);
        }
    }
}
