using System;
using System.Runtime.Serialization;
using BOp.Message;
namespace Realm.APODemand
{
    [DataContract(Name = "ArticleRequestCreation")]
    public class ArticleRequestCreation
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.article-request-creation.request";

        #region Properties

        public String Person_BusinessParticipantITL { get; set; }
        public String Doctor_FirstName { get; set; }
        public String Doctor_LastName { get; set; }
        
        public Guid CreatedBy_TenantID { get; set; }
        public String Customer_CompanyName { get; set; }

        public Guid IntendedFor_TenantID { get; set; }

        public Guid CMN_BPT_CTM_CatalogProductExtensionRequestID { get; set; }
        public String CatalogITL { get; set; }
        public String Request_Question { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        public string ToPayload()
        {
            return SerializationUtils.SerializeObject<ArticleRequestCreation>(this);
        }

        public static ArticleRequestCreation FromPayload(string payload)
        {
            var decodedPayload = System.Web.HttpUtility.UrlDecode(payload);

            return SerializationUtils.ParseFromPayload<ArticleRequestCreation>(decodedPayload);
        }

    }
}
