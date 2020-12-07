using System;
using System.Collections.Generic;
using ConfigMgr.Domain;
using Newtonsoft.Json.Linq;

namespace ConfigMgr.Core.Json.Domain
{
    /// <summary>
    /// Represents a collection of related configuration values.
    /// </summary>
    public class JsonConfigurationCollection : ConfigurationCollection
    {
        public JsonConfigurationCollection(JArray array) : base(ToCollection(array))
        {
        }

        private static ICollection<ConfigurationValue> ToCollection(JArray array)
        {
            throw new NotImplementedException();
        }

        public override TData As<TData>()
        {
            throw new System.NotImplementedException();
        }

        public override void Bind<TData>(TData output, string memberName)
        {
            throw new System.NotImplementedException();
        }
    }
}