
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

        public override void Tick(float delta)
        {
            base.Tick(delta);

        }

        public override void Render(SpriteBatch sprite)
        {
            base.Render(sprite);
        }

    }
}
