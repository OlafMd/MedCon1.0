using CL1_HEC;
using CL1_HEC_HIS;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Complex.Manipulation;
using DataImporter.Elastic_Methods.HIP.Retrieval;
using DataImporter.Elastic_test.Model;
using DataImporter.Excel_Templates;
using DLExcelUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods.Import_Data_from_xls
{


    public class Import_Patients_From_Excel
    {
        public static void Import_Patients_from_xls(bool create_consents, string connectionString, SessionSecurityTicket securityTicket)
        {
            DbConnection Connection = null;
            DbTransaction Transaction = null;
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;
            if (cleanupConnection == true)
            {
                Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
                Connection.Open();
            }
            if (cleanupTransaction == true)
            {
                Transaction = Connection.BeginTransaction();
            }
            try
            {

                string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string filePath = Path.Combine(folder, "Excel\\patients.xlsx");
                bool hasHeader = true;
                DataTable excelData = null;
                try
                {
                    excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
                }
                catch (Exception ex)
                {
                    filePath = Path.Combine(folder, "Excel\\patients.xls");
                }

                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);

                CultureInfo culture = CultureInfo.InvariantCulture;
                List<Patient_Model_xls> patientL = new List<Patient_Model_xls>();
                DO_GAPR_1112[] PracticeData = new DO_GAPR_1112[] { };
                PracticeData = cls_Get_all_Practices.Invoke(Connection, Transaction, securityTicket).Result;
                var HiPs = Get_HIPs.Get_HIPs_for_Search_Criteria("");
                List<string> FirstLastNameUnique = new List<string>();
                List<string> HipNumUnique = new List<string>();
                bool flagValid = true;
                foreach (System.Data.DataRow item in excelData.Rows)
                {


                    flagValid = true;
                    Patient_Model_xls patient = new Patient_Model_xls();
                    patient.ValidationErrors = "";
                    patient.isPrivatelyInsured = item.ItemArray[6].ToString() == "private";

                    if (!String.IsNullOrEmpty(item.ItemArray[0].ToString()))
                    {
                        patient.name = item.ItemArray[0].ToString();
                    }
                    else
                    {
                        patient.name = " ";
                        flagValid = false;
                        patient.ValidationErrors = patient.ValidationErrors + ", " + "Patient First Name empty";
                    }

                    if (!String.IsNullOrEmpty(item.ItemArray[1].ToString()))
                    {
                        patient.LastName = item.ItemArray[1].ToString();

                    }
                    else
                    {
                        patient.LastName = " ";
                        flagValid = false;
                        patient.ValidationErrors = patient.ValidationErrors + ", " + "Patient Last Name empty";
                    }

                    if (!String.IsNullOrEmpty(item.ItemArray[2].ToString()))
                    {
                        try
                        {

                            patient.birthday_string = item.ItemArray[2].ToString();
                            patient.birthday = DateTime.ParseExact(patient.birthday_string, "M/d/yyyy", culture);
                            if (FirstLastNameUnique.Contains(patient.name + " " + patient.LastName + " " + patient.birthday_string))
                            {
                                // patient.ValidationErrors = patient.ValidationErrors + ", " + "Patient with same first, last name and birthday already exists";
                            }
                            FirstLastNameUnique.Add(patient.name + " " + patient.LastName + " " + patient.birthday_string);
                        }
                        catch
                        {
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + "Patient birthday not valid";
                        }
                    }
                    else
                    {
                        patient.birthday_string = " ";
                        flagValid = false;
                        patient.ValidationErrors = patient.ValidationErrors + ", " + "Birthday empty ";
                    }

                    if (!String.IsNullOrEmpty(item.ItemArray[3].ToString()))
                    {

                        patient.sex = item.ItemArray[3].ToString();
                    }
                    else
                    {
                        patient.sex = " ";
                        flagValid = false;
                        patient.ValidationErrors = patient.ValidationErrors + ", " + "Gender empty ";
                    }

                    if (!patient.isPrivatelyInsured)
                    {
                        if (!String.IsNullOrEmpty(item.ItemArray[4].ToString()))
                        {
                            patient.health_insurance_providerNumber = item.ItemArray[4].ToString();
                            if (!HiPs.Any(hp => hp.ik_number == patient.health_insurance_providerNumber))
                            {
                                flagValid = false;
                                patient.ValidationErrors = patient.ValidationErrors + ", " + "Health insurance IK do not exists ";
                            }
                        }
                        else
                        {
                            patient.health_insurance_providerNumber = " ";
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + "Health insurance IK empty ";
                        }


                        if (!String.IsNullOrEmpty(item.ItemArray[5].ToString()))
                        {
                            if (!patient.isPrivatelyInsured)
                            {
                                patient.health_insurance_provider = item.ItemArray[5].ToString();
                                var hip = HiPs.Where(hp => hp.ik_number == patient.health_insurance_providerNumber).SingleOrDefault();
                                if (hip == null || hip.name != patient.health_insurance_provider)
                                {
                                    flagValid = false;
                                    patient.ValidationErrors = patient.ValidationErrors + ", " + "Health insurance name do not match given Health insurance IK ";
                                }
                            }
                        }
                        else
                        {
                            patient.health_insurance_provider = " ";
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + " Health insurance name empty ";
                        }

                        if (!String.IsNullOrEmpty(item.ItemArray[6].ToString()))
                        {
                            patient.insurance_id = item.ItemArray[6].ToString();

                            if (HipNumUnique.Contains(patient.insurance_id))
                            {

                                // patient.ValidationErrors = patient.ValidationErrors + ", " + " Insurance number already exists ";

                            }

                            HipNumUnique.Add(patient.insurance_id);
                        }
                        else
                        {
                            patient.insurance_id = " ";
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + " Insurance number empty ";
                        }

                        if (!String.IsNullOrEmpty(item.ItemArray[7].ToString()))
                        {
                            patient.insurance_status = item.ItemArray[7].ToString();

                        }
                        else
                        {
                            patient.insurance_status = " ";
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + " Insurance state empty ";
                        }


                        var insurancestatusValid = ValidationMethods.ValidateInsuranceStatusCode(patient.insurance_status);
                        bool invalidStatus = insurancestatusValid.Item1;
                        patient.insurance_status = insurancestatusValid.Item2;
                        if (!invalidStatus)
                        {
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + " Insurance status not valid ";
                        }
                    }

                    if (!String.IsNullOrEmpty(item.ItemArray[8].ToString()))
                    {
                        patient.practice_bsnr = item.ItemArray[8].ToString();
                        if (!ValidationMethods.IsDigitsOnly(patient.practice_bsnr))
                        {
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + "BSNR doesn't have only digits";
                        }
                        if (patient.practice_bsnr.Length != 9)
                        {
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + "BSNR doesn't have 9 digits";
                        }


                        if (PracticeData.Where(pp => pp.CompanyInfo_EstablishmentNumber == patient.practice_bsnr).SingleOrDefault() == null)
                        {
                            flagValid = false;
                            patient.ValidationErrors = patient.ValidationErrors + ", " + "Practice with given BSNR do not exists";
                        }


                    }
                    else
                    {
                        patient.practice_bsnr = " ";
                        flagValid = false;
                        patient.ValidationErrors = patient.ValidationErrors + ", " + "BSNR empty ";

                    }


                    if (!String.IsNullOrEmpty(item.ItemArray[9].ToString()))
                    {
                        patient.practice_name = item.ItemArray[9].ToString();

                        if (!String.IsNullOrWhiteSpace(patient.practice_bsnr))
                        {
                            if (!String.IsNullOrEmpty(patient.practice_name))
                            {

                                var practice = PracticeData.Where(bs => bs.CompanyInfo_EstablishmentNumber == patient.practice_bsnr).SingleOrDefault();
                                if (practice == null)
                                {
                                    flagValid = false;
                                    patient.ValidationErrors = patient.ValidationErrors + ", " + "Practice with given BSNR do not exists";
                                }
                                else if (practice.DisplayName != patient.practice_name)
                                {
                                    flagValid = false;
                                    patient.practice_name = " ";
                                    patient.ValidationErrors = patient.ValidationErrors + ", " + "Practice with given Name do not match given BSNR";

                                }

                                else
                                {
                                    patient.practice_id = practice.HEC_MedicalPractiseID.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        patient.practice_name = " ";
                        patient.ValidationErrors = patient.ValidationErrors + ", " + "Practice Name empty ";
                        flagValid = false;

                    }

                    if (patient.ValidationErrors != "")
                        patient.ValidationErrors = patient.ValidationErrors.Substring(1);
                    patient.isValid = flagValid;
                    patientL.Add(patient);

                }


                string file = ExportPatientsBeforeUpload.ExportPatientsBeforeUploadToDB(patientL);
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
                Console.WriteLine("----- XLS created.");

                if (!patientL.Any(vl => vl.isValid == false))
                {
                    //import patients to DB
                    foreach (var patientForSave in patientL)
                    {
                        Save_Patients.Save_Patients_to_DB(patientForSave, create_consents, connectionString, securityTicket);
                    }

                    Console.WriteLine("Patients imported");

                }
                else
                {

                    Console.WriteLine("Data not valid,won't be saved ");
                }
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }


            }




            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }

                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }

                }
                catch { }

                throw ex;
            }
        }
    }
}
