using ConfigMgr.Domain;

namespace ConfigMgr.Core.Interfaces
{
    /// <summary>
    /// Helps execute configuration queries.
    /// </summary>
    public interface IQueryExecutionManager : IQueryExecuter
    {
        /// <summary>
        /// Adds the given executer to the manager.
        /// </summary>
        /// <param name="queryExecuter"></param>
        void AddExecuter(IQueryExecuter queryExecuter);
    }
}