using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EdifactInterface;
using System.IO;
using OfficeOpenXml;
using System.Globalization;
using OfficeOpenXml.Style;
using System.Net.Mail;
using CL6_Lucenits_Treatments.Complex.Manipulation;
using System.Drawing;
using CL6_Lucenits_Treatments.Complex.Retrieval;
using CL5_Lucentis_Doctors.Atomic.Retrieval;

namespace CL6_Lucenits_Treatments.Utils
{
    public class ReportUtils
    {
        public static string generateBillTreatmentsXLS(List<ExcelOutput> data, List<L5DO_GDDfLfR_1409> doctorsData)
        {
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            FileInfo file = new FileInfo(filename);
            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");
                
                // --------- Data and styling goes here -------------- //
                if (data != null)
                {
                    worksheet.Cells[1, 1].Value = "Datum, Behandlung";
                    worksheet.Cells[1, 2].Value = "Vorgangsnummer";
                    worksheet.Cells[1, 3].Value = "Vorname, Patient";
                    worksheet.Cells[1, 4].Value = "Nachname, Patient";
                    worksheet.Cells[1, 5].Value = "Artikel";
                    worksheet.Cells[1, 6].Value = "Diagnose";
                    worksheet.Cells[1, 7].Value = "GPOS";
                    worksheet.Cells[1, 8].Value = "Berechnete Summe in EUR";
                    worksheet.Cells[1, 9].Value = "Versicherrungsstatus, Patient";
                    worksheet.Cells[1, 10].Value = "Versicherrungsnummer, Patient";
                    worksheet.Cells[1, 11].Value = "LANR, Arzt";
                    worksheet.Cells[1, 12].Value = "BSNR, Patient";
                    worksheet.Cells[1, 13].Value = "Diagnosesicherheit";
                    worksheet.Cells[1, 14].Value = "Lokalisation";
                    worksheet.Cells[1, 15].Value = "Praxis";
                    worksheet.Cells[1, 16].Value = "Arzt der Nachuntersuchung";
                   
                    worksheet.Cells[1, 17].Value = "Kontoinhaber";
                    worksheet.Cells[1, 18].Value = "BLZ";
                    worksheet.Cells[1, 19].Value = "Konto-Nummer";
                    worksheet.Cells[1, 20].Value = "Kreditinstitut";
                    worksheet.Cells[1, 21].Value = "IBAN";
                    worksheet.Cells[1, 22].Value = "BIC";

                    worksheet.Cells[1, 23].Value = "Nachfolge durchgeführt am";
                    worksheet.Cells[1, 24].Value = "Status der Nachsorge";
                    worksheet.Cells[1, 25].Value = "Behandlung Nr.";
                    worksheet.Cells[1, 26].Value = "Behandlung mit Ozurdex";
                    worksheet.Cells[1, 27].Value = "Behandlung mit Bevacizumab";
                    worksheet.Cells[1, 28].Value = "Übermittelung-Nr.";

                    using (ExcelRange rng = worksheet.Cells["A1:U1"])
                    {
                        rng.Style.Font.Bold = true;   
                    }

                    int i = 2;
                    double sum = 0;

                    foreach (var row in data)
                    {
                        worksheet.Cells[i, 1].Value = row.strDateOfTreatment;
                        worksheet.Cells[i, 2].Value = row.iProcessNumber;
                        worksheet.Cells[i, 3].Value = row.strPatientFirstName;
                        worksheet.Cells[i, 4].Value = row.strPatientLastName;
                        worksheet.Cells[i, 5].Value = row.aiRelevantArticle.strName;
                        worksheet.Cells[i, 6].Value = row.strMainDiagnosis;
                        worksheet.Cells[i, 7].Value = row.strGpos;
                        worksheet.Cells[i, 8].Value = double.Parse(row.strChargedValue.Replace(',', '.'), CultureInfo.InvariantCulture);
                        worksheet.Cells[i, 9].Value = row.strPatientInsuranceState;
                        worksheet.Cells[i, 10].Value = row.strPatientInsuranceNumber;
                        worksheet.Cells[i, 11].Value = row.strDoctorLANR;
                        worksheet.Cells[i, 12].Value = row.strPracticeBSNR;
                        worksheet.Cells[i, 13].Value = row.cDiagnosisState.ToString();
                        worksheet.Cells[i, 14].Value = row.cTreatmentLocalization.ToString();
                        worksheet.Cells[i, 15].Value = row.strFollowupPractice;
                        worksheet.Cells[i, 16].Value = row.strFollowupDoctor;

                        var doctor = doctorsData.FirstOrDefault(x=>x.LANR == row.strDoctorLANR);
                        if (doctor != null)
                        {
                            worksheet.Cells[i, 17].Value = doctor.OwnerText;
                            worksheet.Cells[i, 18].Value = doctor.BankNumber;
                            worksheet.Cells[i, 19].Value = doctor.AccountNumber;
                            worksheet.Cells[i, 20].Value = doctor.BankName;
                            worksheet.Cells[i, 21].Value = doctor.BICCode;
                        }
                        try
                        {
                            worksheet.Cells[i, 22].Value = (DateTime.ParseExact(row.strDateOfFollowup, "MM.dd.yyyy", CultureInfo.InvariantCulture) != DateTime.MinValue) ? row.strDateOfFollowup : "-";
                        }catch(Exception ex)
                        {
                             worksheet.Cells[i, 22].Value = row.strDateOfFollowup;
                        }
                        worksheet.Cells[i, 23].Value = row.strFollowupStatus;
                        worksheet.Cells[i, 24].Value = row.iTreatmentNumber;
                        worksheet.Cells[i, 25].Value = (row.bTreatmentWithOzurdex)? 1 : 0;
                        worksheet.Cells[i, 26].Value = (row.bTreatmentWithBeva) ? 1 : 0;
                        worksheet.Cells[i, 27].Value = row.iBillingID;

                        sum += double.Parse(row.strChargedValue.Replace(',', '.'), CultureInfo.InvariantCulture);
                        i++;
                    }

                    i++;
                    worksheet.Cells[i, 7].Value = "Summe:";
                    worksheet.Cells[i, 8].Value = "=SUM(H2:H" + (i-2) + ")";//sum.ToString("0,00");

                    worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();

                    package.Save();
                }          
            }

            return file.FullName;
        }

        public static string generateReport2SheetXLS(L6TR_GTI_fTR_1816 data)
        {
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            FileInfo file = new FileInfo(filename);
            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet1 = package.Workbook.Worksheets.Add("Details-Daten");
                ExcelWorksheet worksheet2 = package.Workbook.Worksheets.Add("Buchhaltung");
                string dateFormat = "dd/MM/yyyy";
                string priceFormat = "#,##0.00";
                // --------- Data and styling goes here -------------- //
                if (data != null)
                {
                    string header1Key = "A1:F1";
                    worksheet1.Cells[header1Key].Merge = true;
                    worksheet1.Cells[header1Key].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    worksheet1.Cells[header1Key].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet1.Cells[header1Key].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet1.Cells[header1Key].Value = "Patientendaten";
                    worksheet1.Cells[header1Key].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet1.Cells[2, 1].Value = "Versicherrungsstatus";
                    worksheet1.Cells[2, 2].Value = "Versicherrungsnummer";
                    worksheet1.Cells[2, 3].Value = "Krankenkasse";
                    worksheet1.Cells[2, 4].Value = "Vorname";
                    worksheet1.Cells[2, 5].Value = "Nachname";
                    worksheet1.Cells[2, 6].Value = "geb.am.";

                    string header2Key = "H1:S1";
                    worksheet1.Cells[header2Key].Merge = true;
                    worksheet1.Cells[header2Key].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    worksheet1.Cells[header2Key].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet1.Cells[header2Key].Style.Fill.BackgroundColor.SetColor((Color.FromArgb(252, 213, 180)));
                    worksheet1.Cells[header2Key].Value = "Vorgang";
                    worksheet1.Cells[header2Key].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet1.Cells[2, 8].Value = "Vorgangsnummer";
                    worksheet1.Cells[2, 9].Value = "Typ";
                    worksheet1.Cells[2, 10].Value = "GPOS";
                    worksheet1.Cells[2, 11].Value = "Summe [€]";
                    worksheet1.Cells[2, 12].Value = "Number of negative tries";
                    worksheet1.Cells[2, 13].Value = "Übermittlungsdatum";
                    worksheet1.Cells[2, 14].Value = "Rückmeldung AOK";
                    worksheet1.Cells[2, 15].Value = "Zahlungsdatum";
                    worksheet1.Cells[2, 16].Value = "Datum des aktuellen Status";
                    worksheet1.Cells[2, 17].Value = "aktueller Prozess-Status";
                    worksheet1.Cells[2, 18].Value = "Datum des vorherigen Status";
                    worksheet1.Cells[2, 19].Value = "vorheriger Prozess-Status";

                    string header3Key = "U1:Y1";
                    worksheet1.Cells[header3Key].Merge = true;
                    worksheet1.Cells[header3Key].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    worksheet1.Cells[header3Key].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet1.Cells[header3Key].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(216, 228, 188));
                    worksheet1.Cells[header3Key].Value = "Diagnose";
                    worksheet1.Cells[header3Key].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet1.Cells[2, 21].Value = "Diagnose";
                    worksheet1.Cells[2, 22].Value = "Code";
                    worksheet1.Cells[2, 23].Value = "Lokalisation";
                    worksheet1.Cells[2, 24].Value = "DG. Sicherheit";
                    worksheet1.Cells[2, 25].Value = "Medikament";

                    string header4Key = "AA1:AF1";
                    worksheet1.Cells[header4Key].Merge = true;
                    worksheet1.Cells[header4Key].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    worksheet1.Cells[header4Key].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet1.Cells[header4Key].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet1.Cells[header4Key].Value = "Termin-Daten (OP oder Nachbehandlung)";
                    worksheet1.Cells[header4Key].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet1.Cells[2, 27].Value = "Behandlungsdatum";
                    worksheet1.Cells[2, 28].Value = "OP-Behandlungsdatum";
                    worksheet1.Cells[2, 29].Value = "BSNR";
                    worksheet1.Cells[2, 30].Value = "Praxisname";
                    worksheet1.Cells[2, 31].Value = "LANR";
                    worksheet1.Cells[2, 32].Value = "Behandelnder Arzt";


                    string header5Key = "AH1:AM1";
                    worksheet1.Cells[header5Key].Merge = true;
                    worksheet1.Cells[header5Key].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    worksheet1.Cells[header5Key].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet1.Cells[header5Key].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 184, 183));
                    worksheet1.Cells[header5Key].Value = "Auszahlung";
                    worksheet1.Cells[header5Key].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet1.Cells[2, 34].Value = "Kontoinhaber";
                    worksheet1.Cells[2, 35].Value = "BLZ";
                    worksheet1.Cells[2, 36].Value = "Konto-Nummer";
                    worksheet1.Cells[2, 37].Value = "Kreditinstitut";
                    worksheet1.Cells[2, 38].Value = "IBAN";
                    worksheet1.Cells[2, 39].Value = "BIC";

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    string header1KeySeet2 = "A1:D1";
                    worksheet2.Cells[header1KeySeet2].Merge = true;
                    worksheet2.Cells[header1KeySeet2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    worksheet2.Cells[header1KeySeet2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet2.Cells[header1KeySeet2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet2.Cells[header1KeySeet2].Value = "Patientendaten";
                    worksheet2.Cells[header1KeySeet2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet2.Cells[2, 1].Value = "Versicherrungsnummer";
                    worksheet2.Cells[2, 2].Value = "Vorname";
                    worksheet2.Cells[2, 3].Value = "Nachname";
                    worksheet2.Cells[2, 4].Value = "geb.am.";

                    string header2KeySheet2 = "F1:K1";
                    worksheet2.Cells[header2KeySheet2].Merge = true;
                    worksheet2.Cells[header2KeySheet2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    worksheet2.Cells[header2KeySheet2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet2.Cells[header2KeySheet2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 184, 183));
                    worksheet2.Cells[header2KeySheet2].Value = "Auszahlung";
                    worksheet2.Cells[header2KeySheet2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet2.Cells[2, 6].Value = "Kontoinhaber";
                    worksheet2.Cells[2, 7].Value = "BLZ";
                    worksheet2.Cells[2, 8].Value = "Konto-Nummer";
                    worksheet2.Cells[2, 9].Value = "Kreditinstitut";
                    worksheet2.Cells[2, 10].Value = "IBAN";
                    worksheet2.Cells[2, 11].Value = "BIC";

                    string header3KeySheet2 = "M1:P1";
                    worksheet2.Cells[header3KeySheet2].Merge = true;
                    worksheet2.Cells[header3KeySheet2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                    worksheet2.Cells[header3KeySheet2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet2.Cells[header3KeySheet2].Style.Fill.BackgroundColor.SetColor((Color.FromArgb(252, 213, 180)));
                    worksheet2.Cells[header3KeySheet2].Value = "Vorgang";
                    worksheet2.Cells[header3KeySheet2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet2.Cells[2, 13].Value = "Vorgangsnummer";
                    worksheet2.Cells[2, 14].Value = "Typ";
                    worksheet2.Cells[2, 15].Value = "Summe [€]";
                    worksheet2.Cells[2, 16].Value = "Behandlungsdatum";

                    using (ExcelRange rng = worksheet1.Cells["A2:AM2"])
                    {
                        rng.Style.Font.Bold = true;
                    }
                    using (ExcelRange rng = worksheet2.Cells["A2:P2"])
                    {
                        rng.Style.Font.Bold = true;
                    }

                    int i = 3;
                    long processNumber = -1;
                    if(data.Positions != null)
                        foreach (var row in data.Positions)
                        {
                            if (processNumber != row.positionSequence && processNumber != -1)
                                processNumber = row.positionSequence;

                            worksheet1.Cells[i, 1].Value = row.InsuranceStateCode;
                            worksheet1.Cells[i, 2].Value = row.HealthInsuranceNumber;
                            worksheet1.Cells[i, 3].Value = row.HICompanyName;
                            worksheet1.Cells[i, 4].Value = row.PatientFirstName;
                            worksheet1.Cells[i, 5].Value = row.PatientLastName;
                            worksheet1.Cells[i, 6].Value = row.PatientDOB;
                            worksheet1.Cells[i, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet1.Cells[i, 6].Style.Numberformat.Format =dateFormat;

                            if (row.TransmitionStatus_Comment1 != "offen")
                            {
                                if (row.PositionProcessNumber > 0) worksheet1.Cells[i, 8].Value = row.PositionProcessNumber;
                                worksheet1.Cells[i, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                worksheet1.Cells[i, 11].Value = row.Price;
                                worksheet1.Cells[i, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                worksheet1.Cells[i, 11].Style.Numberformat.Format = priceFormat;
                                worksheet1.Cells[i, 12].Value = row.NumberOfNegativeTries;
                                worksheet1.Cells[i, 13].Value = row.DateOfTransmision;
                                worksheet1.Cells[i, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                worksheet1.Cells[i, 13].Style.Numberformat.Format = dateFormat;
                                worksheet1.Cells[i, 14].Value = row.TransmitionStatus_Comment2;
                                if (!(row.positionStatus == 6 && row.TreatmentType == "Nachsorge"))
                                {
                                    worksheet1.Cells[i, 15].Value = row.DateOfPayment;
                                    worksheet1.Cells[i, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                    worksheet1.Cells[i, 15].Style.Numberformat.Format = dateFormat;
                                }
                            }
                            worksheet1.Cells[i, 10].Value = row.GPOS;
                            worksheet1.Cells[i, 9].Value = row.TreatmentType;

                            worksheet1.Cells[i, 16].Value = row.DateOfLastStatusChange;
                            worksheet1.Cells[i, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet1.Cells[i, 16].Style.Numberformat.Format = dateFormat;
                            worksheet1.Cells[i, 17].Value = row.TransmitionStatus_Comment1;

                            worksheet1.Cells[i, 18].Value = row.DateOfSecondLastStatusChange;
                            worksheet1.Cells[i, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet1.Cells[i, 18].Style.Numberformat.Format = dateFormat;
                            worksheet1.Cells[i, 19].Value = row.SecondLastStatusChange;

                            worksheet1.Cells[i, 21].Value = row.DiagnoseName;
                            worksheet1.Cells[i, 22].Value = row.DiagnoseCode;
                            worksheet1.Cells[i, 23].Value = row.DiagnoseLocalization;
                            worksheet1.Cells[i, 24].Value = row.DiagnoseState;
                            worksheet1.Cells[i, 25].Value = row.ArticleName;

                            worksheet1.Cells[i, 27].Value = row.TreatmentDate;
                            worksheet1.Cells[i, 27].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet1.Cells[i, 27].Style.Numberformat.Format = dateFormat;
                            worksheet1.Cells[i, 28].Value = row.TreatmentDateFromOriginalTreatment;
                            worksheet1.Cells[i, 28].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            worksheet1.Cells[i, 28].Style.Numberformat.Format = dateFormat;
                            worksheet1.Cells[i, 29].Value = row.BSNR;
                            worksheet1.Cells[i, 30].Value = row.PracticeName;
                            worksheet1.Cells[i, 31].Value = row.LANR;
                            worksheet1.Cells[i, 32].Value = row.DoctroFullName;

                            worksheet1.Cells[i, 34].Value = row.AccountOwner;
                            worksheet1.Cells[i, 35].Value = row.BLZ;
                            worksheet1.Cells[i, 36].Value = row.AccountNumber;
                            worksheet1.Cells[i, 37].Value = row.BankName;
                            worksheet1.Cells[i, 38].Value = row.IBAN;
                            worksheet1.Cells[i, 39].Value = row.BIC;
                            i++;
                        }

                    i = 3;
                    processNumber = -1;
                    if(data.Positions != null)
                        foreach (var row in data.Positions)
                        {
                            if (row.positionStatus == 3 || row.positionStatus == 5 || row.positionStatus == 6)
                            {
                                if (row.positionStatus == 6 && row.TreatmentType == "Nachsorge")
                                    continue;

                                if (processNumber != row.positionSequence && processNumber != -1)
                                    //i++;
                                    processNumber = row.positionSequence;

                                worksheet2.Cells[i, 1].Value = row.HealthInsuranceNumber;
                                worksheet2.Cells[i, 2].Value = row.PatientFirstName;
                                worksheet2.Cells[i, 3].Value = row.PatientLastName;
                                worksheet2.Cells[i, 4].Value = row.PatientDOB;
                                worksheet2.Cells[i, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                worksheet2.Cells[i, 4].Style.Numberformat.Format = dateFormat;

                                worksheet2.Cells[i, 6].Value = row.AccountOwner;
                                worksheet2.Cells[i, 7].Value = row.BLZ;
                                worksheet2.Cells[i, 8].Value = row.AccountNumber;
                                worksheet2.Cells[i, 9].Value = row.BankName;
                                worksheet2.Cells[i, 10].Value = row.IBAN;
                                worksheet2.Cells[i, 11].Value = row.BIC;

                                if (row.PositionProcessNumber > 0) worksheet2.Cells[i, 13].Value = row.PositionProcessNumber;
                                worksheet2.Cells[i, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                worksheet2.Cells[i, 14].Value = row.TreatmentType;
                                worksheet2.Cells[i, 15].Value = row.Price;
                                worksheet2.Cells[i, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                worksheet2.Cells[i, 15].Style.Numberformat.Format = priceFormat;
                                worksheet2.Cells[i, 16].Value = row.TreatmentDate;
                                worksheet2.Cells[i, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                worksheet2.Cells[i, 16].Style.Numberformat.Format = dateFormat;

                                i++;
                            }
                        }

                    worksheet2.Cells[worksheet1.Dimension.Address.ToString()].AutoFitColumns();
                    worksheet1.Cells[worksheet1.Dimension.Address.ToString()].AutoFitColumns();

                    package.Save();
                }


            }

            return file.FullName;
        }
    }
}