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
