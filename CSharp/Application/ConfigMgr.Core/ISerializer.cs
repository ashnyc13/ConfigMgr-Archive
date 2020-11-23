using System;

namespace ConfigMgr.Core
{
    /// <summary>
    /// Serialization and deserialization support for configuration data.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes given object to its string representation.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <returns></returns>
        string Serialize(object obj);

        /// <summary>
        /// Serializes given object to its string representation.
        /// </summary>
        /// <param name="obj">Object to serialize.</param>
        /// <typeparam name="TObj">Type of object.</typeparam>
        /// <returns></returns>
        string Serialize<TObj>(TObj obj);

        /// <summary>
        /// Deserializes given object from its string representation.
        /// </summary>
        /// <param name="data">Serialized data.</param>
        /// <param name="objType">Type of the object to deserialize into.</param>
        /// <returns></returns>
        object Deserialize(string data, Type objType);

        /// <summary>
        /// Deserializes given object from its string representation.
        /// </summary>
        /// <param name="data">Serialized data.</param>
        /// <typeparam name="TObj">Type of the object to deserialize into.</typeparam>
        /// <returns></returns>
        TObj Deserialize<TObj>(string data);
    }
}
