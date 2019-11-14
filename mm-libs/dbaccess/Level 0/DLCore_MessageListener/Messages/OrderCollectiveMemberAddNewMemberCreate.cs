using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BOp.Message;

namespace DLCore_MessageListener.Messages.Standard
{
    [DataContract(Name = "OrderCollectiveMemberAddNewMemberCreate")]
    public class OrderCollectiveMemberAddNewMemberCreate
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.order-collective-member.add-new-member.create";

        #region Properties
        public Guid NewMemberID { get; set; }
        public Guid NewMemberOrderCollectiveId { get; set; }
        public DateTime NewMemberEndOfMembershipDate { get; set; }
        public DateTime NewMemberMemberSince { get; set; }
        public string NewMemberName { get; set; }
        public string NewMemberEmailAddress { get; set; }
        public Guid NewMemberTenantBussinesParticipantID { get; set; }
        public Guid NewMemberTenantUniversalContactDetailID { get; set; }
        public Guid NewMemberCompanyInfoUniversalContactDetailID { get; set; }
        #endregion
    }
}
