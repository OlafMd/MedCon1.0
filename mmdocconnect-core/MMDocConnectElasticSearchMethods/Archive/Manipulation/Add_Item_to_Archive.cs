using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Archive.Manipulation
{
    public static class Add_Item_to_Archive
     {

        public static string BuildArchiveMapping()
        {
             return new MapBuilder<Archive_Model>()
               .RootObject("docarchive", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                     .MultiField("documentId", mfp => mfp.Fields(f => f
                                        .String("documentId", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("filedate", mfp => mfp.Fields(f => f
                                        .Date("filedate")
                                        )
                                     )
                                       .MultiField(t=>t.creationtimestamp, mfp => mfp.Fields(f => f
                                        .Date(t=>t.creationtimestamp)
                                        )
                                     )
                                       .MultiField("datestring", mfp => mfp.Fields(f => f
                                        .String("datestring", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("filetype", mfp => mfp.Fields(f => f
                                        .String("filetype", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("recipient", mfp => mfp.Fields(f => f
                                        .String("recipient", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("description", mfp => mfp.Fields(f => f
                                        .String("description", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                     )))
                     ).BuildBeautified();

        }

        public static void Import_Archive_Item_to_ElasticDB(Archive_Model ArchiveModel, string indexName)
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

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/docarchive", connection);
            if (!type_exists)
            {
                string json_case_mapping = BuildArchiveMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "docarchive"), json_case_mapping);
            }
            List<Archive_Model> archiveList = new List<Archive_Model>();
            archiveList.Add(ArchiveModel);
            Elastic_Utils.BulkType<Archive_Model>(archiveList, connection, serializer, indexName, "docarchive");
        }



    }
}
