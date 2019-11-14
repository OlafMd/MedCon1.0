using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DLCore_MessageListener.Messages
{
    [DataContract(Name = "OrderCollectiveLeadShareNewMemberWithMembersCreate")]
    public class OrderCollectiveLeadShareNewMemberWithMembersCreate
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.order-collective-lead.share-new-member-with-members.create";

        #region Properties
        public Guid NewMemberOrderCollectiveId { get; set; }
        public string NewMemberITL { get; set; }
        public DateTime NewMemberMemberSince { get; set; }
        public DateTime NewMemberEndOfMembership { get; set; }
        public string NewMemberBusinessParticipantITL { get; set; }
        public string NewMemberBusinessParticipantDisplayName { get; set; }
        public string NewMemberTenantUniversalContactDetailITL { get; set; }
        public string NewMemberCompanyInfoUniversalContactDetailITL { get; set; }
        public string NewMemberUniversalContactDetailCompanyName { get; set; }
        public string NewMemberUniversalContactDetailEmail { get; set; }
        public string NewMemberTenantITL { get; set; }
        #endregion
    }
}
