using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis.Core.Common;
using Mantis.Core.MonoGame.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mantis26.Sokoban
{
    public static class AnimationTypes
    {
        public static readonly Id<AnimationType> Fire = Id<AnimationType>.GetByName(nameof(Fire));
        public static readonly Id<AnimationType> Water = Id<AnimationType>.GetByName(nameof(Water));

        public static void Initialize(ContentManager content)
        {
            Texture2D fireTexture = content.Load<Texture2D>("Sprites/fire");

            SpriteSheet fireSpriteSheet = new SpriteSheet(fireTexture, [
                new SpriteData("1", new Rectangle(0, 0, 32, 32)),
                new SpriteData("2", new Rectangle(32, 0, 32, 32)),
                new SpriteData("3", new Rectangle(0, 32, 32, 32)),
                new SpriteData("4", new Rectangle(32, 32, 32, 32)),
            ]);

            fireSpriteSheet.CreateAnimationType(AnimationTypes.Fire, [
                new AnimationFrameContext("3", 100),
                new AnimationFrameContext("1", 100),
                new AnimationFrameContext("2", 100),
                new AnimationFrameContext("4", 100),
                new AnimationFrameContext("2", 100),
                new AnimationFrameContext("1", 100),
                new AnimationFrameContext("3", 100),
                new AnimationFrameContext("4", 100),
                new AnimationFrameContext("1", 100),
                new AnimationFrameContext("2", 100),
                new AnimationFrameContext("3", 100),
                new AnimationFrameContext("4", 100),
            ]);

            Texture2D waterTexture = content.Load<Texture2D>("Sprites/water");

            SpriteSheet waterSpriteSheet = new SpriteSheet(waterTexture, [
                new SpriteData("1", new Rectangle(0, 0, 32, 32)),
                new SpriteData("2", new Rectangle(32, 0, 32, 32)),
                new SpriteData("3", new Rectangle(0, 32, 32, 32)),
                new SpriteData("4", new Rectangle(32, 32, 32, 32)),
            ]);

            waterSpriteSheet.CreateAnimationType(AnimationTypes.Water, [
                new AnimationFrameContext("3", 200),
                new AnimationFrameContext("1", 200),
                new AnimationFrameContext("2", 200),
                new AnimationFrameContext("4", 200),
                new AnimationFrameContext("2", 200),
                new AnimationFrameContext("1", 200),
                new AnimationFrameContext("3", 200),
                new AnimationFrameContext("4", 200),
                new AnimationFrameContext("1", 200),
                new AnimationFrameContext("2", 200),
                new AnimationFrameContext("3", 200),
                new AnimationFrameContext("4", 200),
            ]);
        }
    }
}
