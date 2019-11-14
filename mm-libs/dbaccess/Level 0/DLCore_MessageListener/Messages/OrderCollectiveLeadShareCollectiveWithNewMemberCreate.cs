using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BOp.Message;
using System.Xml.Serialization;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace DLCore_MessageListener.Messages
{
    [DataContract(Name = "OrderCollectiveLeadShareCollectiveWithNewMemberCreate")]
    public class OrderCollectiveLeadShareCollectiveWithNewMemberCreate
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.order-collective-lead.share-collective-with-new-member.create";

        #region Properties
        public Guid OrderCollectiveID { get; set; }
        public string OrderCollectiveName { get; set; }
        public DateTime OrderCollectiveCreationTimestamp { get; set; }

        [XmlArrayItem(ElementName = "OrderCollectiveMembers")]
        public List<OrderCollectiveMember> OrderCollectiveMembers { get; set; }
        #endregion
    }

    #region HELPER CLASSES
    public class OrderCollectiveMember
    {
        public Guid ID { get; set; }
        public string ITL { get; set; }
        public bool IsLead { get; set; }
        public bool IsNewMember { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public DateTime MemberSince { get; set; }
        public DateTime EndOfMembership { get; set; }
        public string BusinessParticipantITL { get; set; }
        public string BusinessParticipantDisplayName { get; set; }
        public string TenantUniversalContactDetailITL { get; set; }
        public string CompanyInfoUniversalContactDetailITL { get; set; }
        public string UniversalContactDetailsCompanyName { get; set; }
        public string UniversalContactDetailEmail { get; set; }
        public string TenantITL { get; set; }
    }
    #endregion
}
