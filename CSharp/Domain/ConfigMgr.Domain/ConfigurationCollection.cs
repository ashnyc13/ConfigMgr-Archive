using System.Collections;
using System.Collections.Generic;

namespace ConfigMgr.Domain
{
    /// <summary>
    /// Represents a collection of related configuration values.
    /// </summary>
    public abstract class ConfigurationCollection : ConfigurationValue, ICollection<ConfigurationValue>
    {
        private readonly ICollection<ConfigurationValue> _sourceCollection;

        /// <summary>
        /// Creates a new instance of <see cref="ConfigurationCollection" />
        /// </summary>
        /// <param name="sourceCollection"></param>
        internal ConfigurationCollection(ICollection<ConfigurationValue> sourceCollection)
        {
            _sourceCollection = sourceCollection;
        }

        /// <inheritdoc />
        public int Count => _sourceCollection?.Count ?? 0;

        /// <inheritdoc />
        public bool IsReadOnly => _sourceCollection?.IsReadOnly ?? false;

        /// <inheritdoc />
        public void Add(ConfigurationValue item) => _sourceCollection?.Add(item);

        /// <inheritdoc />
        public void Clear() => _sourceCollection?.Clear();

        /// <inheritdoc />
        public bool Contains(ConfigurationValue item) => _sourceCollection?.Contains(item) ?? false;

        /// <inheritdoc />
        public void CopyTo(ConfigurationValue[] array, int arrayIndex) => _sourceCollection?.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public bool Remove(ConfigurationValue item) => _sourceCollection?.Remove(item) ?? false;

        /// <inheritdoc />
        public IEnumerator<ConfigurationValue> GetEnumerator() => _sourceCollection?.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => _sourceCollection?.GetEnumerator();
    }
}