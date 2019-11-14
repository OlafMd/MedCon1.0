using CSV2Core.SessionSecurity;
using DataImporter.Elastic_test.Model;
using MMDocConnectElasticSearchMethods;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Elastic_test
{
    public static class PatientLiveTest
    {
        public static void  ExecudeAddingToLynx(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            Patient_Model_xls patientModel = new Patient_Model_xls();
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

            patientModel.birthday = DateTime.Parse(DateTime.Now.ToString("dd.MM.yyyy"), culture, System.Globalization.DateTimeStyles.AssumeLocal);
            patientModel.birthday_string = DateTime.Now.ToString("dd.MM.yyyy");
            patientModel.name = "pera" + ", " + "peric";
            patientModel.health_insurance_provider = "AOK Berlin";
            patientModel.name_with_birthdate = "pera" + " " + "peric" + " (" + patientModel.birthday_string + ")";
            patientModel.id = Guid.NewGuid().ToString();
            patientModel.insurance_id = "12341";
            patientModel.insurance_status = "123456742";
            patientModel.group_name = "";
            patientModel.participation_consent = "";
            patientModel.practice_id = "7547b215-cb90-4fc0-a546-2041471ec71d";
            patientModel.participation_consent = "none";

            Console.WriteLine("TenantID je  " + securityTicket.TenantID.ToString());
            Import_Patients_to_ElasticDB(patientModel, securityTicket.TenantID.ToString());
            

        }

        public static void ExecuteRetrive(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
        {
            ElasticParameterObject param = new ElasticParameterObject();
            param.isAsc = true;
            param.search_params = "";
            param.sort_by = "name";
            param.start_row_index = 0;


            Get_PatientsList(param, "7547b215-cb90-4fc0-a546-2041471ec71d", securityTicket);
        }

        public static string BuildPatientMapping()
        {
            var a = new MapBuilder<Patient_Model_xls>()
              .RootObject("patient", ro => ro
                  .Properties(pr => pr
                                  .MultiField("id", mfp => mfp.Fields(f => f
                                       .String("id", sp => sp.IndexAnalyzer("not_analyzed"))
                                       )
                                   )
                                   .MultiField("group_name", mfp => mfp.Fields(f => f
                                       .String("lower_case_sort", sp => sp.IndexAnalyzer("not_analyzed"))
                                          )
                                   )
                                   .MultiField("name", mfp => mfp.Fields(f => f
                                       .String("name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                       .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                          )
                                   )
                                   .MultiField("practice_id", mfp => mfp.Fields(f => f
                                         .String("practice_id", sp => sp.IndexAnalyzer("not_analyzed"))
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
                                       .String("birthday_string", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                                       .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                       )
                                    )
                                    .MultiField("insurance_status", mfp => mfp.Fields(f => f
                                       .String("insurance_status", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                       .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                       )
                                    )
                                            .MultiField("health_insurance_provider", mfp => mfp.Fields(f => f
                                       .String("health_insurance_provider", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                       .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                       )
                                    )
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
                                     .MultiField("participation_consent", mfp => mfp.Fields(f => f
                                               .String("participation_consent", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.keyword))
                                               .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                                               )
                                       )
                                 )

                    ).BuildBeautified();

            Console.WriteLine(a);
            return a;
        }

        public static void Import_Patients_to_ElasticDB(Patient_Model_xls patient, string TenantID)
        {


            string indexElastic = TenantID;
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            connection.Delete(indexElastic);
            //bool checkIndex = Elastic_Utils.IfIndexOrTypeExists(indexElastic, connection);


            //if (!checkIndex)
            //{
            //    Console.WriteLine("Index ne postoji");

            //    string settings = Elastic_Utils.BuildIndexSettings();
            //    connection.Put(indexElastic, settings);

            //    string jsonProductMapping = BuildPatientMapping();
            //    string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, "patient"), jsonProductMapping);
            //}

            //Console.WriteLine("Index exists: " + checkIndex.ToString());

            //bool checkTupe = Elastic_Utils.IfIndexOrTypeExists(indexElastic + "/patient", connection);

            //if (!checkTupe)
            //{
            //    Console.WriteLine("Type ne postoji. ");

            //    string jsonProductMapping = BuildPatientMapping();
            //    string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, "patient"), jsonProductMapping);

            //    Console.WriteLine("Type Kreiran. ");
            //}

            //Console.WriteLine("Type exists: " + checkTupe.ToString());

            //List<Patient_Model> modelList = new List<Patient_Model>();
            //modelList.Add(patient);
            //Elastic_Utils.BulkType_Generic<Patient_Model>(modelList, connection, serializer, indexElastic, "patient");
        }

        public static void Get_PatientsList(ElasticParameterObject Parameter, string practice_id, SessionSecurityTicket userSecurityTicket)
        {
            List<Patient_Model_xls> patientList = new List<Patient_Model_xls>();
            var TenantID = userSecurityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            string elasticType = "patient";

            if (Elastic_Utils.IfIndexOrTypeExists(TenantID, connection) && Elastic_Utils.IfIndexOrTypeExists(TenantID + "/" + elasticType, connection))
            {
                string sort_by_second_key = "name";
                string sort_by_third_key = "name";

                switch (Parameter.sort_by)
                {
                    case "name":
                        sort_by_second_key = "name";
                        sort_by_third_key = "birthday";
                        break;
                    case "participation_consent":
                        sort_by_second_key = "birthday";
                        sort_by_third_key = "birthday";
                        break;
                }

                Console.WriteLine(sort_by_second_key  + "   "+ sort_by_third_key);

                string query = String.Empty;
                if (string.IsNullOrEmpty(Parameter.search_params))
                    query = QueryBuilderPatients.BuildGetPatientsQuery(Parameter.start_row_index, 100, Parameter.sort_by, Parameter.isAsc, practice_id, sort_by_second_key, sort_by_third_key);
                else
                    query = QueryBuilderPatients.BuildGetPatientsSearchAsYouTypeQuery(Parameter.start_row_index, 100, Parameter.sort_by, Parameter.isAsc, Parameter.search_params, practice_id, sort_by_second_key, sort_by_third_key);


                string searchCommand = Commands.Search(TenantID, elasticType).Pretty();
                string result = connection.Post(searchCommand, query);

                Console.WriteLine(searchCommand + query);
                var foundResults = serializer.ToSearchResult<Patient_Model_xls>(result);

                Console.WriteLine(foundResults.hits.total);

                foreach (var item in foundResults.Documents)
                {
                    Console.WriteLine(item.name);

                    IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
                    Patient_Model_xls patient = new Patient_Model_xls();
                    patient.birthday_string = item.birthday_string;
                    patient.birthday = DateTime.Parse(item.birthday_string, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    patient.health_insurance_provider = item.health_insurance_provider;
                    patient.id = item.id;
                    patient.insurance_id = item.insurance_id;
                    patient.insurance_status = item.insurance_status;
                    patient.name = item.name;
                    patient.participation_consent = item.participation_consent;
                    patient.sex = item.sex;
                    switch (Parameter.sort_by)
                    {
                        case "name":
                            patient.group_name = string.IsNullOrEmpty(item.name) ? "-" : item.name.Substring(0, 1).ToUpper();
                            break;
                        case "sex":
                            patient.group_name = string.IsNullOrEmpty(item.sex) ? "-" : item.sex;
                            break;
                        case "health_insurance_provider":
                            patient.group_name = string.IsNullOrEmpty(item.health_insurance_provider) ? "-" : item.health_insurance_provider;
                            break;
                        case "participation_consent":
                            patient.group_name = string.IsNullOrEmpty(item.participation_consent) ? "-" : item.participation_consent;
                            break;
                    }
                    patientList.Add(patient);
                    Console.WriteLine("Zavrsio");
                }
            }

        }
    }
}

