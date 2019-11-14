using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using OfficeOpenXml;

namespace DLExcelUtils
{
    public class ExcelUtils
    {
        public static DataTable getDataFromExcelFile(string filePath, bool hasHeader)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("File is not found!");
            }
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {

                using (var stream = File.OpenRead(filePath))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                var reuslt = new DataTable();

                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    reuslt.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    DataRow row = reuslt.NewRow();
                    var p = row as IDictionary<String, object>;
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    int i = 0;
                    foreach (var cell in wsRow)
                    {
                        row[i] = cell.Text;
                        i++;
                    }
                    reuslt.Rows.Add(row);
                }
                return reuslt;
            }

        }
        public static DataTable getDataFromExcelFileNoPath(MemoryStream ms, bool hasHeader)
        {
            var result = new DataTable();
            using (ExcelPackage package = new ExcelPackage(ms))
            {
                if (package.Workbook.Worksheets.Count != 0)
                {
                    using (var ws = package.Workbook.Worksheets.First())
                    {
                        foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                        {
                            result.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                        }

                        var startRow = hasHeader ? 2 : 1;
                        for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                        {
                            DataRow row = result.NewRow();
                            var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                            int i = 0;
                            foreach (var cell in wsRow)
                            {
                                if (i < row.ItemArray.Length)
                                {
                                    row[i] = cell.Text;
                                    i++;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            result.Rows.Add(row);
                        }
                    }
                }
            }

            return result;
        }

        public static string makeExcelFileFromModel(DataTable model, string filePath = "")
        {
            string fileName = (filePath == String.Empty) ? System.IO.Path.GetTempFileName().Replace(".tmp", ".xlsx") : filePath;
            FileInfo file = new FileInfo(fileName);
            // Create the package and make sure you wrap it in a using statement
            using (var package = new ExcelPackage(file))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Table1");
                // --------- Data and styling goes here -------------- //
                int headerIndex = 1;
                foreach (DataColumn col in model.Columns)
                {
                    worksheet.Cells[1, headerIndex++].Value = col.ColumnName;
                }

                char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                using (ExcelRange rng = worksheet.Cells["A1:" + alpha[model.Columns.Count - 1] + "1"])
                {
                    rng.Style.Font.Bold = true;
                }
                var startRow = 2;
                foreach (DataRow row in model.Rows)
                {
                    int colIndex = 1;
                    foreach (DataColumn col in model.Columns)
                    {
                        worksheet.Cells[startRow, colIndex++].Value = row[col];
                    }
                    startRow++;
                }
                worksheet.Cells[worksheet.Dimension.Address.ToString()].AutoFitColumns();
                package.Save();
            }
            return file.FullName;
        }
    }
}
