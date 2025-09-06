using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Solarized.Level
{
    public static class GraphicManager
    {
        /// <summary>
        /// Draws a texture stretched to fit the entire screen.
        /// </summary>
        public static void DrawFullScreen(ResourceLocation<Texture2D> textures, Color color)
        {
            SpriteBatch spriteBatch = GamePanel.Instance.SpriteBatch;
            Rectangle Bounds = new Rectangle(0, 0, GamePanel.Instance.GetScreenWidth(), GamePanel.Instance.GetScreenHeight());
            spriteBatch.Draw(textures.Get(), Bounds, color);
        }

        public static void DrawFullScreen(ResourceLocation<Texture2D> texture)
        {
            DrawFullScreen(texture, Color.White);
        }

        /// <summary>
        /// Draws a texture scaled to fit inside a rectangle while keeping aspect ratio and centered on screen.
        /// </summary>
        public static void DrawCenteredFit(ResourceLocation<Texture2D> resourceLocation, int x, int y, Color color)
        {
            Texture2D texture = resourceLocation.Get();
            int baseWidth = texture.Width;
            int baseHeight = texture.Height;
            SpriteBatch spriteBatch = GamePanel.Instance.SpriteBatch;
            int screenW = GamePanel.Instance.GetScreenWidth();
            int screenH = GamePanel.Instance.GetScreenHeight();

            // Compute scale so it never exceeds the screen size
            float scaleX = (float) screenW / baseWidth;
            float scaleY = (float) screenH / baseHeight;
            float scale = Math.Min(scaleX, scaleY);

            // Final draw size
            int drawW = (int) (baseWidth * scale);
            int drawH = (int)( baseHeight * scale);

            // Centered rectangle
            Rectangle drawRect = new Rectangle(
                (screenW - drawW) / 2 ,
                y,
                drawW,
                drawH
            );

            spriteBatch.Draw(texture, drawRect, color);
        }
        public static void DrawCenteredFit(ResourceLocation<Texture2D> resourceLocation, int x, int y)
        {
            DrawCenteredFit(resourceLocation, x, y, Color.White);
        }
        public static void DrawCenteredFit(ResourceLocation<Texture2D> resourceLocation, Color color)
        {
            DrawCenteredFit(resourceLocation, 0, 0, color);
        }
        public static void DrawCenteredFit(ResourceLocation<Texture2D> resourceLocation)
        {
            DrawCenteredFit(resourceLocation, 0, 0, Color.White);
        }
        /// <summary>
        /// Draws a texture scaled to fit inside a rectangle while keeping aspect ratio.
        /// </summary>
        public static void DrawFit(ResourceLocation<Texture2D> resourceLocation, Rectangle targetRect, Color color)
        {
            Texture2D texture = resourceLocation.Get();
            SpriteBatch spriteBatch = GamePanel.Instance.SpriteBatch;
            float textureAspect = (float)texture.Width / texture.Height;
            float targetAspect = (float)targetRect.Width / targetRect.Height;

            Rectangle drawRect;

            if (textureAspect > targetAspect)
            {
                int height = (int)(targetRect.Width / textureAspect);
                drawRect = new Rectangle(targetRect.X, targetRect.Y + (targetRect.Height - height) / 2, targetRect.Width,height);
            }
            else
            {
                int width = (int)(targetRect.Height * textureAspect);
                drawRect = new Rectangle(targetRect.X + (targetRect.Width - width) / 2, targetRect.Y, width, targetRect.Height);
            }
            spriteBatch.Draw(texture, drawRect, color);
        }
        public static void DrawFit(ResourceLocation<Texture2D> resourceLocation, Rectangle targetRect)
        {
            DrawFit(resourceLocation, targetRect, Color.White);
        }

        /// <summary>
        /// Draws a texture inside a slot (scaled down if needed).
        /// </summary>
        public static void DrawInSlot(ResourceLocation<Texture2D> resourceLocation, Rectangle slotRect, Color color, float padding = 4f)
        {
            Texture2D texture = resourceLocation.Get();
            SpriteBatch spriteBatch = GamePanel.Instance.SpriteBatch;
            float maxWidth = slotRect.Width - padding * 2;
            float maxHeight = slotRect.Height - padding * 2;

            float scale = Math.Min(maxWidth / texture.Width, maxHeight / texture.Height);

            int drawWidth = (int)(texture.Width * scale);
            int drawHeight = (int)(texture.Height * scale);

            Rectangle drawRect = new Rectangle(
                slotRect.X + (slotRect.Width - drawWidth) / 2,
                slotRect.Y + (slotRect.Height - drawHeight) / 2,
                drawWidth,
                drawHeight
            );

            spriteBatch.Draw(texture, drawRect, color);
        }
        /// <summary>
        /// Draws a texture at a position, scaled with UI scale.
        /// </summary>
        public static void DrawUIScaled(Vector2 position, ResourceLocation<Texture2D> resourceLocation, float uiScale, Color color)
        {
            Texture2D texture = resourceLocation.Get();
            SpriteBatch spriteBatch = GamePanel.Instance.SpriteBatch;
            spriteBatch.Draw(texture, position * uiScale, null, color, 0f, Vector2.Zero, uiScale, SpriteEffects.None, 0f);
        }
    }
}
