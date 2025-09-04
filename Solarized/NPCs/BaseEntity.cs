using Microsoft.Xna.Framework;
using Solarized.Content;
using Solarized.Effect;
using Solarized.Level.Registry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solarized.NPCs
{
    public abstract class BaseEntity
    {
        private Dictionary<string, AttributeInstance> attributes = new Dictionary<string, AttributeInstance>();
        public float posX;
        public float posY;
        public float facing;
        public float health;
        public int level;
        public int healthRegenTick;
        public int coins;
        public int deathTick;
        public bool IsEnemy;
        public bool IsPlayer;
        public bool IsInvul;
        public bool IsFrozen;
        public bool IsHaveStatus;
        public bool IsAlive;
        public bool IsCritAttack;
        public bool IsRemove;
        public int HurtDuration;
        public int tick = 0;
        private List<RegistryKey<BaseEffect>> effects = new List<RegistryKey<BaseEffect>>();
        public EntityClass classType = EntityClass.Object;
        public Random randon = new Random();
        

        public BaseEntity()
        {
            this.SetAttributes();
        }

        public abstract void SetAttributes();
        public void Hurt(float damage)
        {
            if (this.IsInvul == false)
            {
                if (this.HurtDuration <= 0)
                {
                    this.HurtDuration = 20;
                    this.DamageDealt(damage);
                }
            }
        }
        //public void ApplyBuff(BuffType type, int durationTicks)
        //{
        //    var existing = activeBuffs.FirstOrDefault(b => b.Type == type);
        //    if (existing != null)
        //        existing.Duration = durationTicks;
        //    else
        //    {
        //        var buff = new BuffInstance(type, durationTicks);
        //        activeBuffs.Add(buff);

        //        BuffRegistry.Get(type)?.OnApply(this, buff);
        //    }
        //}

        public void ApplyEffects(RegistryKey<BaseEffect> effect, int duration)
        {
            var isAlreadyHave = this.effects.FirstOrDefault(effects => effects.registryName == effect.registryName);
        }

        public virtual void Tick(GameTime gameTime)
        {
            for (int i = this.effects.Count - 1; i >= 0; i--)
            {
                BaseEffect buff = this.effects[i].Get();
                buff.duration--;
                buff.OnUpdate(this, gameTime, buff);
                if (buff.duration <= 0)
                {
                    buff.OnExpired(this, buff);
                    this.effects.RemoveAt(i);
                }
            }
        }

        public void DamageDealt(float amount)
        {
            float damageDealt = (float) (amount * this.DamageDealt());
            if (this.randon.NextDouble() <= this.GetAttributeValue(Attributes.CRITICAL_STRIKE))
            {
                damageDealt *= (float) this.GetAttributeValue(Attributes.CRITICAL_DAMAGE);
                this.IsCritAttack = true;
            } else
            {
                this.IsCritAttack = false;
            }
            float DamageTaken = damageDealt * (this.Armor() <= 0 ? 100 / 100 + this.Armor() : 2 - (100 / 100 - this.Armor()));
            DamageTaken *= this.DamageTaken();
            this.SetHealth(this.GetHealth() - DamageTaken);
        }

        public void SetHealth(float health)
        {
            this.health = health;
        }

        public float GetHealth() 
        {
            return this.health;
        }
    
        public float MaxHealth()
        {
            return (float)this.GetAttributeValue(Attributes.MAX_HEALTH);
        }

        public float Armor()
        {
            return (float) this.GetAttributeValue(Attributes.ARMOR);
        }
        public float DamageDealt()
        {
            return (float)this.GetAttributeValue(Attributes.DAMAGE_DEALT);
        }
        public float DamageTaken()
        {
            return (float)this.GetAttributeValue(Attributes.DAMAGE_TAKEN);
        }
        protected void RegisterAttributes(RegistryKey<GameAttribute> registry)
        {
            GameAttribute attribute = registry.Get();
            this.attributes[registry.RegistryName()] = new AttributeInstance(attribute);
        }

        public AttributeInstance GetAttribute(RegistryKey<GameAttribute> attribute)
        {
            AttributeInstance attributeInstance;
            if (this.attributes.TryGetValue(attribute.Get().Name, out attributeInstance))
            {
                return attributeInstance;
            }
            return null;
        }

        public double GetAttributeValue(RegistryKey<GameAttribute> attribute)
        {
            AttributeInstance attributeInstance;
            if (this.attributes.TryGetValue(attribute.Get().Name, out attributeInstance))
            {
                return attributeInstance.GetValue();
            }
            return 0.0D;
        }
    }
}
