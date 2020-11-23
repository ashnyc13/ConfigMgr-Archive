using System.Collections;
using System.Collections.Generic;

namespace ConfigMgr.Domain
{
    /// <summary>
    /// Represents a dictionary of related configuration values.
    /// </summary>
    public abstract class ConfigurationMap : ConfigurationValue, IDictionary<string, ConfigurationValue>
    {
        private readonly IDictionary<string, ConfigurationValue> _sourceDictionary;

        public ConfigurationMap(IDictionary<string, ConfigurationValue> sourceDictionary)
        {
            _sourceDictionary = sourceDictionary ?? throw new System.ArgumentNullException(nameof(sourceDictionary));
        }

        public ConfigurationValue this[string key]
        {
            get => _sourceDictionary[key];
            set => _sourceDictionary[key] = value;
        }

        public ICollection<string> Keys => _sourceDictionary.Keys;

        public ICollection<ConfigurationValue> Values => _sourceDictionary.Values;

        public int Count => _sourceDictionary.Count;

        public bool IsReadOnly => _sourceDictionary.IsReadOnly;

        public void Add(string key, ConfigurationValue value)
        {
            _sourceDictionary.Add(key, value);
        }

        public void Add(KeyValuePair<string, ConfigurationValue> item)
        {
            _sourceDictionary.Add(item);
        }

        public void Clear()
        {
            _sourceDictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, ConfigurationValue> item)
        {
            return _sourceDictionary.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return _sourceDictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, ConfigurationValue>[] array, int arrayIndex)
        {
            _sourceDictionary.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, ConfigurationValue>> GetEnumerator()
        {
            return _sourceDictionary.GetEnumerator();
        }

        public bool Remove(string key)
        {
            return _sourceDictionary.Remove(key);
        }

        public bool Remove(KeyValuePair<string, ConfigurationValue> item)
        {
            return _sourceDictionary.Remove(item);
        }

        public bool TryGetValue(string key, out ConfigurationValue value)
        {
            return _sourceDictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _sourceDictionary.GetEnumerator();
        }
    }
}