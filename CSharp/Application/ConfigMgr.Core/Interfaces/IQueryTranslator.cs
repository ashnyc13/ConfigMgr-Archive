using ConfigMgr.Domain;

namespace ConfigMgr.Core.Interfaces
{
    /// <summary>
    /// Helps translating the queries into native format.
    /// </summary>
    public interface IQueryTranslator
    {
        /// <summary>
        /// Converts the given <see cref="ConfigurationQuery" /> instance
        /// into a native format query specific to a configuration store.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        string ToNative(ConfigurationQuery query);
    }
}