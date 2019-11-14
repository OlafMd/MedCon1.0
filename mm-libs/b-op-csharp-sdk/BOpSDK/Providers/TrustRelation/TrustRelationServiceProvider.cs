using BOp.Services.Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    internal class TrustRelationServiceProvider : BaseProvider, ITrustRelationServiceProvider
    {

        public TrustRelationServiceProvider(IRestClient client) : base(client) { }

        public List<TrustRelation> GetAllTrustRelations(Guid tenantID, bool fetchDetails = false, TrustRelationFilter filter = null)
        {
            var url = string.Format("{0}/trust-relations/", tenantID);
            var httpRequest = new JSONRestRequest(url);
            httpRequest.ApplyTrustRelationFilters(filter);
            httpRequest.AddParameter("details", fetchDetails);
            var response = Execute<List<TrustRelation>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public TrustRelation GetTrustRelation(Guid tenantID, Guid trustRelationID)
        {
            var url = string.Format("{0}/trust-relations/{1}", tenantID, trustRelationID);
            var httpRequest = new JSONRestRequest(url);
            var response = Execute<TrustRelation>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public void TerminateTrustRelation(Guid tenantID, Guid trustRelationID, string terminationReason = null)
        {
            var url = string.Format("{0}/trust-relations/{1}", tenantID, trustRelationID);
            var httpRequest = new JSONRestRequest(url, Method.DELETE);
            Dictionary<string, string> message = new Dictionary<string, string> { { "terminationReason", terminationReason } };
            httpRequest.AddBody(message);
            Execute(httpRequest, HttpStatusCode.NoContent);
        }
    }
}
