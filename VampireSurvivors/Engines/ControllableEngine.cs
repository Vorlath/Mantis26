using Mantis.Core.Common;
using Mantis.Core.Common.Attributes;
using Mantis.Core.MonoGame.Common;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Svelto.ECS;
using VampireSurvivors.Components;

namespace VampireSurvivors.Engines
{
    internal class ControllableEngine : IEngine, IQueryingEntitiesEngine, IUpdateSystem, ISceneSystem
    {
        public EntitiesDB entitiesDB { get; set; } = null!;

        public void Ready()
        {
            // throw new NotImplementedException();
        }

        [SequenceGroup<UpdateSequenceGroupEnum>(UpdateSequenceGroupEnum.Update)]
        public void Update(GameTime gameTime)
        {


            // float targetVelocityModifier = GetTargetVelocityModifier();

            var groups = this.entitiesDB.FindGroups<Animated, Controllable, Velocity, Transform2D>();
            foreach (var ((animations, controllables, velocities, transform2Ds, _, count), group) in this.entitiesDB.QueryEntities<Animated, Controllable, Velocity, Transform2D>(groups))
            {
                var (directions, speeds, _) = this.entitiesDB.QueryEntities<Direction, Speed>(group);
                for (int i = 0; i < count; i++)
                {
                    ref Controllable controllable = ref controllables[i];
                    ref Velocity velocity = ref velocities[i];
                    ref Transform2D transform2D = ref transform2Ds[i];
                    ref Animated animated = ref animations[i];
                    ref Speed speed = ref speeds[i];
                    //    ref PlayerState playerState = ref playerStates[i];
                    ref Direction direction = ref directions[i];
                    //    ref Jump jump = ref jumps[i];

                    //    GetJump(ref jump, ref playerState, ref velocity, ref animated, ref direction, gameTime);
                    GetDirection(ref animated, ref direction);
                    //    getAnimationState(ref playerState, ref direction, ref animated);
                    //if (GetThrusters() == 1)

                    if (direction.isFacingRight)
                    {
                        if (direction.isRight || direction.isDown || direction.isUp)
                        {
                            if (animated.Animation.TypeId != Id<AnimationType>.GetByName("BirdWalkRight"))
                            {
                                animated.Animation.Type = AnimationType.GetAnimationTypeById(Id<AnimationType>.GetByName("BirdWalkRight"));
                            }
                        }
                        else
                        {
                            if (animated.Animation.TypeId != Id<AnimationType>.GetByName("BirdIdleRight"))
                            {
                                animated.Animation.Type = AnimationType.GetAnimationTypeById(Id<AnimationType>.GetByName("BirdIdleRight"));
                            }
                        }
                    }
                    else
                    {

                        if (direction.isLeft || direction.isDown || direction.isUp)
                        {
                            if (animated.Animation.TypeId != Id<AnimationType>.GetByName("BirdWalkLeft"))
                            {
                                animated.Animation.Type = AnimationType.GetAnimationTypeById(Id<AnimationType>.GetByName("BirdWalkLeft"));
                            }
                        }
                        else
                        {
                            if (animated.Animation.TypeId != Id<AnimationType>.GetByName("BirdIdleLeft"))
                            {
                                animated.Animation.Type = AnimationType.GetAnimationTypeById(Id<AnimationType>.GetByName("BirdIdleLeft"));
                            }
                        }

                    }
                    //{
                    //    if (animated.Animation.TypeId != 1)
                    //    {
                    //        animated.Animation.Type = AnimationType.GetAnimationTypeById(1);
                    //    }
                    //}
                    //else
                    //{
                    //    if (animated.Animation.TypeId != 0)
                    //    {
                    //        animated.Animation.Type = AnimationType.GetAnimationTypeById(0);
                    //    }
                    //}

                    // transform2D.Rotation += 100f * targetVelocityModifier * (float)gameTime.ElapsedGameTime.TotalSeconds;0
                    velocity.Value = direction.Value * speed.Value;
                    //velocity.Value.X = MathHelper.Lerp(velocity.Value.X, controllable.TargetVelocity * targetVelocityModifier, (float)gameTime.ElapsedGameTime.TotalSeconds * 2f);
                }
            }
        }

        private static void GetDirection(ref Animated animated, ref Direction direction)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Right))
            {
                direction.isRight = true;
                direction.isFacingRight = true;
            }
            else
            {
                direction.isRight = false;
            }

            if (keyboard.IsKeyDown(Keys.Up))
            {
                direction.isUp = true;
            }
            else
            {
                direction.isUp = false;
            }

            if (keyboard.IsKeyDown(Keys.Down))
            {
                direction.isDown = true;
            }
            else
            {
                direction.isDown = false;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                direction.isLeft = true;
                if (direction.isRight)
                {
                    direction.isFacingRight = true;
                }
                else
                {
                    direction.isFacingRight = false;
                }
            }
            else
            {
                direction.isLeft = false;
            }
        }
    }
}