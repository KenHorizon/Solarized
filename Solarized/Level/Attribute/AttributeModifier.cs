using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.NPCs
{
    public enum OperationType
    {
        Add,
        MultiplyBase,
        MultiplyTotal
    }
    public class AttributeModifier
    {
        public Guid UUID { get; }  = Guid.NewGuid();
        public double Value { get; }
        public OperationType Operation { get; }
        public string Name { get; }

        public AttributeModifier(string name, double value, OperationType type)
        {
            this.Name = name;
            this.Value = value;
            this.Operation = type;
        }
        public override string ToString()
        {
            return $"{this.Name} : {this.Operation} {this.Value}";
        }
    }
}
