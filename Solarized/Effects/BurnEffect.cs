using Microsoft.Xna.Framework;
using Solarized.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Effects
{
    public class BurnEffect : BaseEffect
    {
        public BurnEffect(EffectType effectType, string description) : base(effectType, description)
        {
        }

        public override void OnApply(BaseEntity entity, BaseEffect effect)
        {
            
        }

        public override void OnExpired(BaseEntity entity, BaseEffect effect)
        {

        }

        public override void OnUpdate(BaseEntity entity, GameTime gameTime, BaseEffect effect)
        {
            entity.SetHealth(entity.GetHealth() - 1);
        }
    }
}
