using Svelto.ECS;

namespace VampireSurvivors.Components
{
    public struct Controllable() : IEntityComponent
    {
        public float TargetVelocity { get; set; } = 50f;

    }
}