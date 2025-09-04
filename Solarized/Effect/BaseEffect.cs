using Microsoft.Xna.Framework;
using Solarized.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Effect
{
    public enum EffectType
    {
        Buff,
        Debuff
    }
    public abstract class BaseEffect
    {
        public EffectType EffectType { get; }
        public string Description { get; }

        public int duration;

        public BaseEffect(EffectType effectType, string description)
        {
            this.EffectType = effectType;
            this.Description = description;
        }
        public abstract void OnApply(BaseEntity entity, BaseEffect effect);
        public abstract void OnUpdate(BaseEntity entity, GameTime gameTime, BaseEffect effect);
        public abstract void OnExpired(BaseEntity entity, BaseEffect effect);
    }
}
