using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Content;
using Solarized.Level.Registry;
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
        public SpriteBatch sprite;
        public Game GameInstance
        {
            get { return game; }
        }
        public GameGraphics(GamePanel game, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.game = game;
        }
        
        public void Render(double delta)
        {

        }

        public void Draw(FontStyle fontStyle, int x, int y, string text, Color color, Font fonts, float scale = 1.0F)
        {
            IGraphicsDeviceService IdeviceService = (IGraphicsDeviceService)GamePanel.Instance.Services.GetService(typeof(IGraphicsDeviceService));
            SpriteBatch spriteBatch = new SpriteBatch(IdeviceService.GraphicsDevice);
            spriteBatch.DrawString(Font.Get(fonts.Name), text, new Vector2(x, y), color, 0.0F, Vector2.Zero, scale, SpriteEffects.None, 0.0F);

            if (fontStyle == FontStyle.Shadow)
            {
                spriteBatch.DrawString(Font.Get(fonts.Name), text, new Vector2(x + 2, y + 2), color, 0.0F, Vector2.Zero, scale, SpriteEffects.None, 0.0F);

            }
        }
        public void Draw(int x, int y, string text, Color color)
        {
            this.Draw(FontStyle.Default, x, y, text, color, GameFonts.DEFAULT.Get());
        }
        public void Draw(int x, int y, string text)
        {
            this.Draw(FontStyle.Default, x, y, text, Color.White, GameFonts.DEFAULT.Get());
        }
        public void Draw(FontStyle fontStyle, int x, int y, string text, Color color)
        {
            this.Draw(fontStyle, x, y, text, color, GameFonts.DEFAULT.Get());
        }
        public void Draw(FontStyle fontStyle, int x, int y, string text)
        {
            this.Draw(fontStyle, x, y, text, Color.White, GameFonts.DEFAULT.Get());
        }
    }
}
