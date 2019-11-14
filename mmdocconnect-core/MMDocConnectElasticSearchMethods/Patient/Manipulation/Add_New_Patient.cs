using MMDocConnectElasticSearchMethods.Models;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectElasticSearchMethods.Patient.Manipulation
{
    public static class Add_New_Patient
    {
        private static string elasticType = "patient";
        public static string BuildPatientMapping()
        {
            return new MapBuilder<Patient_Model>()
               .RootObject(elasticType, ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                    .MultiField("name", mfp => mfp.Fields(f => f
                                        .String("name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                    .MultiField("practice_id", mfp => mfp.Fields(f => f
                                          .String("practice_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("name_with_birthdate", mfp => mfp.Fields(f => f
                                        .String("name_with_birthdate", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                      .MultiField("birthday", mfp => mfp.Fields(f => f
                                         .Date("birthday")
                                     ))
                                      .MultiField("birthday_string", mfp => mfp.Fields(f => f
                                        .String("birthday_string", sp => sp.Analyzer("caseinsensitive"))
                                        ))


                                     .MultiField("insurance_status", mfp => mfp.Fields(f => f
                                        .String("insurance_status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )

                                         .MultiField("health_insurance_provider", mfp => mfp.Fields(f => f
                                        .String("health_insurance_provider", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        ))


                                      .MultiField("sex", mfp => mfp.Fields(f => f
                                                .String("sex", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                                .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                                )
                                        )
                                      .MultiField("insurance_id", mfp => mfp.Fields(f => f
                                        .String("insurance_id", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                           .MultiField("participation_consent_from", mfp => mfp.Fields(f => f
                                         .Date("participation_consent_from")
                                     ))
                                        .MultiField("participation_consent_to", mfp => mfp.Fields(f => f
                                         .Date("participation_consent_to")
                                     ))
                                         .MultiField("has_participation_consent", mfp => mfp.Fields(f => f
                                         .Boolean("has_participation_consent")
                                     ))
                                         .MultiField("last_first_op_doctor_name", mfp => mfp.Fields(f => f
                                        .String("last_first_op_doctor_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                      .MultiField("op_doctor_lanr", mfp => mfp.Fields(f => f
                                        .String("op_doctor_lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                    .MultiField("ac_doctor_lanr", mfp => mfp.Fields(f => f
                                        .String("ac_doctor_lanr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                      .MultiField("last_first_ac_doctor_name", mfp => mfp.Fields(f => f
                                        .String("last_first_ac_doctor_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                      .MultiField("op_practice_id", mfp => mfp.Fields(f => f
                                           .String("op_practice_id", sp => sp.Analyzer("caseinsensitive"))
                                         )
                                     )

                                    .MultiField("practice", mfp => mfp.Fields(f => f
                                        .String("practice", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                    .MultiField("practice_bsnr", mfp => mfp.Fields(f => f
                                        .String("practice_bsnr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                      .MultiField("ac_practice_id", mfp => mfp.Fields(f => f
                                          .String("ac_practice_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                      .MultiField("ac_practice", mfp => mfp.Fields(f => f
                                        .String("ac_practice", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                    .MultiField("ac_practice_bsnr", mfp => mfp.Fields(f => f
                                        .String("ac_practice_bsnr", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                             .MultiField("op_doctor_id", mfp => mfp.Fields(f => f
                                        .String("op_doctor_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                    .MultiField("ac_doctor_id", mfp => mfp.Fields(f => f
                                        .String("ac_doctor_id", sp => sp.Analyzer("caseinsensitive"))
                                    ))
                                    .MultiField("originating_patient_id", mfp => mfp.Fields(f => f
                                        .String("originating_patient_id", sp => sp.Analyzer("caseinsensitive"))
                                    ))
                                    .MultiField("originating_practice_id", mfp => mfp.Fields(f => f
                                        .String("originating_practice_id", sp => sp.Analyzer("caseinsensitive"))
                                    ))
                                    .MultiField("originating_practice_name", mfp => mfp.Fields(f => f
                                        .String("originating_practice_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                    ))
                                    .MultiField("external_id", mfp => mfp.Fields(f => f
                                        .String("external_id", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                    ))
                                    .MultiField("has_rejected_oct", mfp => mfp.Fields(f => f
                                        .Boolean("has_rejected_oct"))
                                    ))).BuildBeautified();
        }

        public static void Import_Patients_to_ElasticDB(List<Patient_Model> patients, string TenantID)
        {
            string indexElastic = TenantID;
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            bool checkIndex = Elastic_Utils.IfIndexOrTypeExists(indexElastic, connection);

            if (!checkIndex)
            {
                string settings = Elastic_Utils.BuildIndexSettings();
                connection.Put(indexElastic, settings);

                string jsonProductMapping = BuildPatientMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, elasticType), jsonProductMapping);
            }

            bool checkTupe = Elastic_Utils.IfIndexOrTypeExists(indexElastic + "/" + elasticType, connection);


            if (!checkTupe)
            {
                string jsonProductMapping = BuildPatientMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, elasticType), jsonProductMapping);
            }

            Elastic_Utils.BulkType<Patient_Model>(patients, connection, serializer, indexElastic, elasticType);
        }

        //------------------------Patient Details ---------------------------------------------//

        public static string BuildPatientDetailsMapping()
        {
            return new MapBuilder<PatientDetailViewModel>()
               .RootObject("patient_details", ro => ro
                   .Properties(pr => pr
                                   .MultiField("id", mfp => mfp.Fields(f => f
                                        .String("id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("treatment_doctor_id", mfp => mfp.Fields(f => f
                                        .String("treatment_doctor_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("aftercare_doctor_practice_id", mfp => mfp.Fields(f => f
                                        .String("aftercare_doctor_practice_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("diagnose_id", mfp => mfp.Fields(f => f
                                        .String("diagnose_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("drug_id", mfp => mfp.Fields(f => f
                                        .String("drug_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("case_id", mfp => mfp.Fields(f => f
                                        .String("case_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                       .MultiField("order_id", mfp => mfp.Fields(f => f
                                        .String("order_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                    .MultiField("drug", mfp => mfp.Fields(f => f
                                        .String("drug", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                      .MultiField("practice_id", mfp => mfp.Fields(f => f
                                        .String("practice_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                    .MultiField("group_name", mfp => mfp.Fields(f => f
                                        .String("group_name", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                     .MultiField("patient_id", mfp => mfp.Fields(f => f
                                        .String("patient_id", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("date", mfp => mfp.Fields(f => f
                                         .Date("date")
                                     ))
                                     .MultiField("date_string", mfp => mfp.Fields(f => f
                                        .String("date_string", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("detail_type", mfp => mfp.Fields(f => f
                                        .String("detail_type", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                       .MultiField("diagnose_or_medication", mfp => mfp.Fields(f => f
                                        .String("diagnose_or_medication", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                       .MultiField("localisation", mfp => mfp.Fields(f => f
                                        .String("localisation", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                          .MultiField("doctor", mfp => mfp.Fields(f => f
                                        .String("doctor", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                    .MultiField("order_status", mfp => mfp.Fields(f => f
                                        .String("order_status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                    .MultiField("previous_order_status", mfp => mfp.Fields(f => f
                                        .String("previous_order_status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                       .MultiField("status", mfp => mfp.Fields(f => f
                                        .String("status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                        .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                           )
                                    )
                                    .MultiField("if_settlement_is_report_downloaded", mfp => mfp.Fields(f => f
                                        .Boolean("if_settlement_is_report_downloaded"))
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
                                    .MultiField("hip_ik", mfp => mfp.Fields(f => f
                                        .String("hip_ik", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                        )
                                     )

                                  )

                     ).BuildBeautified();
        }

        public static void ImportPatientDetailsToElastic(List<PatientDetailViewModel> patientList, string TenantID)
        {
            string indexElastic = TenantID;
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();


            bool checkIndex = Elastic_Utils.IfIndexOrTypeExists(indexElastic, connection);

            if (!checkIndex)
            {
                string settings = Elastic_Utils.BuildIndexSettings();
                connection.Put(indexElastic, settings);
                string jsonProductMapping = BuildPatientDetailsMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, "patient_details"), jsonProductMapping);
            }

            bool checkTupe = Elastic_Utils.IfIndexOrTypeExists(indexElastic + "/patient_details", connection);

            if (!checkTupe)
            {
                string jsonProductMapping = BuildPatientDetailsMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, "patient_details"), jsonProductMapping);
            }

            Elastic_Utils.BulkType<PatientDetailViewModel>(patientList, connection, serializer, indexElastic, "patient_details");
        }
    }
}
