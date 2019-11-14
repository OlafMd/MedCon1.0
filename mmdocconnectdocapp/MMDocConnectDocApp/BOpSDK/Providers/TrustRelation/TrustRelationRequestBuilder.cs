using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.TrustRelation
{
    public class TrustRelationRequestBuilder
    {
        private TrustRelationRequest Request;

        public TrustRelationRequestBuilder()
        {
            Request = new TrustRelationRequest();
            Request.OfferedTrustTypes = new List<TrustRelationTypeInfo>();
            Request.RequestedTrustTypes = new List<TrustRelationTypeInfo>();
            Request.RequiredTrustTypeGroups = new List<string>();
        }

        public TrustRelationRequestBuilder SetRequestCode(Guid code)
        {
            Request.Code = code;
            return this;
        }
        public TrustRelationRequestBuilder SetInvitationCode(string invitaitonCode)
        {
            Request.InvitationCode = invitaitonCode;
            return this;
        }
        public TrustRelationRequestBuilder SetTitle(string title)
        {
            Request.Title = title;
            return this;
        }
        public TrustRelationRequestBuilder SetMessage(string message)
        {
            Request.Message = message;
            return this;
        }
        public TrustRelationRequestBuilder SetLanguageISO(string language)
        {
            Request.RequestLanguage = language;
            return this;
        }

        public TrustRelationRequestBuilder SetAutoApproved(bool autoApproved)
        {
            Request.IsAutoApproved = autoApproved;
            return this;
        }

        public TrustRelationRequestBuilder SetFromTenant(Guid tenant)
        {
            Request.FromTenant = tenant;
            return this;
        }
        public TrustRelationRequestBuilder SetToTenant(Guid tenant)
        {
            Request.ToTenant = tenant;
            return this;
        }
        public TrustRelationRequestBuilder SetInitiatedFromTenant(Guid tenant)
        {
            Request.InitiatedFromTenant = tenant;
            return this;
        }

        public TrustRelationRequestBuilder AddOfferedTrustTypes(Guid[] trustRelationTypeIDs)
        {
            foreach (var trustRelationTypeID in trustRelationTypeIDs)
            {
                this.AppendOfferedTrustType(trustRelationTypeID);
            }
            return this;
        }
        public TrustRelationRequestBuilder AddOfferedTrustType(Guid trustRelationTypeID)
        {
            this.AppendOfferedTrustType(trustRelationTypeID);
            return this;
        }
        private void AppendOfferedTrustType(Guid trustRelationTypeID)
        {
            if (Request.OfferedTrustTypes.FirstOrDefault(x => x.ID == trustRelationTypeID) == null)
            {
                Request.OfferedTrustTypes.Add(new TrustRelationTypeInfo()
                {
                    ID = trustRelationTypeID
                });
            }
        }
        public TrustRelationRequestBuilder AddRequestedTrustTypes(Guid[] trustRelationTypeIDs)
        {
            foreach (var trustRelationTypeID in trustRelationTypeIDs)
            {
                this.AppendRequestedTrustType(trustRelationTypeID);
            }
            return this;
        }
        public TrustRelationRequestBuilder AddRequestedTrustType(Guid trustRelationTypeID)
        {
            this.AppendRequestedTrustType(trustRelationTypeID);
            return this;
        }

        private void AppendRequestedTrustType(Guid trustRelationTypeID)
        {
            if (Request.RequestedTrustTypes.FirstOrDefault(x => x.ID == trustRelationTypeID) == null)
            {
                Request.RequestedTrustTypes.Add(new TrustRelationTypeInfo()
                {
                    ID = trustRelationTypeID
                });
            }
        }
        public TrustRelationRequestBuilder SetRequiredTrustTypeGroups(List<string> requiredTrustTypeGroups)
        {
            Request.RequiredTrustTypeGroups.AddRange(requiredTrustTypeGroups);
            return this;
        }

        public TrustRelationRequest Build()
        {
            //validate types: no duplicates
            return Request;
        }
    }
}
