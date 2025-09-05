using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level.Registry;
using Solarized.Utils;

namespace Solarized.Level
{
    public class GameGraphics : SpriteBatch
    {
        protected GamePanel game;
        public SpriteBatch spriteBatch;
        public Game GameInstance
        {
            get { return game; }
        }
        public GameGraphics(GraphicsDevice graphicsDevice) : base(graphicsDevice)
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

        public void Draw(int x, int y, ResourceLocation<Texture2D> texture, Color color, float scale, float rotation)
        {
            this.spriteBatch.Begin();
            float scaleX = (float)GamePanel.Instance.GetScreenWidth() / texture.Get().Width;
            float scaleY = (float)GamePanel.Instance.GetScreenHeight() / texture.Get().Height;
            float size = MathHelper.Min(scaleX, scaleY);
            this.spriteBatch.Draw(texture.Get(), new Vector2(x, y), null, color, rotation, Vector2.Zero, size, SpriteEffects.None, 1.0F);
            this.spriteBatch.End();
        }
        public void Draw(int x, int y, ResourceLocation<Texture2D> texture, Color color, float scale)
        {
            this.Draw(x, y, texture, color, scale, 0.0F);
        }
        public void Draw(int x, int y, ResourceLocation<Texture2D> texture, Color color)
        {
            this.Draw(x, y, texture, color, 1.0F, 0.0F);
        }
        public void Draw(int x, int y, ResourceLocation<Texture2D> texture)
        {
            this.Draw(x, y, texture, Color.White, 1.0F, 0.0F);
        }
        public void Draw(int x, int y, ResourceLocation<Texture2D> texture, float scale)
        {
            this.Draw(x, y, texture, Color.White, scale, 0.0F);
        }
    }
}
