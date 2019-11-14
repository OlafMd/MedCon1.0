using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Services.Auth;
using RestSharp.Authenticators;

namespace BOp.Services
{
    interface IAuthenticationProvider
    {
        IAuthenticator GetAuthentication();
    }
}
