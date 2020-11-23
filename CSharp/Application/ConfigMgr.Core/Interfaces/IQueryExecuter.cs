using ConfigMgr.Domain;

namespace ConfigMgr.Core.Interfaces
{
    /// <summary>
    /// Helps execute configuration queries.
    /// </summary>
    public interface IQueryExecuter
    {
        /// <summary>
        /// Executes the given query against a configuration store
        /// and loads a configuration map based on the data
        /// returned from the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ConfigurationMap Map(ConfigurationQuery query);

        /// <summary>
        /// Executes the given query against a configuration store
        /// and loads a configuration collection based on the data
        /// returned from the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ConfigurationCollection Collection(ConfigurationQuery query);

        /// <summary>
        /// Executes the given query against a configuration store
        /// and loads a configuration value based on the data
        /// returned from the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        ConfigurationValue Value(ConfigurationQuery query);
    }
}