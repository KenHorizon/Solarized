using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Solarized.Level.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level
{
    abstract public class AbstractScreen
    {
        protected GamePanel game = null;
        protected string ScreenTitle = "";
        public List<string> Contents = new List<string>();
        protected List<GuisElements> GuisElements = new List<GuisElements>();
        public int TitleX;
        public int TitleY;
        public bool Hide = false;
        public void AddRenderableWidget(GuisElements element) => GuisElements.Add(element);
        public GamePanel GameInstance
        {
            get
            {
                return game;
            }
        }
        
        public AbstractScreen(GamePanel game, string screenTitle = "")
        {
            this.game = game;
            this.ScreenTitle = screenTitle;

        }

        public void OnMouseHovered(int x, int y)
        {

        }

        public void OnMouseClicked(int x, int y, bool clicked)
        {
            foreach (var button in GuisElements)
            {
                button.OnClick(x, y);
            }
        }

        public virtual void Tick(GameTime gameTime)
        {

        }
        public virtual void Render(GameGraphics gameGraphics)
        {
            foreach (var button in GuisElements)
            {
                button.Render(gameGraphics);
            }
        }
    }
}
