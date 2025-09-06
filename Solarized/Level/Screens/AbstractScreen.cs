using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level.Container;
using Solarized.Level.Utils;
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
        private bool init;
        public void AddRenderableWidget(GuisElements element) => GuisElements.Add(element);
        public GamePanel GameInstance
        {
            get
            {
                return game;
            }
        }
        public DynamicRandom Random;
        public AbstractScreen(GamePanel game, string screenTitle = "")
        {
            this.game = game;
            this.Random = game.Random;
            this.ScreenTitle = screenTitle;
        }

        public virtual void Init() 
        {
            this.init = true;
        }

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
            if (this.init == false)
            {
                this.Init();
            }
            foreach (var button in GuisElements)
            {
                button.Tick();
            }
        }
        public virtual void Render(GameGraphics gameGraphics)
        {
            this.RenderBackground(gameGraphics);
            this.RenderButtons(gameGraphics);
        }

        private void RenderButtons(GameGraphics gameGraphics)
        {
            foreach (var button in GuisElements)
            {
                button.Render(gameGraphics);
            }
        }

        public virtual void RenderBackground(GameGraphics gameGraphics)
        {
        }
    }
}
