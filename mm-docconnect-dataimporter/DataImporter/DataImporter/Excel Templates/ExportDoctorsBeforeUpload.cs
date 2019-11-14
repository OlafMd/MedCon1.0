using DataImporter.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Excel_Templates
{
  public static  class ExportDoctorsBeforeUpload
    {

      public static string ExportDoctorBeforeUploadToDB(List<Doctor_model_from_xlsx> doctors)
      {
          string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
          Console.WriteLine("You can find xls file here: " + filename);
          FileInfo file = new FileInfo(filename);

          using (var package = new ExcelPackage(file))
          {
              // add a new worksheet to the empty workbook
              ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

              // --------- Data and styling goes here -------------- //
              if (doctors != null)
              {
                  worksheet.Cells[1, 1].Value = "Salutation";
                  worksheet.Cells[1, 2].Value = "Title";
                  worksheet.Cells[1, 3].Value = "First name";
                  worksheet.Cells[1, 4].Value = "Last name";
                  worksheet.Cells[1, 5].Value = "Email";
                  worksheet.Cells[1, 6].Value = "Phone";
                  worksheet.Cells[1, 7].Value = "LANR";
                  worksheet.Cells[1, 8].Value = "BSNR";
                  worksheet.Cells[1, 9].Value = "Practice name";
                  worksheet.Cells[1, 10].Value = "Use practice bank account";
                  worksheet.Cells[1, 11].Value = "Account holder";
                  worksheet.Cells[1, 12].Value = "BIC";
                  worksheet.Cells[1, 13].Value = "IBAN";
                  worksheet.Cells[1, 14].Value = "Bank";
                  worksheet.Cells[1, 15].Value = "Login email";
                  worksheet.Cells[1, 16].Value = "Password";
                  worksheet.Cells[1, 17].Value = "Imported";
                  worksheet.Cells[1, 18].Value = "Feedback";

                  using (ExcelRange rng = worksheet.Cells["A1:Y1"])
                  {
                      rng.Style.Font.Bold = true;
                  }

                  int i = 2;

                  foreach (var row in doctors)
                  {

                      worksheet.Cells[i, 1].Value = row.Salutation;
                      worksheet.Cells[i, 2].Value = row.Title;
                      worksheet.Cells[i, 3].Value = row.FirstName;
                      worksheet.Cells[i, 4].Value = row.LastNAme;
                      worksheet.Cells[i, 5].Value = row.Email;
                      worksheet.Cells[i, 6].Value = row.Phone;
                      worksheet.Cells[i, 7].Value = row.LANR;
                      worksheet.Cells[i, 8].Value = row.BSNR;
                      worksheet.Cells[i, 9].Value = row.PracticeName;
                      worksheet.Cells[i, 10].Value = row.IsUsePracticeBank;
                      worksheet.Cells[i, 11].Value = row.AccountHolder;
                      worksheet.Cells[i, 12].Value = row.Bic;
                      worksheet.Cells[i, 13].Value = row.IBAN;
                      worksheet.Cells[i, 14].Value = row.Bank;
                      worksheet.Cells[i, 15].Value = row.LoginEmail;
                      worksheet.Cells[i, 16].Value = row.inPassword;
                      worksheet.Cells[i, 17].Value = row.isValid;
                      worksheet.Cells[i, 18].Value = row.ValidationErrors;

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
