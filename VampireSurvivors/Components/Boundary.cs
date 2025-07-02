using Svelto.ECS;

namespace VampireSurvivors.Components
{
    public struct Boundary(RectangleF boundary) : IEntityComponent
    {
        public RectangleF Value = boundary;
    }
}