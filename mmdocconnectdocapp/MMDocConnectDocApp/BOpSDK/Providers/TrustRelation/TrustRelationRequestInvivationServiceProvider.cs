using BOp.Services.Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace BOp.Providers.TrustRelation
{
    internal class TrustRelationRequestInvivationServiceProvider : BaseProvider, ITrustRelationRequestInvitationServiceProvider
    {
        public TrustRelationRequestInvivationServiceProvider(IRestClient client) : base(client) { }

        public List<TrustRelationRequestInvitation> GetAllTrustRelationRequestInvitations(Guid tenantID, InvitationStatus? status = null)
        {
            var url = string.Format("trust-relation-request-invitations/{0}{1}", 
                tenantID, 
                status == null ? string.Empty : string.Format("?status={0}", (int)status));
            var httpRequest = new JSONRestRequest(url);
            var response = Execute<List<TrustRelationRequestInvitation>>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public TrustRelationRequestInvitation GetTrustRelationRequestInvitation(string invitationCode, Guid tenantID)
        {
            var url = string.Format("trust-relation-request-invitations/{0}/{1}", tenantID, invitationCode);
            var httpRequest = new JSONRestRequest(url);
            var response = Execute<TrustRelationRequestInvitation>(httpRequest, HttpStatusCode.OK);
            return response.Data;
        }

        public void SaveTrustRelationRequestInvitation(TrustRelationRequestInvitation trustRelationInvitation, Guid tenantID)
        {
            var url = string.Format("trust-relation-request-invitations/{0}", tenantID);
            var httpRequest = new JSONRestRequest(url, Method.POST);
            httpRequest.AddBody(trustRelationInvitation);
            Execute(httpRequest, HttpStatusCode.Created);
        }

        public void RemoveTrustRelationRequestInvitation(string invitationCode, Guid tenantID)
        {
            var url = string.Format("trust-relation-request-invitations/{0}/{1}", tenantID, invitationCode);
            var httpRequest = new JSONRestRequest(url, Method.DELETE);
            Execute(httpRequest, HttpStatusCode.NoContent);
        }

        public void RevokeTrustRelationRequestInvitation(string invitationCode, Guid tenantID)
        {
            var url = string.Format("trust-relation-request-invitations/{0}/{1}/revoke", tenantID, invitationCode);
            var httpRequest = new JSONRestRequest(url, Method.POST);
            var response = Execute(httpRequest, HttpStatusCode.NoContent);
        }
    }
}
