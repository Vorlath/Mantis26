using Svelto.ECS;

namespace VampireSurvivors.Components
{
    public struct Input() : IEntityComponent
    {
        public bool isChargingJump { get; set; } = false;

    }
}
