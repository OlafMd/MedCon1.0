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
    public static class Add_New_Submitted_Case
    {
        public static string BuildSubmittedCaseMapping()
        {
            return new MapBuilder<Submitted_Case_Model>()
               .RootObject("submitted_case", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
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
                                    .MultiField("treatment_date", mfp => mfp.Fields(f => f
                                        .Date("treatment_date")
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
                                     .MultiField("treatment_date_string", mfp => mfp.Fields(f => f
                                        .String("treatment_date_string", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
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
                                        )
                                     )
                                     .MultiField("patient_birthdate_string", mfp => mfp.Fields(f => f
                                        .String("patient_birthdate_string", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("type", mfp => mfp.Fields(f => f
                                        .String("type", sp => sp.Analyzer("caseinsensitive"))
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
                                           .MultiField("doctor_name", mfp => mfp.Fields(f => f
                                        .String("doctor_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                              .MultiField("status", mfp => mfp.Fields(f => f
                                        .String("status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                          )
                                        )
                                     .MultiField("drug", mfp => mfp.Fields(f => f
                                        .String("drug", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                            .MultiField("management_pauschale", mfp => mfp.Fields(f => f.
                                        String("management_pauschale", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))

                                           .MultiField("practice_id", mfp => mfp.Fields(f => f
                                           .String("practice_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        ))
                                     .MultiField("status_date", mfp => mfp.Fields(f => f
                                        .Date("status_date")
                                        )
                                     )
                                     .MultiField("if_aftercare_treatment_date", mfp => mfp.Fields(f => f
                                        .Date("if_aftercare_treatment_date")
                                        )
                                     )                                     
                                     .MultiField("status_date_string", mfp => mfp.Fields(f => f
                                        .String("status_date_string", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("hip_name", mfp => mfp.Fields(f => f
                                        .String("hip_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("doctor_lanr", mfp => mfp.Fields(f => f
                                        .String("doctor_lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        )
                                     )
                                     .MultiField("practice_bsnr", mfp => mfp.Fields(f => f
                                        .String("practice_bsnr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        )
                                     )
                                     .MultiField("patient_insurance_number", mfp => mfp.Fields(f => f
                                        .String("patient_insurance_number", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        )
                                     )
                                     .MultiField("practice_name", mfp => mfp.Fields(f => f
                                        .String("practice_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     ))
                     ).BuildBeautified();
        }

        public static void Import_Submitted_Case_Data_to_ElasticDB(List<Submitted_Case_Model> SubmittedCaseModelList, string indexName)
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

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/submitted_case", connection);

            if (!type_exists)
            {
                string json_case_mapping = BuildSubmittedCaseMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "submitted_case"), json_case_mapping);
            }

            Elastic_Utils.BulkType_Generic<Submitted_Case_Model>(SubmittedCaseModelList, connection, serializer, indexName, "submitted_case");

        }

    }
}
