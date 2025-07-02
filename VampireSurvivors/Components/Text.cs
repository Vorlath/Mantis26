using Svelto.ECS;
using VampireSurvivors.Systems;

namespace VampireSurvivors.Components
{
    public struct Text(TextElement textElement) : IEntityComponent
    {
        public TextElement Value = textElement;
    }
}
