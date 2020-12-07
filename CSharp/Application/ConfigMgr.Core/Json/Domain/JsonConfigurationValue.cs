using System;
using System.Linq;
using System.Reflection;
using ConfigMgr.Domain;
using Newtonsoft.Json.Linq;

namespace ConfigMgr.Core.Json.Domain
{
    /// <summary>
    /// A Configuration value is the lowest level
    /// node in the configuration heirarchy.
    /// </summary>
    public class JsonConfigurationValue : ConfigurationValue
    {
        private readonly JToken _token;

        public JsonConfigurationValue(JToken token)
        {
            _token = token ?? throw new System.ArgumentNullException(nameof(token));
        }

        /// <inheritdoc />
        public override TData As<TData>()
        {
            return (TData)ChangeType(typeof(TData));
        }

        /// <inheritdoc />
        public override void Bind<TData>(TData output, string memberName)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));
            if (string.IsNullOrEmpty(memberName)) throw new ArgumentException($"'{nameof(memberName)}' cannot be null or empty", nameof(memberName));

            var propOrFields = typeof(TData).GetMember(memberName, BindingFlags.SetField | BindingFlags.SetProperty | BindingFlags.Instance);
            if (propOrFields == null || !propOrFields.Any())
                throw new ArgumentException($"Couldn't find a property or field with the given name '{memberName}'.", nameof(memberName));

            var firstPropOrField = propOrFields[0];
            if (firstPropOrField.MemberType == MemberTypes.Field)
            {
                var field = firstPropOrField as FieldInfo;
                field.SetValue(output, ChangeType(field.FieldType));
                return;
            }
            if (firstPropOrField.MemberType == MemberTypes.Property)
            {
                var prop = firstPropOrField as PropertyInfo;
                prop.SetValue(output, ChangeType(prop.PropertyType));
            }
        }

        private object ChangeType(Type destType)
        {
            return Convert.ChangeType(_token.ToString(), destType);
        }
    }
}
