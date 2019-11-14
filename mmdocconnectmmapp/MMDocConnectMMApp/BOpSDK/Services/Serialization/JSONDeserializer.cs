using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Newtonsoft.Json;

namespace BOp.Services.Serialization
{
    internal class JSONDeserializer : RestSharp.Deserializers.IDeserializer
    {
        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            if (string.IsNullOrEmpty(response.Content))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
