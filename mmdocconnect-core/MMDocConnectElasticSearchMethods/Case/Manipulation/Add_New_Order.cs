using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Case.Manipulation
{
    public static class Add_New_Order
    {
        public static string BuildOrderMapping()
        {
            return new MapBuilder<Order_Model>()
               .RootObject("order", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                   .MultiField("doctor_id", mfp => mfp.Fields(f => f
                                        .String("doctor_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                   .MultiField("patient_id", mfp => mfp.Fields(f => f
                                        .String("patient_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                      .MultiField("case_id", mfp => mfp.Fields(f => f
                                        .String("case_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                      .MultiField("drug_id", mfp => mfp.Fields(f => f
                                        .String("drug_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                      .MultiField("diagnose_id", mfp => mfp.Fields(f => f
                                        .String("diagnose_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                       .MultiField("practice_id", mfp => mfp.Fields(f => f
                                        .String("practice_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("treatment_date", mfp => mfp.Fields(f => f
                                        .Date("treatment_date")
                                        )
                                     )
                                     .MultiField("treatment_date_day_month", mfp => mfp.Fields(f => f
                                        .String("treatment_date_day_month", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("treatment_date_month_year", mfp => mfp.Fields(f => f
                                        .String("treatment_date_month_year", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("patient_name", mfp => mfp.Fields(f => f
                                        .String("patient_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("patient_birthdate", mfp => mfp.Fields(f => f
                                        .Date("patient_birthdate")
                                        )
                                     )
                                     .MultiField("diagnose", mfp => mfp.Fields(f => f
                                        .String("diagnose", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("drug", mfp => mfp.Fields(f => f
                                        .String("drug", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                           .MultiField("localization", mfp => mfp.Fields(f => f
                                        .String("localization", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                           .MultiField("treatment_doctor_name", mfp => mfp.Fields(f => f
                                        .String("treatment_doctor_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                        .MultiField("treatment_doctor_practice_name", mfp => mfp.Fields(f => f
                                        .String("treatment_doctor_practice_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )

                                            .MultiField("status_drug_order", mfp => mfp.Fields(f => f
                                        .String("status_drug_order", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                          )
                                        )
                                           .MultiField("order_modification_timestamp", mfp => mfp.Fields(f => f
                                        .String("order_modification_timestamp", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                         .MultiField("delivery_time_from", mfp => mfp.Fields(f => f
                                        .String("delivery_time_from", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                       .MultiField("delivery_time_to", mfp => mfp.Fields(f => f
                                        .String("delivery_time_to", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                      .MultiField("is_orders_drug", mfp => mfp.Fields(f => f
                                        .String("is_orders_drug", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                         .MultiField("hip", mfp => mfp.Fields(f => f
                                        .String("hip", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )

                                         .MultiField("patient_insurance_number", mfp => mfp.Fields(f => f
                                        .String("patient_insurance_number", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )

                                         .MultiField("lanr", mfp => mfp.Fields(f => f
                                        .String("lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )

                                         .MultiField("bsnr", mfp => mfp.Fields(f => f
                                        .String("bsnr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )
                                         .MultiField("isOverdue", mfp => mfp.Fields(f => f
                                        .String("isOverdue", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                        .MultiField("pharmacy_id", mfp => mfp.Fields(f => f
                                        .String("pharmacy_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                      .MultiField("pharmacy_name", mfp => mfp.Fields(f => f
                                        .String("pharmacy_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                          )
                     ).BuildBeautified();
        }

        public static void Import_Order_Data_to_ElasticDB(List<Order_Model> OrderModelList, string indexName)
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

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/order", connection);

            if (!type_exists)
            {
                string json_case_mapping = BuildOrderMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "order"), json_case_mapping);
            }

            Elastic_Utils.BulkType<Order_Model>(OrderModelList, connection, serializer, indexName, "order");

        }

    }
}
