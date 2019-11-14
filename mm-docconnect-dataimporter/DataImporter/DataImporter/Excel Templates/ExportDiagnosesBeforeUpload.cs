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
    public static class ExportDiagnosesBeforeUpload
    {

        public static string ExportDiagnosesBeforeUploadToElastic(List<KeyValueModel> hips)
        {
            string fname = "/ICD10_" + new Random().Next(1, 100) + ".xlsx";

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
                if (hips != null)
                {
                    worksheet.Cells[1, k++].Value = "Code";
                    worksheet.Cells[1, k++].Value = "Name";
                    worksheet.Cells[1, k++].Value = "Imported";
                    worksheet.Cells[1, k++].Value = "Feedback";
                }

                using (ExcelRange rng = worksheet.Cells["A1:D1"])
                {
                    rng.Style.Font.Bold = true;
                }
                k = 1;
                int i = 2;
                foreach (var hip in hips)
                {
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");

                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = hip.key;
                    worksheet.Cells[i, k++].Value = hip.value;
                    worksheet.Cells[i, k++].Value = hip.isValid;
                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = hip.validationMessage;
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
