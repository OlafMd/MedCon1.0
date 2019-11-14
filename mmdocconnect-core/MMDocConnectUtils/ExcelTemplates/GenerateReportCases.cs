using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Web;
using OfficeOpenXml;

namespace MMDocConnectUtils.ExcelTemplates
{
    public static class GenerateReportCases
    {
        public static string CreateCaseXlsReport(List<CaseForReportModel> cases, string filename)
        {


            string path = Path.GetTempPath();
            FileInfo file = new FileInfo(path + filename + ".xlsx");

            var package = new ExcelPackage(file);
            // add a new worksheet to the empty workbook
            if (package.Workbook.Worksheets.FirstOrDefault(w => w.Name == "Tabelle1") != null)
            {
                package.Workbook.Worksheets.Delete("Tabelle1");
            }


            var col = 1;
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");
            // --------- Data and styling goes here -------------- // 
            if (cases != null)
            {//Patientendaten
                worksheet.Cells[2, col++].Value = "Krankenkasse";
                worksheet.Cells[2, col++].Value = "Versicherrungsnummer";
                worksheet.Cells[2, col++].Value = "Versicherrungsstatus";
                worksheet.Cells[2, col++].Value = "Vorname";
                worksheet.Cells[2, col++].Value = "Nachname";
                worksheet.Cells[2, col++].Value = "geb.am.";
                worksheet.Cells[2, col++].Value = "Anrede";
                worksheet.Cells[2, col++].Value = "Teilnahmeerklärung gültig bis";
                col++;

                //Vorgang
                worksheet.Cells[2, col++].Value = "Vorgangsnummer";
                worksheet.Cells[2, col++].Value = "Typ";
                worksheet.Cells[2, col++].Value = "Medikament";
                worksheet.Cells[2, col++].Value = "Diagnose";
                worksheet.Cells[2, col++].Value = "Code";
                worksheet.Cells[2, col++].Value = "Lokalisation";
                worksheet.Cells[2, col++].Value = "Behandlungsnummer";
                worksheet.Cells[2, col++].Value = "GPOS";
                worksheet.Cells[2, col++].Value = "Behandlungsdatum";
                worksheet.Cells[2, col++].Value = "OP-Behandlungsdatum";
                worksheet.Cells[2, col++].Value = "aktueller Prozess-Status";
                worksheet.Cells[2, col++].Value = "Datum des aktuellen Status";
                worksheet.Cells[2, col++].Value = "vorheriger Prozess-Status";
                worksheet.Cells[2, col++].Value = "Datum des vorherigen Status";
                col++;

                //Abrechnung
                worksheet.Cells[2, col++].Value = "Abrechnungsnummer";
                worksheet.Cells[2, col++].Value = "Summe [€]";
                worksheet.Cells[2, col++].Value = "Übermittlungsnummer";
                worksheet.Cells[2, col++].Value = "Übermittlungsdatum";
                worksheet.Cells[2, col++].Value = "Rückmeldung";
                worksheet.Cells[2, col++].Value = "Zahlungsdatum";
                col++;
#if BESTELLDATEN
                //Bestellung
                worksheet.Cells[2, col++].Value = "Medikament bestellt";
                worksheet.Cells[2, col++].Value = "Gebührenbefreit";
                worksheet.Cells[2, col++].Value = "Rechnung an Praxis";
                worksheet.Cells[2, col++].Value = "Nur Etikett liefern";
                worksheet.Cells[2, col++].Value = "Managementpauschale";
                col++;
#endif
                //Arztdaten
                worksheet.Cells[2, col++].Value = "BSNR";
                worksheet.Cells[2, col++].Value = "Praxisname";
                worksheet.Cells[2, col++].Value = "LANR";
                worksheet.Cells[2, col++].Value = "Behandelnder Arzt";
                worksheet.Cells[2, col++].Value = "Kontoinhaber";
                worksheet.Cells[2, col++].Value = "Kreditinstitut";
                worksheet.Cells[2, col++].Value = "IBAN";
                worksheet.Cells[2, col++].Value = "BIC";

                using (ExcelRange rng = worksheet.Cells["A1:AS1"])
                {
                    rng.Style.Font.Bold = true;
                }
                using (ExcelRange rng = worksheet.Cells["A2:AS2"])
                {
                    rng.Style.Font.Bold = true;
                    rng.AutoFilter = true;
                }
                using (ExcelRange rng = worksheet.Cells["A1:H1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(189, 215, 238));
                    rng.Merge = true;
                    rng.Value = "Patientendaten";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                using (ExcelRange rng = worksheet.Cells["J1:W1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(252, 213, 180));
                    rng.Merge = true;
                    rng.Value = "Vorgang";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                using (ExcelRange rng = worksheet.Cells["Y1:AD1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(216, 228, 188));
                    rng.Merge = true;
                    rng.Value = "Abrechnung";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

#if BESTELLDATEN
                using (ExcelRange rng = worksheet.Cells["AF1:AJ1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    rng.Merge = true;
                    rng.Value = "Bestellung";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                using (ExcelRange rng = worksheet.Cells["AL1:AS1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 184, 183));
                    rng.Merge = true;
                    rng.Value = "Arztdaten";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
#else
                using (ExcelRange rng = worksheet.Cells["AF1:AN1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 184, 183));
                    rng.Merge = true;
                    rng.Value = "Arztdaten";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

#endif
                int i = 3;

                foreach (var item in cases)
                {
                    col = 1;
#region Patient info
                    worksheet.Cells[i, col++].Value = item.HIP;
                    worksheet.Cells[i, col++].Value = item.PatientInsuranceNumber;
                    worksheet.Cells[i, col++].Value = item.PatientStatusNumber;
                    worksheet.Cells[i, col++].Value = item.PatientFirstName;
                    worksheet.Cells[i, col++].Value = item.PatientLastName;

                    if (item.PatientBirthday == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.PatientBirthday;
                    }

                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
                    worksheet.Cells[i, col++].Value = item.PatientSalutation;

                    if (item.PatientParticipationConsentValidUntil == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else if (item.PatientParticipationConsentValidUntil == DateTime.MaxValue) 
                    {
                        worksheet.Cells[i, col].Value = "∞";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.PatientParticipationConsentValidUntil;
                    }

                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
#endregion
                    col++;

#region Vorgang
                    worksheet.Cells[i, col++].Value = item.CaseNumber;
                    worksheet.Cells[i, col++].Value = item.CaseType;
                    worksheet.Cells[i, col++].Value = item.Drug;
                    if (item.Diagnose == "neovaskuläre (feuchte) altersabhängige Makuladegeneration")
                    {
                        worksheet.Cells[i, col++].Value = "AMD (fcht)";
                    }
                    else if (item.Diagnose == "Makulaödem nach venösem Netzhautgefäßverschluss")
                    {
                        worksheet.Cells[i, col++].Value = "Mö nvNhgv";
                    }
                    else
                    {
                        worksheet.Cells[i, col++].Value = item.Diagnose;
                    }
                    
                    worksheet.Cells[i, col++].Value = item.DiagnoseCode;
                    worksheet.Cells[i, col++].Value = item.Localization;
                    worksheet.Cells[i, col++].Value = item.TreatmentCount;
                    worksheet.Cells[i, col++].Value = item.GPOS;
                    if (item.TreatmentDay == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.TreatmentDay;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";

                    if (item.SurgeryDateForThisCase == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.SurgeryDateForThisCase;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";

                    worksheet.Cells[i, col++].Value = item.CurrentStatus;
                    if (item.DateOfCurrentStatus == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.DateOfCurrentStatus;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
                    worksheet.Cells[i, col++].Value = item.PreCurrentStatus;
                    if (item.DateOfPreCurrentStatus == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.DateOfPreCurrentStatus;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
#endregion

                    col++;

#region Abrechnung
                    worksheet.Cells[i, col++].Value = item.InvoiceNumberForTheHIP == 0 ? "-" : item.InvoiceNumberForTheHIP.ToString();
                    worksheet.Cells[i, col++].Value = item.AmountForThisGPOS;
                    worksheet.Cells[i, col++].Value = item.NumberOfNegativeTry;
                    if (item.DateOfTheSubmissionToTheHIP == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.DateOfTheSubmissionToTheHIP;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
                    if (item.FeedBackOfTheHIP == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.FeedBackOfTheHIP;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
                    if (item.PaymentDate == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.PaymentDate;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
#endregion

                    col++;

#if BESTELLDATEN

                    worksheet.Cells[i, col++].Value = item.DrugOrdered;
                    worksheet.Cells[i, col++].Value = item.NoFee;
                    worksheet.Cells[i, col++].Value = item.InvoiceToPractice;
                    worksheet.Cells[i, col++].Value = item.OnlyLabelRequired;
                    worksheet.Cells[i, col++].Value = item.ManagementFee;
                    col++;
#endif


#region  Arztdaten
                    worksheet.Cells[i, col++].Value = item.BSNR;
                    worksheet.Cells[i, col++].Value = item.PracticeName;
                    worksheet.Cells[i, col++].Value = item.LANR;
                    worksheet.Cells[i, col++].Value = item.DocName;
                    worksheet.Cells[i, col++].Value = item.BankAccountHolder;
                    worksheet.Cells[i, col++].Value = item.BankName;
                    worksheet.Cells[i, col++].Value = item.IBAN;
                    worksheet.Cells[i, col++].Value = item.BIC;
#endregion

                    i++;
                }

                worksheet.View.FreezePanes(3, 7);
                //worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                for (var columnIndex = 1; columnIndex < worksheet.Dimension.End.Column; columnIndex++)
                {
                    worksheet.Column(columnIndex).Width = 11;
                }

            }

            try
            {
                package.Save();     // Olaf: Ausserhalb der if-Bedingung
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                package.Dispose();
            }
            return file.FullName;

        }
    }
}
