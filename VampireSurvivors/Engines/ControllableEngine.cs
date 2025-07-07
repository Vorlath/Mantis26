using Mantis.Core.Common.Attributes;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Microsoft.Xna.Framework;
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
                //var (playerStates, jumps, directions, _) = this.entitiesDB.QueryEntities<PlayerState, Jump, Direction>(group);
                for (int i = 0; i < count; i++)
                {
                    ref Controllable controllable = ref controllables[i];
                    ref Velocity velocity = ref velocities[i];
                    ref Transform2D transform2D = ref transform2Ds[i];
                    ref Animated animated = ref animations[i];
                    //    ref PlayerState playerState = ref playerStates[i];
                    //    ref Direction direction = ref directions[i];
                    //    ref Jump jump = ref jumps[i];

                    //    GetJump(ref jump, ref playerState, ref velocity, ref animated, ref direction, gameTime);
                    //    GetDirection(ref playerState, ref animated, ref direction);
                    //    getAnimationState(ref playerState, ref direction, ref animated);
                    //if (GetThrusters() == 1)
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

                    // transform2D.Rotation += 100f * targetVelocityModifier * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    //velocity.Value += new Vector2(MathF.Sin(transform2D.Rotation * (MathF.PI / 180)), -MathF.Cos(transform2D.Rotation * (MathF.PI / 180))) * (GetThrusters() * 0.0012f);
                    //velocity.Value.X = MathHelper.Lerp(velocity.Value.X, controllable.TargetVelocity * targetVelocityModifier, (float)gameTime.ElapsedGameTime.TotalSeconds * 2f);
                }
            }
        }
    }
}