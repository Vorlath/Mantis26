using Mantis.Core.Common.Attributes;
using Mantis.Engine.Common.Enums;
using Mantis.Engine.Common.Systems;
using Microsoft.Xna.Framework;
using Svelto.ECS;
using VampireSurvivors.Extensions;
using VampireSurvivors.Scenes;

namespace VampireSurvivors.Systems
{
    internal class EnemySpawnSystem(IEntityFactory entityFactory, float spawnTime = 1f) : IUpdateSystem, ISceneSystem, IInitializableSystem<GameScene>
    {

        private readonly IEntityFactory _entityFactory = entityFactory;
        private float _spawnTime = spawnTime;
        private uint _spawnCount = 0;
        Random _random = new Random();

        [SequenceGroup<UpdateSequenceGroupEnum>(UpdateSequenceGroupEnum.Update)]
        public void Update(GameTime gameTime)
        {
            if (_spawnTime <= 0)
            {

                _spawnTime = 1f;

                int side = _random.Next(3);
                Vector2 spawnPos;
                switch (side)
                {
                    //top
                    case 0:
                        spawnPos = new Vector2(_random.Next(1920), -80);
                        break;
                    //right
                    case 1:
                        spawnPos = new Vector2(1930, _random.Next(1000));
                        break;
                    //left
                    case 2:
                        spawnPos = new Vector2(-80, _random.Next(1920));
                        break;
                    //bottom
                    case 3:
                        spawnPos = new Vector2(_random.Next(1920), 1000);
                        break;
                    default:
                        spawnPos = new Vector2(_random.Next(1920), -80);
                        break;
                }




                _entityFactory.SpawnWorm(spawnPos, _spawnCount++);
            }
            _spawnTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        [SequenceGroup<InitializeSequenceGroupEnum>(InitializeSequenceGroupEnum.Initialize)]
        public void Initialize(GameScene arg)
        {

        }
    }
}
