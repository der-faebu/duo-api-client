using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DuoApiClientGUI.Helpers
{
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // T is Dictionary<string, object>
            // but we want List<Dictionary<string, object>>

            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                JArray jArray = (JArray) token;
                var myList = jArray.ToObject<List<T>>();
                return myList;
            }

            var obj = token.ToObject<T>();
            var list = new List<T>();
            list.Add(obj);
            return list;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
