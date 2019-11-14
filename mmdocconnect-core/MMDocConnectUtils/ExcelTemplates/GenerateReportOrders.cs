using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocApp.ExcelTemplates
{
    public static class GenerateReportOrders
    {
        public static string CreateOrdersXlsReport(List<OrdersForReportModel> orders, string filename)
        {
            string path = System.IO.Path.GetTempPath();
            FileInfo file = new FileInfo(path + filename + ".xlsx");
            var package = new ExcelPackage(file);
            // add a new worksheet to the empty workbook
            if (package.Workbook.Worksheets.FirstOrDefault(w => w.Name == "Tabelle1") != null)
            {
                package.Workbook.Worksheets.Delete("Tabelle1");
            }
            var col = 1;
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");
            if (orders != null)
            {//Patientendaten
                worksheet.Cells[2, col++].Value = "Krankenkasse";
                worksheet.Cells[2, col++].Value = "Versicherrungsnummer";
                worksheet.Cells[2, col++].Value = "Versicherrungsstatus";
                worksheet.Cells[2, col++].Value = "Vorname";
                worksheet.Cells[2, col++].Value = "Nachname";
                worksheet.Cells[2, col++].Value = "geb.am.";
                worksheet.Cells[2, col++].Value = "Anrede";
                col++;

                //Vorgang
                worksheet.Cells[2, col++].Value = "Vorgangsnummer";
                worksheet.Cells[2, col++].Value = "Bestellungsnummer";
                worksheet.Cells[2, col++].Value = "Typ";
                worksheet.Cells[2, col++].Value = "Medikament";
                worksheet.Cells[2, col++].Value = "PZN";
                worksheet.Cells[2, col++].Value = "OP-Behandlungsdatum";
                worksheet.Cells[2, col++].Value = "Lieferdatum";
                worksheet.Cells[2, col++].Value = "Lieferzeit ab";
                worksheet.Cells[2, col++].Value = "Lieferzeit bis";
                worksheet.Cells[2, col++].Value = "Bestellt am";
                col++;

                //Bestellung
                worksheet.Cells[2, col++].Value = "Apotheke";
                worksheet.Cells[2, col++].Value = "Gebührenbefreit";
                worksheet.Cells[2, col++].Value = "Rechnung an Praxis";
                worksheet.Cells[2, col++].Value = "Nur Etikett liefern";
                worksheet.Cells[2, col++].Value = "Kommentar";
                worksheet.Cells[2, col++].Value = "Header-Kommentar";
                col++;

                //Arztdaten
                worksheet.Cells[2, col++].Value = "Praxisname";
                worksheet.Cells[2, col++].Value = "Behandelnder Arzt";
                worksheet.Cells[2, col++].Value = "Straße";
                worksheet.Cells[2, col++].Value = "Ort";
                worksheet.Cells[2, col++].Value = "PLZ";

                using (ExcelRange rng = worksheet.Cells["A1:AB1"])
                {
                    rng.Style.Font.Bold = true;
                }
                using (ExcelRange rng = worksheet.Cells["A2:AD2"])
                {
                    rng.Style.Font.Bold = true;
                    rng.AutoFilter = true;
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
                using (ExcelRange rng = worksheet.Cells["I1:R1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(252, 213, 180));
                    rng.Merge = true;
                    rng.Value = "Vorgang";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                using (ExcelRange rng = worksheet.Cells["T1:Y1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    rng.Merge = true;
                    rng.Value = "Bestellung";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                using (ExcelRange rng = worksheet.Cells["AA1:AE1"])
                {
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 184, 183));
                    rng.Merge = true;
                    rng.Value = "Arztdaten";
                    rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                int i = 3;
                foreach (var item in orders)
                {
                    col = 1;
                    worksheet.Cells[i, col++].Value = item.HIP;
                    worksheet.Cells[i, col++].Value = item.PatientInsuranceNumber;
                    worksheet.Cells[i, col++].Value = item.PatientStatusNumber;
                    worksheet.Cells[i, col++].Value = item.PatientFirstName;
                    worksheet.Cells[i, col++].Value = item.PatientLastName;
                    if (item.PatientBirthDate == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.PatientBirthDate;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
                    worksheet.Cells[i, col++].Value = item.PatientSalutation;
                    col++;

                    worksheet.Cells[i, col++].Value = item.CaseNumber;
                    worksheet.Cells[i, col++].Value = item.OrderNumber;
                    worksheet.Cells[i, col++].Value = item.OrderType;
                    worksheet.Cells[i, col++].Value = item.DrugName;
                    worksheet.Cells[i, col++].Value = item.Pzn;
                    if (item.TreatmentDate == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.TreatmentDate;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
                    if (item.DeliveryDate == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.DeliveryDate;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";

                    if (item.DeliveryTimeFrom == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.DeliveryTimeFrom;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "HH:mm";

                    if (item.DeliveryTimeTo == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.DeliveryTimeTo;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "HH:mm";
                    if (item.DateOfSubmission == DateTime.MinValue)
                    {
                        worksheet.Cells[i, col].Value = "-";
                    }
                    else
                    {
                        worksheet.Cells[i, col].Value = item.DateOfSubmission;
                    }
                    worksheet.Cells[i, col++].Style.Numberformat.Format = "dd.MM.yyyy";
                    col++;

                    worksheet.Cells[i, col++].Value = item.PharmacyName;
                    worksheet.Cells[i, col++].Value = item.ChargesFee;
                    worksheet.Cells[i, col++].Value = item.PracticeInvoice;
                    worksheet.Cells[i, col++].Value = item.OnlyLabel;
                    worksheet.Cells[i, col++].Value = !String.IsNullOrEmpty(item.OrderComment) ? item.OrderComment : "-";
                    worksheet.Cells[i, col++].Value = !String.IsNullOrEmpty(item.HeaderComment) ? item.HeaderComment : "-";
                    col++;

                    worksheet.Cells[i, col++].Value = item.PracticeName;
                    worksheet.Cells[i, col++].Value = item.TreatmentDoctor;
                    worksheet.Cells[i, col++].Value = item.Street;
                    worksheet.Cells[i, col++].Value = item.City;
                    worksheet.Cells[i, col++].Value = item.Zip;

                    i++;
                }

                //worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                worksheet.View.FreezePanes(3, 7);
                for (var columnIndex = 1; columnIndex < worksheet.Dimension.End.Column; columnIndex++)
                {
                    worksheet.Column(columnIndex).Width = 11;
                }
                package.Save();
            }
            package.Dispose();

            return file.FullName;
        }
    }
}
