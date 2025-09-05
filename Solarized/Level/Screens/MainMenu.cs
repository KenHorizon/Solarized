
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level;
using Solarized.Level.Buttons;
using System.Diagnostics;

namespace Solarized.Screen
{
    public class MainMenu : AbstractScreen
    {
        private ResourceLocation<Texture2D> MainMenuScreen = new ResourceLocation<Texture2D>("Content/Textures/MainMenu/MainMenuBackground");
        private ResourceLocation<Texture2D> GameTitle = new ResourceLocation<Texture2D>("Content/Textures/MainMenu/GameTitle");
        public string Title = "Solarized";
        public MainMenu() : base(GamePanel.Instance)
        {
            this.Contents.Add("Play Game");
            this.Contents.Add("Options");
            this.Contents.Add("Exit");
        }

        public override void Init()
        {
            base.Init();
            this.SetupButtons();
        }

        private void SetupButtons()
        {
            int x = 20;
            int y = 10;
            int row = 0;
            foreach (string content in this.Contents)
            {
                row++;
                y += (10 * row);
                if (content.Equals(Contents[0]))
                {
                    this.AddRenderableWidget(new BaseButton(x, y, 200, 60, content, this.GameInstance.Font, () =>
                    {
                        this.GameInstance.Exit();
                    }));
                }
            }
        }

        public override void Tick(GameTime gameTime)
        {   
            base.Tick(gameTime);

        }

        public override void RenderBackground(GameGraphics gameGraphics)
        {
            base.RenderBackground(gameGraphics);
            GraphicManager.DrawFullScreen(MainMenuScreen);
            GraphicManager.DrawCenteredFit(GameTitle, 0, 20);
        }
    }
}
