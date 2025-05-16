using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantis26.Sokoban.Enums;
using Microsoft.Xna.Framework.Input;

namespace Mantis26.Sokoban.Extensions
{
    public static class KeyboardStateExtensions
    {
        public static InputEnum GetCurrentInput(this KeyboardState state)
        {
            InputEnum result = InputEnum.None;

            if(state.IsKeyDown(Keys.W))
            {
                result |= InputEnum.Up;
            }

            if (state.IsKeyDown(Keys.A))
            {
                result |= InputEnum.Left;
            }

            if (state.IsKeyDown(Keys.S))
            {
                result |= InputEnum.Down;
            }

            if (state.IsKeyDown(Keys.D))
            {
                result |= InputEnum.Right;
            }

            return result;
        }
    }
}
