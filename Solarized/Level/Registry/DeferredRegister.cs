using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solarized.Level.Registry
{
    public class DeferredRegister<T>
    {
        private readonly Registry<T> registry;
        private readonly string registryName;
        private readonly List<(string name, Func<T> supplier)> pending = new List<(string name, Func<T> supplier)>();

        public DeferredRegister(Registry<T> registry, string registryName)
        {
            this.registry = registry;
            this.registryName = registryName;
        }
        public RegistryKey<T> Register(string name, Func<T> supplier)
        {
            var obj = new RegistryKey<T>(name);
            pending.Add((name, supplier));
            return obj;
        }

        public void Register()
        {
            foreach (var (name, supplier) in pending)
            {
                var id = name;
                var value = supplier();
                registry.Register(id, value);
            }
            pending.Clear();
        }
    }
}
