using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Solarized.Level.Sound;

namespace Solarized.Level.Container
{
    public abstract class GuisElements
    {
        public int Width;
        public int Height;
        public bool IsMouseHovered = false;
        public ResourceLocation<SoundEffect> Clicked = null;
        public ResourceLocation<SoundEffect> Sounds = null;
        protected MouseState PrevMouseState;
        public Vector2 Position;
        public Rectangle Bounds => new Rectangle((int) this.Position.X, (int) this.Position.Y, this.Width, this.Height);

        public GuisElements(int x, int y)
        {
            this.Position = new Vector2(x, y);
        }

        public virtual void Tick()
        {
            MouseState mouse = Mouse.GetState();
            Point point = new Point(mouse.X, mouse.Y);
            bool CurrentlyHovering = this.Bounds.Contains(point);
            if (CurrentlyHovering == true && !this.IsMouseHovered)
            {
                if (Sounds != null)
                {
                    SoundManager.Play(this.Sounds);
                }
            }
            if (CurrentlyHovering == true)
            {
                this.IsMouseHovered = true;
                
                if (mouse.LeftButton == ButtonState.Pressed && PrevMouseState.LeftButton == ButtonState.Released)
                {
                    this.OnClick(mouse.X, mouse.Y);
                    if (Clicked != null)
                    {
                        SoundManager.Play(this.Clicked);
                    }
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
