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

namespace MMDocConnectElasticSearchMethods.Doctor.Manipulation
{
    public static class Add_Practice_Doctors_to_Elastic
    {
      
              public static string BuildDoctorPracticeMapping()
        {
            return new MapBuilder<Practice_Doctors_Model>()
               .RootObject("user", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("name", mfp => mfp.Fields(f => f
                                        .String("name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.simple))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                    .MultiField("autocomplete_name", mfp => mfp.Fields(f => f
                                        .String("autocomplete_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                      .MultiField("group_name", mfp => mfp.Fields(f => f
                                        .String("group_name", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                     .MultiField("name_untouched", mfp => mfp.Fields(f => f
                                        .String("name_untouched", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("salutation", mfp => mfp.Fields(f => f
                                        .String("salutation", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("type", mfp => mfp.Fields(f => f
                                        .String("type", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                             .MultiField("aditional_info", mfp => mfp.Fields(f => f
                                        .String("aditional_info", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                             .MultiField("bsnr_lanr", mfp => mfp.Fields(f => f
                                        .String("bsnr_lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                                             .MultiField("address", mfp => mfp.Fields(f => f
                                        .String("address", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("zip", mfp => mfp.Fields(f => f
                                        .String("zip", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                           .MultiField("city", mfp => mfp.Fields(f => f
                                        .String("city", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                           .MultiField("phone", mfp => mfp.Fields(f => f
                                        .String("phone", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                            .MultiField("email", mfp => mfp.Fields(f => f
                                        .String("email", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                              .MultiField("bank", mfp => mfp.Fields(f => f
                                        .String("bank", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                          )
                                        )
                                        .MultiField("bank_untouched", mfp => mfp.Fields(f => f
                                        .String("bank_untouched", sp => sp.Analyzer("caseinsensitive"))
                                                )
                                            )
                                            .MultiField("bank_id", mfp => mfp.Fields(f => f
                                                .String("bank_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                                )
                                            )
                                            .MultiField("bank_info_inherited", mfp => mfp.Fields(f => f
                                                .Boolean("bank_info_inherited")
                                                )
                                            )
                                            .MultiField("bic", mfp => mfp.Fields(f => f.
                                        String("bic", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                        )
                                                  .MultiField("iban", mfp => mfp.Fields(f => f.
                                        String("iban", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                        )
                                               .MultiField("contract", mfp => mfp.Fields(f => f
                                        .Number("contract", sp => sp.Type(NumberMappingType.Integer))
                                        )
                                     ).MultiField("account_status", mfp => mfp.Fields(f => f
                                        .String("account_status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                           ).MultiField("practice_name_for_doctor", mfp => mfp.Fields(f => f
                                        .String("practice_for_doctor", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                           ).MultiField("practice_for_doctor_id", mfp => mfp.Fields(f => f
                                        .String("practice_for_doctor_id", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )

                                     ).MultiField("role", mfp => mfp.Fields(f => f
                                        .String("role", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )

                                     )

                     ).BuildBeautified();
        }

        public static void Import_Practice_Data_to_ElasticDB(List<Practice_Doctors_Model> DPModelL, string indexName)
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

            bool type_exists = Elastic_Utils.IfIndexOrTypeExists(indexName + "/user", connection);

            if (!type_exists)
            {
                string json_case_mapping = BuildDoctorPracticeMapping();
                string result_case_mapping = connection.Put(new PutMappingCommand(indexName, "user"), json_case_mapping);
            }

            Elastic_Utils.BulkType_Generic<Practice_Doctors_Model>(DPModelL, connection, serializer, indexName, "user");

        }

        public static void Delete_index_on_Elastic(string indexName)
        {
            var connection = Elastic_Utils.ElsaticConnection();
            connection.Delete(indexName);
        }

    }
}
