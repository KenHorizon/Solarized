using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level.Registry
{
    public class GameFonts
    {
        public static DeferredRegister<Font> FONTS = new DeferredRegister<Font>(GameRegistry.FONT, "Fonts");

        public static RegistryKey<Font> DEFAULT = FONTS.Register("Default", () => new Font("Default", "Fonts/00"));
        public static RegistryKey<Font> FANCY = FONTS.Register("Default", () => new Font("Default", "Fonts/01"));
    }
}
