using CSV2Core.SessionSecurity;
using DataImporter.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods
{
   public static class ExportPracticesBeforeUpload
    {
       public static string ExportPracticesBeforeUploadToDB(List<Practice_Model_from_xlsx>practices)
       {
           string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
           Console.WriteLine("You can find xls file here: "+ filename);
           FileInfo file = new FileInfo(filename);

           using (var package = new ExcelPackage(file))
           {
               ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

               if (practices != null)
               {
                   worksheet.Cells[1, 1].Value = "Name";
                   worksheet.Cells[1, 2].Value = "BSNR";
                   worksheet.Cells[1, 3].Value = "Street";
                   worksheet.Cells[1, 4].Value = "Number";
                   worksheet.Cells[1, 5].Value = "ZIP";
                   worksheet.Cells[1, 6].Value = "City";
                   worksheet.Cells[1, 7].Value = "Main email";
                   worksheet.Cells[1, 8].Value = "Main phone";
                   worksheet.Cells[1, 9].Value = "Fax";
                   worksheet.Cells[1, 10].Value = "Contact person";
                   worksheet.Cells[1, 11].Value = "Email";
                   worksheet.Cells[1, 12].Value = "Phone";
                   worksheet.Cells[1, 13].Value = "Account holder";
                   worksheet.Cells[1, 14].Value = "BIC";
                   worksheet.Cells[1, 15].Value = "IBAN";
                   worksheet.Cells[1, 16].Value = "Bank";
                   worksheet.Cells[1, 17].Value = "Login email";
                   worksheet.Cells[1, 18].Value = "Password";
                   worksheet.Cells[1, 19].Value = "Surgery practice";
                   worksheet.Cells[1, 20].Value = "Orders drugs";
                   worksheet.Cells[1, 21].Value = "Default shipping date offset";
                   worksheet.Cells[1, 22].Value = "Only label required";
                   worksheet.Cells[1, 23].Value = "Waive service fee";
                   worksheet.Cells[1, 24].Value = "Imported";
                   worksheet.Cells[1, 25].Value = "Feedback";


                   using (ExcelRange rng = worksheet.Cells["A1:Y1"])
                   {
                       rng.Style.Font.Bold = true;
                   }

                   int i = 2;


                   foreach (var practice in practices)
                   {
                       worksheet.Cells[i, 1].Value = practice.PracticeName;
                       worksheet.Cells[i, 2].Value = practice.BSNR;
                       worksheet.Cells[i, 3].Value = practice.Street;
                       worksheet.Cells[i, 4].Value = practice.No;
                       worksheet.Cells[i, 5].Value = practice.Zip;
                       worksheet.Cells[i, 6].Value = practice.City;
                       worksheet.Cells[i, 7].Value = practice.MainEmail;
                       worksheet.Cells[i, 8].Value = practice.MainPhone;
                       worksheet.Cells[i, 9].Value = practice.Fax;
                       worksheet.Cells[i, 10].Value = practice.ContactPerson;
                       worksheet.Cells[i, 11].Value = practice.Email;
                       worksheet.Cells[i, 12].Value = practice.Phone;
                       worksheet.Cells[i, 13].Value = practice.AccountHolder;
                       worksheet.Cells[i, 14].Value = practice.Bic;
                       worksheet.Cells[i, 15].Value = practice.IBAN;
                       worksheet.Cells[i, 16].Value = practice.Bank;
                       worksheet.Cells[i, 17].Value = practice.LoginEmail;
                       worksheet.Cells[i, 18].Value = practice.inPassword;
                       worksheet.Cells[i, 19].Value = practice.IsSurgeryPractice;
                       worksheet.Cells[i, 20].Value = practice.IsOrderDrugs;
                       worksheet.Cells[i, 21].Value = practice.DefaultShippingDateOffset;
                       worksheet.Cells[i, 22].Value = practice.IsOnlyLabelRequired;
                       worksheet.Cells[i, 23].Value = practice.isWaiveServiceFee;
                       worksheet.Cells[i, 24].Value = practice.isValid;
                       worksheet.Cells[i, 25].Value = practice.ValidationErrors;

                       i++;

                   }
                   worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                   package.Save();

               }

           }


           return file.FullName;
       }


    }
}
