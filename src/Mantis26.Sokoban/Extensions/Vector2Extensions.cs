using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Utilities;
using Microsoft.Xna.Framework;

namespace Mantis26.Sokoban.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 ToWorld(this Vector2 value, Camera camera)
        {
            return camera.ToWorld(value);
        }

        public static Vector2 ToScreen(this Vector2 value, Camera camera)
        {
            return camera.ToScreen(value);
        }

        public static Vector2 ToCeiling(this Vector2 value)
        {
            return new Vector2(MathF.Ceiling(value.X), MathF.Ceiling(value.Y));
        }

        public static Vector2 ToFloor(this Vector2 value)
        {
            return new Vector2(MathF.Floor(value.X), MathF.Floor(value.Y));
        }
    }
}
