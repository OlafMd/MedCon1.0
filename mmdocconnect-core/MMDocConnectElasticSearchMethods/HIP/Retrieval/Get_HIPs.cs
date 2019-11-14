using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.HIP.Retrieval
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
        public static IEnumerable<Practice_Doctor_Last_Used_Model> Get_LastUsed_HIPs(string index_name, string practice_id)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            var elastic_type = "last_used_hips_" + practice_id;
            if (Elastic_Utils.IfIndexOrTypeExists(index_name, connection) && Elastic_Utils.IfIndexOrTypeExists(index_name + "/" + elastic_type, connection))
            {
                var query = new QueryBuilder<Practice_Doctor_Last_Used_Model>().From(0).Size(4).Sort(s => s.Field("date_of_use", PlainElastic.Net.SortDirection.desc));
                return serializer.ToSearchResult<Practice_Doctor_Last_Used_Model>(connection.Post(Commands.Search(index_name, elastic_type), query.BuildBeautified())).Documents;
            }

            return new List<Practice_Doctor_Last_Used_Model>();
        }
    }
}
