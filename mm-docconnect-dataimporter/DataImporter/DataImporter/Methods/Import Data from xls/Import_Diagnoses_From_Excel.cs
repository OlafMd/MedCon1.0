using CL1_HEC;
using CL1_HEC_DIA;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Case.Atomic.Manipulation;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
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
    class Import_Diagnoses_From_Excel
    {
        public static void Import_Diagnoses(string connectionString, SessionSecurityTicket securityTicket)
        {
            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\ICD10.xlsx");
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
                filePath = Path.Combine(folder, "Excel\\ICD10.xls");
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }

            List<KeyValueModel> diagnoses = new List<KeyValueModel>();
            int i = 1;
            Console.WriteLine("Validate diagnoses in the excel file? [y/n]");
            var validate = Console.ReadLine().ToLower() == "y";
            var message = validate ? "validated." : "imported.";
            try
            {

                foreach (System.Data.DataRow item in excelData.Rows)
                {
                    KeyValueModel diagnose = new KeyValueModel();

                    #region DIAGNOSE IMPORT
                    diagnose.key = (string)item.ItemArray[0];
                    diagnose.value = (string)item.ItemArray[1];
                    diagnose.isValid = true;
                    #endregion

                    if (validate)
                    {
                        if (diagnoses.Any(h => h.key == diagnose.key))
                        {
                            diagnose.isValid = false;
                            diagnose.validationMessage = "Drug ICD10 code ";
                        }
                    }

                    diagnoses.Add(diagnose);
                    Console.Write("\rDiagnose {0} of {1} {2}", i++, excelData.Rows.Count, message);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.Write(ex.StackTrace);
            }


            string file = ExportDiagnosesBeforeUpload.ExportDiagnosesBeforeUploadToElastic(diagnoses);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
            Console.WriteLine("----- XLS created.");

            if (diagnoses.Any(vl => !vl.isValid))
            {
                Console.WriteLine("Data not valid, won't be saved.");
            }
            else
            {
                if (Elastic_Utils.IfIndexOrTypeExists("external_data", Elastic_Utils.ElsaticConnection()) &&
                    Elastic_Utils.IfIndexOrTypeExists("external_data/diagnose", Elastic_Utils.ElsaticConnection()))
                {
                    Elastic_Utils.Delete_Type("external_data", "diagnose");
                }

                var pageSize = 1000;
                var page = 0;

                while (true)
                {
                    var skip = pageSize * page;
                    if (skip < diagnoses.Count)
                    {
                        var diagnoseList = diagnoses.Skip(skip).Take(pageSize).Select(diag => { return new Diagnose_Model() { id = Guid.NewGuid().ToString(), icd10 = diag.key, name = diag.value.Trim() }; }).ToList();

                        Add_New_Diagnose.Import_Diagnose_Data_to_ElasticDB(diagnoseList, "external_data");
                    }
                    else
                        break;

                    page++;
                }
            }
        }
    }
}
