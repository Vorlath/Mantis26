using Svelto.ECS;

namespace TextAdventure.Components
{
    public struct Boundary(RectangleF boundary) : IEntityComponent
    {
        public RectangleF Value = boundary;
    }
}