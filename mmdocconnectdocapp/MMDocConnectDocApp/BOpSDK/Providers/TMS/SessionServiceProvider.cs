using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using BOp.Services.Serialization;
using RestSharp;
using BOp.Utility;
using BOp.Config;
using BOp.Services.Rest;
using BOp.Services;
using BOp.Providers.TMS.Requests;
using System.Runtime.Caching;
using BOp.Exceptions;

namespace BOp.Providers.TMS
{
    internal class SessionServiceProvider : BaseProvider, ISessionServiceProvider
    {
        private static int _sessionValidationCacheDuration = 4;
        private static int _sessionExistanceCacheDuration = 4;
        private static int _sessionInformationCacheDuration = 60;
        private ObjectCache _SDKCache;

        public SessionServiceProvider(IRestClient client, ObjectCache pSDKCache)
            : base(client)
        {
            _SDKCache = pSDKCache;
        }

        public Session SignIn(SignInRequest request)
        {
            var httpRequest = new JSONRestRequest("api/v3/sessions/", Method.POST);
            httpRequest.AddBody(request);
            var signInResponse = Execute(httpRequest, HttpStatusCode.Created);

            var location = (string)signInResponse.Headers.FirstOrDefault(x => x.Name == "Location").Value;
            var sessionToken = location.Split('/').Last();
            return GetSessionInformation(sessionToken);
        }

        public Session SignInWithoutPasswordHashing(string email, string password)
        {
            var request = new SignInRequest()
            {
                Email = email,
                Password = password,
                UseDefaultTenant = true
            };
            return SignIn(request);
        }


        public Session SignIn(string email, string password)
        {
            var request = new SignInRequest()
            {
                Email = email,
                Password = HashingUtil.CalculateMD5Hash(password),
                UseDefaultTenant = true
            };
            return SignIn(request);
        }

        public Session SignIn(string email, string password, Guid tenantID)
        {

            var request = new SignInRequest()
            {
                Email = email,
                Password = HashingUtil.CalculateMD5Hash(password),
                TenantID = tenantID
            };
            return SignIn(request);
        }


        public void SignOut(string token)
        {
            var httpRequest = new JSONRestRequest("/api/v3/sessions/{token}", Method.DELETE);
            httpRequest.AddUrlSegment("token", token);

            var response = Execute(httpRequest, HttpStatusCode.OK);
        }

        public bool CheckIfSessionExists(string token)
        {
            var httpRequest = new JSONRestRequest("/api/v3/sessions/{token}", Method.HEAD);
            httpRequest.AddUrlSegment("token", token);

            if (!_SDKCache.Contains("bop.sdk.session-exists." + token))
            {
                var response = _client.Execute(httpRequest);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _SDKCache.Set("bop.sdk.session-exists." + token, true, DateTimeOffset.Now.AddSeconds(_sessionExistanceCacheDuration));
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return true;
            }
        }

        public Session GetSessionInformation(string token)
        {
            if (CheckIfSessionIsValid(token))
            {
                var httpRequest = new JSONRestRequest("/api/v3/sessions/{token}", Method.GET);
                httpRequest.AddUrlSegment("token", token);

                var cachedSessionInformation = _SDKCache["bop.sdk.session-information." + token] as Session;
                if (cachedSessionInformation == null)
                {
                    var response = Execute<Session>(httpRequest, HttpStatusCode.OK);
                    var session = response.Data;
                    _SDKCache.Set("bop.sdk.session-information." + token, session, DateTimeOffset.Now.AddSeconds(_sessionInformationCacheDuration));
                    return session;
                }
                else
                {
                    return cachedSessionInformation;
                }
            }
        
            throw new SDKServiceException("Session not valid!", new ServiceErrror());
        }

        public bool CheckIfSessionIsValid(string token)
        {
            var httpRequest = new JSONRestRequest("/api/v3/sessions/{token}/verify", Method.POST);
            httpRequest.AddUrlSegment("token", token);

            if (!_SDKCache.Contains("bop.sdk.session-valid." + token))
            {
                var response = _client.Execute(httpRequest);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    _SDKCache.Set("bop.sdk.session-valid." + token, true, DateTimeOffset.Now.AddSeconds(_sessionValidationCacheDuration));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public Session SwitchTenant(SwitchTenantRequest request, string token)
        {
            var httpRequest = new JSONRestRequest("/api/v3/sessions/{token}/switch", Method.POST);
            httpRequest.AddUrlSegment("token", token);
            httpRequest.AddBody(request);
            var response = Execute(httpRequest, HttpStatusCode.NoContent);
            var location = response.Headers.FirstOrDefault(x => x.Name == "Location").Value as string;
            var sessionToken = location.Split('/').Last();
            return GetSessionInformation(sessionToken);
        }

        public List<Session> GetAccountSessions(Guid tenantID, Guid accountID, SessionFilter filter = null)
        {
            var httpRequest = new JSONRestRequest("/api/v3/sessions/");
            httpRequest.ApplySessionFilters(filter);
            var response = Execute<List<Session>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }
        public string GenerateTemporarySession(TemporaryTokenRequest request)
        {
            var httpRequest = new JSONRestRequest("/api/v3/sessions/create-temporary-token", Method.POST);
            httpRequest.AddBody(request);
            var response = Execute(httpRequest, HttpStatusCode.Created);
            var location = response.Headers.FirstOrDefault(x => x.Name == "Location").Value as string;
            var sessionToken = location.Split('/').Last();
            return sessionToken;
        }

        public bool CheckIfCredentialsAreValid(SignInRequest request)
        {
            var httpRequest = new JSONRestRequest("/api/v3/sessions/sing-in-check", Method.POST);
            httpRequest.AddBody(request);

            try
            {
                var response = Execute(httpRequest, HttpStatusCode.OK);
                return response.Content == "true";
            }
            catch
            {
                return false;
            }

        }
    }
}
