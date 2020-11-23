namespace ConfigMgr.Domain
{
    /// <summary>
    /// Represents query that could return a <see cref="ConfigurationMap" />,
    /// <see cref="ConfigurationCollection" />, or a <see cref="ConfigurationValue" />.
    /// </summary>
    public abstract class ConfigurationQuery
    {
        /// <summary>
        /// Creates a new instance of <see cref="ConfigurationQuery" /> based
        /// on the given string representation.
        /// </summary>
        /// <param name="query"></param>
        protected ConfigurationQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new System.ArgumentException($"'{nameof(query)}' cannot be null or empty", nameof(query));
            }

            Query = query;
        }

        /// <summary>
        /// String representation of the query instance.
        /// </summary>
        /// <value></value>
        public string Query { get; }
    }
}