using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level.Utils
{
    public class DynamicRandom
    {
        private Random random;

        public DynamicRandom()
        {
            random = new Random();
        }

        public DynamicRandom(int seed)
        {
            random = new Random(seed);
        }

        public int Next()
        {
            return random.Next();
        }

        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            return random.NextDouble();
        }

        public float NextFloat()
        {
            return (float)random.NextDouble();
        }

        public double NextDouble(double maxValue)
        {
            return random.NextDouble() * maxValue;
        }

        public float NextFloat(float maxValue)
        {
            return (float)(random.NextDouble() * maxValue);
        }

        public double NextDouble(double minValue, double maxValue)
        {
            return minValue + random.NextDouble() * (maxValue - minValue);
        }

        public float NextFloat(float minValue, float maxValue)
        {
            return minValue + (float)random.NextDouble() * (maxValue - minValue);
        }
        public bool NextBool()
        {
            return random.Next(2) == 0;
        }
        public bool NextBool(int chance)
        {
            if (chance <= 0) return true;
            return random.Next(chance) == 0;
        }
        public bool NextBool(double probability)
        {
            return random.NextDouble() < probability;
        }
    }
}
