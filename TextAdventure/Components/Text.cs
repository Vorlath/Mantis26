using Svelto.ECS;
using TextAdventure.Systems;

namespace TextAdventure.Components
{
    public struct Text(TextElement textElement) : IEntityComponent
    {
        public TextElement Value = textElement;
    }
}
