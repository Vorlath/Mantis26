using Svelto.ECS;
using VampireSurvivors.Components;

namespace VampireSurvivors.Descriptors
{
    public class TextElementDescriptor : IEntityDescriptor
    {
        public IComponentBuilder[] componentsToBuild => [

            new ComponentBuilder<Velocity>(new Velocity()),
            new ComponentBuilder<Size>(new Size()),
            new ComponentBuilder<Transform2D>(new Transform2D()),
            new ComponentBuilder<Font>(new Font()),
            ];

    }
}
