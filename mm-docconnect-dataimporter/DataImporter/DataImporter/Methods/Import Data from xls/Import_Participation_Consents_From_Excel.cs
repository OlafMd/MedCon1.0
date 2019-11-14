using CL1_HEC;
using CL1_HEC_DIA;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Case.Atomic.Manipulation;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Manipulation;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Excel_Templates;
using DataImporter.Models;
using DLExcelUtils;
using MMDocConnectElasticSearchMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods.Import_Data_from_xls
{
    class Import_Participation_Consents_From_Excel
    {
        public static void Import_Consents(string connectionString, SessionSecurityTicket securityTicket)
        {
            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\consents.xlsx");
            bool hasHeader = true;
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
            DataTable excelData = null;
            Console.WriteLine("Loading data from excel...");
            try
            {
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }
            catch (Exception ex)
            {
                filePath = Path.Combine(folder, "Excel\\consents.xls");
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }

            List<ParticipationConsentModel> consents = new List<ParticipationConsentModel>();
            int i = 1;
            Console.WriteLine();
            try
            {

                foreach (System.Data.DataRow item in excelData.Rows)
                {
                    ParticipationConsentModel consent = new ParticipationConsentModel();

                    #region consent
                    consent.insurance_id = (string)item.ItemArray[0];
                    consent.bsnr = (string)item.ItemArray[1];
                    consent.start_date = DateTime.Parse((string)item.ItemArray[2]);
                    consent.isValid = true;
                    #endregion
                    
                    consents.Add(consent);
                    Console.Write("\rConsent {0} of {1} validated.", i++, excelData.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.Write(ex.StackTrace);
            }


            string file = ExportConsentsBeforeUpload.ExportConsentsBeforeUploadToDB(consents);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
            Console.WriteLine("----- XLS created.");

            if (consents.Any(vl => !vl.isValid))
            {
                Console.WriteLine("Data not valid, won't be saved.");
            }
            else
            {
                cls_Add_Consents_to_Patients.Invoke(connectionString, new P_PA_ACtP_1452()
                {
                    consents = consents.Select(c =>
                    {
                        return new P_PA_ACtP_1452a()
                        {
                            bsnr = c.bsnr,
                            insurance_id = c.insurance_id,
                            start_date = c.start_date
                        };
                    }).ToArray()
                }, securityTicket);
            }
        }
    }
}
