using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Case.Manipulation
{
    public static class Add_New_Oct
    {
        private static string elasticType = "oct";

        public static void Import_Oct_Data_to_ElasticDB(IEnumerable<Oct_Model> octs, string indexName)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            bool index_exists = Elastic_Utils.IfIndexOrTypeExists(indexName, connection);

            if (!index_exists)
            {
                //create new index
                string settings = Elastic_Utils.BuildIndexSettings();
                connection.Put(indexName, settings);
            }

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(String.Format("{0}/{1}", indexName, elasticType), connection);

            if (!type_exists)
            {
                string json_oct_mapping = Elastic_Utils.BuildElasticMapping<Oct_Model>(elasticType, new List<ElasticMappingConfigObject>() 
                { 
                    new ElasticMappingConfigObject { analyzerName = "not_analyzed", fieldName = "id" },
                    new ElasticMappingConfigObject { analyzerName = "autocomplete", fieldName = "treatment_doctor_lanr", searchAnalyzer = "keyword" },
                    new ElasticMappingConfigObject { analyzerName = "autocomplete", fieldName = "oct_doctor_lanr", searchAnalyzer = "keyword" },
                    new ElasticMappingConfigObject { analyzerName = "autocomplete", fieldName = "treatment_doctor_practice_bsnr", searchAnalyzer = "keyword" },
                    new ElasticMappingConfigObject { analyzerName = "autocomplete", fieldName = "patient_insurance_number", searchAnalyzer = "keyword" },
                });

                connection.Put(new PutMappingCommand(indexName, elasticType), json_oct_mapping);
            }

            Elastic_Utils.BulkType<Oct_Model>(octs.ToList(), connection, serializer, indexName, elasticType);
        }
    }
}
