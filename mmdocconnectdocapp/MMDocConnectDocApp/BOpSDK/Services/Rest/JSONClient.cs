using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Services.Serialization;
using RestSharp.Authenticators;

namespace BOp.Services.Rest
{
    internal class JSONClient : RestSharp.RestClient
    {

        public JSONClient(Uri baseUrl, IAuthenticator authenticator)
            : base(baseUrl)
        {
            var deserializer = new JSONDeserializer();
            this.AddHandler("application/json", deserializer);
            this.AddHandler("text/json", deserializer);
            this.AddHandler("text/x-json", deserializer);
            this.AddHandler("*", deserializer);

            this.Authenticator = authenticator;
        }
    }
}
