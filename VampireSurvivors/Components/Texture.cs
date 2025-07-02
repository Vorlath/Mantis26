using Microsoft.Xna.Framework;
using Svelto.ECS;
using VampireSurvivors.Enums;

namespace VampireSurvivors.Components
{
    public struct Texture(TextureEnum value, Color color) : IEntityComponent
    {
        public TextureEnum Value = value;
        public Color Color = color;
    }
}