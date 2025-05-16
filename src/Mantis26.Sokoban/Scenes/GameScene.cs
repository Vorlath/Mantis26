using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis.Engine.Common;
using Mantis.Engine.Common.Services;
using Mantis26.Sokoban.Descriptors;
using Mantis26.Sokoban.Extensions;
using Mantis26.Sokoban.Utilities;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Scenes
{
    public class GameScene(ISystemService systemService, IEntityFactory entityFactory) : BaseScene(systemService)
    {
        private readonly IEntityFactory _entityFactory = entityFactory;

        public override void Initialize()
        {
            base.Initialize();

            this._entityFactory.BuildPlayer(Point.Zero);
        }
    }
}
