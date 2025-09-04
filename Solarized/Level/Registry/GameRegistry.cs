using Solarized.Effect;
using Solarized.NPCs;
using System;

namespace Solarized.Level.Registry
{
    public static class GameRegistry
    {
        public static readonly Registry<BaseEffect> EFFECTS = new Registry<BaseEffect>();
        public static readonly Registry<GameAttribute> ATTRIBUTE = new Registry<GameAttribute>();
        public static readonly Registry<Font> FONT = new Registry<Font>();
    }
}
