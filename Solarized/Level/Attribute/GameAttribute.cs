using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.NPCs
{
    public class GameAttribute
    {
        public string Name;
        protected double defaultValue;
        protected double minValue;
        protected double maxValue;

        public GameAttribute(string name, double defaultValue, double min, double max)
        {
            this.Name = name;
            this.defaultValue = defaultValue;
            this.minValue = min;
            this.maxValue = max;
        }

        public override string ToString()
        {
            return $"[{this.Name} [{this.defaultValue}] - [{this.minValue} / {this.maxValue}]]";
        }

        public double DefaultValue()
        {
            return this.defaultValue;
        }
        public double MinValue()
        {
            return this.minValue;
        }
        public double MaxValue()
        {
            return this.maxValue;
        }
    }
}
