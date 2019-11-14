using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OfficeOpenXml;
using System.Globalization;
using System.Net.Mail;

namespace CL6_Lucentis_BillingHistory.Utils
{
    class ExportDoctorsBillingXLS
    {
        public static string generateDoctorsBillingXLS(List<DoctorsBilling_Excel> treatmentData, List<DoctorsBilling_Excel> excelDataListFollowup)
        {
            string filename = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            FileInfo file = new FileInfo(filename);
            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Tabelle1");

                // --------- Data and styling goes here -------------- //
                if (treatmentData != null)
                {
                    worksheet.Cells[1, 1].Value = "Datum, Behandlung";
                    worksheet.Cells[1, 2].Value = "Vorgangsnummer";
                    worksheet.Cells[1, 3].Value = "Abrechnungsstatus";
                    worksheet.Cells[1, 4].Value = "Vorname, Patient";
                    worksheet.Cells[1, 5].Value = "Nachname, Patient";
                    worksheet.Cells[1, 6].Value = "BSNR, Patient";
                    worksheet.Cells[1, 7].Value = "Artikel";
                    worksheet.Cells[1, 8].Value = "Diagnose";
                    worksheet.Cells[1, 9].Value = "GPOS";
                    worksheet.Cells[1, 10].Value = "Berechnete Summe in EUR";
                    worksheet.Cells[1, 11].Value = "Versicherrungsstatus, Patient";
                    worksheet.Cells[1, 12].Value = "Versicherrungsnummer, Patient";
                    worksheet.Cells[1, 13].Value = "Praxisname";
                    worksheet.Cells[1, 14].Value = "LANR Arzt";
                    worksheet.Cells[1, 15].Value = "Vorname, Arzt";
                    worksheet.Cells[1, 16].Value = "Nachname, Arzt";
                    worksheet.Cells[1, 17].Value = "Kontoinhaber";
                    worksheet.Cells[1, 18].Value = "BLZ";
                    worksheet.Cells[1, 19].Value = "Konto-Nummer";
                    worksheet.Cells[1, 20].Value = "Kreditinstitut";

                    using (ExcelRange rng = worksheet.Cells["A1:T1"])
                    {
                        rng.Style.Font.Bold = true;
                    }

                    int row =2;

                    for (int i = 0; i < treatmentData.Count; i++)
                    {
                        int counter = 1;
                        if (treatmentData[i].BevacizumabData != null)
                            counter = 2;

                        //Date of treatment
                        worksheet.Cells[row, 1].Value = treatmentData[i].treatmentDate;
                        worksheet.Cells[row + 1, 1].Value = excelDataListFollowup[i].treatmentDate;
                        for (int count = 2; count < counter + 2;count++ )
                        {
                            worksheet.Cells[row + count, 1].Value = treatmentData[i].treatmentDate;
                        }
                        //Processnumber
                        worksheet.Cells[row, 2].Value = treatmentData[i].processNumber;
                        worksheet.Cells[row + 1, 2].Value = excelDataListFollowup[i].processNumber;
                        if (counter == 1)
                        {
                            worksheet.Cells[row + 2, 2].Value = treatmentData[i].AdditionalCompensationData.processNumber;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, 2].Value = treatmentData[i].BevacizumabData.processNumber;
                            worksheet.Cells[row + 3, 2].Value = treatmentData[i].AdditionalCompensationData.processNumber;
                        }

                        //Billing status
                        worksheet.Cells[row, 3].Value = treatmentData[i].billlingStatus;
                        worksheet.Cells[row + 1, 3].Value = excelDataListFollowup[i].billlingStatus;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 3].Value = treatmentData[i].billlingStatus;
                        }

                        //First name, patient
                        worksheet.Cells[row, 4].Value = treatmentData[i].patientFirstName;
                        worksheet.Cells[row + 1, 4].Value = excelDataListFollowup[i].patientFirstName;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 4].Value = treatmentData[i].patientFirstName;
                        }

                        //Last name, patient
                        worksheet.Cells[row, 5].Value = treatmentData[i].patientLastName;
                        worksheet.Cells[row + 1, 5].Value = excelDataListFollowup[i].patientLastName;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 5].Value = treatmentData[i].patientLastName;
                        }

                        //BSNR, patient
                        worksheet.Cells[row, 6].Value = treatmentData[i].BSNR;
                        worksheet.Cells[row + 1, 6].Value = excelDataListFollowup[i].BSNR;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 6].Value = treatmentData[i].BSNR;
                        }

                        //main article treatment
                        worksheet.Cells[row, 7].Value = treatmentData[i].mainArticle;
                        worksheet.Cells[row + 1, 7].Value = "-";
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 7].Value = "-";
                        }

                        string diagnose = "";

                        //diagnosis
                        for (int k = 0; k < treatmentData[i].diagnosis.Count; k++)
                        {
                            if (k == treatmentData[i].diagnosis.Count-1)
                            {
                                diagnose = diagnose + treatmentData[i].diagnosis[k];
                            }
                            else
                            {
                                diagnose = diagnose + treatmentData[i].diagnosis[k] + ", ";
                            }
                        }

                        worksheet.Cells[row, 8].Value = diagnose;
                        worksheet.Cells[row + 1, 8].Value = "Nachsorge";


                        if (counter == 1)
                        {
                            worksheet.Cells[row + 2, 8].Value = "Zusatzposition Vergütung";
                        }
                        else
                        {
                            worksheet.Cells[row + 2, 8].Value = "Zusatzposition Bevacuzimab";
                            worksheet.Cells[row + 3, 8].Value = "Zusatzposition Vergütung";
                        }


                        //GPOS
                        worksheet.Cells[row, 9].Value = treatmentData[i].GPOS;
                        worksheet.Cells[row + 1, 9].Value = excelDataListFollowup[i].GPOS;
                        if (counter == 1)
                        {
                            worksheet.Cells[row + 2, 9].Value = treatmentData[i].AdditionalCompensationData.GPOS;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, 9].Value = treatmentData[i].BevacizumabData.GPOS;
                            worksheet.Cells[row + 3, 9].Value = treatmentData[i].AdditionalCompensationData.GPOS;
                        }

                        //Invoiced amount in EUR
                        worksheet.Cells[row, 10].Value = "230";
                        worksheet.Cells[row + 1, 10].Value = "60";
                        if (counter == 1)
                        {
                            worksheet.Cells[row + 2, 10].Value = treatmentData[i].AdditionalCompensationData.amount;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, 10].Value = treatmentData[i].BevacizumabData.amount;
                            worksheet.Cells[row + 3, 10].Value = treatmentData[i].AdditionalCompensationData.amount;
                        }

                        //Insurrance state, patient
                        worksheet.Cells[row, 11].Value = treatmentData[i].insuranceState;
                        worksheet.Cells[row + 1, 11].Value = excelDataListFollowup[i].insuranceState;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 11].Value = treatmentData[i].insuranceState;
                        }

                        //insurance number, patient
                        worksheet.Cells[row, 12].Value = treatmentData[i].insuranceNumber;
                        worksheet.Cells[row + 1, 12].Value = excelDataListFollowup[i].insuranceNumber;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 12].Value = treatmentData[i].insuranceNumber;
                        }

                        //Doctor's first practice name
                        worksheet.Cells[row, 13].Value = treatmentData[i].doctorsPractice;
                        worksheet.Cells[row + 1, 13].Value = excelDataListFollowup[i].doctorsPractice;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 13].Value = treatmentData[i].doctorsPractice;
                        }

                        //LANR doctor
                        worksheet.Cells[row, 14].Value = treatmentData[i].LANR;
                        worksheet.Cells[row + 1, 14].Value = excelDataListFollowup[i].LANR;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 14].Value = treatmentData[i].LANR;
                        }

                        //First name, doctor
                        worksheet.Cells[row, 15].Value = treatmentData[i].doctorsFirstName;
                        worksheet.Cells[row + 1, 15].Value = excelDataListFollowup[i].doctorsFirstName;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 15].Value = treatmentData[i].doctorsFirstName;
                        }

                        //Last name, doctor
                        worksheet.Cells[row, 16].Value = treatmentData[i].doctorsLastName;
                        worksheet.Cells[row + 1, 16].Value = excelDataListFollowup[i].doctorsLastName;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 16].Value = treatmentData[i].doctorsLastName;
                        }

                        //account holder
                        worksheet.Cells[row, 17].Value = treatmentData[i].accountHolder;
                        worksheet.Cells[row + 1, 17].Value = excelDataListFollowup[i].accountHolder;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 17].Value = treatmentData[i].accountHolder;
                        }

                        //Bank number (BLZ)
                        worksheet.Cells[row, 18].Value = treatmentData[i].BLZ;
                        worksheet.Cells[row + 1, 18].Value = excelDataListFollowup[i].BLZ;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 18].Value = treatmentData[i].BLZ;
                        }

                        //Account number
                        worksheet.Cells[row, 19].Value = treatmentData[i].accountNumber;
                        worksheet.Cells[row + 1, 19].Value = excelDataListFollowup[i].accountNumber;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 19].Value = treatmentData[i].accountNumber;
                        }

                        //Name of bank
                        worksheet.Cells[row, 20].Value = treatmentData[i].nameOfTheBank;
                        worksheet.Cells[row + 1, 20].Value = excelDataListFollowup[i].nameOfTheBank;
                        for (int count = 2; count < counter + 2; count++)
                        {
                            worksheet.Cells[row + count, 20].Value = treatmentData[i].nameOfTheBank;
                        }

                        row = row + 2 + counter;
                    }


                        worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();

                    package.Save();
                }
            }

            return file.FullName;
        }
    }
}
