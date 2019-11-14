using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TrustRelation
{

    [DataContract]
    public class TrustRelationRequest : ITrustRelationRequestWithInvitation, ITrustRelationRequestWithInitiatingTenant
    {
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public Guid Code { get; set; }
        [DataMember(Name = "fromTenant")]
        public Guid FromTenant { get; set; }
        [DataMember(Name = "fromRealm", EmitDefaultValue = false)]
        public Guid FromRealm { get; set; }
        [DataMember(Name = "toTenant")]
        public Guid ToTenant { get; set; }
        [DataMember(Name = "initiatedFromTenant")]
        public Nullable<Guid> InitiatedFromTenant { get; set; }
        [DataMember(Name = "initiatedFromRealm", EmitDefaultValue = false)]
        public Nullable<Guid> InitiatedFromRealm { get; set; }
        [DataMember(Name = "toRealm", EmitDefaultValue = false)]
        public Guid ToRealm { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "requestStatus", EmitDefaultValue = false)]
        public TrustRequestStatus Status { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "languageIso6391")]
        public string RequestLanguage { get; set; }
        [DataMember(Name = "offeredTrustTypes")]
        public List<TrustRelationTypeInfo> OfferedTrustTypes { get; set; }
        [DataMember(Name = "requestedTrustTypes")]
        public List<TrustRelationTypeInfo> RequestedTrustTypes { get; set; }
        [DataMember(Name = "requestDate", EmitDefaultValue = false)]
        public Nullable<DateTime> RequestDate { get; set; }
        [DataMember(Name = "autoApproved")]
        public Boolean? IsAutoApproved { get; set; }
        [DataMember(Name = "trustTypeGroups")]
        public List<String> RequiredTrustTypeGroups { get; set; }
        [DataMember(Name = "invitationCode")]
        public string InvitationCode { get; set; }

        

        public TrustRelationRequest()
        {
            IsAutoApproved = false;
            OfferedTrustTypes = new List<TrustRelationTypeInfo>();
            RequestedTrustTypes = new List<TrustRelationTypeInfo>();
            RequiredTrustTypeGroups = new List<string>();
        }
    

        public void AddOfferedTrustRelationType(Guid trustRelationTypeId)
        {
            if (OfferedTrustTypes.FirstOrDefault(x => x.ID == trustRelationTypeId) == null)
            {
                OfferedTrustTypes.Add(new TrustRelationTypeInfo()
                {
                    ID = trustRelationTypeId
                });
            }
        }

        public void AddRequestedTrustRelationType(Guid trustRelationTypeId)
        {
            if (RequestedTrustTypes.FirstOrDefault(x => x.ID == trustRelationTypeId) == null)
            {
                RequestedTrustTypes.Add(new TrustRelationTypeInfo()
                {
                    ID = trustRelationTypeId
                });
            }
        }

   
        public override bool Equals(object obj)
        {
            var item = obj as TrustRelationRequest;
            if (item == null) return false;


            return item.Code.Equals(this.Code) &&
                item.FromRealm.Equals(this.FromRealm) &&
                item.FromTenant.Equals(this.FromTenant) &&
                item.InitiatedFromTenant.Equals(this.InitiatedFromTenant) &&
                item.InitiatedFromRealm.Equals(this.InitiatedFromRealm) &&
                item.IsAutoApproved.Equals(this.IsAutoApproved) &&
                item.Message == this.Message &&
                item.RequestLanguage == this.RequestLanguage &&
                item.Status.Equals(this.Status) &&
                item.Title.Equals(this.Title) &&
                item.ToRealm.Equals(this.ToRealm) &&
                item.ToTenant.Equals(this.ToTenant);
        }

    }

    public interface ITrustRelationRequestWithInvitation : IBasicTrustRelationRequest
    {
        string InvitationCode { get; set; }
    }
    public interface ITrustRelationRequestWithInitiatingTenant : IBasicTrustRelationRequest
    {
        Nullable<Guid> InitiatedFromTenant { get; set; }
    }

    public interface IBasicTrustRelationRequest
    {
        Guid Code { get; set; }
        Guid FromTenant { get; set; }
        string Message { get; set; }
        List<TrustRelationTypeInfo> OfferedTrustTypes { get; }
        List<TrustRelationTypeInfo> RequestedTrustTypes { get; }
        string RequestLanguage { get; set; }
        string Title { get; set; }
        Guid ToTenant { get; set; }
        Nullable<DateTime> RequestDate { get; set; }
        List<String> RequiredTrustTypeGroups { get; }
        TrustRequestStatus Status { get; set; }

        void AddOfferedTrustRelationType(Guid trustRelationTypeId);
        void AddRequestedTrustRelationType(Guid trustRelationTypeId);
    }
    public class TrustRelationRequestFilter
    {
        public static TrustRelationRequestFilter Pending
        {
            get
            {
                var filter = new TrustRelationRequestFilter();
                filter.RequestStatus = TrustRequestStatus.Pending;
                return filter;
            }
        }

        public TrustRelationRequestFilter()
        {
            RequestStatus = TrustRequestStatus.None;
        }

        public TrustRequestStatus RequestStatus { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

    }


}
