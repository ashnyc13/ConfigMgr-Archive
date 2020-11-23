namespace ConfigMgr.Domain
{
    /// <summary>
    /// A Configuration value is the lowest level
    /// node in the configuration heirarchy.
    /// </summary>
    public abstract class ConfigurationValue
    {
        /// <summary>
        /// Gets the raw data associated with the configuration value.
        /// </summary>
        /// <returns></returns>
        public object RawData { get; private set; }

        /// <summary>
        /// Deserializes the given configuration item as <see cref="ConfigurationValue<TData>" />.
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <returns></returns>
        public abstract ConfigurationValue<TData> As<TData>();
    }

    /// <summary>
    /// A Configuration value is the lowest level
    /// node in the configuration heirarchy.
    /// </summary>
    /// <typeparam name="TData">Type of data attached to the configuration item.</typeparam>
    public abstract class ConfigurationValue<TData> : ConfigurationValue
    {
        /// <summary>
        /// Gets the data deserialized into the expected format.
        /// </summary>
        /// <returns></returns>
        public TData Data { get; private set; }
    }
}
