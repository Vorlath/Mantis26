using Svelto.ECS;
using System.Numerics;

namespace VampireSurvivors.Components
{
    public struct Direction() : IEntityComponent
    {
        public Vector2 Horizontal
        {
            get
            {
                Vector2 result = Vector2.Zero;
                if (isRight)
                {
                    result.X += 1f;
                }
                if (isLeft)
                {
                    result.X -= 1f;
                }
                return result;
            }
        }

        public Vector2 Vertical
        {
            get
            {
                Vector2 result = Vector2.Zero;
                if (isDown)
                {
                    result.Y += 1f;
                }
                if (isUp)
                {
                    result.Y -= 1f;
                }
                return result;
            }
        }

        public Vector2 Value => this.Horizontal + this.Vertical;
        public bool isFacingRight { get; set; } = true;
        public bool isRight { get; set; } = false;
        public bool isUp { get; set; } = false;
        public bool isDown { get; set; } = false;
        public bool isLeft { get; set; } = false;

    }
}
