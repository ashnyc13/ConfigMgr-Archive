using ConfigMgr.Domain;

namespace ConfigMgr.Core
{
    /// <summary>
    /// Helps execute configuration queries.
    /// </summary>
    public abstract class QueryExecuter
    {
        private readonly ConfigurationStore _configurationStore;

        /// <summary>
        /// Executes the given query against a configuration store
        /// and loads a configuration map based on the data
        /// returned from the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public abstract ConfigurationMap Map(ConfigurationQuery query);

        /// <summary>
        /// Executes the given query against a configuration store
        /// and loads a configuration collection based on the data
        /// returned from the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public abstract ConfigurationCollection Collection(ConfigurationQuery query);

        /// <summary>
        /// Executes the given query against a configuration store
        /// and loads a configuration value based on the data
        /// returned from the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public abstract ConfigurationValue Value(ConfigurationQuery query);

        /// <summary>
        /// Creates a new instance of <see cref="ConfigurationStore" />.
        /// </summary>
        /// <param name="configurationStore"></param>
        protected QueryExecuter(ConfigurationStore configurationStore)
        {
            _configurationStore = configurationStore ?? throw new System.ArgumentNullException(nameof(configurationStore));
        }
    }
}