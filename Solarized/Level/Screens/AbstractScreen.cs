using Microsoft.Xna.Framework;
using Solarized.Level.Container;
using System.Collections.Generic;

namespace Solarized.Level
{
    abstract public class AbstractScreen
    {
        private GamePanel game = null;
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
            this.Init();
        }

        public virtual void Init() { }
        public void OnMouseHovered(int x, int y)
        {
        }

        public void OnMouseClicked(int x, int y)
        {
            foreach (var button in GuisElements)
            {
                button.OnClick(x, y);
            }
        }

        public virtual void Tick(GameTime gameTime)
        {
            foreach (var button in GuisElements)
            {
                button.Tick();
            }
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
