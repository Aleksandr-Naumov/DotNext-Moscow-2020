using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HightechAngular.Orders.Services
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            //session.SetString(key, JsonSerializer.Serialize(value));
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            //return value == null ? default : JsonSerializer.Deserialize<T>(value);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}