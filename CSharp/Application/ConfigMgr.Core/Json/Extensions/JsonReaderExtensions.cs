using Newtonsoft.Json;

namespace ConfigMgr.Core.Json.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="JsonReader"/>
    /// </summary>
    public static class JsonReaderExtensions
    {
        public static string CurrentPropertyName(this JsonReader reader)
        {
            if (reader is null)
            {
                throw new System.ArgumentNullException(nameof(reader));
            }

            if (string.IsNullOrEmpty(reader.Path)) return string.Empty;

            var lastIndexOfDot = reader.Path.LastIndexOf('.');
            return lastIndexOfDot == -1 ? reader.Path : reader.Path.Substring(lastIndexOfDot + 1);
        }
    }
}