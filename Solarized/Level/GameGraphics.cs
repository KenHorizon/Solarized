using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level
{
    public class GameGraphics
    {
        protected GamePanel game;
        public SpriteBatch sprite;
        public Game GameInstance
        {
            get { return game; }
        }
        public GameGraphics(GamePanel game)
        {
            this.game = game;
        }
        public void Render(SpriteBatch sprite, double delta)
        {

        }
    }
}
