using Solarized.NPCs;

namespace Solarized.Level.Registry
{
    public class RegistryAttributes
    {
        public static DeferredRegister<GameAttribute> ATTRIBUTES = new DeferredRegister<GameAttribute>(GameRegistry.ATTRIBUTE, "Attributes");

        public static RegistryKey<GameAttribute> MAX_HEALTH = Register("MaxHealth", 20.0D, 0.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> ATTACK_DAMAGE = Register("AttackDamage", 0.0D, -999999999.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> ATTACK_SPEED = Register("AttackSpeed", 1.0D, -999999999.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> ARMOR = Register("Armor", 0.0D, -999999999.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> DAMAGE_DEALT = Register("DamageDealt", 1.0D, -1.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> DAMAGE_TAKEN = Register("DamageTaken", 1.0D, -999999999.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> CRITICAL_STRIKE = Register("CriticalStrike", 0.0D, 0.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> CRITICAL_DAMAGE = Register("CriticalDamage", 1.5D, 0.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> MOVEMENT_SPEED = Register("MovementSpeed", 250.0D, 0.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> HEALTH_REGEN = Register("HealthRegen", 5.0D, 0.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> MANA_REGEN = Register("ManaRegen", 1.0D, 0.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> SCALE = Register("Scale", 1.0D, 0.0D, 999999999.0D);
        public static RegistryKey<GameAttribute> LUCK = Register("Luck", 0.0D, 0.0D, 999999999.0D);

        public static RegistryKey<GameAttribute> Register(string name, double defaultValue, double min, double max)
        {
            return ATTRIBUTES.Register(name, () => new GameAttribute(name, defaultValue, min, max));
        }

    }
}
