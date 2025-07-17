using Svelto.ECS;

namespace VampireSurvivors.Components
{
    public struct Speed(float value = 1) : IEntityComponent
    {
        public float Value = value;
    }
}
