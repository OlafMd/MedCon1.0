using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Providers.TMS.Requests;
using RestSharp;
using BOp.Services.Rest;
using BOp.Providers.TMS.Responses;
using System.Net;

namespace BOp.Providers.TMS
{
    internal class TenantServiceProvider : BaseProvider, ITenantServiceProvider
    {

        public TenantServiceProvider(IRestClient client)
            : base(client)
        {
        }

        public void CreateTenantAndAccount(RegistrationRequest request)
        {
            //Verify request data!
            var httpRequest = new JSONRestRequest("api/v3/tenants/registration", Method.POST);
            httpRequest.AddBody(request);
            Execute(httpRequest, HttpStatusCode.Created);
        }

        public List<TenantBasicInfo> GetTenantsForSessionToken(string sessionToken)
        {
            var httpRequest = new JSONRestRequest("api/v3/tenants/", Method.GET);
            httpRequest.AddParameter("session", sessionToken);
            var response = Execute<List<TenantBasicInfo>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public List<TenantBasicInfo> GetTenantsForUsernamePassword(SignInRequest request)
        {
            var httpRequest = new JSONRestRequest("api/v3/tenants/search-username", Method.POST);
            httpRequest.AddBody(request);
            var response = Execute<List<TenantBasicInfo>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public List<TenantBasicInfo> GetMultipleTenantsForCredentials(SignInRequest request)
        {
            var httpRequest = new JSONRestRequest("api/v3/tenants/search/", Method.POST);
            httpRequest.AddBody(request);
            var response = Execute<List<TenantBasicInfo>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

    }
}
