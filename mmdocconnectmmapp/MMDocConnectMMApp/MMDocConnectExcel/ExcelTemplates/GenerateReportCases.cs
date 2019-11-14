using MMDocConnectDocAppModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Web;

namespace MMDocConnectExcell.ExcelTemplates
{
    public static class GenerateReportCases
    {
        public static string CreateCaseXlsReport(List<CaseForReportModel> cases, string filename)
        {


            string path = System.IO.Path.GetTempPath();
            FileInfo file = new FileInfo(path + filename + ".xls");
            //List<string> log = new List<string>();
            //log.Add(path + filename + ".xls");
         

            //using (StreamWriter _testData = new StreamWriter(HttpContext.Current.Server.MapPath("~/log.txt"), true))
            //{
            //    foreach (var _log in log)
            //        _testData.WriteLine(_log);
            //}
           // try
           // {

                using (var package = new ExcelPackage(file))
                {
                    // add a new worksheet to the empty workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");
                    // --------- Data and styling goes here -------------- // 
                    if (cases != null)
                    {//Patientendaten
                        worksheet.Cells[2, 1].Value = "Krankenkasse";
                        worksheet.Cells[2, 2].Value = "Versicherrungsnummer";
                        worksheet.Cells[2, 3].Value = "Versicherrungsstatus";
                        worksheet.Cells[2, 4].Value = "Vorname";
                        worksheet.Cells[2, 5].Value = "Nachname";
                        worksheet.Cells[2, 6].Value = "geb.am.";
                        worksheet.Cells[2, 7].Value = "Teilnahmeerklärung gültig bis";

                        //Vorgang
                        worksheet.Cells[2, 9].Value = "Vorgangsnummer";
                        worksheet.Cells[2, 10].Value = "Typ";
                        worksheet.Cells[2, 11].Value = "Medikament";
                        worksheet.Cells[2, 12].Value = "Diagnose";
                        worksheet.Cells[2, 13].Value = "Code";
                        worksheet.Cells[2, 14].Value = "Lokalisation";
                        worksheet.Cells[2, 15].Value = "Behandlungsnummer";
                        worksheet.Cells[2, 16].Value = "GPOS";
                        worksheet.Cells[2, 17].Value = "Behandlungsdatum";
                        worksheet.Cells[2, 18].Value = "OP-Behandlungsdatum";
                        worksheet.Cells[2, 19].Value = "aktueller Prozess-Status";
                        worksheet.Cells[2, 20].Value = "Datum des aktuellen Status";
                        worksheet.Cells[2, 21].Value = "vorheriger Prozess-Status";
                        worksheet.Cells[2, 22].Value = "Datum des vorherigen Status";

                        //Abrechnung
                        worksheet.Cells[2, 24].Value = "Abrechnungsnummer";
                        worksheet.Cells[2, 25].Value = "Summe [€]";
                        worksheet.Cells[2, 26].Value = "Übermittlungsnummer";
                        worksheet.Cells[2, 27].Value = "Übermittlungsdatum";
                        worksheet.Cells[2, 28].Value = "Rückmeldung";
                        worksheet.Cells[2, 29].Value = "Zahlungsdatum";

                        //Bestellung
                        worksheet.Cells[2, 31].Value = "Medikament bestellt";
                        worksheet.Cells[2, 32].Value = "Gebührenbefreit";
                        worksheet.Cells[2, 33].Value = "Rechnung an Praxis";
                        worksheet.Cells[2, 34].Value = "Nur Etikett liefern";
                        worksheet.Cells[2, 35].Value = "Managementpauschale";

                        //Arztdaten
                        worksheet.Cells[2, 37].Value = "BSNR";
                        worksheet.Cells[2, 38].Value = "Praxisname";
                        worksheet.Cells[2, 39].Value = "LANR";
                        worksheet.Cells[2, 40].Value = "Behandelnder Arzt";
                        worksheet.Cells[2, 41].Value = "Kontoinhaber";
                        worksheet.Cells[2, 42].Value = "Kreditinstitut";
                        worksheet.Cells[2, 43].Value = "IBAN";
                        worksheet.Cells[2, 44].Value = "BIC";

                        using (ExcelRange rng = worksheet.Cells["A1:AR1"])
                        {
                            rng.Style.Font.Bold = true;
                        }
                        using (ExcelRange rng = worksheet.Cells["A2:AR2"])
                        {
                            rng.Style.Font.Bold = true;
                        }
                        using (ExcelRange rng = worksheet.Cells["A1:G1"])
                        {
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));
                            rng.Merge = true;
                            rng.Value = "Patientendaten";
                            rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        using (ExcelRange rng = worksheet.Cells["I1:V1"])
                        {
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(252, 213, 180));
                            rng.Merge = true;
                            rng.Value = "Vorgang";
                            rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }
                        using (ExcelRange rng = worksheet.Cells["X1:AC1"])
                        {
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(216, 228, 188));
                            rng.Merge = true;
                            rng.Value = "Abrechnung";
                            rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        }

                        using (ExcelRange rng = worksheet.Cells["AE1:AI1"])
                        {
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                            rng.Merge = true;
                            rng.Value = "Bestellung";
                            rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }
                        using (ExcelRange rng = worksheet.Cells["AK1:AR1"])
                        {
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 184, 183));
                            rng.Merge = true;
                            rng.Value = "Arztdaten";
                            rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        int i = 3;
                        foreach (var item in cases)
                        {

                            worksheet.Cells[i, 1].Value = item.HIP;
                            worksheet.Cells[i, 2].Value = item.PatientInsuranceNumber;
                            worksheet.Cells[i, 3].Value = item.PatientStatusNumber;
                            worksheet.Cells[i, 4].Value = item.PatientFirstName;
                            worksheet.Cells[i, 5].Value = item.PatientLastName;
                            worksheet.Cells[i, 6].Value = item.PatientBirthday;
                            worksheet.Cells[i, 7].Value = item.PatientParticipationConsentValidUntil;

                            worksheet.Cells[i, 9].Value = item.CaseNumber;
                            worksheet.Cells[i, 10].Value = item.CaseType;
                            worksheet.Cells[i, 11].Value = item.Drug;
                            worksheet.Cells[i, 12].Value = item.Diagnose;
                            worksheet.Cells[i, 13].Value = item.DiagnoseCode;
                            worksheet.Cells[i, 14].Value = item.Localization;
                            worksheet.Cells[i, 15].Value = item.TreatmentCount;
                            worksheet.Cells[i, 16].Value = item.GPOS;
                            worksheet.Cells[i, 17].Value = item.TreatmentDay;
                            worksheet.Cells[i, 18].Value = item.SurgeryDateForThisCase;
                            worksheet.Cells[i, 19].Value = item.CurrentStatus;
                            worksheet.Cells[i, 20].Value = item.DateOfCurrentStatus;
                            worksheet.Cells[i, 21].Value = item.PreCurrentStatus;
                            worksheet.Cells[i, 22].Value = item.DateOfPreCurrentStatus;

                            worksheet.Cells[i, 24].Value = item.InvoiceNumberForTheHIP;
                            worksheet.Cells[i, 25].Value = item.AmountForThisGPOS;
                            worksheet.Cells[i, 26].Value = item.NumberOfNegativeTry;
                            worksheet.Cells[i, 27].Value = item.DateOfTheSubmissionToTheHIP;
                            worksheet.Cells[i, 28].Value = item.FeedBackOfTheHIP;
                            worksheet.Cells[i, 29].Value = item.PaymentDate;

                            worksheet.Cells[i, 31].Value = item.DrugOrdered;
                            worksheet.Cells[i, 32].Value = item.NoFee;
                            worksheet.Cells[i, 33].Value = item.InvoiceToPractice;
                            worksheet.Cells[i, 34].Value = item.OnlyLabelRequired;
                            worksheet.Cells[i, 35].Value = item.ManagementFee;

                            worksheet.Cells[i, 37].Value = item.BSNR;
                            worksheet.Cells[i, 38].Value = item.PracticeName;
                            worksheet.Cells[i, 39].Value = item.LANR;
                            worksheet.Cells[i, 40].Value = item.DocName;
                            worksheet.Cells[i, 41].Value = item.BankAccountHolder;
                            worksheet.Cells[i, 42].Value = item.BankName;
                            worksheet.Cells[i, 43].Value = item.IBAN;
                            worksheet.Cells[i, 44].Value = item.BIC;

                            i++;
                        }
                        worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                        package.Save();

                    }
                }

            //}
            //catch (Exception ex)
            //{
            //    List<string> logexp = new List<string>();
            //    logexp.Add("GENERAL EXCEPTION");
            //    logexp.Add(ex.StackTrace);
                
            //    using (StreamWriter _testData = new StreamWriter(HttpContext.Current.Server.MapPath("~/log.txt"), true))
            //    {
            //        foreach (var _log in logexp)
            //            _testData.WriteLine(_log);
            //    }
               
            //}

                return file.FullName;
     
        }
    }
}
