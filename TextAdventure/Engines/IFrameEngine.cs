using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace TextAdventure.Engines
{
    public interface IFrameEngine : IEngine
    {
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
    }
}