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
    class Import_HIPs_From_Excel
    {
        public static void Import_HIPs(string connectionString, SessionSecurityTicket securityTicket)
        {
            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\HIPs.xlsx");
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
                filePath = Path.Combine(folder, "Excel\\HIPs.xls");
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }

            List<KeyValueModel> hips = new List<KeyValueModel>();
            int i = 1;
            Console.WriteLine();
            try
            {

                foreach (System.Data.DataRow item in excelData.Rows)
                {
                    KeyValueModel hip = new KeyValueModel();

                    #region CASE IMPORT
                    hip.key = (string)item.ItemArray[0];
                    hip.value = (string)item.ItemArray[1];
                    hip.isValid = true;
                    #endregion

                    if (hips.Any(h => h.key == hip.key))
                    {
                        hip.isValid = false;
                        hip.validationMessage = "Hip number not unique";
                    }

                    hips.Add(hip);
                    Console.Write("\rHIP {0} of {1} validated.", i++, excelData.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.Write(ex.StackTrace);
            }


            string file = ExportHIPsBeforeUpload.ExportHIPsBeforeUploadToDB(hips);
            MemoryStream ms = new MemoryStream(File.ReadAllBytes(file));
            Console.WriteLine("----- XLS created.");

            if (hips.Any(vl => !vl.isValid))
            {
                Console.WriteLine("Data not valid, won't be saved.");
            }
            else
            {
                if (Elastic_Utils.IfIndexOrTypeExists("external_data", Elastic_Utils.ElsaticConnection()) &&
                    Elastic_Utils.IfIndexOrTypeExists("external_data/hip", Elastic_Utils.ElsaticConnection()))
                {
                    Elastic_Utils.Delete_Type("external_data", "hip");
                }

                Add_New_HIP.Import_HIP_Data_to_ElasticDB(hips.Select(hip =>
                {
                    return new HIP_Model()
                    {
                        id = Guid.NewGuid().ToString(),
                        ik_number = hip.key.Trim(),
                        name = hip.value.Trim()
                    };
                }).ToList(), "external_data");
            }
        }
    }
}
