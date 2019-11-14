using DataImporter.Models;
using MMDocConnectElasticSearchMethods;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System.Collections.Generic;

namespace DataImporter.Elastic_Methods.HIP.Retrieval
{
    public class Get_HIPs
    {
        private static string elasticType = "hip";
        private static string indexName = "external_data";
        public static IEnumerable<HIP_Model> Get_HIPs_for_Search_Criteria(string search_criteria)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            if (Elastic_Utils.IfIndexOrTypeExists(indexName, connection) && Elastic_Utils.IfIndexOrTypeExists(indexName + "/" + elasticType, connection))
            {                
                return serializer.ToSearchResult<HIP_Model>(connection.Post(Commands.Search(indexName, elasticType), QueryBuilderHIP.BuildGetHIPQuerySearchAsYouTupe(search_criteria))).Documents;
            }

            return new List<HIP_Model>();
        }
    }
}
