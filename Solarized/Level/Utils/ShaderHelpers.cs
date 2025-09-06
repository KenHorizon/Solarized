using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level.Utils
{
    public static class ShaderHelpers
    {
        public static void FadeOutRectangle(SpriteBatch spriteBatch,
            Texture2D texture,
            Rectangle rectangle,
            Effect shader,
            Color color, float start = 0.0F, float end = 1.0F)
        {
            spriteBatch.End();
            float a = ((float) color.A / 255);
            float r = ((float) color.R / 255);
            float g = ((float) color.G / 255);
            float b = ((float) color.B / 255);
            shader.CurrentTechnique = shader.Techniques["FadeOutEffect"];
            shader.Parameters["BaseColor"].SetValue(new Vector4(r, g, b, a));
            shader.Parameters["FadeStart"].SetValue(start);
            shader.Parameters["FadeEnd"].SetValue(end);
            spriteBatch.Begin(effect: shader, blendState: BlendState.AlphaBlend);
            spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.End();
        }
    }
}
