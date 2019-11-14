using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Excel_Templates
{
    public static class ExportPatientsXLSTemplate
    {
        public static string ExportpatientsBeforeUploadToDB(List<ED_GPfOS_1048> patients)
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
                }

                 using (ExcelRange rng = worksheet.Cells["A1:Y1"])
                   {
                       rng.Style.Font.Bold = true;
                   }

                   int i = 2;


                   foreach (var patient in patients)
                   {
                       worksheet.Cells[i, 1].Value = patient.FirstName;
                       worksheet.Cells[i, 2].Value = patient.LastName;
                       worksheet.Cells[i, 3].Value = patient.BirthDate.ToShortDateString();
                       switch(patient.Gender)
                       {
                           case "0":
                               worksheet.Cells[i, 4].Value = "M";
                               break;
                           case "1":
                               worksheet.Cells[i, 4].Value = "W";
                               break;
                           default:
                               worksheet.Cells[i, 4].Value = "o.A.";
                               break;
                       }

                       worksheet.Cells[i, 5].Value = patient.HealthInsurance_IKNumber;
                       worksheet.Cells[i, 6].Value = patient.Health_insurance_name;
                       worksheet.Cells[i, 7].Value = patient.HealthInsurance_Number;
                       worksheet.Cells[i, 8].Value = patient.InsuranceStateCode;
                       worksheet.Cells[i, 9].Value = patient.BSNR;
                       worksheet.Cells[i, 10].Value = patient.practice_name;

                       i++;
                   }

                   worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                   package.Save();
            }
            return file.FullName;
        }
    }
}
