using Svelto.ECS;
using System.Numerics;

namespace TextAdventure.Components
{
    public struct Size(float width, float height) : IEntityComponent
    {
        public Vector2 Value = new(width, height);
    }
}