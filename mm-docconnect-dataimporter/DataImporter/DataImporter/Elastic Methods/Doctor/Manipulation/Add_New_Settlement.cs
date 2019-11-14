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
    public static class Add_new_Settlement
    {
        public static string BuildSettlementMapping()
        {
            return new MapBuilder<Settlement_Model>()
              .RootObject("settlement", ro => ro
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
                                       .MultiField("aftercare_doctor_practice_id", mfp => mfp.Fields(f => f
                                           .String("aftercare_doctor_practice_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                       .MultiField("drug_id", mfp => mfp.Fields(f => f
                                           .String("drug_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                       .MultiField("patient_id", mfp => mfp.Fields(f => f
                                           .String("patient_id", sp => sp.IndexAnalyzer("not_analyzed"))

                                           )
                                        )
                                         .MultiField("surgery_date", mfp => mfp.Fields(f => f
                                            .Date("surgery_date")
                                        ))
                                          .MultiField("surgery_date_string", mfp => mfp.Fields(f => f
                                           .String("surgery_date_string", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        )
                                          .MultiField("patient_full_name", mfp => mfp.Fields(f => f
                                           .String("patient_full_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        )
                                         .MultiField("surgery_date_string_month", mfp => mfp.Fields(f => f
                                           .String("surgery_date_string_month", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        )
                                          .MultiField("first_name", mfp => mfp.Fields(f => f
                                           .String("first_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        )
                                         .MultiField("last_name", mfp => mfp.Fields(f => f
                                           .String("last_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        ).MultiField("birthday", mfp => mfp.Fields(f => f
                                           .String("birthday", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        )
                                         .MultiField("case_type", mfp => mfp.Fields(f => f
                                           .String("case_type", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        )
                                            .MultiField("diagnose", mfp => mfp.Fields(f => f
                                           .String("diagnose", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        ).MultiField("drug", mfp => mfp.Fields(f => f
                                           .String("drug", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        )
                                              .MultiField("localization", mfp => mfp.Fields(f => f
                                           .String("localization", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        ).MultiField("doctor", mfp => mfp.Fields(f => f
                                           .String("doctor", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                           )
                                           .MultiField("acpractice", mfp => mfp.Fields(f => f
                                           .String("acpractice", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        ).MultiField("status", mfp => mfp.Fields(f => f
                                           .String("status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                           .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        ).MultiField("practice_id", mfp => mfp.Fields(f => f
                                           .String("practice_id", sp => sp.Analyzer("caseinsensitive"))
                                           ))
                                        .MultiField("previous_status", mfp => mfp.Fields(f => f
                                          .String("previous_status", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                        .MultiField("if_aftercare_treatment_date", mfp => mfp.Fields(f => f
                                          .String("if_aftercare_treatment_date", sp => sp.Analyzer("caseinsensitive"))
                                        ))
                                           .MultiField("hip", mfp => mfp.Fields(f => f
                                           .String("hip", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
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
                                          .MultiField("is_report_downloaded", mfp => mfp.Fields(f => f
                                        .Boolean("is_report_downloaded")
                                        )
                                     ).MultiField("ac_status", mfp => mfp.Fields(f => f
                                           .String("ac_status", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                        )
                                     .MultiField("hip_ik_number", mfp => mfp.Fields(f => f
                                        .String("hip_ik_number", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )
                                       .MultiField("status_date", mfp => mfp.Fields(f => f
                                           .Date("status_date")
                                           )
                                        )
                                )
                        ).BuildBeautified();
        }

        public static void Import_Settlement_to_ElasticDB(List<Settlement_Model> settlements, string TenantID)
        {
            string indexElastic = TenantID;
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            bool checkIndex = Elastic_Utils.IfIndexOrTypeExists(indexElastic, connection);
            if (!checkIndex)
            {
                string settings = Elastic_Utils.BuildIndexSettings();
                connection.Put(indexElastic, settings);

                string jsonProductMapping = BuildSettlementMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, "settlement"), jsonProductMapping);

            }
            bool checkType = Elastic_Utils.IfIndexOrTypeExists(indexElastic + "/settlement", connection);
            if (!checkType)
            {
                string jsonProductMapping = BuildSettlementMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, "settlement"), jsonProductMapping);
            }

            Elastic_Utils.BulkType_Generic<Settlement_Model>(settlements, connection, serializer, indexElastic, "settlement");
        }

    }
}
