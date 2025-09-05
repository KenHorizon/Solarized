using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level.Container;
using Solarized.Level.Fonts;
using Solarized.Utils;
using System;

namespace Solarized.Level.Buttons
{
    public class BaseButton : GuisElements
    {
        public Texture2D Texture;
        public string Text;
        public SpriteFont Font;
        public Action OnPress;
        public Color DefaultColor = Color.White;
        public Color HoveredColor = Color.Blue;
        protected Align align = Align.Centered;
        public BaseButton(int x, int y, string text, Texture2D texture, SpriteFont font)
        {
            this.Texture = texture;
            this.Font = font;
            this.Text = text;
            this.PosX = x;
            this.PosY = y;
        }
        public override void OnClick(int mouseX, int mouseY)
        {
            this.OnPress?.Invoke();
        }

        public void SetAlign(Align align)
        {
            this.align = align;
        }
        public void SetupColor(Color DefaultColor, Color HoveredColor)
        {
            this.DefaultColor = DefaultColor;
            this.HoveredColor = HoveredColor;
        }

        public override void Render(GameGraphics gameGraphics)
        {
            Color color = this.IsMouseHovered == false ? DefaultColor : HoveredColor;
            Vector2 TextSize = Font.MeasureString(this.Text);
            Vector2 TextPosition;
            if (this.align == Align.Centered)
            {
                TextPosition = this.Position + new Vector2((this.Width - TextSize.X) / 2, (this.Height - TextSize.Y) / 2);
            }
            else
            {
                TextPosition = this.Position + new Vector2(this.Width, (this.Height - TextSize.Y) / 2);
            }
            FontManager.DrawText(TextPosition, this.Text, color);
        }
    }
}
