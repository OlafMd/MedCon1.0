using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

namespace BOp.Services.Auth
{
    internal class DigestAuthentication : IAuthenticator
    {
        private string _username;
        private string _password;

        public DigestAuthentication(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.Credentials = new NetworkCredential(_username, _password);
        }
    }
}
