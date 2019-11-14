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
    public static class ExportCasesBeforeUpload
    {

        public static string ExportCasesBeforeUploadToDB(List<CaseModel> cases)
        {
            string fname = "/cases" + new Random().Next(1, 100) + ".xls";
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fname;
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            FileInfo file = new FileInfo(filename);

            Console.Clear();
            Console.Write("Generating xls file...");
            Console.WriteLine();
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

                int k = 1;
                if (cases != null)
                {
                    worksheet.Cells[1, k++].Value = "Patient First name";
                    worksheet.Cells[1, k++].Value = "Patient Last name";
                    worksheet.Cells[1, k++].Value = "Patient HIP number";
                    worksheet.Cells[1, k++].Value = "Treatment date";
                    worksheet.Cells[1, k++].Value = "Drug name";
                    worksheet.Cells[1, k++].Value = "PZN / Schema";
                    worksheet.Cells[1, k++].Value = "Diagnose code";
                    worksheet.Cells[1, k++].Value = "Localization";
                    worksheet.Cells[1, k++].Value = "OP doc first name";
                    worksheet.Cells[1, k++].Value = "OP doc last name";
                    worksheet.Cells[1, k++].Value = "OP LANR";
                    worksheet.Cells[1, k++].Value = "OP Practice BSNR";
                    worksheet.Cells[1, k++].Value = "OP Practice Name";
                    worksheet.Cells[1, k++].Value = "AC doc first name";
                    worksheet.Cells[1, k++].Value = "AC doc last name";
                    worksheet.Cells[1, k++].Value = "AC LANR";
                    worksheet.Cells[2, k++].Value = "AC Practice BSNR";
                    worksheet.Cells[1, k++].Value = "AC Practice Name";
                    worksheet.Cells[1, k++].Value = "OP1";
                    worksheet.Cells[1, k++].Value = "OP2";
                    worksheet.Cells[1, k++].Value = "OP5";
                    worksheet.Cells[1, k++].Value = "OP6";
                    worksheet.Cells[1, k++].Value = "OP7";
                    worksheet.Cells[1, k++].Value = "OP8";
                    worksheet.Cells[1, k++].Value = "OP10";
                    worksheet.Cells[1, k++].Value = "AC1";
                    worksheet.Cells[1, k++].Value = "AC2";
                    worksheet.Cells[1, k++].Value = "AC6";
                    worksheet.Cells[1, k++].Value = "AC7";
                    worksheet.Cells[1, k++].Value = "AC8";
                    worksheet.Cells[1, k++].Value = "AC9";
                    worksheet.Cells[1, k++].Value = "AC11";
                    worksheet.Cells[1, k++].Value = "OP settlement number";
                    worksheet.Cells[1, k++].Value = "OP GPOS";
                    worksheet.Cells[1, k++].Value = "OP-FS1";
                    worksheet.Cells[1, k++].Value = "OP-FS2";
                    worksheet.Cells[1, k++].Value = "OP-FS4";
                    worksheet.Cells[1, k++].Value = "OP-FS5";
                    worksheet.Cells[1, k++].Value = "OP-FS7";
                    worksheet.Cells[1, k++].Value = "OP-FS8";
                    worksheet.Cells[1, k++].Value = "AC settlement number";
                    worksheet.Cells[1, k++].Value = "AC GPOS";
                    worksheet.Cells[1, k++].Value = "AC-FS1";
                    worksheet.Cells[1, k++].Value = "AC-FS2";
                    worksheet.Cells[1, k++].Value = "AC-FS4";
                    worksheet.Cells[1, k++].Value = "AC-FS5";
                    worksheet.Cells[1, k++].Value = "AC-FS7";
                    worksheet.Cells[1, k++].Value = "AC-FS8";
                    worksheet.Cells[1, k++].Value = "Bevacizumab settlement number";
                    worksheet.Cells[1, k++].Value = "Bevacizumab GPOS";
                    worksheet.Cells[1, k++].Value = "Beva-FS1";
                    worksheet.Cells[1, k++].Value = "Beva-FS2";
                    worksheet.Cells[1, k++].Value = "Beva-FS4";
                    worksheet.Cells[1, k++].Value = "Beva-FS5";
                    worksheet.Cells[1, k++].Value = "Beva-FS7";
                    worksheet.Cells[1, k++].Value = "Beva-FS8";
                    worksheet.Cells[1, k++].Value = "Management fee settlement number";
                    worksheet.Cells[1, k++].Value = "Management fee GPOS";
                    worksheet.Cells[1, k++].Value = "Man-FS1";
                    worksheet.Cells[1, k++].Value = "Man-FS2";
                    worksheet.Cells[1, k++].Value = "Man-FS4";
                    worksheet.Cells[1, k++].Value = "Man-FS5";
                    worksheet.Cells[1, k++].Value = "Man-FS7";
                    worksheet.Cells[1, k++].Value = "Man-FS8";
                    worksheet.Cells[1, k++].Value = "OP primary comment";
                    worksheet.Cells[1, k++].Value = "AC primary comment";
                    worksheet.Cells[1, k++].Value = "Beva primary comment";
                    worksheet.Cells[1, k++].Value = "Man primary comment";
                    worksheet.Cells[1, k++].Value = "OP secondary comment";
                    worksheet.Cells[1, k++].Value = "AC secondary comment";
                    worksheet.Cells[1, k++].Value = "Beva secondary comment";
                    worksheet.Cells[1, k++].Value = "Man secondary comment";
                    worksheet.Cells[1, k++].Value = "Imported";
                    worksheet.Cells[1, k++].Value = "Feedback";
                }

                using (ExcelRange rng = worksheet.Cells["A1:AN1"])
                {
                    rng.Style.Font.Bold = true;
                }
                k = 1;
                int i = 2;
                foreach (var patient in cases)
                {
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");

                    worksheet.Cells[i, k++].Value = patient.patientFirstName;
                    worksheet.Cells[i, k++].Value = patient.patientLastName;
                    worksheet.Cells[i, k++].Value = patient.hip;
                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = patient.treatmentDate;
                    worksheet.Cells[i, k++].Value = patient.drugName;
                    worksheet.Cells[i, k++].Value = patient.pzn;
                    worksheet.Cells[i, k++].Value = patient.icd10;
                    worksheet.Cells[i, k++].Value = patient.localization;
                    worksheet.Cells[i, k++].Value = patient.opDocFirstName;
                    worksheet.Cells[i, k++].Value = patient.opDocLastName;
                    worksheet.Cells[i, k++].Value = patient.opDocLANR;
                    worksheet.Cells[i, k++].Value = patient.treatmentPractice.BSNR;
                    worksheet.Cells[i, k++].Value = patient.treatmentPractice.Name;
                    worksheet.Cells[i, k++].Value = patient.acDocFirstName;
                    worksheet.Cells[i, k++].Value = patient.acDocLastName;
                    worksheet.Cells[i, k++].Value = patient.acDocLANR;
                    worksheet.Cells[i, k++].Value = patient.aftercarePractice.BSNR;
                    worksheet.Cells[i, k++].Value = patient.aftercarePractice.Name;
                    worksheet.Cells[i, k++].Value = patient.op1;
                    worksheet.Cells[i, k++].Value = patient.op2;
                    worksheet.Cells[i, k++].Value = patient.op5;
                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = patient.op6;
                    worksheet.Cells[i, k++].Value = patient.op7;
                    worksheet.Cells[i, k++].Value = patient.op8;
                    worksheet.Cells[i, k++].Value = patient.op10;
                    worksheet.Cells[i, k++].Value = patient.ac1;
                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = patient.ac2;
                    worksheet.Cells[i, k++].Value = patient.ac6;
                    worksheet.Cells[i, k++].Value = patient.ac7;
                    worksheet.Cells[i, k++].Value = patient.ac8;
                    worksheet.Cells[i, k++].Value = patient.ac9;
                    worksheet.Cells[i, k++].Value = patient.ac11;
                    worksheet.Cells[i, k++].Value = patient.opSettlementNumber;
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.gpos;//
                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.fs1;
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.fs2;
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.fs4;
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.fs5;
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.fs7;
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.fs8;
                    worksheet.Cells[i, k++].Value = patient.acSettlementNumber;
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.gpos;//
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.fs1;
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.fs2;
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.fs4;
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.fs5;
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.fs7;
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.fs8;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabSettlementNumber;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.gpos;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.fs1;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.fs2;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.fs4;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.fs5;
                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.fs7;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.fs8;
                    worksheet.Cells[i, k++].Value = patient.managementFeeSettlementNumber;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.gpos;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.fs1;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.fs2;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.fs4;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.fs5;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.fs7;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.fs8;
                    worksheet.Cells[i, k++].Value = patient.comments.opPrimaryComment;
                    worksheet.Cells[i, k++].Value = patient.comments.acPrimaryComment;
                    worksheet.Cells[i, k++].Value = patient.comments.bevaPrimaryComment;
                    worksheet.Cells[i, k++].Value = patient.comments.manPrimaryComment;
                    Console.Write(".");
                    worksheet.Cells[i, k++].Value = patient.comments.opSecondaryComment;
                    worksheet.Cells[i, k++].Value = patient.comments.acSecondaryComment;
                    worksheet.Cells[i, k++].Value = patient.comments.bevaSecondaryComment;
                    worksheet.Cells[i, k++].Value = patient.comments.manSecondaryComment;
                    worksheet.Cells[i, k++].Value = !cases.Any(cas => !cas.isValid);
                    worksheet.Cells[i, k++].Value = patient.validationMessages;

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
