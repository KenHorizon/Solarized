using Solarized.Effects;
using Solarized.NPCs;

namespace Solarized.Level.Registry
{
    public static class GameRegistry
    {
        public static readonly Registry<BaseEffect> EFFECTS = new Registry<BaseEffect>();
        public static readonly Registry<GameAttribute> ATTRIBUTE = new Registry<GameAttribute>();
    }
}
