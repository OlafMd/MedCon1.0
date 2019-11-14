using DataImporter.Elastic_test.Model;
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
    public static class ExportConsentsBeforeUpload
    {

        public static string ExportConsentsBeforeUploadToDB(List<ParticipationConsentModel> consents)
        {
            string fname = "/consents" + new Random().Next(1, 100) + ".xlsx";

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fname;
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xlsx");
            FileInfo file = new FileInfo(filename);

            Console.Clear();
            Console.Write("Generating xlsx file...");
            Console.WriteLine();
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

                int k = 1;
                if (consents != null)
                {
                    worksheet.Cells[1, k++].Value = "Insurance ID Patient";
                    worksheet.Cells[1, k++].Value = "BSNR";
                    worksheet.Cells[1, k++].Value = "Participation consent start date";
                    worksheet.Cells[1, k++].Value = "Imported";
                    worksheet.Cells[1, k++].Value = "Feedback";
                }

                using (ExcelRange rng = worksheet.Cells["A1:E1"])
                {
                    rng.Style.Font.Bold = true;
                }
                k = 1;
                int i = 2;
                foreach (var consent in consents)
                {
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");

                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = consent.insurance_id;
                    worksheet.Cells[i, k++].Value = consent.bsnr;
                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = consent.start_date.ToString("dd.MM.yyyy");
                    worksheet.Cells[i, k++].Value = consent.isValid;
                    worksheet.Cells[i, k++].Value = consent.validationMessage;
                    Console.Write(".");
                    i++;
                    k = 1;
                }

                Console.WriteLine("\nPlease wait...");
                worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                package.Save();
            }

            System.IO.File.Copy(filename, path, true);
            Console.WriteLine("You can find xls file on your desktop, named: " + fname);
            Console.WriteLine("");
            return path;
        }
    }
}
