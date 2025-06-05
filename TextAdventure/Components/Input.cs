using Svelto.ECS;

namespace TextAdventure.Components
{
    public struct Input() : IEntityComponent
    {
        public bool isChargingJump { get; set; } = false;

    }
}
