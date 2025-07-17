using Mantis.Core.Common.Attributes;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Microsoft.Xna.Framework;
using Svelto.ECS;

//using System.Numerics;
using VampireSurvivors.Components;

namespace VampireSurvivors.Engines
{
    public class MovementEngine() : IQueryingEntitiesEngine, IUpdateSystem, ISceneSystem
    {

        public EntitiesDB entitiesDB { get; set; } = null!;

        public void Ready()
        {
            //    throw new NotImplementedException();
        }

        [SequenceGroup<UpdateSequenceGroupEnum>(UpdateSequenceGroupEnum.Update)]
        public void Update(GameTime gameTime)
        {
            var playerGroups = this.entitiesDB.FindGroups<Velocity, Transform2D, Controllable>();
            foreach (var ((velocities, positions, controllables, count), group) in this.entitiesDB.QueryEntities<Velocity, Transform2D, Controllable>(playerGroups))
            {
                var (animations, collisions, _) = this.entitiesDB.QueryEntities<Animated, Collidable>(group);
                for (int i = 0; i < count; i++)
                {
                    ref Velocity velocity = ref velocities[i];
                    ref Transform2D position = ref positions[i];

                    ref Animated animation = ref animations[i];
                    ref Collidable collision = ref collisions[i];

                    UpdatePlayer(ref velocity, ref position, ref animation, ref collision, gameTime);
                    var enemyGroups = this.entitiesDB.FindGroups<Velocity, Transform2D, Enemy, Speed>();
                    foreach (var ((enemyVelocities, enemyPositions, enemies, enemyCount), enemyGroup) in this.entitiesDB.QueryEntities<Velocity, Transform2D, Enemy>(enemyGroups))
                    {
                        var (enemySpeeds, enemyCollisions, _) = this.entitiesDB.QueryEntities<Speed, Collidable>(enemyGroup);
                        for (int j = 0; j < enemyCount; j++)
                        {
                            ref Velocity enemyVelocity = ref enemyVelocities[j];
                            ref Transform2D enemyPosition = ref enemyPositions[j];
                            ref Speed enemySpeed = ref enemySpeeds[j];
                            ref Collidable enemyCollision = ref enemyCollisions[j];

                            UpdateEnemy(ref enemyVelocity, ref enemyPosition, ref enemySpeed, ref position, gameTime);
                        }
                    }
                }
            }
        }

        private static void UpdatePlayer(ref Velocity velocity, ref Transform2D position, ref Animated animation, ref Collidable collision, GameTime gameTime)
        {
            position.Position += (velocity.Value * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
        }

        private static void UpdateEnemy(ref Velocity enemyVelocity, ref Transform2D enemyPosition, ref Speed enemySpeed, ref Transform2D playerPosition, GameTime gameTime)
        {
            Vector2 chaseDirection = new Vector2(playerPosition.Position.X - enemyPosition.Position.X, playerPosition.Position.Y - enemyPosition.Position.Y);
            float normalized = MathF.Sqrt((chaseDirection.X * chaseDirection.X + chaseDirection.Y * chaseDirection.Y));
            if (chaseDirection.X != 0 && normalized != 0)
            {
                chaseDirection.X /= normalized;
            }
            else
            {
                chaseDirection.X = 0;
            }
            if (chaseDirection.Y != 0 && normalized != 0)
            {
                chaseDirection.Y /= normalized;
            }
            else
            {
                chaseDirection.Y = 0;
            }
            enemyVelocity.Value = chaseDirection * enemySpeed.Value;

            enemyPosition.Position += (enemyVelocity.Value * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            //Debug.WriteLine(enemyPosition.Position.Y);
        }
    }
}