
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
    public class MainMenu : AbstractScreen
    {
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
        }

    }
}
