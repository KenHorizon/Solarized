
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public int timer;
        public StartupScreen() : base(GamePanel.Instance)
        {
            this.Contents.Add("Project: RRR");
            this.Contents.Add("Presenting");
            this.Contents.Add("Solarized: Dawn Of Darkness");
        }

        public override void Tick(float delta)
        {
            base.Tick(delta);
            this.timer++;

        }

        public override void Render(SpriteBatch sprite)
        {
            base.Render(sprite);
        }

    }
}
