using System.Collections;
using System.Collections.Generic;

namespace ConfigMgr.Domain
{
    /// <summary>
    /// Represents a collection of related configuration items.
    /// </summary>
    public class ConfigurationItemGroup : ICollection<IConfigurationItem>
    {
        private readonly ICollection<IConfigurationItem> _sourceCollection;

        /// <summary>
        /// Creates a new instance of <see cref="ConfigurationItemGroup" />
        /// </summary>
        /// <param name="sourceCollection"></param>
        public ConfigurationItemGroup(ICollection<IConfigurationItem> sourceCollection)
        {
            _sourceCollection = sourceCollection ?? throw new System.ArgumentNullException(nameof(sourceCollection));
        }

        public int Count => _sourceCollection.Count;
        public bool IsReadOnly => _sourceCollection.IsReadOnly;
        public void Add(IConfigurationItem item) => _sourceCollection.Add(item);
        public void Clear() => _sourceCollection.Clear();
        public bool Contains(IConfigurationItem item) => _sourceCollection.Contains(item);
        public void CopyTo(IConfigurationItem[] array, int arrayIndex) => _sourceCollection.CopyTo(array, arrayIndex);
        public bool Remove(IConfigurationItem item) => _sourceCollection.Remove(item);
        public IEnumerator<IConfigurationItem> GetEnumerator() => _sourceCollection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _sourceCollection.GetEnumerator();
    }
}