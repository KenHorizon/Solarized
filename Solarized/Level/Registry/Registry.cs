using System;
using System.Collections.Generic;

namespace Solarized.Level.Registry
{
    public class Registry<T>
    {
        private Dictionary<string, T> entries = new Dictionary<string, T>();

        public void Register(string id, T value)
        {
            if (entries.ContainsKey(id))
            {
                throw new Exception($"Duplicate registry entry: {id}");
            }
            entries[id] = value;
        }

        public T Get(string id) =>
            entries.TryGetValue(id, out var value) ? value : default;

        public IEnumerable<KeyValuePair<string, T>> GetAll() => entries;
    }
}
