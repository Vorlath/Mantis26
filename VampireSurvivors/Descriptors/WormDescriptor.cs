using Svelto.ECS;
using VampireSurvivors.Components;

namespace VampireSurvivors.Descriptors
{
    public class WormDescriptor : IEntityDescriptor
    {
        public IComponentBuilder[] componentsToBuild => [
            new ComponentBuilder<Transform2D>(new Transform2D()),
            new ComponentBuilder<Velocity>(new Velocity()),
            new ComponentBuilder<Size>(new Size(128, 128)),
            new ComponentBuilder<Animated>(new Animated()),
            new ComponentBuilder<Collidable>(new Collidable()),
            new ComponentBuilder<Direction>(new Direction()),
            new ComponentBuilder<Enemy>(new Enemy()),
            new ComponentBuilder<Speed>(new Speed())
       ];
    }
}
