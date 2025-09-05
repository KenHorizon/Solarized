using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level.Registry;
using Solarized.Utils;

namespace Solarized.Level
{
    public class GameGraphics
    {
        protected GamePanel game;
        public SpriteBatch spriteBatch;
        public Game GameInstance
        {
            get { return game; }
        }
        public GameGraphics()
        {
            this.game = GamePanel.Instance;
            IGraphicsDeviceService IdeviceService = (IGraphicsDeviceService)GamePanel.Instance.Services.GetService(typeof(IGraphicsDeviceService));
            if (game != null)
            {
                this.spriteBatch = new SpriteBatch(IdeviceService.GraphicsDevice);
            }
        }
        
        public void Render(double delta)
        {
        
        }
    }
}
