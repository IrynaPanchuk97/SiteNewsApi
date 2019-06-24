using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace SiteNewsApi.Redis
{
    public class RedisCash : ICache
    {
        private readonly ConnectionMultiplexer redisConnections;

        public RedisCash()
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints =
                    {
                        { "https://localhost:44396",443 }
                    },
                AbortOnConnectFail = false,
            };
            this.redisConnections = ConnectionMultiplexer.Connect(configurationOptions);
        }
        public void Set<T>(string key, T objectToCache) where T : class
        {
            var db = this.redisConnections.GetDatabase();
            db.StringSet(key, JsonConvert.SerializeObject(objectToCache
                        , Formatting.Indented
                        , new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        }));
        }


        public T Get<T>(string key) where T : class
        {
            var db = this.redisConnections.GetDatabase();
            var redisObject = db.StringGet(key);
            if (redisObject.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(redisObject
                        , new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        });
            }
            else
            {
                return (T)null;
            }
        }

        public void Delete(string key)
        {
            redisConnections.GetDatabase().KeyDelete(key);
        }

        //Not Working
        public IEnumerable<T> GetAll<T>() where T : class
        {
            var db = this.redisConnections.GetDatabase();
            var keys =  redisConnections.GetServer("127.0.0.1:6379", "allowAdmin = true").Keys();
            var values = keys.Select(i => db.StringGet(i));
            var result = values.Select(
                val =>
                {
                  return  JsonConvert.DeserializeObject<T>(val
                         , new JsonSerializerSettings
                         {
                             ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                             PreserveReferencesHandling = PreserveReferencesHandling.Objects
                         });
                }
                );
            return result;
        }
    }
}
