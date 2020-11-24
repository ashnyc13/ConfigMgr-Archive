namespace ConfigMgr.Core.Interfaces
{
    /// <summary>
    /// Represents a configuration store.
    /// </summary>
    public interface IConfigurationStore
    {
        /// <summary>
        /// Executes the given native query on the store
        /// and returns the data from the store.
        /// </summary>
        /// <param name="nativeQuery">A query in the format native to the configuration store.</param>
        /// <returns></returns>
        object Read(string nativeQuery);

        /// <summary>
        /// Uri of the source in its native format.
        /// </summary>
        /// <value></value>
        string Uri { get; }
    }
}