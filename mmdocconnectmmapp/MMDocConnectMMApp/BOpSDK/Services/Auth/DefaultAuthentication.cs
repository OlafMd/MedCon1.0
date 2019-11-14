using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;

namespace BOp.Services.Auth
{
    class DefaultAuthentication : IAuthenticator
    {
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            
        }
    }
}
