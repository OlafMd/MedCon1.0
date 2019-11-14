using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    public interface ITrustRelationTypeServiceProvider
    {
        List<TrustRelationType> GetAllTrustRelationTypes(Guid? applicationID = null);
        TrustRelationType GetTrustRelationType(Guid trustRelationTypeID);
        void SaveTrustRelationType(TrustRelationType trustRelationType);
        void RemoveTrustRelationType(Guid trustRelationTypeID);


        List<TrustRelationTypeGroup> GetAllTrustRelationTypeGroups(Guid? applicationID = null);
        TrustRelationTypeGroup GetTrustRelationGroup(string trustRelationTypeGroupCode);
        void SaveTrustRelationTypeGroup(TrustRelationTypeGroup trustRelationTypeGroup);
        void RemoveTrustRelationTypeGroup(string trustRelationTypeGroupCode);

    }
}
