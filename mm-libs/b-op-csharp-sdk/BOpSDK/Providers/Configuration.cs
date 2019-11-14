using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Authenticators;

namespace BOp.Providers
{
    public class Configuration
    {
        public Uri BaseUrl { get; set; }
        public IAuthenticator Authenticator { get; set; }
    }
}
