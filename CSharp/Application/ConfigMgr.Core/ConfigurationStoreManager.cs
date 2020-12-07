// using System;
// using System.Collections.Generic;
// using ConfigMgr.Core.Interfaces;
// using ConfigMgr.Domain;

// namespace ConfigMgr.Core
// {
//     /// <summary>
//     /// Represents a configuration storage manager.
//     /// Helps query multiple configuration stores
//     /// for the requested data. Stores are searched in
//     /// the last-in order, i.e. priority is given to the
//     /// stores that were added later.
//     /// </summary>
//     public class ConfigurationStoreManager : IConfigurationStore
//     {
//         private readonly IList<IConfigurationStore> _stores;
//         private readonly HashSet<string> _storeUris;

//         /// <summary>
//         /// Creates a new instance of <see cref="ConfigurationStoreManager" />
//         /// </summary>
//         public ConfigurationStoreManager()
//         {
//             _stores = new List<IConfigurationStore>();
//             _storeUris = new HashSet<string>();
//         }

//         /// <summary>
//         /// Adds the given configuration store
//         /// to the manager.
//         /// </summary>
//         /// <param name="configurationStore"></param>
//         public void AddStore(IConfigurationStore configurationStore)
//         {
//             if (configurationStore is null)
//                 throw new ArgumentNullException(nameof(configurationStore));
//             if (_storeUris.Contains(configurationStore.Uri))
//                 throw new ArgumentException($"A store at the Uri '{configurationStore.Uri}' was already added.", nameof(configurationStore));
//             if (configurationStore is ConfigurationStoreManager)
//                 throw new ArgumentException("Cannot add another store manager to this store manager instance.", nameof(configurationStore));
//             _stores.Add(configurationStore);
//             _storeUris.Add(configurationStore.Uri);
//         }

//         /// <inheritdoc />
//         public object Read(ConfigurationQuery query)
//         {
//             // Go through the stores from last to first
//             // and look for the data requested
//             for (var i = _stores.Count - 1; i >= 0; i--)
//             {
//                 var result = _stores[i].Read(query);
//                 if (result != null) return result;
//             }

//             return null;
//         }

//         /// <inheritdoc />
//         public string Uri => null;
//     }
// }