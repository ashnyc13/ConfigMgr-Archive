using System;
using System.Collections.Generic;
using ConfigMgr.Core.Interfaces;
using ConfigMgr.Domain;

namespace ConfigMgr.Core
{
    /// <summary>
    /// Represents a query execution manager.
    /// Helps merge output from multiple query
    /// executers into a final output.
    /// </summary>
    public class QueryExecutionManager : IQueryExecutionManager
    {
        private readonly ICollection<IQueryExecuter> _executers;

        /// <summary>
        /// Creates a new instance of <see cref="QueryExecutionManager" />
        /// </summary>
        public QueryExecutionManager()
        {
            _executers = new HashSet<IQueryExecuter>();
        }

        /// <summary>
        /// Adds the given executer to the manager.
        /// </summary>
        /// <param name="queryExecuter"></param>
        public void AddExecuter(IQueryExecuter queryExecuter)
        {
            if (queryExecuter is null)
                throw new ArgumentNullException(nameof(queryExecuter));
            if (_executers.Contains(queryExecuter))
                throw new ArgumentException($"Query executer '{queryExecuter.GetType().FullName}' was added already.", nameof(queryExecuter));
            if (queryExecuter is QueryExecutionManager)
                throw new ArgumentException("Cannot add another query manager to this query manager instance.", nameof(queryExecuter));
            _executers.Add(queryExecuter);
        }

        /// <inheritdoc />
        public ConfigurationCollection Collection(ConfigurationQuery query)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ConfigurationMap Map(ConfigurationQuery query)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ConfigurationValue Value(ConfigurationQuery query)
        {
            throw new NotImplementedException();
        }
    }
}