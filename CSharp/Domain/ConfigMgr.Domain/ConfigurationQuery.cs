using System.Diagnostics;

namespace ConfigMgr.Domain
{
    /// <summary>
    /// Represents query that could return a <see cref="ConfigurationMap" />,
    /// <see cref="ConfigurationCollection" />, or a <see cref="ConfigurationValue" />.
    /// </summary>
    [DebuggerDisplay("{" + nameof(ToString) + "(),nq}")]
    public abstract class ConfigurationQuery
    {
        /// <summary>
        /// Creates a new instance of <see cref="ConfigurationQuery" /> based
        /// on the given string representation.
        /// </summary>
        /// <param name="value"></param>
        protected ConfigurationQuery(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new System.ArgumentException($"'{nameof(value)}' cannot be null or empty", nameof(value));
            }

            Value = value;
        }

        /// <summary>
        /// String representation of the query instance.
        /// </summary>
        /// <value></value>
        public string Value { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value;
        }
    }
}