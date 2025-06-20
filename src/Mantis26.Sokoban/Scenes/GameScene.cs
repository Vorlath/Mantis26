using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Mantis.Core.Files.Common;
using Mantis.Core.Files.Common.Services;
using Mantis.Core.Files.Services;
using Mantis.Engine.Common;
using Mantis.Engine.Common.Services;
using Mantis26.Sokoban.Components;
using Mantis26.Sokoban.Descriptors;
using Mantis26.Sokoban.Extensions;
using Mantis26.Sokoban.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Svelto.ECS;

namespace Mantis26.Sokoban.Scenes
{
    public enum TileType
    {
        Wall = 0,
        Fire = 1,
        Rock = 2,
        Ice = 3,
        Water = 4
    }

    public class TileData
    {
        public required int X { get; set; }
        public required int Y { get; set; }
        public required TileType Type { get; set; }
    }

    public class GameScene(IFileService fileService, ISystemService systemService, IEntityFactory entityFactory, ContentManager content) : BaseScene(systemService)
    {
        private readonly IEntityFactory _entityFactory = entityFactory;
        private readonly IFileService _fileService = fileService;
        private readonly ContentManager _content = content;

        public override void Initialize()
        {
            base.Initialize();

            AnimationTypes.Initialize(_content);

            this._entityFactory.BuildPlayer(Point.Zero);

            TileData[] tiles = _fileService.ReadJson<TileData[]>(FilePath.Relative("Content/level.json"));

            foreach (TileData tile in tiles)
            {
                switch (tile.Type)
                {
                    case TileType.Wall:
                        this._entityFactory.BuildObject<WallDescriptor>(new Point(tile.X, tile.Y));
                        break;
                    case TileType.Fire:
                        this._entityFactory.BuildObject<FireDescriptor>(new Point(tile.X, tile.Y));
                        break;
                    case TileType.Rock:
                        this._entityFactory.BuildObject<RockDescriptor>(new Point(tile.X, tile.Y));
                        break;
                    case TileType.Ice:
                        this._entityFactory.BuildObject<IceDescriptor>(new Point(tile.X, tile.Y));
                        break;
                    case TileType.Water:
                        this._entityFactory.BuildObject<WaterDescriptor>(new Point(tile.X, tile.Y));
                        break;
                }
            }
        }
    }
}
