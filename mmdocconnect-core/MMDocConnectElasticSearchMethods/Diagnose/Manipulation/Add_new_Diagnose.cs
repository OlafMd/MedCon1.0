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
    public static class Add_New_Diagnose
    {
        public static string BuildDiagnoseMapping()
        {
            return new MapBuilder<Diagnose_Model>()
               .RootObject("diagnose", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                   ))
                                   .MultiField("icd10", mfp => mfp.Fields(f => f
                                      .String("icd10", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                      .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                   ))
                                   .MultiField("name", mfp => mfp.Fields(f => f
                                      .String("name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                      .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                   )))
                     ).BuildBeautified();
        }

        public static void Import_Diagnose_Data_to_ElasticDB(List<Diagnose_Model> diagnoseList, string indexName)
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

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/diagnose", connection);

            if (!type_exists)
            {
                string json_case_mapping = BuildDiagnoseMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "diagnose"), json_case_mapping);
            }

            Elastic_Utils.BulkType<Diagnose_Model>(diagnoseList, connection, serializer, indexName, "diagnose");
        }

    }
}
