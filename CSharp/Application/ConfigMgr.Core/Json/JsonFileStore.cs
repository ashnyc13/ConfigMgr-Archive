using System;
using System.IO;
using ConfigMgr.Core.Interfaces;
using ConfigMgr.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConfigMgr.Core.Json
{
    /// <summary>
    /// Represents a Json file based configuration store.
    /// </summary>
    public class JsonFileStore : IConfigurationStore, IDisposable
    {
        private bool disposedValue;
        private JsonReader _jsonReader;
        private StreamReader _fileReader;
        private Stream _stream;
        // private static readonly Regex _arrayExpression = new Regex(
        //     @"(?<arrayName>[^\[]+)\[(?<arrayIndex>\d+)\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

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
            _stream = File.OpenRead(filePath);
            _fileReader = new StreamReader(_stream);
            _jsonReader = new JsonTextReader(_fileReader);
        }

        /// <inheritdoc />
        public string Uri { get; private set; }

        /// <inheritdoc />
        public object Read(ConfigurationQuery query)
        {
            // Parse out the query
            var queryValue = query.Value;
            var queryParts = queryValue.Split('.');

            // Go through the reader to find the object requested
            _stream.Seek(0, SeekOrigin.Begin);
            while (_jsonReader.Read())
            {
                // Check if we should skip/bail out
                var partIndex = _jsonReader.Depth - 1;
                if (partIndex < 0) continue;
                if (partIndex > queryParts.Length - 1) break;

                // Did we land on a property?
                if (_jsonReader.TokenType != JsonToken.PropertyName
                    && _jsonReader.TokenType != JsonToken.StartObject)
                    continue;

                // Get the requested property name
                var requestedPropertyName = queryParts[partIndex];

                // Check if the current property name matches
                // the requested property name
                var path = _jsonReader.Path;
                var lastDotIndex = path.LastIndexOf('.');
                var currentPropertyName = lastDotIndex == -1 ? path : path.Substring(lastDotIndex + 1);
                if (currentPropertyName != requestedPropertyName)
                {
                    // Skip reading children
                    _jsonReader.Skip();
                    continue;
                }

                // If we found a match and reached the end of parts collection
                if (partIndex == queryParts.Length - 1)
                {
                    // this is the answer
                    return JToken.ReadFrom(_jsonReader);
                }
            }

            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects)
                    _jsonReader.Close();
                    _fileReader.Dispose();
                }

                // set large fields to null
                _fileReader = null;
                _jsonReader = null;
                _stream = null;
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}