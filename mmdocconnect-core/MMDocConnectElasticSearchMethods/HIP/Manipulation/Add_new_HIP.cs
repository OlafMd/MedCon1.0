using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Settlement.Manipulation
{
    public static class Add_New_HIP
    {
        public static string BuildHIPMapping()
        {
            return new MapBuilder<HIP_Model>()
               .RootObject("hip", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                      .String("id", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                   ))
                                   .MultiField("name", mfp => mfp.Fields(f => f
                                      .String("name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                      .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                   )))
                     ).BuildBeautified();
        }


        public static void Import_HIP_Data_to_ElasticDB(List<HIP_Model> hipList, string indexName)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            bool index_exists = Elastic_Utils.IfIndexOrTypeExists(indexName, connection);
            if (!index_exists)
            {
                //create new index
                string settings = Elastic_Utils.BuildExternalDataIndexSettings();
                connection.Put(indexName, settings);
            }

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/hip", connection);

            if (!type_exists)
            {
                string json_case_mapping = BuildHIPMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "hip"), json_case_mapping);
            }

            Elastic_Utils.BulkType<HIP_Model>(hipList, connection, serializer, indexName, "hip");
        }

        public static void Delete_Case_After_Submitting(string index_name, string type, string id)
        {
            var command = Commands.Delete(index_name, type, id);
            var connection = Elastic_Utils.ElsaticConnection();

            connection.Delete(command);
            connection.Post(index_name + "/_refresh");
        }

        public static string BuildHipLastUsedMapping(string practice_id)
        {
            return new MapBuilder<Practice_Doctor_Last_Used_Model>()
               .RootObject("last_used_hips_" + practice_id, ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("display_name", mfp => mfp.Fields(f => f
                                        .String("display_name", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                    .MultiField("secondary_display_name", mfp => mfp.Fields(f => f
                                        .String("secondary_display_name", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                      .MultiField("date_of_use", mfp => mfp.Fields(f => f
                                        .Date("date_of_use")
                                      )))

                     ).BuildBeautified();
        }

        public static void Import_Last_Used_HIPs_to_ElasticDB(List<Practice_Doctor_Last_Used_Model> model_list, string indexName, string practice_id)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            bool index_exists = Elastic_Utils.IfIndexOrTypeExists(indexName, connection);

            if (!index_exists)
            {
                string settings = Elastic_Utils.BuildIndexSettings();
                connection.Put(indexName, settings);
            }

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/last_used_hips_" + practice_id, connection);

            if (!type_exists)
            {
                string jsonProductMapping = BuildHipLastUsedMapping(practice_id);
                string resultProductMapping = connection.Put(new PutMappingCommand(indexName, "last_used_hips_" + practice_id), jsonProductMapping);
            }

            Elastic_Utils.BulkType<Practice_Doctor_Last_Used_Model>(model_list, connection, serializer, indexName, "last_used_hips_" + practice_id);

        }
    }
}
