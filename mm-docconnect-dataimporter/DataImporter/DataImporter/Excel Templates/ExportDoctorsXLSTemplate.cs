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
    public class ExportDoctorsXLSTemplate
    {
        public static string generateExportDoctorsTemplate(List<Doctor_Model> doctorData)
        {
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            FileInfo file = new FileInfo(filename);

            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

                // --------- Data and styling goes here -------------- //
                if (doctorData != null)
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

                    foreach (var row in doctorData)
                    {

                        worksheet.Cells[i, 1].Value = "";
                        worksheet.Cells[i, 2].Value = row.title;
                        worksheet.Cells[i, 3].Value = row.first_name;
                        worksheet.Cells[i, 4].Value = row.last_name;
                        worksheet.Cells[i, 5].Value = row.email;
                        worksheet.Cells[i, 6].Value = row.phone;
                        worksheet.Cells[i, 7].Value = row.lanr;
                        string bsnr = "";
                        if(row.practice_list.Count>0)
                        {
                            for (int hh = 0; hh < row.practice_list.Count; hh++)
                            {
                                if (hh == 0)
                                    bsnr += row.practice_list[hh].bsnr;
                                else
                                {
                                    bsnr += "; " + row.practice_list[hh].bsnr;
                                }
                            }
                        }

                        worksheet.Cells[i, 8].Value = bsnr;

                        string practice_name = "";
                        if (row.practice_list.Count > 0)
                        {
                            for (int w = 0; w < row.practice_list.Count; w++)
                            {
                                if (w == 0)
                                    practice_name += row.practice_list[w].name;
                                else
                                {
                                    practice_name += "; " + row.practice_list[w].name;
                                }
                            }
                        }

                        worksheet.Cells[i, 9].Value = practice_name;
                        worksheet.Cells[i, 10].Value = "";
                        worksheet.Cells[i, 11].Value = row.account_holder;
                        worksheet.Cells[i, 12].Value = row.bic;
                        worksheet.Cells[i, 13].Value = row.iban;
                        worksheet.Cells[i, 14].Value = row.bank_name;
                        worksheet.Cells[i, 15].Value = row.login_email;
                        worksheet.Cells[i, 16].Value = "";
                        worksheet.Cells[i, 17].Value = "";
                        worksheet.Cells[i, 18].Value = "";
                  
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
