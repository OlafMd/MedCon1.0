using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.PCH
{
    [DataContract]
    public class PrintJobRequest
    {
        [DataMember(Name = "priority")]
        public int Priority { get; set; }
        [DataMember(Name = "type")]
        public EPrintJobType Type { get; set; }
        [DataMember(Name = "template")]
        public string Template { get; set; }
        [DataMember(Name = "localization")]
        public string TemplateLocalization { get; set; }
        [DataMember(Name = "data")]
        public string Data { get; set; }
        [DataMember(Name = "sessionToken")]
        public string SessionToken { get; set; }
        [DataMember(Name = "requestedByAccountId")]
        public Guid RequestedByAccountID { get; set; }
        [DataMember(Name = "requestedByTenantId")]
        public Guid RequestedByTenantID { get; set; }
        [DataMember(Name = "logicalPrinters")]
        public List<string> LogicalPrinters { get; set; }
        [DataMember(Name = "physicalPrinters")]
        public List<string> PhysicalPrinters { get; set; }       

        [DataMember(Name="localizationFileName")]
        public string LocalizationFileName { get; set; }
    }

    [DataContract]
    public class PrintPreviewRequest
    {
        [DataMember(Name = "template")]
        public string Template { get; set; }
        [DataMember(Name = "localization")]
        public string TemplateLocalization { get; set; }
        [DataMember(Name = "data")]
        public string Data { get; set; }
        [DataMember(Name = "requestedByAccountId")]
        public Guid RequestedByAccountID { get; set; }
        [DataMember(Name = "requestedByTenantId")]
        public Guid RequestedByTenantID { get; set; }
        [DataMember(Name = "sessionToken")]
        public string SessionToken { get; set; }
    }

    [DataContract]
    public class ResponseMessage
    {
        [DataMember(Name = "printJobId")]
        public Guid PrintJobId { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
