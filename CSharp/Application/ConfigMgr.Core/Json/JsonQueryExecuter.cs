using System;
using ConfigMgr.Core.Interfaces;
using ConfigMgr.Domain;
using Newtonsoft.Json.Linq;

namespace ConfigMgr.Core.Json
{
    /// <summary>
    /// An <see cref="IQueryExecuter" /> implementation
    /// for executing queries on a JSON <see cref="IConfigurationStore{TData}"/>.
    /// </summary>
    public class JsonQueryExecuter : IQueryExecuter
    {
        private readonly IConfigurationStore<JToken> _jsonConfigStore;

        /// <summary>
        /// Creates a new instance of <see cref="JsonQueryExecuter"/>.
        /// </summary>
        /// <param name="jsonConfigStore"></param>
        public JsonQueryExecuter(IConfigurationStore<JToken> jsonConfigStore)
        {
            _jsonConfigStore = jsonConfigStore ?? throw new System.ArgumentNullException(nameof(jsonConfigStore));
        }

        /// <inheritdoc />
        public ConfigurationCollection Collection(ConfigurationQuery query)
        {
            var result = _jsonConfigStore.Read(query);
            if (!result.HasValues) throw new InvalidOperationException($"A query for collection didn't return a collection. Query: '{query}'");
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public ConfigurationMap Map(ConfigurationQuery query)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public ConfigurationValue Value(ConfigurationQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}