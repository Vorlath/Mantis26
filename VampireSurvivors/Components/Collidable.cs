using Svelto.ECS;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace VampireSurvivors.Components
{

    public struct Collidable(RectangleF rectangle, Vector2 offset) : IEntityComponent
    {
        public static readonly FilterContextID FilterContextID = FilterContextID.GetNewContextID();
        public RectangleF CollisionBox { get; set; } = rectangle;
        public Vector2 Offset { get; set; } = offset;
    }
}