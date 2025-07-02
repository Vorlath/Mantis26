using Microsoft.Xna.Framework;
using Svelto.ECS;

namespace VampireSurvivors.Engines
{
    public interface IFrameEngine : IEngine
    {
        void Draw(GameTime gameTime);
        void Update(GameTime gameTime);
    }
}