using Solarized.NPCs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.NPCs
{
    public class AttributeInstance
    {
        public GameAttribute attribute { get; }
        public double BaseValue { get; }
        private List<AttributeModifier> modifiers = new List<AttributeModifier>();

        public AttributeInstance(GameAttribute attribute)
        {
            this.attribute = attribute;
            this.BaseValue = attribute.DefaultValue();
        }

        public void AddModifier(AttributeModifier attributeModifier)
        {
            modifiers.Add(attributeModifier);
        }

        public void RemoveModifier(Guid UUID)
        {
            modifiers.RemoveAll(modifier => modifier.UUID == UUID);
        }

        public double GetValue()
        {
            double add = 0, mulBase = 0, mulTotal = 0;

            foreach (var modifier in modifiers)
            {
                switch (modifier.Operation)
                {
                    case OperationType.Add:
                        add += modifier.Value;
                        break;
                    case OperationType.MultiplyBase:
                        mulBase += modifier.Value;
                        break;
                    case OperationType.MultiplyTotal:
                        mulTotal += modifier.Value;
                        break;
                }
            }

            return (this.BaseValue + add) * (1 + mulBase) * (1 + mulTotal);
        }
    }
}
