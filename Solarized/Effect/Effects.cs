using Solarized;
using Solarized.Level.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Effect
{
    public class Effects
    {
        public static DeferredRegister<BaseEffect> EFFECTS = new DeferredRegister<BaseEffect>(GameRegistry.EFFECTS, "Effects");

        public static RegistryKey<BaseEffect> DEFAULT = EFFECTS.Register("Burn", () => new BurnEffect(EffectType.Debuff, "Engulfed with flames, lose life over time"));
    }
}
