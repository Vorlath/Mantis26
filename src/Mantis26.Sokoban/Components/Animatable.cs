using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis.Core.Common;
using Mantis.Core.MonoGame.Common;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Components
{
    public struct Animatable(Id<AnimationType> animationTypeId) : IEntityComponent
    {
        public Animation Animation = new Animation(animationTypeId, Color.White);
    }
}
