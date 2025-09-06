
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level;
using Solarized.Level.Sound;

namespace Solarized.Screen
{
    public class StartupScreen : AbstractScreen
    {
        public int progress;
        public double timer;
        public ResourceLocation<Texture2D> TeamLogo = new ResourceLocation<Texture2D>("Content/Textures/TeamLogo");
        public ResourceLocation<Texture2D> PresentingLogo = new ResourceLocation<Texture2D>("Content/Textures/PresentingLogo");
        public StartupScreen() : base(GamePanel.Instance)
        {
        }

        public override void Init()
        {
            base.Init();
            SoundManager.Play(SoundID.STARTUP);
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
                    this.GameInstance.SetScreen(new MainMenu());
                    break;
            }
        }

        public void Progress()
        {

            this.progress++;
            this.timer = 0;
        }

        public override void RenderBackground(GameGraphics gameGraphics)
        {
            Texture2D texture = TeamLogo.Get();
            switch (this.progress)
            {
                case 0:
                    float alphaIn = (float)(this.timer / 2.0F);
                    GraphicManager.DrawCenteredFit(TeamLogo, Color.White * MathHelper.Clamp(alphaIn, 0.0F, 1.0F));
                    break;
                case 1:
                    GraphicManager.DrawCenteredFit(TeamLogo);
                    break;
                case 2:
                    float alphaOut = (float)(this.timer / 2.0F);
                    GraphicManager.DrawCenteredFit(PresentingLogo, Color.White * MathHelper.Clamp(alphaOut, 0.0F, 1.0F));
                    break;
                case 3:
                    float alphaText = (float)(this.timer / 2.0F);
                    string GameTitle = "Solarized: Dawn of Darkness";
                    Vector2 size = FontManager.MeasureString(GameTitle);
                    FontManager.DrawCenteredFit(0, 0, GameTitle, Color.White);
                    break;
            }
        }
    }
}
