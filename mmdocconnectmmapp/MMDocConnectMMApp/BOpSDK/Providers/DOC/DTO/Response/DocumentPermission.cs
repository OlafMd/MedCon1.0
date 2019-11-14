using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.DOC
{
    [DataContract]
    public class DocumentPermission : IDocumentPermissionRequest
    {
        [DataMember(Name = "id")]
        public Guid ID { get; set; }
        [DataMember(Name = "accountId")]
        public Guid AccountID { get; set; }
        [DataMember(Name = "tenantId")]
        public Guid TenantID { get; set; }
    }
    public interface IDocumentPermissionRequest
    {
        Guid AccountID { get; set; }
        Guid TenantID { get; set; }
    }
}
