using Microsoft.Xna.Framework;
using Svelto.ECS;
using TextAdventure.Enums;

namespace TextAdventure.Components
{
    public struct Texture(TextureEnum value, Color color) : IEntityComponent
    {
        public TextureEnum Value = value;
        public Color Color = color;
    }
}