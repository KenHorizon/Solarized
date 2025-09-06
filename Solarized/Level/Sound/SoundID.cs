using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level.Sound
{
    public class SoundID
    {
        public static readonly ResourceLocation<SoundEffect> STARTUP = new ResourceLocation<SoundEffect>("Sounds/Startup");
        public static readonly ResourceLocation<SoundEffect> INTRO = new ResourceLocation<SoundEffect>("Sounds/Intro");
        public static readonly ResourceLocation<SoundEffect> DEFAULT_BUTTON_HOVERED = new ResourceLocation<SoundEffect>("Sounds/DefaultButtonHovered");
        public static readonly ResourceLocation<SoundEffect> DEFAULT_BUTTON_CLICK = new ResourceLocation<SoundEffect>("Sounds/DefaultButtonClick");
    }
}
