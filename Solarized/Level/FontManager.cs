using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solarized.Level
{
    public static class FontManager
    {

        private static readonly Regex ColorTagRegex = new(@"\[c\/([0-9A-Fa-f]{6}):(.*?)\]", RegexOptions.Compiled);

        public static void DrawCenteredFit(SpriteFont font, int x, int y, string text, Color color, float scale = 1.0F)
        {
            int screenWidth = GamePanel.Instance.GetScreenWidth();
            int screenHeight = GamePanel.Instance.GetScreenHeight();
            Vector2 textSize = MeasureString(text);
            float scaleX = screenWidth / textSize.X;
            float scaleY = screenHeight / textSize.Y;
            float scales = Math.Min(scaleX, scaleY);
            scales = Math.Min(scale, scale);
            Vector2 position = new Vector2((screenWidth - textSize.X * scale) / 2.0F + x, 
                (screenHeight - textSize.Y * scale) / 2.0F + y);
            DrawText(GamePanel.Instance.SpriteBatch, font, position, text, color, scale);
        }
        public static void DrawCenteredFit(int x, int y, string text, Color color, float scale = 1.0F)
        {
            DrawCenteredFit(GamePanel.Instance.Font, x, y, text, color, scale);
        }

        public static void DrawCenteredFit(int x, int y, string text, float scale = 1.0F)
        {
            DrawCenteredFit(GamePanel.Instance.Font, x, y, text, Color.White, scale);
        }
        public static void DrawText(SpriteBatch spriteBatch, SpriteFont font, Vector2 position, string text, Color color, float scale = 1.0F)
        {
            Vector2 cursor = position;
            foreach (var part in ParseTextParts(text, color))
            {
                spriteBatch.DrawString(font, part.Text, cursor + new Vector2(1, 1), Color.Black * 0.75F, 0.0F, Vector2.Zero, scale * 1.1F, SpriteEffects.None, 0.0F);
                spriteBatch.DrawString(font, part.Text, cursor, part.Color, 0.0F, Vector2.Zero, scale, SpriteEffects.None, 0.0F);
                cursor.X += font.MeasureString(part.Text).X * scale;
            }
        }
        public static void DrawText(SpriteBatch spriteBatch, Vector2 position, string text, Color color, float scale = 1.0F)
        {
            DrawText(spriteBatch, GamePanel.Instance.Font, position, text, color, scale);
        }
        public static void DrawText(Vector2 position, string text, Color color, float scale = 1.0F)
        {
            DrawText(GamePanel.Instance.SpriteBatch, GamePanel.Instance.Font, position, text, color, scale);
        }
        public static Vector2 MeasureString(SpriteFont font, string text, float scale = 1.0F)
        {
            float totalWidth = 0.0F;
            float height = 0.0F;
            foreach (var part in ParseTextParts(text, Color.White))
            {
                Vector2 size = font.MeasureString(part.Text);
                totalWidth += size.X * scale;
                height = Math.Max(height, size.Y * scale);
            }
            return new Vector2(totalWidth, height);
        }
        public static Vector2 MeasureString(string text, float scale = 1.0F)
        {
            return MeasureString(GamePanel.Instance.Font, text, scale);
        }
        private static IEnumerable<TextPart> ParseTextParts(string text, Color defaultColor)
        {
            int lastIndex = 0;
            foreach (Match match in ColorTagRegex.Matches(text))
            {
                if (match.Index > lastIndex)
                {
                    yield return new TextPart(text[lastIndex..match.Index], defaultColor);
                }
                string hex = match.Groups[1].Value;
                string content = match.Groups[2].Value;
                Color color = HexToColor(hex);

                yield return new TextPart(content, color);
                lastIndex = match.Index + match.Length;
            }
            if (lastIndex < text.Length)
            {
                yield return new TextPart(text[lastIndex..], defaultColor);
            }
        }

        private static Color HexToColor(string hex)
        {
            return new Color(
                Convert.ToInt32(hex.Substring(0, 2), 16),
                Convert.ToInt32(hex.Substring(2, 2), 16),
                Convert.ToInt32(hex.Substring(4, 2), 16)
            );
        }

        private record TextPart(string Text, Color Color);
    }

}
