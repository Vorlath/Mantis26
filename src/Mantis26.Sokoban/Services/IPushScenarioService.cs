using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Components;
using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace Mantis26.Sokoban.Services
{
    public interface IPushScenarioService
    {
        public bool CanHandleScenario(PushScenario scenario);

        public bool HandleScenario(PushScenario scenario);
    }
}
