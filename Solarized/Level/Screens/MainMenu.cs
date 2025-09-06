
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level;
using Solarized.Level.Buttons;
using Solarized.Level.Sound;
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
            MusicManager.Play(SoundID.INTRO);
            this.SetupButtons();
        }
        private void SetupButtons()
        {
            int row = 0;
            foreach (string content in this.Contents)
            {
                Vector2 vec = this.GameInstance.Font.MeasureString(content);
                int padding = (int) vec.Y + 20;
                int x = (int) ((this.GameInstance.GetScreenWidth() - vec.X) / 2);
                int y = this.GameInstance.GetMaxTileSize() * 4;
                row += 1;
                if (content.Equals(Contents[0]))
                {
                    this.AddRenderableWidget(new BaseButton(x, y + (padding * row), 250, 20, content, this.GameInstance.Font, () =>
                    {
                        this.GameInstance.Exit();
                    }));
                }
                if (content.Equals(Contents[1]))
                {
                    this.AddRenderableWidget(new BaseButton(x, y + (padding * row), 250, 20, content, this.GameInstance.Font, () =>
                    {
                        this.GameInstance.Exit();
                    }));
                }
                if (content.Equals(Contents[2]))
                {
                    this.AddRenderableWidget(new BaseButton(x, y + (padding * row), 250, 20, content, this.GameInstance.Font, () =>
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
            GraphicManager.DrawFullScreen(MainMenuScreen);
            GraphicManager.DrawCenteredFit(GameTitle, 0, 20);
        }
    }
}
