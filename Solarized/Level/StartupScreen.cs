
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Solarized.Level;
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
        public StartupScreen() : base(GamePanel.Instance)
        {
            this.Contents.Add("Project: RRR");
            this.Contents.Add("Presenting");
            this.Contents.Add("Solarized: Dawn Of Darkness");
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
            base.Render(sprite);

            switch (this.progress)
            {
                case 0:
                    float alpha = (float)(this.timer / 2.0F);
                    Color color = Color.White * MathHelper.Clamp(alpha, 0.0F, 1.0F);

                    break;
            }
        }
    }
}
