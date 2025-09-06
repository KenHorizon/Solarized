using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Solarized.Level.Container;
using Solarized.Level.Sound;
using System;

namespace Solarized.Level.Buttons
{
    public class BaseButton : GuisElements
    {
        public string Text;
        public string HoveredText;
        public SpriteFont Font;
        public Action OnPress;
        public Color DefaultColor = Color.White;
        public Color HoveredColor = Color.LightCyan;
        protected Align align = Align.Centered;
        private Effect effect;
        private Texture2D SelectedTexture;
        private Texture2D Texture;
        private ResourceLocation<Effect> SHADER = new ResourceLocation<Effect>("Content/Effects/BasicEffects");
        public BaseButton(int x, int y, int witdh, int height, string text, SpriteFont font, Action action) : base(x, y)
        {
            this.effect = SHADER.Get();
            this.Font = font;
            this.Text = text;
            this.Width = witdh;
            this.Height = height;
            this.OnPress = action;
            this.SelectedTexture = new Texture2D(GamePanel.Instance.GraphicsDevice, 1, 1);
            this.Texture = new Texture2D(GamePanel.Instance.GraphicsDevice, 1, 1);
            this.SelectedTexture.SetData(new[] { Color.White });
            this.Texture.SetData(new[] { Color.White });
            this.Sounds = SoundID.DEFAULT_BUTTON_HOVERED;
            this.Clicked = SoundID.DEFAULT_BUTTON_CLICK;
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
            SpriteBatch spriteBatch = GamePanel.Instance.SpriteBatch;
            if (this.align != Align.Centered)
            {
                this.Position = new Vector2(this.Width, (this.Height - TextSize.Y) / 2);
            }
            if (this.IsMouseHovered == true)
            {
                spriteBatch.End();
                effect.Parameters["BaseColor"].SetValue(new Vector4(0.0F, 0.0F, 1.0F, 1.0F));
                effect.Parameters["FadeStart"].SetValue(0.0F);
                effect.Parameters["FadeEnd"].SetValue(1.0F);
                Vector2 RectScale = FontManager.MeasureString(this.Text) / 2;
                int RectX = (int)(this.Position.X - ((int)(this.Width - TextSize.X) / 2));
                int RectY = (int)this.Position.Y - 6;
                Rectangle rectangle = new Rectangle(RectX, RectY, this.Width, (int)(this.Height + RectScale.Y));

                Rectangle StartSelected = new Rectangle(RectX, RectY, 10, (int)(this.Height + RectScale.Y));
                Rectangle EndSelected = new Rectangle(RectX + this.Width, RectY, 10, (int)(this.Height + RectScale.Y));

                spriteBatch.Begin(effect: this.effect, blendState: BlendState.AlphaBlend);
                spriteBatch.Draw(Texture, rectangle, Color.White);
                
                spriteBatch.End();
                spriteBatch.Begin();
                
                spriteBatch.Draw(Texture, StartSelected, Color.White);
                spriteBatch.Draw(Texture, EndSelected, Color.White);
            }
            FontManager.DrawText(this.Position, this.Text, color);
        }
    }
}
