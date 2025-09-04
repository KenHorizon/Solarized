using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level.Registry
{
    public class RegistryKey<T>
    {
        private readonly string registryName;
        public T value;
        public RegistryKey(string RegistryName) 
        {
            this.registryName = RegistryName;
        }

        internal void SetValue(T val) => value = val;

        public T Get() => this.value;
        public string RegistryName() => this.registryName;
    }
}
