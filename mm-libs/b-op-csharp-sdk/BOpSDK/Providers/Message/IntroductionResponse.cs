using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.Message
{
    [DataContract(Name = "IntroductionResponse")]
    public class IntroductionResponse 
    {
        public static readonly string MESSAGE_TYPE = "tenant_introduction.response";

        [DataMember(Name = "introductionRequestITL")]
        public string IntroductionRequestITL { get; set; }
        [DataMember(Name = "approved")]
        public bool IsApproved { get; set; }
        [DataMember(Name = "rejected")]
        public bool IsRejected { get; set; }
        [DataMember(Name = "permanentlyRejected")]
        public bool IsPermanentyRejected { get; set; }
        [DataMember(Name = "rejectedReason")]
        public string RejectedReason { get; set; }
        [DataMember(Name = "approvingAccountId")]
        public string ApprovingAccountID { get; set; }
        [DataMember(Name = "requestingTenantCode")]
        public string RequestingTenantCode { get; set; }
        [DataMember(Name = "approvingTenantId")]
        public string ApprovingTenantID { get; set; }
        [DataMember(Name = "approvingTenantRealm")]
        public string ApprovingTenantRealm { get; set; }


        public string ToPayload()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
