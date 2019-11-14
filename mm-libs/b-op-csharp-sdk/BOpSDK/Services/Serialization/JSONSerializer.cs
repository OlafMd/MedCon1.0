using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BOp.Services.Serialization
{
    internal class JSONSerializer : RestSharp.Serializers.ISerializer
    {
        public string ContentType
        {
            get
            {
                return "application/json";
            }
            set { }
        }
        public string DateFormat { get; set; }
        public string Namespace { get; set; }
        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            var content = JsonConvert.SerializeObject(obj, new CustomDateTimeConverter());
            return content;
        }
    }

    class CustomDateTimeConverter : IsoDateTimeConverter
    {
        private string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";

        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = DATETIME_FORMAT;
        }
    }
}
