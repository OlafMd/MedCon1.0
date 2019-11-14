using BOp.Services.Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    internal class TrustRelationRequestServiceProvider : BaseProvider, ITrustRelationRequestServiceProvider
    {
        public TrustRelationRequestServiceProvider(IRestClient client) : base(client) { }

        public List<TrustRelationRequest> GetAllIncomingTrustRelationRequests(Guid tenantID, TrustRelationRequestFilter filter = null)
        {
            var url = string.Format("{0}/trust-relations/incoming-requests", tenantID);
            var httpRequest = new JSONRestRequest(url);
            httpRequest.ApplyTrustRelationRequestFilters(filter);
            var response = Execute<List<TrustRelationRequest>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public TrustRelationRequest GetIncomingTrustRelationRequest(Guid tenantID, Guid trustRelationRequestID)
        {
            var url = string.Format("{0}/trust-relations/incoming-requests/{1}", tenantID, trustRelationRequestID);
            var httpRequest = new JSONRestRequest(url);
            var response = Execute<TrustRelationRequest>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public void AcceptIncomingTrustRelationRequest(Guid tenantID, Guid incomingTrustRelationRequestID, string responseMessage)
        {
            var url = string.Format("{0}/trust-relations/incoming-requests", tenantID);
            var httpRequest = new JSONRestRequest(url, Method.POST);
            Dictionary<string, object> responseObject = new Dictionary<string, object>(){
                { "accepted", true},
                { "externalId", incomingTrustRelationRequestID},
                { "responseMessage", responseMessage}
            };
            httpRequest.AddBody(responseObject);
            Execute(httpRequest, HttpStatusCode.NoContent);
        }

        public List<TrustRelationRequest> GetAllOutgoingTrustRelationRequests(Guid tenantID, TrustRelationRequestFilter filter = null)
        {
            var url = string.Format("{0}/trust-relations/outgoing-requests", tenantID);
            var httpRequest = new JSONRestRequest(url);
            httpRequest.ApplyTrustRelationRequestFilters(filter);
            var response = Execute<List<TrustRelationRequest>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public TrustRelationRequest GetOutgoingTrustRelationRequest(Guid tenantID, Guid trustRelationRequestID)
        {
            var url = string.Format("{0}/trust-relations/outgoing-requests/{1}", tenantID, trustRelationRequestID);
            var httpRequest = new JSONRestRequest(url);
            var response = Execute<TrustRelationRequest>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public void CancelOutgoingTrustRelationRequest(Guid tenantID, Guid outgoingTrustRelationRequestID)
        {
            var url = string.Format("{0}/trust-relations/outgoing-requests/{1}", tenantID, outgoingTrustRelationRequestID);
            var httpRequest = new JSONRestRequest(url, Method.DELETE);
            Execute(httpRequest, HttpStatusCode.NoContent);
        }

        public List<TrustRelationRequest> GetAllInitiatedTrustRelationRequests(Guid tenantID, TrustRelationRequestFilter filter = null)
        {
            var url = string.Format("{0}/trust-relations/initiated-requests", tenantID);
            var httpRequest = new JSONRestRequest(url);
            httpRequest.ApplyTrustRelationRequestFilters(filter);
            var response = Execute<List<TrustRelationRequest>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public TrustRelationRequest GetInitiatedTrustRelationRequest(Guid tenantID, Guid trustRelationRequestID)
        {
            var url = string.Format("{0}/trust-relations/initiated-requests/{1}", tenantID, trustRelationRequestID);
            var httpRequest = new JSONRestRequest(url);
            var response = Execute<TrustRelationRequest>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public TrustRelationRequest SendTrustRelationRequest(TrustRelationRequest trustRelationRequest, bool autoApprove = false)
        {
            trustRelationRequest.IsAutoApproved = autoApprove;
            if (trustRelationRequest.InitiatedFromTenant == null)
            {
                trustRelationRequest.InitiatedFromTenant = trustRelationRequest.FromTenant;
            }

            var url = string.Format("{0}/trust-relations/outgoing-requests/", trustRelationRequest.InitiatedFromTenant);
            var httpRequest = new JSONRestRequest(url, Method.POST);
            httpRequest.AddBody(trustRelationRequest);
            var creationResponse = Execute<Dictionary<String, String>>(httpRequest, HttpStatusCode.Created);
            Guid requestCode = Guid.Parse(creationResponse.Data["code"]);

            var createdRequest = GetInitiatedTrustRelationRequest(trustRelationRequest.InitiatedFromTenant.GetValueOrDefault(), requestCode);
            return createdRequest;
        }

        public void RejectIncomingTrustRelationRequest(Guid tenantID, Guid incomingTrustRelationRequestID, string rejectionReason)
        {
            var url = string.Format("{0}/trust-relations/incoming-requests/{1}", tenantID, incomingTrustRelationRequestID);
            var httpRequest = new JSONRestRequest(url, Method.DELETE);
            Dictionary<string, string> message = new Dictionary<string, string> { { "message", rejectionReason } };
            httpRequest.AddBody(message);
            var response = Execute(httpRequest, HttpStatusCode.NoContent);
        }
    }
}
