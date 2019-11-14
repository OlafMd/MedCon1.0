using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class RegistrationRequest
    {
        [DataMember(Name="tenant", EmitDefaultValue=false)]
        public Tenant Tenant { get; set; }
        [DataMember(Name = "account")]
        public Account Account { get; set; }
    }

    [DataContract]
    public class Tenant
    {
        [DataMember(Name = "id")]
        public Guid ID { get; set; }
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "type")]
        public ETenantType Type { get; set; }
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
        [DataMember(Name = "testTenant")]
        public bool TestTenant { get; set; }
        [DataMember(Name = "activityDomain")]
        public string ActivityDomain { get; set; }
        [DataMember(Name = "bannerImageId")]
        public Guid BannerImageId { get; set; }
        [DataMember(Name = "bannerImageUrl")]
        public string BannerImageUrl { get; set; }
        [DataMember(Name = "disabled")]
        public bool Disabled { get; set; }
        [DataMember(Name = "disabledReason")]
        public string DisabledReason { get; set; }
        [DataMember(Name = "deactivated")]
        public bool Deactivated { get; set; }
        [DataMember(Name = "deactivationReason")]
        public string DeactivationReason { get; set; }
        [DataMember(Name = "locale")]
        public Locale Locale { get; set; }
        [DataMember(Name = "person")]
        public Person Person { get; set; }
        [DataMember(Name = "organization")]
        public Organization Organization { get; set; }
        [DataMember(Name = "address")]
        public Address Address { get; set; }

        [DataMember(Name = "communicationContacts")]
        public List<CommunicationContact> CommunicationContacts { get; set; }


    }
}
