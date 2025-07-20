using Mantis.Core.Logging.Common;
using Mantis.Core.MonoGame.Common;
using Mantis.Engine.Common;
using Mantis.Engine.Common.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using VampireSurvivors.Components;
using VampireSurvivors.Descriptors;

namespace VampireSurvivors.Scenes
{
    public static class ExclusiveGroups
    {

        public static readonly ExclusiveGroup PlayerGroup = new();
        public static readonly ExclusiveGroup EnemyGroup = new();
        public static readonly ExclusiveGroup WallGroup = new();

    }

    public class JsonRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class GameScene : BaseScene
    {
        private readonly EntitiesSubmissionScheduler _entitiesSubmissionScheduler;
        private readonly ILogger<GameScene> _logger;

        public GameScene(
            EnginesRoot enginesRoot,
            IEntityFactory entityFactory,
            EntitiesSubmissionScheduler entitiesSubmissionScheduler,
            ILogger<GameScene> logger,
            ISystemService systemService,
            ContentManager content) : base(systemService)
        {
            this._entitiesSubmissionScheduler = entitiesSubmissionScheduler;
            this._logger = logger;

            foreach (IEngine engine in this.SystemService.GetSystems<IEngine>())
            {
                enginesRoot.AddEngine(engine);
            }

            /////////////////////////////////////////////////////
            /// MNKY Animations

            var _BirdTexture = content.Load<Texture2D>("Bird");
            var BirdSpriteSheet = new SpriteSheet(_BirdTexture, [
                new SpriteData("1", new Rectangle(0, 0, 64, 80)),
                new SpriteData("2", new Rectangle(65, 0, 64, 80)),
                new SpriteData("3", new Rectangle((64 * 2) + 1, 0, 64, 80)),
                new SpriteData("4", new Rectangle((64 * 3) + 1, 0, 64, 80)),
                new SpriteData("5", new Rectangle((64 * 4) + 1, 0, 64, 80)),
                new SpriteData("6", new Rectangle((64 * 5) + 1, 0, 64, 80)),
                new SpriteData("7", new Rectangle((64 * 6) + 1, 0, 64, 80)),
                new SpriteData("8", new Rectangle((64 * 7) + 1, 0, 64, 80)),
                ]);

            var _WormTexture = content.Load<Texture2D>("Worm");
            var WormSpriteSheet = new SpriteSheet(_WormTexture, [
                new SpriteData("9", new Rectangle(0, 0, 64, 80))
                ]);

            AnimationType BirdIdleRight = BirdSpriteSheet.CreateAnimationType(AnimationTypes.BirdIdleRight, [
                new AnimationFrameContext("1", 1000)
            ]);

            // Walk right
            BirdSpriteSheet.CreateAnimationType(AnimationTypes.BirdWalkRight, [
                new AnimationFrameContext("2", 200),
                new AnimationFrameContext("3", 200),
                new AnimationFrameContext("4", 200),
                new AnimationFrameContext("1", 200),
            ]);

            // Idle left
            BirdSpriteSheet.CreateAnimationType(AnimationTypes.BirdIdleLeft, [
                new AnimationFrameContext("5", 1000)
            ]);

            // Walk left
            BirdSpriteSheet.CreateAnimationType(AnimationTypes.BirdWalkLeft, [
                new AnimationFrameContext("6", 200),
                new AnimationFrameContext("7", 200),
                new AnimationFrameContext("8", 200),
                new AnimationFrameContext("5", 200),
            ]);

            AnimationType WormRight = WormSpriteSheet.CreateAnimationType(AnimationTypes.WormRight, [
              new AnimationFrameContext("9", 1000)
          ]);


            /////////////////////////////////////////////////////
            // MNKY
            var Bird = entityFactory.BuildEntity<PlayerDescriptor>(0, ExclusiveGroups.PlayerGroup);
            Bird.Init(new Transform2D(500, 500, 0));
            Bird.Init(new Velocity(75, 0));
            Bird.Init(new Size(64, 80));
            Bird.Init(new Animated(AnimationTypes.BirdIdleRight));
            Bird.Init(new Collidable(new RectangleF(0, 0, 32, 64), new Vector2(16, 0)));
            Bird.Init(new Speed(0.2f));
            Bird.Init(new Controllable());

            //EnemySpawnSystem enemySpawnSystem = new EnemySpawnSystem(content, entityFactory, 1);

            //var Worm = entityFactory.BuildEntity<WormDescriptor>(0, ExclusiveGroups.EnemyGroup);
            //Worm.Init(new Transform2D(500, 200, 0));
            //Worm.Init(new Velocity(0, 0));
            //Worm.Init(new Size(64, 80));
            //Worm.Init(new Animated(AnimationTypes.WormRight));
            //Worm.Init(new Collidable(new RectangleF(0, 0, 32, 64), new Vector2(16, 0)));
            //Worm.Init(new Speed(0.1f));
            //Worm.Init(new Enemy());

            //Random rng = new Random();

            //uint num = 2;
            //for (int i = 2; i < 100; i++)
            //{
            //    Worm = entityFactory.BuildEntity<WormDescriptor>(num, ExclusiveGroups.EnemyGroup);
            //    Worm.Init(new Transform2D(rng.Next(1000), rng.Next(1000), 0));
            //    Worm.Init(new Velocity(0, 0));
            //    Worm.Init(new Size(64, 80));
            //    Worm.Init(new Animated(WormRight));
            //    Worm.Init(new Collidable(new RectangleF(0, 0, 32, 64), new Vector2(16, 0)));
            //    Worm.Init(new Speed(0.1f));
            //    Worm.Init(new Enemy());
            //    num++;
            //}

            /////////////////////////////////////////////////////
            /// Block
            /// 

            //string json = System.IO.File.ReadAllText("Content/Level.json");

            //List<JsonRectangle> jsonRectangles = JsonSerializer.Deserialize<List<JsonRectangle>>(json);

            //int num = 0;
            //foreach (JsonRectangle jsonRectangle in jsonRectangles)
            //{
            //    var Block = entityFactory.BuildEntity<BlockDescriptor>((uint)num, ExclusiveGroups.BlockGroup);
            //    Block.Init(new Transform2D(jsonRectangle.X * 32, jsonRectangle.Y * 32, 0));
            //    Block.Init(new Size(32, 32));
            //    Block.Init(new Collidable(new RectangleF(jsonRectangle.X * 32, jsonRectangle.Y * 32, 32, 32), Vector2.Zero));
            //    Block.Init(new Texture(Enums.TextureEnum.Block, Color.White));
            //    num++;
            //}

            //int num = 0;
            //var Block = entityFactory.BuildEntity<BlockDescriptor>((uint)num, ExclusiveGroups.BlockGroup);
            //Block.Init(new Transform2D(500, 800, 0));
            //Block.Init(new Size(32, 32));
            //Block.Init(new Collidable(new RectangleF(500, 800, 32, 32), Vector2.Zero));
            //Block.Init(new Texture(Enums.TextureEnum.Block, Color.White));
            //num++;
            //for (int i = 2; i < 10; i++)
            //{
            //    Block = entityFactory.BuildEntity<BlockDescriptor>((uint)num, ExclusiveGroups.BlockGroup);
            //    Block.Init(new Transform2D(32 * i + 500, 800, 0));
            //    Block.Init(new Size(32, 32));
            //    Block.Init(new Collidable(new RectangleF(32 * i + 500, 800, 32, 32), Vector2.Zero));
            //    Block.Init(new Texture(Enums.TextureEnum.Block, Color.White));
            //    num++;
            //}



            // Example logger usage.
            this._logger.Debug("Created GameScene!");
        }

        public override void Draw(GameTime gameTime)
        {
            // Example logger usage.
            // This will not be logged with a minimum log level of Debug
            this._logger.Verbose("Draw");

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            // Example logger usage.
            // This will not be logged with a minimum log level of Debug
            this._logger.Verbose("Update");

            this._entitiesSubmissionScheduler.SubmitEntities();
            base.Update(gameTime);
        }
    }
}