using CSV2Core.SessionSecurity;
using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.HIP.Retrieval
{
    public class Get_Diagnoses
    {
        private static string elasticType = "diagnose";
        private static string indexName = "external_data";
        public static IEnumerable<Diagnose_Model> Get_Diagnoses_for_Search_Criteria(string search_criteria)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            if (Elastic_Utils.IfIndexOrTypeExists(indexName, connection) && Elastic_Utils.IfIndexOrTypeExists(indexName + "/" + elasticType, connection))
            {
                return serializer.ToSearchResult<Diagnose_Model>(connection.Post(Commands.Search(indexName, elasticType), QueryBuilderDiagnose.BuildGetDiagnosesQuerySearchAsYouTupe(search_criteria))).Documents;
            }

            return new List<Diagnose_Model>();
        }
    }
}
