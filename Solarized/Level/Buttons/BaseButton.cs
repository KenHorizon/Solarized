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
        public string Text;
        public SpriteFont Font;
        public Action OnPress;
        public Color DefaultColor = Color.White;
        public Color HoveredColor = Color.LightCyan;
        protected Align align = Align.Centered;
        private Effect effect;
        Texture2D texture;
        private ResourceLocation<Effect> SHADER = new ResourceLocation<Effect>("Content/Effects/BaseButtonEffect");
        public BaseButton(int x, int y, int witdh, int height, string text, SpriteFont font, Action action)
        {
            this.effect = SHADER.Get();
            this.Font = font;
            this.Text = text;
            this.PosX = x;
            this.PosY = y;
            this.Width = witdh;
            this.Height = height;
            this.OnPress = action;
            this.texture = new Texture2D(GamePanel.Instance.GraphicsDevice, 1, 1);
            this.texture.SetData(new[] { Color.White });
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
            Vector2 TextSize = FontManager.MeasureString(this.Text);
            Vector2 TextPosition;
            SpriteBatch spriteBatch = new SpriteBatch(GamePanel.Instance.GraphicsDevice);
            if (this.align == Align.Centered)
            {
                TextPosition = this.Position + new Vector2((this.Width - TextSize.X) / 2, (this.Height - TextSize.Y) / 2);
            }
            else
            {
                TextPosition = this.Position + new Vector2(this.Width, (this.Height - TextSize.Y) / 2);
            }
            if (this.IsMouseHovered == true)
            {
                effect.Parameters["BaseColor"].SetValue(new Vector4(0.0F, 0.0F, 1.0F, 1.0F));
                effect.Parameters["FadeStart"].SetValue(0.0F);
                effect.Parameters["FadeEnd"].SetValue(1.0F);
                Vector2 RectScale = GamePanel.Instance.Font.MeasureString(this.Text) / 2;
                Rectangle rectangle = new Rectangle((int)TextPosition.X - 8, (int)TextPosition.Y - 4, this.Width, (int)(this.Height + RectScale.Y));
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, effect: effect);
                spriteBatch.Draw(texture, rectangle, Color.White);
                spriteBatch.End();
            }
            FontManager.DrawText(TextPosition, this.Text, color);
        }
    }
}
