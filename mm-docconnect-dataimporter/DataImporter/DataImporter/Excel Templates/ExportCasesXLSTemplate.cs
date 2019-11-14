using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
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
    public static class ExportCasesXLSTemplate
    {
        public static string ExportCasesBeforeUploadToDB(List<CaseModel> cases)
        {
            //string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            string fname = "/export_cases_from_the_old_system.xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fname;
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            Console.WriteLine("You can find xls file here: " + filename);
            FileInfo file = new FileInfo(filename);

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
                    worksheet.Cells[1, k++].Value = "AC Practice BSNR";
                    worksheet.Cells[1, k++].Value = "AC Practice Name";
                    worksheet.Cells[1, k++].Value = "OP1";
                    worksheet.Cells[1, k++].Value = "OP2";
                    worksheet.Cells[2, k++].Value = "OP5";
                    worksheet.Cells[2, k++].Value = "OP6";
                    worksheet.Cells[2, k++].Value = "OP7";
                    worksheet.Cells[2, k++].Value = "OP8";
                    worksheet.Cells[2, k++].Value = "OP10";
                    worksheet.Cells[2, k++].Value = "AC1";
                    worksheet.Cells[2, k++].Value = "AC2";
                    worksheet.Cells[2, k++].Value = "AC6";
                    worksheet.Cells[2, k++].Value = "AC7";
                    worksheet.Cells[2, k++].Value = "AC8";
                    worksheet.Cells[2, k++].Value = "AC9";
                    worksheet.Cells[2, k++].Value = "AC11";
                    worksheet.Cells[2, k++].Value = "OP settlement number";
                    worksheet.Cells[2, k++].Value = "OP GPOS";
                    worksheet.Cells[2, k++].Value = "OP-FS1";
                    worksheet.Cells[2, k++].Value = "OP-FS2";
                    worksheet.Cells[2, k++].Value = "OP-FS4";
                    worksheet.Cells[2, k++].Value = "OP-FS5";
                    worksheet.Cells[2, k++].Value = "OP-FS7";
                    worksheet.Cells[2, k++].Value = "OP-FS8";
                    worksheet.Cells[2, k++].Value = "AC settlement number";
                    worksheet.Cells[2, k++].Value = "AC GPOS";
                    worksheet.Cells[2, k++].Value = "AC-FS1";
                    worksheet.Cells[2, k++].Value = "AC-FS2";
                    worksheet.Cells[2, k++].Value = "AC-FS4";
                    worksheet.Cells[2, k++].Value = "AC-FS5";
                    worksheet.Cells[2, k++].Value = "AC-FS7";
                    worksheet.Cells[2, k++].Value = "AC-FS8";
                    worksheet.Cells[2, k++].Value = "Bevacizumab settlement number";
                    worksheet.Cells[2, k++].Value = "Bevacizumab GPOS";
                    worksheet.Cells[2, k++].Value = "Beva-FS1";
                    worksheet.Cells[2, k++].Value = "Beva-FS2";
                    worksheet.Cells[2, k++].Value = "Beva-FS4";
                    worksheet.Cells[2, k++].Value = "Beva-FS5";
                    worksheet.Cells[2, k++].Value = "Beva-FS7";
                    worksheet.Cells[2, k++].Value = "Beva-FS8";
                    worksheet.Cells[2, k++].Value = "Management fee settlement number";
                    worksheet.Cells[2, k++].Value = "Management fee GPOS";
                    worksheet.Cells[2, k++].Value = "Man-FS1";
                    worksheet.Cells[2, k++].Value = "Man-FS2";
                    worksheet.Cells[2, k++].Value = "Man-FS4";
                    worksheet.Cells[2, k++].Value = "Man-FS5";
                    worksheet.Cells[2, k++].Value = "Man-FS7";
                    worksheet.Cells[2, k++].Value = "Man-FS8";
                    worksheet.Cells[2, k++].Value = "OP primary comment";
                    worksheet.Cells[2, k++].Value = "AC primary comment";
                    worksheet.Cells[2, k++].Value = "Beva pimary comment";
                    worksheet.Cells[2, k++].Value = "Man primary comment";
                    worksheet.Cells[2, k++].Value = "OP secondary comment";
                    worksheet.Cells[2, k++].Value = "AC secondary comment";
                    worksheet.Cells[2, k++].Value = "Beva secondary comment";
                    worksheet.Cells[2, k++].Value = "Man secondary comment";
                }

                using (ExcelRange rng = worksheet.Cells["A2:AV2"])
                {
                    rng.Style.Font.Bold = true;
                }
                k = 1;
                int i = 2;
                foreach (var patient in cases)
                {
                    worksheet.Cells[i, k++].Value = patient.patientFirstName;
                    worksheet.Cells[i, k++].Value = patient.patientLastName;
                    worksheet.Cells[i, k++].Value = patient.hip;
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
                    worksheet.Cells[i, k++].Value = patient.op6;
                    worksheet.Cells[i, k++].Value = patient.op7;
                    worksheet.Cells[i, k++].Value = patient.op8;
                    worksheet.Cells[i, k++].Value = patient.op10;
                    worksheet.Cells[i, k++].Value = patient.ac1;
                    worksheet.Cells[i, k++].Value = patient.ac2;
                    worksheet.Cells[i, k++].Value = patient.ac6;
                    worksheet.Cells[i, k++].Value = patient.ac7;
                    worksheet.Cells[i, k++].Value = patient.ac8;
                    worksheet.Cells[i, k++].Value = patient.ac9;
                    worksheet.Cells[i, k++].Value = patient.ac11;
                    worksheet.Cells[i, k++].Value = patient.opSettlementNumber;
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.gpos;//
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
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.primaryComment;
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.primaryComment;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.primaryComment;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.primaryComment;
                    worksheet.Cells[i, k++].Value = patient.opFSStatuses.secondaryComment;
                    worksheet.Cells[i, k++].Value = patient.acFSStatuses.secondaryComment;
                    worksheet.Cells[i, k++].Value = patient.bevacizumabFSStatuses.secondaryComment;
                    worksheet.Cells[i, k++].Value = patient.managementFeeFSStatuses.secondaryComment;
                    i++;
                    k = 1;
                }
                worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                package.Save();
            }
            System.IO.File.Copy(filename, path, true);
            Console.WriteLine("You can find xls file on your desktop, named: " + fname);
            return file.FullName;
        }

        public static string ExportCasesMoreThenOneArticle(List<ED_GATOS_1212> cases)
        {
            //string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            string fname = "/cases_with_more_than_one_article.xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fname;
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            Console.WriteLine("You can find xls file here: " + filename);
            FileInfo file = new FileInfo(filename);

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

                worksheet.Cells[1, 1].Value = "CASES THAT HAVE MORE THEN ONE ARTICLE FOR TREATMENT";
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                int k = 1;
                if (cases != null)
                {
                    worksheet.Cells[2, k++].Value = "Treatment ID";
                    worksheet.Cells[2, k++].Value = "Patient First name";
                    worksheet.Cells[2, k++].Value = "Patient Last name";
                    worksheet.Cells[2, k++].Value = "Patient HIP number";
                    worksheet.Cells[2, k++].Value = "isTreatmentPerformed";
                    worksheet.Cells[2, k++].Value = "treatment date";
                    worksheet.Cells[2, k++].Value = "Doctor first name";
                    worksheet.Cells[2, k++].Value = "Doctor last name";
                    worksheet.Cells[2, k++].Value = "Doctor LANR";
                    worksheet.Cells[2, k++].Value = "Drug name";
                    worksheet.Cells[2, k++].Value = "PZN / Schema";

                }

                using (ExcelRange rng = worksheet.Cells["A2:K2"])
                {
                    rng.Style.Font.Bold = true;
                }
                k = 1;
                int i = 3;
                foreach (var patient in cases)
                {
                    worksheet.Cells[i, k++].Value = patient.HEC_Patient_TreatmentID.ToString();
                    worksheet.Cells[i, k++].Value = patient.PatientFirstName;
                    worksheet.Cells[i, k++].Value = patient.PatientLastName;
                    worksheet.Cells[i, k++].Value = patient.HealthInsurance_Number;
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed;
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed ? patient.treatmentPerformedDate.ToString("dd.MM.yyyy") : patient.treatmentScheduledDate.ToString("dd.MM.yyyy");
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed?patient.OPperformedDoctorFirstName:patient.OPScheduledDoctorFirstName;
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed ? patient.OPperformedDoctorLastName : patient.OPScheduledDoctorLastName;
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed ? patient.OPperformedDoctorLANR : patient.OPscheduledDoctorLANR;

                    int h = k+1;
                    foreach (var drug in patient.Articles)
                    {
                        worksheet.Cells[i, k].Value = drug.ArticleName;
                        worksheet.Cells[i, h].Value = drug.PZN;
                        i++;
                    }

                    i++;
                    k = 1;
                }
                worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                package.Save();
            }
            System.IO.File.Copy(filename, path, true);
            Console.WriteLine("You can find xls file on your desktop, named: " + fname);
            return file.FullName;
        }

        public static string ExportCasesMoreThenOneDiagnose(List<ED_GATOS_1212> cases)
        {
            //string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            string fname = "/cases_with_more_than_one_diagnose.xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fname;
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            Console.WriteLine("You can find xls file here: " + filename);
            FileInfo file = new FileInfo(filename);

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

                worksheet.Cells[1, 1].Value = "CASES THAT HAVE MORE THEN ONE DIAGNOSE FOR TREATMENT";
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                int k = 1;
                if (cases != null)
                {
                    worksheet.Cells[2, k++].Value = "Treatment ID";
                    worksheet.Cells[2, k++].Value = "Patient First name";
                    worksheet.Cells[2, k++].Value = "Patient Last name";
                    worksheet.Cells[2, k++].Value = "Patient HIP number";
                    worksheet.Cells[2, k++].Value = "isTreatmentPerformed";
                    worksheet.Cells[2, k++].Value = "treatment date";
                    worksheet.Cells[2, k++].Value = "Doctor first name";
                    worksheet.Cells[2, k++].Value = "Doctor last name";
                    worksheet.Cells[2, k++].Value = "Doctor LANR";
                    worksheet.Cells[2, k++].Value = "Diagnose icd10 code";
                    worksheet.Cells[2, k++].Value = "Diagnosed on date";
                }

                using (ExcelRange rng = worksheet.Cells["A2:AN2"])
                {
                    rng.Style.Font.Bold = true;
                }
                k = 1;
                int i = 3;
                foreach (var patient in cases)
                {
                    worksheet.Cells[i, k++].Value = patient.HEC_Patient_TreatmentID.ToString();
                    worksheet.Cells[i, k++].Value = patient.PatientFirstName;
                    worksheet.Cells[i, k++].Value = patient.PatientLastName;
                    worksheet.Cells[i, k++].Value = patient.HealthInsurance_Number;
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed;
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed ? patient.treatmentPerformedDate.ToString("dd.MM.yyyy") : patient.treatmentScheduledDate.ToString("dd.MM.yyyy");
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed ? patient.OPperformedDoctorFirstName : patient.OPScheduledDoctorFirstName;
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed ? patient.OPperformedDoctorLastName : patient.OPperformedDoctorLastName;
                    worksheet.Cells[i, k++].Value = patient.isTreatmentPerformed ? patient.OPperformedDoctorLANR : patient.OPperformedDoctorLANR;
                    

                    int h = k + 1;
                    foreach (var drug in patient.Diagnoses)
                    {
                        worksheet.Cells[i, k].Value = drug.ICD10_Code;
                        worksheet.Cells[i, h].Value = drug.diagnnoseID.ToString("dd.MM.yyyy");
                        i++;
                    }

                    i++;
                    k = 1;
                }
                worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                package.Save();
            }
            System.IO.File.Copy(filename, path, true);
            Console.WriteLine("You can find xls file on your desktop, named: " + fname);
            return file.FullName;
        }

        public static string ExportCasesMoreThenOneAftercare(List<ED_GATOS_1212> cases, Dictionary<Guid, List<ED_GAAOS_1312>> aftercarDictionaryForMoreThenOneAftercare)
        {
            //string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            string fname = "/cases_with_more_than_one_aftercare.xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fname;
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            FileInfo file = new FileInfo(filename);

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

                worksheet.Cells[1, 1].Value = "CASES THAT HAVE MORE THEN ONE AFTERCARE FOR TREATMENT";
                worksheet.Cells[1, 1].Style.Font.Size = 20;
                int k = 1;
                if (cases != null)
                {
                    worksheet.Cells[2, k++].Value = "Treatment ID";
                    worksheet.Cells[2, k++].Value = "Patient First name";
                    worksheet.Cells[2, k++].Value = "Patient Last name";
                    worksheet.Cells[2, k++].Value = "Patient HIP number";
                    worksheet.Cells[2, k++].Value = "isTreatmentPerformed";
                    worksheet.Cells[2, k++].Value = "treatment date";
                    worksheet.Cells[2, k++].Value = "Doctor first name";
                    worksheet.Cells[2, k++].Value = "Doctor last name";
                    worksheet.Cells[2, k++].Value = "Doctor LANR";
                    worksheet.Cells[2, k++].Value = "Aftercare ID";
                    worksheet.Cells[2, k++].Value = "Aftercare Scheduled Date";
                    worksheet.Cells[2, k++].Value = "isAftercare Performed";
                    worksheet.Cells[2, k++].Value = "Aftercare Performed Date";
                    worksheet.Cells[2, k++].Value = "isAftercare Billed";
                    worksheet.Cells[2, k++].Value = "Aftercare Doctor First Name (if performed - performed doctor else scheduled doctor)";
                    worksheet.Cells[2, k++].Value = "Aftercare Doctor Last Name";
                    worksheet.Cells[2, k++].Value = "Aftercare Doctor LANR Name";
                }

                using (ExcelRange rng = worksheet.Cells["A2:K2"])
                {
                    rng.Style.Font.Bold = true;
                }
                k = 1;
                int i = 3;
                foreach (var item in cases)
                {
                    worksheet.Cells[i, k++].Value = item.HEC_Patient_TreatmentID.ToString();
                    worksheet.Cells[i, k++].Value = item.PatientFirstName;
                    worksheet.Cells[i, k++].Value = item.PatientLastName;
                    worksheet.Cells[i, k++].Value = item.HealthInsurance_Number;
                    worksheet.Cells[i, k++].Value = item.isTreatmentPerformed;
                    worksheet.Cells[i, k++].Value = item.isTreatmentPerformed ? item.treatmentPerformedDate.ToString("dd.MM.yyyy") : item.treatmentScheduledDate.ToString("dd.MM.yyyy");
                    worksheet.Cells[i, k++].Value = item.isTreatmentPerformed ? item.OPperformedDoctorFirstName : item.OPScheduledDoctorFirstName;
                    worksheet.Cells[i, k++].Value = item.isTreatmentPerformed ? item.OPperformedDoctorLastName : item.OPScheduledDoctorLastName;
                    worksheet.Cells[i, k++].Value = item.isTreatmentPerformed ? item.OPperformedDoctorLANR : item.OPscheduledDoctorLANR;

                    int h = k + 1;

                    var aftercareList = aftercarDictionaryForMoreThenOneAftercare[item.HEC_Patient_TreatmentID];


                    foreach (var aftercare in aftercareList)
                    {
                        worksheet.Cells[i, k].Value = aftercare.FollowupID;
                        worksheet.Cells[i, h++].Value = aftercare.IfSheduled_Date.ToString("dd.MM.yyyy");
                        worksheet.Cells[i, h++].Value = aftercare.isTreatmentPerformed;
                        worksheet.Cells[i, h++].Value = aftercare.IfTreatmentPerformed_Date.ToString("dd.MM.yyyy");
                        worksheet.Cells[i, h++].Value = aftercare.isTreatmentBilled;
                        worksheet.Cells[i, h++].Value = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorFirstName : aftercare.ScheduledDoctorFirstName;
                        worksheet.Cells[i, h++].Value = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorLastName : aftercare.ScheduledDoctorLastName;
                        worksheet.Cells[i, h++].Value = aftercare.isTreatmentPerformed ? aftercare.PerformedDoctorLANR : aftercare.ScheduledDoctorLANR;
                        h = k + 1;
                        i++;
                    }

                    i++;
                    k = 1;
                }
                worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                package.Save();
            }
            
            System.IO.File.Copy(filename, path, true);
            Console.WriteLine("You can find xls file on your desktop, named: " + fname);
            return file.FullName;
        }
    }
}
