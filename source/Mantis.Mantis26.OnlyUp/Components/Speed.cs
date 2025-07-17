using Svelto.ECS;

namespace VampireSurvivors.Components
{
    public struct Speed(int value = 1) : IEntityComponent
    {
        public int Value = value;
    }
}