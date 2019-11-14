using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Receipt.Manipulation
{
    public static class Add_Item_to_Receipts
    {
        public static string BuildreceiptMapping()
        { 
         return new MapBuilder<Receipt_Model>()
         .RootObject("receipts" , ro=>ro.Properties(
             pr=>pr.MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                     .MultiField("documentId", mfp => mfp.Fields(f => f
                                        .String("documentId", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("doctorID", mfp => mfp.Fields(f => f
                                        .String("doctorID", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("filedate", mfp => mfp.Fields(f => f
                                        .Date("filedate")
                                        )
                                     )

                                       .MultiField("filedateString", mfp => mfp.Fields(f => f
                                        .String("filedateString", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("period", mfp => mfp.Fields(f => f
                                        .String("period", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                       .MultiField("periodDate", mfp => mfp.Fields(f => f
                                        .Date("periodDate")
                                        )
                                     )

                                     .MultiField("amount", mfp => mfp.Fields(f => f
                                        .String("amount", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("amountNo", mfp => mfp.Fields(f => f
                                        .Number("amountNo")                                      
                                        )
                                     )
                                     .MultiField("isViewed", mfp => mfp.Fields(f => f
                                        .Boolean("isViewed")
                                        )
                                     )
                                    )
                     ).BuildBeautified();
        }

        public static void Import_Receipt_Item_to_ElasticDB( List<Receipt_Model> receiptList, string indexName)
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

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/receipts", connection);
            if (!type_exists)
            {
                string json_case_mapping = BuildreceiptMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "receipts"), json_case_mapping);
            }

            Elastic_Utils.BulkType<Receipt_Model>(receiptList, connection, serializer, indexName, "receipts");
        }

    }

   
}
