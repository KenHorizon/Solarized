using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level
{
    public class ShaderManager
    {
        private GraphicsDevice graphicsDevice;
        private Dictionary<string, Effect> shaders = new();

        public ShaderManager(GraphicsDevice graphics)
        {
            this.graphicsDevice = graphics;
        }

        public void Register(string key, ResourceLocation<Effect> shader)
        {
            shaders[key] = shader.Get();
        }

        public Effect Get(string key)
        {
            return shaders[key];
        }

        public void Apply(string key, Action<Effect> configure = null)
        {
            if (shaders.TryGetValue(key, out var shader))
            {
                configure?.Invoke(shader); // let caller set params
                shader.CurrentTechnique.Passes[0].Apply();
            }
        }
    }
}
