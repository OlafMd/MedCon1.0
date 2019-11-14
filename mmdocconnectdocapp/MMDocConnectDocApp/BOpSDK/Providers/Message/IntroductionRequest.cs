using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.Message
{
    [DataContract(Name = "IntroductionRequest")]
    public class IntroductionRequest
    {
        public static readonly string MESSAGE_TYPE = "tenant_introduction.request";

        [DataMember(Name = "requestingTenantCode")]
        public string RequestingTenantCode { get; set; }
        [DataMember(Name = "requestingTenantRealm")]
        public string RequestingTenantRealm { get; set; }
        [DataMember(Name = "requestingTenantId")]
        public string RequestingTenantId { get; set; }
        [DataMember(Name = "requestTitle")]

        public string RequestTitle { get; set; }
        [DataMember(Name = "requestComment")]
        public string RequestComment { get; set; }
        [DataMember(Name = "requestedForTenantCode")]

        public string RequestedForTenantCode { get; set; }
        [DataMember(Name = "approvingTenantId")]
        public string ApprovingTenantId { get; set; }
        [DataMember(Name = "approvingTenantRealm")]
        public string ApprovingTenantRealm { get; set; }

        [DataMember(Name = "autoApproved")]
        public bool IsAutoApproved { get; set; }


        public string ToPayload()
        {
            return JsonConvert.SerializeObject(this);            
        }
    }
}
