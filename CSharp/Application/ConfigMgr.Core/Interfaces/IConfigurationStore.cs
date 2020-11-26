using ConfigMgr.Domain;

namespace ConfigMgr.Core.Interfaces
{
    /// <summary>
    /// Represents a configuration store.
    /// </summary>
    public interface IConfigurationStore
    {
        /// <summary>
        /// Executes the given native query on the store
        /// and returns the data from the store in the native format.
        /// </summary>
        /// <param name="query">A query in the format native to the configuration store.</param>
        /// <returns></returns>
        object Read(ConfigurationQuery query);

        /// <summary>
        /// Uri of the source in its native format.
        /// </summary>
        /// <value></value>
        string Uri { get; }
    }
}