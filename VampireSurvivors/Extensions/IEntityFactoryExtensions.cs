using Microsoft.Xna.Framework;
using Svelto.ECS;
using VampireSurvivors.Components;
using VampireSurvivors.Descriptors;
using VampireSurvivors.Scenes;

namespace VampireSurvivors.Extensions
{
    public static class IEntityFactoryExtensions
    {

        public static EntityInitializer SpawnWorm(this IEntityFactory entityFactory, Vector2 position, uint id)
        {
            var Worm = entityFactory.BuildEntity<WormDescriptor>(id, ExclusiveGroups.EnemyGroup);
            Worm.Init(new Transform2D(position.X, position.Y, 0));
            Worm.Init(new Velocity(0, 0));
            Worm.Init(new Size(64, 80));
            Worm.Init(new Animated(AnimationTypes.WormRight));
            Worm.Init(new Collidable(new RectangleF(0, 0, 32, 64), new Vector2(16, 0)));
            Worm.Init(new Speed(0.1f));
            Worm.Init(new Enemy());

            return Worm;
        }
    }
}
