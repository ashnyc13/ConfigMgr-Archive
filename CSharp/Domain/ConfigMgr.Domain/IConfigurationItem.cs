using System;

namespace ConfigMgr.Domain
{
    /// <summary>
    /// A Configuration item is the lowest level
    /// node in the configuration heirarchy.
    /// </summary>
    public interface IConfigurationItem
    {
        /// <summary>
        /// Gets the raw data associated with the configuration item.
        /// </summary>
        /// <returns></returns>
        object GetRawData();

        /// <summary>
        /// Deserializes the given configuration item as <see cref="IConfigurationItem<TData>" />.
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <returns></returns>
        IConfigurationItem<TData> As<TData>();
    }

    /// <summary>
    /// A Configuration item is the lowest level
    /// node in the configuration heirarchy.
    /// </summary>
    /// <typeparam name="TData">Type of data attached to the configuration item.</typeparam>
    public interface IConfigurationItem<TData> : IConfigurationItem
    {
        /// <summary>
        /// Gets the data deserialized into the expected format.
        /// </summary>
        /// <returns></returns>
        TData GetData();
    }
}
