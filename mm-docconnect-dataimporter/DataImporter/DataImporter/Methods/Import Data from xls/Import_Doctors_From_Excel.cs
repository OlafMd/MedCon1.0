using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Manipulation;
using DataImporter.DBMethods.ExportData.Complex.Manipulation;
using DataImporter.Excel_Templates;
using DataImporter.Methods.Help_Methods;
using DataImporter.Models;
using DLExcelUtils;
using IBAN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods.Import_Data_from_xls
{
    public class Import_Doctors_From_Excel
    {
        public static void Import_Doctors_from_xls(string connectionString, SessionSecurityTicket securityTicket)
        {
            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\doctors.xlsx");
            bool hasHeader = true;
            bool flagValid = true;
            System.Data.DataTable excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            try
            {
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
                filePath = Path.Combine(folder, "Excel\\doctors.xls");
            }
            catch (Exception ex)
            {

            }


            List<Doctor_model_from_xlsx> DoctorL = new List<Doctor_model_from_xlsx>();
            DO_GAPR_1112[] PracticeData = new DO_GAPR_1112[] { };
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

                PracticeData = cls_Get_all_Practices.Invoke(Connection, Transaction, securityTicket).Result;


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
            List<string> LoginMailUnique = new List<string>();
            Dictionary<string, string> LANRUnique = new Dictionary<string, string>();
            IEnumerable<DataRow> doctors = excelData.Rows.Cast<DataRow>();
                        
            foreach (System.Data.DataRow item in excelData.Rows)
            {
                Doctor_model_from_xlsx doctor = new Doctor_model_from_xlsx();
                doctor.ValidationErrors = "";
                // doctor.Salutation = item.ItemArray[0].ToString();
                doctor.Salutation = "";
                doctor.Title = item.ItemArray[1].ToString();
                doctor.FirstName = item.ItemArray[2].ToString();
                if (doctor.FirstName == "")
                {
                    flagValid = false;
                    doctor.ValidationErrors = "First name empty";
                }
                doctor.LastNAme = item.ItemArray[3].ToString();
                if (doctor.LastNAme == "")
                {
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Last name empty";
                }
                doctor.Email = item.ItemArray[4].ToString();
                if (doctor.Email != "")
                {

                    if (!ValidationMethods.IsMailValid(doctor.Email))
                    {
                        flagValid = false;
                        doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Email not valid";

                    }
                }

                doctor.Phone = item.ItemArray[5].ToString();
                if (doctor.Phone == "")
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Phone empty";

                }
                doctor.LANR = item.ItemArray[6].ToString();

                if (doctor.LANR == "")
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "LANR empty";
                }
                else if (doctor.LANR.Length != 9)
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "LANR length not valid";

                }
                else if (!ValidationMethods.IsDigitsOnly(doctor.LANR))
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "LANR not number";


                }

                else if (!ValidationMethods.LANRValidation(doctor.LANR))
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "LANR not valid";
                }

                doctor.BSNR = item.ItemArray[7].ToString();


                if (doctors.Count(doc => doc.ItemArray[6] == doctor.LANR && doc.ItemArray[7] == doctor.BSNR) > 1)
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "LANR already exists in practice: " + item.ItemArray[8].ToString() + ", (BSNR: " + doctor.BSNR + ")";
                }

                
                if (doctor.BSNR == "")
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "BSNR empty";
                }
                doctor.PracticeName = item.ItemArray[8].ToString();
                if (doctor.PracticeName == "")
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Practice name empty";
                }
                var PracticeForDoctor = PracticeData.Where(pr => pr.CompanyInfo_EstablishmentNumber == doctor.BSNR && pr.DisplayName == doctor.PracticeName).SingleOrDefault();
                if (PracticeForDoctor == null)
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Practice with given name and BSNR do not exists";
                }
                else
                {

                    doctor.PracticeID = PracticeForDoctor.HEC_MedicalPractiseID;
                }
                try
                {
                    doctor.IsUsePracticeBank = int.Parse(item.ItemArray[9].ToString()) == 1 ? true : false;
                }
                catch (Exception ex)
                {
                    doctor.IsUsePracticeBank = bool.Parse(item.ItemArray[9].ToString());
                }

                doctor.AccountHolder = item.ItemArray[10].ToString();

                doctor.Bic = item.ItemArray[11].ToString();
                if (doctor.Bic != "")
                {
                    if (!doctor.IsUsePracticeBank && !ValidationMethods.isValidBic(doctor.Bic))
                    {
                        flagValid = false;
                        doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Bic invalid";
                    }
                }
                doctor.IBAN = item.ItemArray[12].ToString();
                if (doctor.IBAN != "")
                {
                    IBAN.IbanValidator validateIban = new IbanValidator();
                    if (doctor.IBAN != "")
                    {

                        try
                        {
                            bool isValidIban = validateIban.ValidateIban(doctor.IBAN);
                        }
                        catch
                        {
                            flagValid = false;
                            doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Iban not valid";
                        }
                    }
                }
                doctor.Bank = item.ItemArray[13].ToString();
                if (!doctor.IsUsePracticeBank && doctor.Bic != "" && doctor.Bank == "")
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Bic entered, bank empty";
                }
                doctor.LoginEmail = item.ItemArray[14].ToString();
                if (doctor.LoginEmail == "")
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Login mail empty";
                }
                else if (!ValidationMethods.IsMailValid(doctor.LoginEmail))
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Login mail not valid";
                }

                foreach (var lg in LoginMailUnique)
                {
                    if (lg == doctor.LoginEmail)
                    {
                        flagValid = false;
                        doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Login email already exists";
                    }

                }
                LoginMailUnique.Add(doctor.LoginEmail);


                doctor.inPassword = item.ItemArray[15].ToString();
                if (doctor.inPassword != "" && !ValidationMethods.isValidPass(doctor.inPassword))
                {
                    flagValid = false;
                    doctor.ValidationErrors = doctor.ValidationErrors + ", " + "Password not valid";
                }
                else if (doctor.inPassword == "")
                {
                    doctor.inPassword = ValidationMethods.CreatePassword(8);
                }
                if (doctor.ValidationErrors != "")
                    doctor.ValidationErrors = doctor.ValidationErrors.Substring(1);
                doctor.isValid = flagValid;
                DoctorL.Add(doctor);
            }


            string file = ExportDoctorsBeforeUpload.ExportDoctorBeforeUploadToDB(DoctorL);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
            Console.WriteLine("----- XLS created.");

            if (!DoctorL.Any(vl => vl.isValid == false))
            {
                foreach (var doctor in DoctorL)
                {
                    if (doctor.LoginEmail != "")
                        doctor.account_id = Create_Accounts.Save_accounts_to_DBPerson(doctor, connectionString, securityTicket);
                }

                foreach (var doctor in DoctorL)
                {
                    if (doctor.LoginEmail != "")
                        Save_Doctors.Save_Doctors_to_DB(doctor, connectionString, securityTicket);
                }

                Console.WriteLine("Doctors imported");
            }
            else
            {
                Console.WriteLine("Data not valid,won't be saved ");
            }

        }

    }
}
