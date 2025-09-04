using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Content;
using Solarized.Level.Registry;
using Solarized.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public GameGraphics(GamePanel game, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.game = game;
            IGraphicsDeviceService IdeviceService = (IGraphicsDeviceService)GamePanel.Instance.Services.GetService(typeof(IGraphicsDeviceService));
            this.spriteBatch = new SpriteBatch(IdeviceService.GraphicsDevice);
        }
        
        public void Render(double delta)
        {

        }

        public void DrawString(FontStyle fontStyle, int x, int y, string text, Color color, Font fonts, float scale = 1.0F)
        {
            this.spriteBatch.DrawString(Font.Get(fonts.Name), text, new Vector2(x, y), color, 0.0F, Vector2.Zero, scale, SpriteEffects.None, 0.0F);

            if (fontStyle == FontStyle.Shadow)
            {
                this.spriteBatch.DrawString(Font.Get(fonts.Name), text, new Vector2(x + 2, y + 2), color, 0.0F, Vector2.Zero, scale, SpriteEffects.None, 0.0F);

            }
        }
        public void DrawString(int x, int y, string text, Color color)
        {
            this.DrawString(FontStyle.Default, x, y, text, color, RegistryFont.DEFAULT.Get());
        }
        public void DrawString(int x, int y, string text)
        {
            this.DrawString(FontStyle.Default, x, y, text, Color.White, RegistryFont.DEFAULT.Get());
        }
        public void DrawString(FontStyle fontStyle, int x, int y, string text, Color color)
        {
            this.DrawString(fontStyle, x, y, text, color, RegistryFont.DEFAULT.Get());
        }
        public void DrawString(FontStyle fontStyle, int x, int y, string text)
        {
            this.DrawString(fontStyle, x, y, text, Color.White, RegistryFont.DEFAULT.Get());
        }

        public void Draw(int x, int y, ResourceLocation<Texture2D> texture, Color color) 
        {
            this.spriteBatch.Draw(texture.Get(), new Vector2(x, y), color);
        }
        public void Draw(int x, int y, ResourceLocation<Texture2D> texture)
        {
            this.Draw(x, y, texture, Color.White);
        }
    }
}
