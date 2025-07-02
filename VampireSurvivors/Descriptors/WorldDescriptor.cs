using Svelto.ECS;

namespace VampireSurvivors.Descriptors
{
    public class WorldDescriptor : IEntityDescriptor
    {
        public IComponentBuilder[] componentsToBuild => _componentsToBuild;

        private static readonly IComponentBuilder[] _componentsToBuild =
        [
            //new ComponentBuilder<Boundary>(new Boundary())
        ];
    }
}