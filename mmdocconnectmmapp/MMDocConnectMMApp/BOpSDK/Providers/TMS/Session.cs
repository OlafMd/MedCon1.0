using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BOp.Services.Rest;

namespace BOp.Providers.TMS
{
    [DataContract]
    public class Session
    {

        [DataMember(Name = "accountId")]
        public Guid AccountID { get; set; }
        [DataMember(Name = "accountType")]
        public int AccountType { get; set; }
        [DataMember(Name = "tenantId")]
        public Guid TenantID { get; set; }
        [DataMember(Name = "tenantIdentificationCode")]
        public string TenantIdentificationCode { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "isPasswordChangeRequired")]
        public Boolean IsPasswordChangeRequired { get; set; }

        [DataMember(Name = "createdOn")]
        public DateTime CreatedOn { get; set; }
        [DataMember(Name = "expiresOn")]
        public DateTime ExpiresOn { get; set; }
        [DataMember(Name = "sessionToken")]
        public string SessionToken { get; set; }
    }

    public class SessionFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Boolean Active { get; set; }

        //public void ApplyFilterToJSONHttpRequest(JSONRestRequest request)
        //{
        //    if (From != null)
        //    {
        //        request.AddParameter("from", From.ToString("dd/MM/yyyy"));
        //    }
        //    if (To != null)
        //    {
        //        request.AddParameter("from", From.ToString("dd/MM/yyyy"));
        //    }
        //    if (Active != null)
        //    {
        //        request.AddParameter("active", Active);
        //    }
        //}
    }
}
