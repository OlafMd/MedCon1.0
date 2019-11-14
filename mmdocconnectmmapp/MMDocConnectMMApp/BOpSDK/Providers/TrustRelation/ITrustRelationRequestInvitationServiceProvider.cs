using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    public interface ITrustRelationRequestInvitationServiceProvider
    {
        List<TrustRelationRequestInvitation> GetAllTrustRelationRequestInvitations(Guid tenantID, InvitationStatus? status = null);
        TrustRelationRequestInvitation GetTrustRelationRequestInvitation(string invitationCode, Guid tenantID);
        void SaveTrustRelationRequestInvitation(TrustRelationRequestInvitation trustRelationInvitation, Guid tenantID);
        void RemoveTrustRelationRequestInvitation(string invitationCode, Guid tenantID);
        void RevokeTrustRelationRequestInvitation(string invitationCode, Guid tenantID);

    }
}
