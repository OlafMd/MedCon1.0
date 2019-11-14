using DataImporter.Elastic_test.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Excel_Templates
{
 public static class ExportPatientsBeforeUpload
    {

     public static string ExportPatientsBeforeUploadToDB(List<Patient_Model_xls> patients)
     {
         string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
         Console.WriteLine("You can find xls file here: " + filename);
         FileInfo file = new FileInfo(filename);
         using (var package = new ExcelPackage(file))
         {
             ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

             if (patients != null)
             {
                 worksheet.Cells[1, 1].Value = "First name";
                 worksheet.Cells[1, 2].Value = "Last name";
                 worksheet.Cells[1, 3].Value = "Birth date";
                 worksheet.Cells[1, 4].Value = "Gender";
                 worksheet.Cells[1, 5].Value = "Health insurance IK";
                 worksheet.Cells[1, 6].Value = "Health insurance name";
                 worksheet.Cells[1, 7].Value = "Insurance number";
                 worksheet.Cells[1, 8].Value = "Insurance state";
                 worksheet.Cells[1, 9].Value = "BSNR";
                 worksheet.Cells[1, 10].Value = "Practice name";
                 worksheet.Cells[1, 11].Value = "Imported";
                 worksheet.Cells[1, 12].Value = "Feedback";

                    using (ExcelRange rng = worksheet.Cells["A1:Y1"])
                  {
                      rng.Style.Font.Bold = true;
                  }

                  int i = 2;

                  foreach (var row in patients)
                  {
                      worksheet.Cells[i, 1].Value = row.name;
                      worksheet.Cells[i, 2].Value = row.LastName;
                      worksheet.Cells[i, 3].Value = row.birthday_string;
                      worksheet.Cells[i, 4].Value = row.sex;
                      worksheet.Cells[i, 5].Value = row.health_insurance_providerNumber;
                      worksheet.Cells[i, 6].Value = row.health_insurance_provider;
                      worksheet.Cells[i, 7].Value = row.insurance_id;
                      worksheet.Cells[i, 8].Value = row.insurance_status;
                      worksheet.Cells[i, 9].Value = row.practice_bsnr;
                      worksheet.Cells[i, 10].Value = row.practice_name;
                      worksheet.Cells[i, 11].Value = row.isValid;
                      worksheet.Cells[i, 12].Value = row.ValidationErrors;
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
