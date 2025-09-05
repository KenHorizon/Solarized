
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level;

namespace Solarized.Screen
{
    public class MainMenu : AbstractScreen
    {
        private ResourceLocation<Texture2D> MainMenuScreen = new ResourceLocation<Texture2D>("Content/Textures/MainMenu/MainMenuBackground");
        public string Title = "Solarized";
        public MainMenu() : base(GamePanel.Instance)
        {
        }

        public override void Tick(GameTime gameTime)
        {
            base.Tick(gameTime);

        }

        public override void Render(GameGraphics gameGraphics)
        {
            base.Render(gameGraphics);
            GraphicManager.DrawFullScreen(MainMenuScreen);
        }
    }
}
