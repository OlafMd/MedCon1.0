using DataImporter.Models;
using DLExcelUtils;
using MMDocConnectElasticSearchMethods;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Methods
{
    class Iban_Bic_Codes_and_Bank_Name_Import
    {
        public static void ImportCodes_to_ElasticDB()
        {
            string folder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(folder, "Excel\\codes.xlsx");
            bool hasHeader = true;
            string bicholder = "";
            DataTable excelData = null;
            try
            {
                excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);
            }
            catch (Exception ex)
            {
                filePath = Path.Combine(folder, "Excel\\codes.xls");
            }

            excelData = ExcelUtils.getDataFromExcelFileMM(filePath, hasHeader);

            List<Bic_Iban_Codes> CodesForImportL = new List<Bic_Iban_Codes>();
            foreach (System.Data.DataRow item in excelData.Rows)
            {
                int bla = 0;
                //string[] data = item.ItemArray[0].ToString();
                Bic_Iban_Codes CodesForImport = new Bic_Iban_Codes();
                CodesForImport.IbanPar = item.ItemArray[0].ToString();
                CodesForImport.CodeID = Guid.NewGuid().ToString();
                CodesForImport.BankName = item.ItemArray[2].ToString();
                if (item.ItemArray[7].ToString() == "")
                {
                    CodesForImport.bic = bicholder;
                }
                else
                {
                    CodesForImport.bic = item.ItemArray[7].ToString();
                }

                bicholder = CodesForImport.bic;
                CodesForImportL.Add(CodesForImport);

                bla++;
            }

            string indexName = "validation";
            Import_IBAN_BIC_Data_to_ElasticDB(CodesForImportL, indexName);


        }


        public static string BuildProductMapping()
        {
            return new MapBuilder<Bic_Iban_Codes>()
               .RootObject("iban_bic", ro => ro
                   .Properties(pr => pr
                                   .MultiField("CodeID", mfp => mfp.Fields(f => f
                                        .String("CodeID", sp => sp.IndexAnalyzer("not_analyzed"))
                                        )
                                    )
                                    .MultiField("IbanPar", mfp => mfp.Fields(f => f
                                        .String("IbanPar", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )
                                     .MultiField("BankName", mfp => mfp.Fields(f => f
                                        .String("BankName", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                    )
                                     .MultiField("bic", mfp => mfp.Fields(f => f
                                        .String("bic", sp => sp.Analyzer("caseinsensitive"))
                                        )
                                     )

                                 )

                     ).BuildBeautified();
        }

        public static void Import_IBAN_BIC_Data_to_ElasticDB(List<Bic_Iban_Codes> CodesForImportL, string indexName)
        {
            var serializer = new JsonNetSerializer();
            var connection = Elastic_Utils.ElsaticConnection();
            bool CheckIndex = Elastic_Utils.IfIndexOrTypeExists(indexName, connection);

            if (!CheckIndex)
            {
                //create new index
                string settings = Elastic_Utils.BuildIndexSettings();
                connection.Put(indexName, settings);
            }

            if (Elastic_Utils.IfIndexOrTypeExists(indexName + "/iban_bic", connection))
            {
                string jsonProductMapping = BuildProductMapping();
                string resultProductMapping = connection.Put(new PutMappingCommand(indexName, "iban_bic"), jsonProductMapping);

            }

            Elastic_Utils.BulkType(CodesForImportL, connection, serializer, indexName);
        }
    }
}
