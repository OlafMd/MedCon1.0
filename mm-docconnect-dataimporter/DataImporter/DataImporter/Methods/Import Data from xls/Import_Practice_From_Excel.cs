
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.ExportData.Atomic.Manipulation;
using DataImporter.DBMethods.ExportData.Complex.Manipulation;
using DataImporter.Methods;
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DataImporter
{
    public class import_Practice_from_excel
    {
        public static void import_Practice_from_xls(string connectionString, SessionSecurityTicket securityTicket)
        {

            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\practices.xlsx");
            bool hasHeader = true;
            bool flagValid = true;

            System.Data.DataTable excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);

           
            try
            {
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }
            catch (Exception ex)
            {
                filePath = Path.Combine(folder, "Excel\\practices.xls");
            }

            excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);


            List<Practice_Model_from_xlsx> PracticeL = new List<Practice_Model_from_xlsx>();
            List<string> BSNRUnique = new List<string>();
            List<string> LoginMailUnique = new List<string>();


            foreach (System.Data.DataRow item in excelData.Rows)
            {

                Practice_Model_from_xlsx practice = new Practice_Model_from_xlsx();
                practice.PracticeName = item.ItemArray[0].ToString();
                practice.ValidationErrors = "";
                if (practice.PracticeName == "")
                {
                    flagValid = false;
                    practice.ValidationErrors = "Practice name empty";
                }

                practice.BSNR = item.ItemArray[1].ToString();
                foreach (var bs in BSNRUnique)
                {
                    if (bs == practice.BSNR)
                    {
                        flagValid = false;
                        practice.ValidationErrors = practice.ValidationErrors + ", " + "BSNR already exists";
                    }

                }
                BSNRUnique.Add(practice.BSNR);
                if (practice.BSNR == "")
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "BSNR name empty";
                }

                if (!ValidationMethods.IsDigitsOnly(practice.BSNR))
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "BSNR doesn't have only digits";

                }
                if (practice.BSNR.Length != 9)
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "BSNR doesn't have 9 digits";
                }

                practice.Street = item.ItemArray[2].ToString();
                if (practice.Street == "")
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "Street name empty";
                }
                practice.No = item.ItemArray[3].ToString();
                if (practice.No == "")
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "Street number empty";
                }
                practice.Zip = item.ItemArray[4].ToString();
                if (practice.Zip == "")
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "ZIP code empty";
                }

                practice.City = item.ItemArray[5].ToString();
                if (practice.City == "")
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "City name empty";
                }
                practice.MainEmail = item.ItemArray[6].ToString();
                if (practice.MainEmail != "")
                    if (!ValidationMethods.IsMailValid(practice.MainEmail))
                    {
                        flagValid = false;
                        practice.ValidationErrors = practice.ValidationErrors + ", " + "Main email not valid";
                    }
                practice.MainPhone = item.ItemArray[7].ToString();

                //if (practice.MainPhone == "")
                //{
                //    flagValid = false;
                //    practice.ValidationErrors = practice.ValidationErrors + ", " + "Main phone empty";
                //}
                practice.Fax = item.ItemArray[8].ToString();
                practice.ContactPerson = item.ItemArray[9].ToString();
                practice.Email = item.ItemArray[10].ToString();
                if (practice.Email != "")
                    if (!ValidationMethods.IsMailValid(practice.Email))
                    {
                        flagValid = false;
                        practice.ValidationErrors = practice.ValidationErrors + ", " + "Email not valid";
                    }

                practice.Phone = item.ItemArray[11].ToString();
                practice.AccountHolder = item.ItemArray[12].ToString();
                practice.Bic = item.ItemArray[13].ToString();
                if (!String.IsNullOrEmpty(practice.Bic))
                {
                    if (!ValidationMethods.isValidBic(practice.Bic.ToString()))
                    {
                        flagValid = false;
                        practice.ValidationErrors = practice.ValidationErrors + ", " + "BIC not valid";
                    }
                }

                practice.IBAN = item.ItemArray[14].ToString();
                practice.Bank = item.ItemArray[15].ToString();
                if (practice.Bic != "" && practice.Bank == "")
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "Bic not empty but bank is empty";
                }

                practice.LoginEmail = item.ItemArray[16].ToString();
                if (practice.LoginEmail == "")
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "Login email empty";
                }

                if (!ValidationMethods.IsMailValid(practice.LoginEmail))
                {
                    flagValid = false;
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "Login email not valid";
                }

                foreach (var lg in LoginMailUnique)
                {
                    if (lg == practice.LoginEmail)
                    {
                        flagValid = false;
                        practice.ValidationErrors = practice.ValidationErrors + ", " + "Login email already exists";
                    }

                }
                LoginMailUnique.Add(practice.LoginEmail);


                practice.inPassword = item.ItemArray[17].ToString();
                if (practice.inPassword != "")
                {

                    if (!ValidationMethods.isValidPass(practice.inPassword))
                    {
                        flagValid = false;
                        practice.ValidationErrors = practice.ValidationErrors + ", " + "Password not valid";
                    }
                }
                else
                {

                    practice.inPassword = ValidationMethods.CreatePassword(8);
                }
                practice.IsSurgeryPractice = int.Parse(item.ItemArray[18].ToString()) == 1 ? true : false;
                practice.IsOrderDrugs = int.Parse(item.ItemArray[19].ToString()) == 1 ? true : false;
                practice.DefaultShippingDateOffset = item.ItemArray[20].ToString();
                if (practice.DefaultShippingDateOffset == "")
                {
                    practice.ValidationErrors = practice.ValidationErrors + ", " + "Default shipping date offset empty";
                    flagValid = false;
                }
                practice.IsOnlyLabelRequired = int.Parse(item.ItemArray[21].ToString()) == 1 ? true : false;
                practice.isWaiveServiceFee = int.Parse(item.ItemArray[22].ToString()) == 1 ? true : false;
                practice.isValid = flagValid;

                if (practice.ValidationErrors != "")
                    practice.ValidationErrors = practice.ValidationErrors.Substring(1);


                PracticeL.Add(practice);
            }

            string file = ExportPracticesBeforeUpload.ExportPracticesBeforeUploadToDB(PracticeL);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
            Console.WriteLine("----- XLS created.");

            if (!PracticeL.Any(vl => vl.isValid == false))
            {

                foreach (var practice in PracticeL)
                {

                    if (practice.LoginEmail != "")
                        Create_Accounts.Save_accounts_to_DBCompany(practice, connectionString, securityTicket);


                }
                foreach (var practice in PracticeL)
                {

                    if (practice.LoginEmail != "")
                        Save_practices.Save_practices_to_DB(practice, connectionString, securityTicket);


                }
                Console.WriteLine("Practices imported");

            }
            else
            {

                Console.WriteLine("Data invalid, won't be saved!");
            }

        }


    }
}
