
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level;
using Solarized.Level.Buttons;

namespace Solarized.Screen
{
    public class MainMenu : AbstractScreen
    {
        private ResourceLocation<Texture2D> MainMenuScreen = new ResourceLocation<Texture2D>("Content/Textures/MainMenu/MainMenuBackground");
        private ResourceLocation<Texture2D> GameTitle = new ResourceLocation<Texture2D>("Content/Textures/MainMenu/GameTitle");
        public string Title = "Solarized";
        public MainMenu() : base(GamePanel.Instance)
        {
        }

        public override void Init()
        {
            this.AddRenderableWidget(new BaseButton(10, 10, 200, 20, "Test", this.GameInstance.Font, () =>
            {
                this.GameInstance.Exit();
            }));
        }
        public override void Tick(GameTime gameTime)
        {
            base.Tick(gameTime);

        }

        public override void Render(GameGraphics gameGraphics)
        {
            base.Render(gameGraphics);
            GraphicManager.DrawFullScreen(MainMenuScreen);
            GraphicManager.DrawCenteredFit(GameTitle, 0, 0);
        }
    }
}
