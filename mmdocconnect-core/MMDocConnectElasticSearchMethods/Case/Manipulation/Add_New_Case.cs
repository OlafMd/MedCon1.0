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
    public static class Add_New_Case
    {
        public static string BuildCaseMapping()
        {
            return new MapBuilder<Case_Model>()
               .RootObject("case", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                       .MultiField("diagnose_id", mfp => mfp.Fields(f => f
                                           .String("diagnose_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                           )
                                        )
                                       .MultiField("drug_id", mfp => mfp.Fields(f => f
                                           .String("drug_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                   .MultiField("treatment_doctor_id", mfp => mfp.Fields(f => f
                                        .String("treatment_doctor_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                   .MultiField("treatment_doctor_id", mfp => mfp.Fields(f => f
                                        .String("treatment_doctor_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                   .MultiField("aftercare_doctor_practice_id", mfp => mfp.Fields(f => f
                                        .String("aftercare_doctor_practice_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                   .MultiField("aftercare_doctors_practice_id", mfp => mfp.Fields(f => f
                                        .String("aftercare_doctors_practice_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("treatment_date", mfp => mfp.Fields(f => f
                                        .Date("treatment_date")
                                        )
                                     )
                                      .MultiField("group_name", mfp => mfp.Fields(f => f
                                        .String("group_name", sp => sp.IndexAnalyzer("not_analyzed"))
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
                                        ))
                                     .MultiField("patient_birthdate_string", mfp => mfp.Fields(f => f
                                        .String("patient_birthdate_string", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                     .MultiField("diagnose", mfp => mfp.Fields(f => f
                                        .String("diagnose", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                     .MultiField("drug", mfp => mfp.Fields(f => f
                                        .String("drug", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                           .MultiField("localization", mfp => mfp.Fields(f => f
                                        .String("localization", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                           .MultiField("treatment_doctor_name", mfp => mfp.Fields(f => f
                                        .String("treatment_doctor_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                            .MultiField("aftercare_name", mfp => mfp.Fields(f => f
                                        .String("aftercare_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                              .MultiField("status_drug_order", mfp => mfp.Fields(f => f
                                        .String("status_drug_order", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                          ))
                                            .MultiField("status_treatment", mfp => mfp.Fields(f => f.
                                        String("status_treatment", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                            .MultiField("practice_id", mfp => mfp.Fields(f => f
                                            .String("practice_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        ))
                                      .MultiField("patient_hip", mfp => mfp.Fields(f => f
                                        .String("patient_hip", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                        .MultiField("patient_insurance_number", mfp => mfp.Fields(f => f
                                        .String("patient_insurance_number", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                      .MultiField("patient_id", mfp => mfp.Fields(f => f
                                        .String("patient_id", sp => sp.Analyzer("not_analyzed"))
                                        ))
                                      .MultiField("treatment_doctor_lanr", mfp => mfp.Fields(f => f
                                        .String("treatment_doctor_lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                      .MultiField("aftercare_doctor_lanr", mfp => mfp.Fields(f => f
                                        .String("aftercare_doctor_lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                      .MultiField("aftercare_practice_bsnr", mfp => mfp.Fields(f => f
                                        .String("aftercare_practice_bsnr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                      .MultiField("previous_status_drug_order", mfp => mfp.Fields(f => f
                                         .String("previous_status_drug_order", sp => sp.IndexAnalyzer("not_analyzed"))
                                      )))
                     ).BuildBeautified();
        }

        public static void Import_Case_Data_to_ElasticDB(List<Case_Model> CaseModelList, string indexName)
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

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/case", connection);

            if (!type_exists)
            {
                string json_case_mapping = BuildCaseMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "case"), json_case_mapping);
            }

            Elastic_Utils.BulkType<Case_Model>(CaseModelList, connection, serializer, indexName, "case");

        }

        public static void Delete_Case_After_Submitting(string index_name, string type, string id)
        {
            var command = Commands.Delete(index_name, type, id);
            var connection = Elastic_Utils.ElsaticConnection();

            connection.Delete(command);
            connection.Post(index_name + "/_refresh");
        }
    }
}
