using System;
using System.Collections;
using System.Collections.Generic;
using ConfigMgr.Core.Json.Extensions;
using ConfigMgr.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConfigMgr.Core.Json.Domain
{
    /// <summary>
    /// Represents a dictionary of related configuration values.
    /// </summary>
    public class JsonConfigurationMap : ConfigurationMap
    {
        public JsonConfigurationMap(JObject jObj) : base(ToDictionary(jObj))
        {
        }

        public override TData As<TData>()
        {
            throw new NotImplementedException();
        }

        public override void Bind<TData>(TData output, string memberName)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<KeyValuePair<string, ConfigurationValue>> ToDictionary(JObject jObj)
        {
            var currentPropertyName = string.Empty;
            using (var reader = new JTokenReader(jObj))
            {
                while (reader.Read())
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.PropertyName:
                            currentPropertyName = reader.CurrentPropertyName();
                            break;
                        case JsonToken.StartObject:
                            if (string.IsNullOrEmpty(currentPropertyName)) continue;
                            var childObj = JObject.Load(reader);
                            yield return new KeyValuePair<string, ConfigurationValue>(
                                currentPropertyName, new JsonConfigurationMap(childObj));
                            break;
                        case JsonToken.StartArray:
                            if (string.IsNullOrEmpty(currentPropertyName)) continue;
                            var childArr = JArray.Load(reader);
                            yield return new KeyValuePair<string, ConfigurationValue>(
                                currentPropertyName, new JsonConfigurationCollection(childArr));
                            break;
                        case JsonToken.Float:
                        case JsonToken.Integer:
                        case JsonToken.String:
                            if (string.IsNullOrEmpty(currentPropertyName)) continue;
                            var childValue = reader.CurrentToken;
                            yield return new KeyValuePair<string, ConfigurationValue>(
                                currentPropertyName, new JsonConfigurationValue(childValue));
                            break;
                    }
                }
            }
        }
    }
}