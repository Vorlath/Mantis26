using Mantis.Core.Common;
using Mantis.Core.MonoGame.Common;
using Svelto.ECS;

namespace VampireSurvivors.Components
{
    public struct Animated(Id<AnimationType> animationType) : IEntityComponent
    {
        public Animation Animation = new Animation(animationType, Microsoft.Xna.Framework.Color.White);
    }
}