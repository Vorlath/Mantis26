using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Mantis26.Sokoban.Extensions
{
    public static class RectangleExtensions
    {
        public static Vector2 ToVector2Bounds(this Rectangle rectangle)
        {
            return new Vector2(rectangle.Width, rectangle.Height);
        }
    }
}
