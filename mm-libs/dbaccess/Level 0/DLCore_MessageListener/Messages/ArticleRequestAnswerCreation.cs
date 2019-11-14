using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using BOp.Message;

namespace Realm.APODemand
{
    [DataContract(Name = "ArticleRequestCreation")]
    public class ArticleRequestAnswerCreation
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.article-request-creation.answer";

        #region Properties

        public Guid CreatedBy_TenantID { get; set; }
        public Guid IntendedFor_TenantID { get; set; }

        public String ArticleRequestITL { get; set; }
        public String RequestAnswer { get; set; }
        public DateTime AnswerSent_Date { get; set; }
        public Guid AnswerSent_By_BusinessParticipant_RefID { get; set; }

        [XmlArrayItem(ElementName = "Product")]
        public List<Product> Products { get; set; }

        #endregion

        public ArticleRequestAnswerCreation()
        {
            Products = new List<Product>();
        }

        public string ToPayload()
        {
            return SerializationUtils.SerializeObject<ArticleRequestAnswerCreation>(this);
        } 

        public static ArticleRequestAnswerCreation FromPayload(string payload)
        {
            var decodedPayload = System.Web.HttpUtility.UrlDecode(payload);

            return SerializationUtils.ParseFromPayload<ArticleRequestAnswerCreation>(decodedPayload);
        }
    
    }

    public class Product
    {
        public String Product_ITL { get; set; }
        public String Name { get; set; }
        public String PZN { get; set; }
        public String Description { get; set; }
    }
}
