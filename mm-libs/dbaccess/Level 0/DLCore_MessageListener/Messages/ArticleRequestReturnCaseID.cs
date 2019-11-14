using System;
using System.Runtime.Serialization;
using BOp.Message;

namespace Realm.APODemand
{
    [DataContract(Name = "ArticleRequestReturnCaseID")]
    public class ArticleRequestReturnCaseID
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.article-request-return.case-id";

        #region Properties

        public Guid CreatedBy_TenantID { get; set; }
        public Guid IntendedFor_TenantID { get; set; }

        public String ArticleRequestITL { get; set; }
        public String CaseID { get; set; }

        #endregion

        public string ToPayload()
        {
            return SerializationUtils.SerializeObject<ArticleRequestReturnCaseID>(this);
        }

        public static ArticleRequestReturnCaseID FromPayload(string payload)
        {
            var decodedPayload = System.Web.HttpUtility.UrlDecode(payload);

            return SerializationUtils.ParseFromPayload<ArticleRequestReturnCaseID>(decodedPayload);
        }
    
    }
}
