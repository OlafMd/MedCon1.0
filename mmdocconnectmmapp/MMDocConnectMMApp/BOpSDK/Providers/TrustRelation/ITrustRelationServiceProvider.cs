using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    public interface ITrustRelationServiceProvider
    {
        List<TrustRelation> GetAllTrustRelations(Guid tenantID, bool fetchDetails = false, TrustRelationFilter filter = null);
        TrustRelation GetTrustRelation(Guid tenantID, Guid trustRelationID);
        void TerminateTrustRelation(Guid tenantID, Guid trustRelationID, string terminationReason = null);
    }
}
