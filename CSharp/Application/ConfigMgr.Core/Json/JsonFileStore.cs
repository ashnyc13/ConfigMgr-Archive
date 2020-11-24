using System.IO;
using ConfigMgr.Core.Interfaces;
using Newtonsoft.Json.Linq;

namespace ConfigMgr.Core.Json
{
    /// <summary>
    /// Represents a Json file based configuration store.
    /// </summary>
    public class JsonFileStore : IConfigurationStore
    {
        private readonly JToken _root;

        /// <summary>
        /// Creates a new instance of <see cref="JsonFileStore" />
        /// based on the file path specified.
        /// </summary>
        /// <param name="filePath"></param>
        public JsonFileStore(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new System.ArgumentException($"'{nameof(filePath)}' cannot be null or empty", nameof(filePath));
            }

            Uri = filePath;
            _root = JToken.Parse(File.ReadAllText(filePath));
        }

        /// <inheritdoc />
        public string Uri { get; private set; }

        /// <inheritdoc />
        public object Read(string nativeQuery)
        {
            return _root.SelectToken(nativeQuery);
        }
    }
}