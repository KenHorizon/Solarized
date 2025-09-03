using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level
{
    public class Font
    {
        private static readonly Dictionary<string, SpriteFont> registry = new Dictionary<string, SpriteFont>();
        public string Name;
        public SpriteFont spriteFont;

        public Font(string name, string fontFile) 
        {
            this.Name = name;
            this.spriteFont = GamePanel.Instance.Content.Load<SpriteFont>(fontFile);
            registry[name] = spriteFont;
        }

        public static Font Register(string name, string fontFile)
        {
            if (registry.ContainsKey(name))
            {
                throw new Exception($"Fonts {name} already exists!");
            }
            return new Font(name, fontFile);
        }
        public static SpriteFont Get(string name) => registry.TryGetValue(name, out var type) ? type : null;

        public static IEnumerable<SpriteFont> Values => registry.Values;
    }
}
