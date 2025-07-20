using Mantis.Core.Common;
using Mantis.Core.MonoGame.Common;

namespace VampireSurvivors
{
    public static class AnimationTypes
    {
        public static readonly Id<AnimationType> WormRight = Id<AnimationType>.GetByName(nameof(WormRight));

        public static readonly Id<AnimationType> BirdIdleLeft = Id<AnimationType>.GetByName(nameof(BirdIdleLeft));
        public static readonly Id<AnimationType> BirdIdleRight = Id<AnimationType>.GetByName(nameof(BirdIdleRight));
        public static readonly Id<AnimationType> BirdWalkLeft = Id<AnimationType>.GetByName(nameof(BirdWalkLeft));
        public static readonly Id<AnimationType> BirdWalkRight = Id<AnimationType>.GetByName(nameof(BirdWalkRight));
    }
}
