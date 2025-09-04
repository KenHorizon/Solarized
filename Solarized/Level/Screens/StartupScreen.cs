
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Solarized.Content;
using Solarized.Level;
using Solarized.Level.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Screen
{
    public class StartupScreen : AbstractScreen
    {
        public int progress;
        public double timer;
        public ResourceLocation<Texture2D> TeamLogo = new ResourceLocation<Texture2D>(@"Textures/TeamLogo");
        public StartupScreen() : base(GamePanel.Instance)
        {
        }

        public override void Tick(GameTime gameTime)
        {
            base.Tick(gameTime);
            this.timer += gameTime.ElapsedGameTime.TotalSeconds;
            switch (this.progress)
            {
                case 0:
                    if (this.timer > 2)
                    {
                        this.Progress();
                    }
                    break;
                case 1:
                    if (this.timer > 2)
                    {
                        this.Progress();
                    }
                    break;
                case 2:
                    if (this.timer > 2)
                    {
                        this.Progress();
                    }
                    break;
                case 3:
                    if (this.timer > 2)
                    {
                        this.Progress();
                    }
                    break;
                case 4:
                    GameInstance.SetScreen(new MainMenu());
                    break;
            }
        }

        public void Progress()
        {

            this.progress++;
            this.timer = 0;
        }

        public override void Render(GameGraphics gameGraphics)
        {
            base.Render(gameGraphics);
            int x = this.game.GetScreenWidth() / 2;
            int y = this.game.GetScreenHeight() / 2;
            switch (this.progress)
            {
                case 0:
                    float alphaIn = (float)(this.timer / 2.0F);
                    gameGraphics.Draw(x, y, TeamLogo, Color.White * MathHelper.Clamp(alphaIn, 0.0F, 1.0F));
                    break;
                case 1:
                    gameGraphics.Draw(x, y, TeamLogo, Color.White);
                    break;
                case 2:
                    float alphaOut = (float)(this.timer / 2.0F);
                    gameGraphics.Draw(x, y, TeamLogo, Color.White * MathHelper.Clamp(alphaOut, 0.0F, 1.0F));
                    break;
                case 3:
                    string GameTitle = "Solarized: Dawn of Darkness";
                    int TextToShow = (int) (this.timer * 10);
                    string visible = GameTitle.Substring(0, TextToShow);
                    gameGraphics.DrawString(x, y, visible);
                    break;
            }
        }
    }
}
