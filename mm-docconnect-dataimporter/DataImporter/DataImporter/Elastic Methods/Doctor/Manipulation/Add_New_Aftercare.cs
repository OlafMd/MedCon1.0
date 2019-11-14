using DataImporter.Models;
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
    public static class Add_New_Aftercare
    {
        public static string BuildCaseMapping()
        {
            return new MapBuilder<Aftercare_Model>()
               .RootObject("aftercare", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                   .MultiField("case_id", mfp => mfp.Fields(f => f
                                        .String("case_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                       .MultiField("diagnose_id", mfp => mfp.Fields(f => f
                                           .String("diagnose_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                       .MultiField("treatment_doctor_id", mfp => mfp.Fields(f => f
                                           .String("treatment_doctor_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                       .MultiField("treatment_doctors_practice_id", mfp => mfp.Fields(f => f
                                           .String("treatment_doctors_practice_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                       .MultiField("aftercare_doctor_practice_id", mfp => mfp.Fields(f => f
                                           .String("aftercare_doctor_practice_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                       .MultiField("drug_id", mfp => mfp.Fields(f => f
                                           .String("drug_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                       .MultiField("aftercare_doctor_account_id", mfp => mfp.Fields(f => f
                                           .String("aftercare_doctor_account_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                           )
                                        )
                                    .MultiField("treatment_date", mfp => mfp.Fields(f => f
                                        .Date("treatment_date")
                                        )
                                     )
                                     .MultiField("aftercare_date_string", mfp => mfp.Fields(f => f
                                        .String("aftercare_date_string", sp => sp.Analyzer("caseinsensitive"))
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
                                      .MultiField("patient_id", mfp => mfp.Fields(f => f
                                        .String("patient_id", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                     .MultiField("patient_birthdate", mfp => mfp.Fields(f => f
                                        .Date("patient_birthdate")
                                        )
                                     )
                                     .MultiField("patient_birthdate_string", mfp => mfp.Fields(f => f
                                        .String("patient_birthdate_string", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("diagnose", mfp => mfp.Fields(f => f
                                        .String("diagnose", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
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
                                            .MultiField("aftercare_doctor_name", mfp => mfp.Fields(f => f
                                        .String("aftercare_doctor_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                        .MultiField("treatment_doctor_practice_name", mfp => mfp.Fields(f => f
                                        .String("treatment_doctor_practice_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                          )
                                        )
                                            .MultiField("status", mfp => mfp.Fields(f => f.
                                        String("status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                            .MultiField("practice_id", mfp => mfp.Fields(f => f
                                            .String("practice_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        ))

                                                 .MultiField("hip", mfp => mfp.Fields(f => f
                                        .String("hip", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                         .MultiField("patient_insurance_number", mfp => mfp.Fields(f => f
                                        .String("patient_insurance_number", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )
                                         .MultiField("op_lanr", mfp => mfp.Fields(f => f
                                        .String("op_lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )
                                         .MultiField("ac_lanr", mfp => mfp.Fields(f => f
                                        .String("ac_lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )
                                     .MultiField("bsnr", mfp => mfp.Fields(f => f
                                        .String("bsnr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )
                                     .MultiField("hip_ik_number", mfp => mfp.Fields(f => f
                                        .String("hip_ik_number", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     ))
                     ).BuildBeautified();
        }

        public static void Import_Aftercare_Data_to_ElasticDB(List<Aftercare_Model> aftercare_model_list, string indexName)
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

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/aftercare", connection);

            if (!type_exists)
            {
                string json_case_mapping = BuildCaseMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "aftercare"), json_case_mapping);
            }

            Elastic_Utils.BulkType_Generic<Aftercare_Model>(aftercare_model_list, connection, serializer, indexName, "aftercare");

        }

        public static void Delete_Aftercare_Submitting(string index_name, string type, string id)
        {
            var command = Commands.Delete(index_name, type, id);
            var connection = Elastic_Utils.ElsaticConnection();

            connection.Delete(command);
            connection.Post(index_name + "/_refresh");
        }

    }
}
