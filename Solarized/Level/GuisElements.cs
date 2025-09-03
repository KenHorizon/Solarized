using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level.Container
{
    public abstract class GuisElements
    {

        public int PosX;
        public int PosY;
        public int Width;
        public int Height;
        public bool IsMouseHovered = false;
        protected MouseState PrevMouseState;
        public Vector2 Position => new Vector2(this.PosX, this.PosY);
        public Rectangle Bounds => new Rectangle((int) this.Position.X, (int) this.Position.Y, this.Width, this.Height);

        public virtual void Tick()
        {
            MouseState mouse = Mouse.GetState();
            Point point = new Point(mouse.X, mouse.Y);
            if (this.Bounds.Contains(point))
            {
                this.IsMouseHovered = true;
                if (mouse.LeftButton == ButtonState.Pressed && PrevMouseState.LeftButton == ButtonState.Released)
                {
                    this.OnClick(mouse.X, mouse.Y);
                }
            } else
            {
                this.IsMouseHovered = false;
            }
            this.PrevMouseState = mouse;
        }
        public abstract void Render(GameGraphics gameGraphics);
        public abstract void OnClick(int mouseX, int mouseY);
    }
}
