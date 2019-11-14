using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    public interface ITrustRelationRequestServiceProvider
    {

        List<TrustRelationRequest> GetAllIncomingTrustRelationRequests(Guid tenantID, TrustRelationRequestFilter filter = null);
        TrustRelationRequest GetIncomingTrustRelationRequest(Guid tenantID, Guid trustRelationRequestID);
        void AcceptIncomingTrustRelationRequest(Guid tenantID, Guid incomingTrustRelationRequestID, string responseMessage);
        void RejectIncomingTrustRelationRequest(Guid tenantID, Guid incomingTrustRelationRequestID, string rejectionReason);

        List<TrustRelationRequest> GetAllOutgoingTrustRelationRequests(Guid tenantID, TrustRelationRequestFilter filter = null);
        TrustRelationRequest GetOutgoingTrustRelationRequest(Guid tenantId, Guid trustRelationRequestID);
        void CancelOutgoingTrustRelationRequest(Guid tenantID, Guid outgoingTrustRelationRequestID);
        

        List<TrustRelationRequest> GetAllInitiatedTrustRelationRequests(Guid tenantID, TrustRelationRequestFilter filter = null);

        TrustRelationRequest GetInitiatedTrustRelationRequest(Guid tenantID, Guid trustRelationRequestID);


        TrustRelationRequest SendTrustRelationRequest(TrustRelationRequest trustRelationOutboundRequest, bool autoApprove = false);


    }
}
