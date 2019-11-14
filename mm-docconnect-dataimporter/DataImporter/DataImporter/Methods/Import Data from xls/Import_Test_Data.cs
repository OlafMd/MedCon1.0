using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_HEC;
using CL1_HEC_HIS;
using CSV2Core.SessionSecurity;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Elastic_test.Model;
using DataImporter.Models;
using DLExcelUtils;
using MMDocConnectElasticSearchMethods;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods.Import_Data_from_xls
{
    public static class Import_Test_Data
    {
        public static void ImportTestPatients(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket, Guid medical_practice_id)
        {
            List<Patient_Model_xls> patientList = new List<Patient_Model_xls>();
            List<Patient_Model> elasticPatientList = new List<Patient_Model>();
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\german_names_sheet.xlsx");
            bool hasHeader = true;
            System.Data.DataTable excelData = ExcelUtils.getDataFromExcelFile(filePath, hasHeader);

            foreach (System.Data.DataRow item in excelData.Rows)
            {
                if (item.ItemArray[0].ToString() == "")
                    break;
                Patient_Model_xls patientModel = new Patient_Model_xls();
                patientModel.name= item.ItemArray[0].ToString();
                patientModel.LastName = item.ItemArray[1].ToString();
                patientModel.sex = item.ItemArray[2].ToString();
                patientModel.birthday = DateTime.Parse(item.ItemArray[3].ToString(), culture, System.Globalization.DateTimeStyles.AssumeLocal);
                patientList.Add(patientModel);
            }

            List<string> StateCode_first_Caracter = new List<string>();
            StateCode_first_Caracter.Add("1");
            StateCode_first_Caracter.Add("3");
            StateCode_first_Caracter.Add("5");


            List<string> StateCode_fift_Caracter = new List<string>();
            StateCode_fift_Caracter.Add("1");
            StateCode_fift_Caracter.Add("4");
            StateCode_fift_Caracter.Add("6");
            StateCode_fift_Caracter.Add("7");
            StateCode_fift_Caracter.Add("8");
            StateCode_fift_Caracter.Add("9");
            StateCode_fift_Caracter.Add("D");
            StateCode_fift_Caracter.Add("F");
            StateCode_fift_Caracter.Add("A");
            StateCode_fift_Caracter.Add("C");
            StateCode_fift_Caracter.Add("S");
            StateCode_fift_Caracter.Add("P");
            StateCode_fift_Caracter.Add("E");
            StateCode_fift_Caracter.Add("N");
            StateCode_fift_Caracter.Add("M");
            StateCode_fift_Caracter.Add("X");
            StateCode_fift_Caracter.Add("L");
            StateCode_fift_Caracter.Add("K");

            int status_code_counter = 0;
            int status_fift_counter = 0;
            int counter = 0;

            var medicalPracticeQuery = new ORM_HEC_HIS_HealthInsurance_Company.Query();
            medicalPracticeQuery.IsDeleted = false;
            medicalPracticeQuery.Tenant_RefID = securityTicket.TenantID;

            var HIPList = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, medicalPracticeQuery).ToList();


            int i = 0;
            foreach(var item in patientList)
            {
                ORM_HEC_Patient patients = new ORM_HEC_Patient();
                patients.HEC_PatientID = Guid.NewGuid();
                patients.Tenant_RefID = securityTicket.TenantID;
                patients.Creation_Timestamp = DateTime.Now;
                patients.Modification_Timestamp = DateTime.Now;
                patients.CMN_BPT_BusinessParticipant_RefID = Guid.NewGuid();
                patients.Save(Connection, Transaction);

                ORM_CMN_BPT_BusinessParticipant businesParticipantPatient = new ORM_CMN_BPT_BusinessParticipant();
                businesParticipantPatient.CMN_BPT_BusinessParticipantID = patients.CMN_BPT_BusinessParticipant_RefID;
                businesParticipantPatient.Tenant_RefID = securityTicket.TenantID;
                businesParticipantPatient.Creation_Timestamp = DateTime.Now;
                businesParticipantPatient.Modification_Timestamp = DateTime.Now;
                businesParticipantPatient.IsNaturalPerson = true;
                businesParticipantPatient.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                businesParticipantPatient.Save(Connection, Transaction);

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = businesParticipantPatient.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.Creation_Timestamp = DateTime.Now;
                personInfo.Modification_Timestamp = DateTime.Now;
                personInfo.FirstName = item.name;//
                personInfo.LastName = item.LastName;//
                personInfo.BirthDate = item.birthday;//
                personInfo.Gender = int.Parse(item.sex);//
                personInfo.Save(Connection, Transaction);

                ORM_HEC_Patient_MedicalPractice medical_practice_to_patient = new ORM_HEC_Patient_MedicalPractice();
                medical_practice_to_patient.HEC_Patient_MedicalPracticeID = Guid.NewGuid();
                medical_practice_to_patient.HEC_Patient_RefID = patients.HEC_PatientID;
                medical_practice_to_patient.HEC_MedicalPractices_RefID = medical_practice_id;//
                medical_practice_to_patient.Tenant_RefID = securityTicket.TenantID;
                medical_practice_to_patient.Creation_Timestamp = DateTime.Now;
                medical_practice_to_patient.Save(Connection, Transaction);


                ORM_HEC_Patient_HealthInsurance patientHealthInsurance = new ORM_HEC_Patient_HealthInsurance();
                patientHealthInsurance.HEC_Patient_HealthInsurancesID = Guid.NewGuid();
                patientHealthInsurance.Patient_RefID = patients.HEC_PatientID;

                Random rnd = new Random();
                int random_insurance_number = rnd.Next(10000000, 99999999);

                int genre =0;
                switch(int.Parse(item.sex))
                {
                    case 0:
                        genre=2;
                        break;
                    case 1:
                        genre=1;
                        break;
                    case 2:
                         genre=0;
                        break;
                }

                var birth = item.birthday.Year.ToString().Substring(2);
                patientHealthInsurance.HealthInsurance_Number = random_insurance_number.ToString();//
                patientHealthInsurance.Tenant_RefID = securityTicket.TenantID;
                patientHealthInsurance.InsuranceStateCode = StateCode_first_Caracter[status_code_counter] + genre.ToString() + birth + StateCode_fift_Caracter[status_fift_counter];//
                patientHealthInsurance.HIS_HealthInsurance_Company_RefID = HIPList[i].HEC_HealthInsurance_CompanyID;
                patientHealthInsurance.Save(Connection, Transaction);


                if (status_code_counter == 2)
                    status_code_counter = 0;
                else
                    status_code_counter++;

                if(status_fift_counter == 17)
                    status_fift_counter=0;
                else
                    status_fift_counter++;

                if (i == HIPList.Count - 1)
                    i = 0;
                else
                    i++;


                var businesParticipantHIPQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                businesParticipantHIPQuery.IsDeleted = false;
                businesParticipantHIPQuery.Tenant_RefID = securityTicket.TenantID;
                businesParticipantHIPQuery.CMN_BPT_BusinessParticipantID = HIPList[i].CMN_BPT_BusinessParticipant_RefID;

                var businesParticipantHIP = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businesParticipantHIPQuery).Single(); ;

                Patient_Model patientModel = new Patient_Model();


                patientModel.birthday = DateTime.Parse(item.birthday.ToString("dd.MM.yyyy"), culture, System.Globalization.DateTimeStyles.AssumeLocal);
                patientModel.birthday_string = item.birthday.ToString("dd.MM.yyyy");
                patientModel.name = item.LastName + ", " + item.name;
                patientModel.health_insurance_provider = businesParticipantHIP.DisplayName;
                patientModel.name_with_birthdate = item.name + " " + item.LastName + " (" + item.birthday.ToString("dd.MM.yyyy") + ")";
                patientModel.id = patients.HEC_PatientID.ToString();
                patientModel.insurance_id = patientHealthInsurance.HealthInsurance_Number;
                patientModel.insurance_status = patientHealthInsurance.InsuranceStateCode;
                patientModel.practice_id = medical_practice_id.ToString();

                if (int.Parse(item.sex) == 0)
                    patientModel.sex = "M";
                else if (int.Parse(item.sex) == 1)
                    patientModel.sex = "W";
                else if (int.Parse(item.sex) == 2)
                    patientModel.sex = "o.A.";


                elasticPatientList.Add(patientModel);



                counter++;
                Console.WriteLine(counter + "________________________" + patientList.Count);
              
            }



            string indexElastic = securityTicket.TenantID.ToString();
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();

            bool checkIndex = Elastic_Utils.IfIndexOrTypeExists(indexElastic, connection);


            if (!checkIndex)
            {
                string settings = Elastic_Utils.BuildIndexSettings();
                connection.Put(indexElastic, settings);

                string jsonProductMapping = Add_New_Patient.BuildPatientMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, "patient"), jsonProductMapping);


            }

            bool checkTupe = Elastic_Utils.IfIndexOrTypeExists(indexElastic + "/patient", connection);
            if (!checkTupe)
            {
                string jsonProductMapping = Add_New_Patient.BuildPatientMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexElastic, "patient"), jsonProductMapping);
            }
            Elastic_Utils.BulkType_Generic<Patient_Model>(elasticPatientList, connection, serializer, indexElastic, "patient");


        }
    }
}
