using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteNewsApi.Redis
{
    interface ICache
    {
        void Set<T>(string key, T objectToCache) where T : class;
        T Get<T>(string key) where T : class;
        void Delete(string key);
        IEnumerable<T> GetAll<T>() where T:class;
    }
}
