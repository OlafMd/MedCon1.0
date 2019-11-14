using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace DataImporter.Excel_Templates
{
    class ExportPracticesXLSTemplate
    {
        public static string generateExportPracticeTemplate(List<ED_GAPOD_1624> practiceData)
        {
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            FileInfo file = new FileInfo(filename);

            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

                     // --------- Data and styling goes here -------------- //
                if (practiceData != null)
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

                    foreach (var row in practiceData)
                    {

                        worksheet.Cells[i, 1].Value = row.PracticeName;
                        worksheet.Cells[i, 2].Value = row.BSNR;
                        worksheet.Cells[i, 3].Value = row.Street_Name;
                        worksheet.Cells[i, 4].Value = row.Street_Number;
                        worksheet.Cells[i, 5].Value = row.ZIP;
                        worksheet.Cells[i, 6].Value = row.Town;
                        worksheet.Cells[i, 7].Value = row.PracticeEmail;
                        worksheet.Cells[i, 8].Value = "";
                        worksheet.Cells[i, 9].Value = "";
                        worksheet.Cells[i, 10].Value = row.ContactPersonFirstName + " " + row.ContactPersonLastName;
                        worksheet.Cells[i, 11].Value = row.ContactPersonEmail;
                        worksheet.Cells[i, 12].Value = row.ContactPersonPhone;
                        worksheet.Cells[i, 13].Value = "";
                        worksheet.Cells[i, 14].Value = "";
                        worksheet.Cells[i, 15].Value = "";
                        worksheet.Cells[i, 16].Value = "";
                        worksheet.Cells[i, 17].Value = "";
                        worksheet.Cells[i, 18].Value = "";
                        worksheet.Cells[i, 19].Value = "";
                        worksheet.Cells[i, 20].Value = "";
                        worksheet.Cells[i, 21].Value = "";
                        worksheet.Cells[i, 22].Value = "";
                        worksheet.Cells[i, 23].Value = "";
                        worksheet.Cells[i, 24].Value = "";
                        worksheet.Cells[i, 25].Value = "";

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
