using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using MMDocConnectDBMethods.Order.Complex.Model;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MMDocConnectDBMethods.Order.Complex.Util
{
    public class OrderPdfReportGenerator
    {
        private OrderReportParameters reportData;
        private PdfDocumentRenderer renderer;
        private Document document;
        private DocumentRenderer docRenderer;
        private Section section;
        private SubmitOrderPdfReportContent labels;

        public byte[] Generate(OrderReportParameters parameters, string reportContentPath)
        {
            reportData = parameters;
            renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            document = new Document();
            document.DefaultPageSetup.TopMargin = "9.75cm";
            document.DefaultPageSetup.BottomMargin = "3.15cm";
            document.DefaultPageSetup.LeftMargin = "3cm";
            document.DefaultPageSetup.RightMargin = "1cm";
            document.DefaultPageSetup.PageFormat = PageFormat.A4;

            docRenderer = new DocumentRenderer(document);
            labels = new SubmitOrderPdfReportContent(reportContentPath);

            document.Info.Title = "Bestellen-" + DateTime.Now.ToString("dd.MM.yyyy");

            var style = document.Styles["Normal"];
            style.Font.Name = "Calibri";
            style.Font.Size = 9;

            section = document.AddSection();

            SetupHeader();
            SetupFooter();

            var drugsGrouped = reportData.Orders.OrderedDrugs.GroupBy(t => t.Name).ToDictionary(t => t.Key, t => t.ToList());
            var summaryTableColumnConfig = new List<TableColumnConfig>() {
                new TableColumnConfig() { ColumnName = labels.Medication, ColumnWidth = "15cm" }, 
                new TableColumnConfig() { ColumnName = labels.Amount, ColumnWidth = "2cm", Alignment = ParagraphAlignment.Right } 
            };

            SetupContent(labels.OrderOverview, summaryTableColumnConfig, drugsGrouped.Select(t => new List<TableContent>() {
                new TableContent() { Alignment = ParagraphAlignment.Left, Value = t.Key },
                new TableContent() { Alignment = ParagraphAlignment.Right, Value =  t.Value.Count.ToString() },               
            }).ToList());
            document.LastSection.AddPageBreak();
            summaryTableColumnConfig = new List<TableColumnConfig>() {
                new TableColumnConfig() { ColumnName = labels.Patient, ColumnWidth = "4cm" }, 
                new TableColumnConfig() { ColumnName = labels.BirthDate, ColumnWidth = "3cm" } , 
                new TableColumnConfig() { ColumnName = labels.HealthInsurance, ColumnWidth = "4cm" } , 
                new TableColumnConfig() { ColumnName = labels.InsuranceStatus, ColumnWidth = "3cm" } , 
                new TableColumnConfig() { ColumnName = labels.FeeWaived, ColumnWidth = "3cm" } , 
            };

            var i = 0;
            foreach (var drug in drugsGrouped)
            {
                SetupContent(drug.Key, summaryTableColumnConfig, drug.Value.Select(t => new List<TableContent>() {
                    new TableContent() { Alignment = ParagraphAlignment.Left, Value = String.Format("{0} {1}", t.Patient.FirstName, t.Patient.LastName) },          
                    new TableContent() { Alignment = ParagraphAlignment.Left, Value = t.Patient.BirthDate.ToString("dd.MM.yyyy") },
                    new TableContent() { Alignment = ParagraphAlignment.Left, Value = t.Patient.Hip },
                    new TableContent() { Alignment = ParagraphAlignment.Left, Value = t.Patient.InsuranceStatus },
                    new TableContent() { Alignment = ParagraphAlignment.Center, Value = t.Patient.FeeWaived },
                    new TableContent() { Alignment = ParagraphAlignment.Left, Value = t.PositionComment, NewRow = true}

                }).ToList(), true);

                if (i++ < drugsGrouped.Count - 1)
                {
                    document.LastSection.AddPageBreak();
                }
            }

            var stream = new MemoryStream();

            renderer.Document = document;
            renderer.RenderDocument();
            renderer.Save(stream, false);

            return stream.ToArray();
        }

        private void SetupFooter()
        {
            var textFrame = section.Footers.Primary.AddTextFrame();
            textFrame.WrapFormat.DistanceBottom = "-2.85cm";

            var leftTableFooter = textFrame.AddTable();
            leftTableFooter.Borders.Width = 0;
            var tableColumnLeft = leftTableFooter.AddColumn("8.25cm");
            tableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
            var signatureRow = leftTableFooter.AddRow();
            var signatureInfo = signatureRow.Cells[0].AddParagraph();
            signatureInfo.AddText(String.Format("{0}., {1}, ", reportData.Orders.CreationDate.ToString("dddd", new CultureInfo("de")).Substring(0, 2), reportData.Orders.CreationDate.ToString("dd.MM.yyyy HH:mm")));
            signatureInfo.AddLineBreak();
            var signatureText = signatureRow.Cells[0].AddParagraph();
            signatureText.AddText(labels.Signature);
            signatureText.Format.Alignment = ParagraphAlignment.Center;
            signatureText.Format.Borders.Top = new Border() { Width = "1pt" };

            var rigthTableFooter = section.Footers.Primary.AddTable();
            rigthTableFooter.Format.SpaceBefore = "1cm";
            rigthTableFooter.Borders.Width = 0;
            rigthTableFooter.AddColumn(GetPageWidth());

            var pageInfoRow = rigthTableFooter.AddRow();
            var paragraphFooter = pageInfoRow.Cells[0].AddParagraph();
            paragraphFooter.AddText("Seite ");
            paragraphFooter.AddPageField();
            paragraphFooter.AddText(" von ");
            paragraphFooter.AddNumPagesField();
            paragraphFooter.Format.Font.Size = 10;
            paragraphFooter.Format.Alignment = ParagraphAlignment.Center;
        }

        private void SetupHeader()
        {
            var pharmacy = reportData.Pharmacy;
            var practice = reportData.Practice;

            var tableHeader = section.Headers.Primary.AddTable();
            tableHeader.Borders.Width = 0;
            tableHeader.Format.SpaceBefore = "3.54cm";

            var tableColumnLeft = tableHeader.AddColumn("9cm");
            tableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
            var tableColumnRight = tableHeader.AddColumn("8.25cm");
            tableColumnRight.Format.Alignment = ParagraphAlignment.Left;
            var row = tableHeader.AddRow();

            var pharmacyInfo = row.Cells[0].AddParagraph();
            pharmacyInfo.Format.Alignment = ParagraphAlignment.Left;
            pharmacyInfo.Format.Font.Size = 10;
            pharmacyInfo.AddFormattedText(labels.Pharmacy, new Font()
            {
                Bold = true
            });
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddText(pharmacy.Name);
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddText(String.Format("{0} {1}", pharmacy.Street, pharmacy.Number));
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddText(String.Format("{0} {1}", pharmacy.Zip, pharmacy.City));
            pharmacyInfo.AddLineBreak();


            var practiceInfo = row.Cells[1].AddParagraph();
            practiceInfo.Format.Alignment = ParagraphAlignment.Right;
            practiceInfo.Format.Font.Size = 10;
            practiceInfo.AddFormattedText(labels.Practice, new Font()
            {
                Bold = true
            });
            practiceInfo.AddLineBreak();
            practiceInfo.AddLineBreak();
            practiceInfo.AddText(practice.Name);
            practiceInfo.AddLineBreak();
            practiceInfo.AddText(String.Format("{0} {1}", practice.Street, practice.Number));
            practiceInfo.AddLineBreak();
            practiceInfo.AddText(String.Format("{0} {1}", practice.Zip, practice.City));
            practiceInfo.AddLineBreak();
            if (!String.IsNullOrEmpty(practice.Email))
            {
                practiceInfo.AddText(String.Format("e: {0}", practice.Email));
                practiceInfo.AddLineBreak();
            }

            if (!String.IsNullOrEmpty(practice.Phone) && practice.Phone.Length > 3)
            {
                practiceInfo.AddText(String.Format("t: {0}", practice.Phone));
                practiceInfo.AddLineBreak();
            }
        }

        private Unit GetPageWidth()
        {
            return document.DefaultPageSetup.PageWidth - document.DefaultPageSetup.LeftMargin - document.DefaultPageSetup.RightMargin;
        }

        private void SetupContent(string heading, List<TableColumnConfig> tableColumns, List<List<TableContent>> tableContents, bool summary = false)
        {
            var tableContent = section.AddTable();
            tableContent.Borders.Width = 0;

            var tableColumnLeft = tableContent.AddColumn(GetPageWidth());
            tableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
            var row = tableContent.AddRow();

            var pharmacyInfo = row.Cells[0].AddParagraph();
            pharmacyInfo.Format.Alignment = ParagraphAlignment.Left;
            pharmacyInfo.Format.Font.Size = 10;
            pharmacyInfo.Format.KeepWithNext = true;
            pharmacyInfo.AddFormattedText(heading, new Font()
            {
                Bold = true,
                Size = 18
            });
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddFormattedText(String.Format("{0}: ", labels.OrderNumber), new Font()
            {
                Bold = true
            });
            pharmacyInfo.AddText(reportData.Orders.OrderNumber);
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddFormattedText(String.Format("{0}: ", labels.DeliveryDate), new Font()
            {
                Bold = true
            });
            pharmacyInfo.AddText(reportData.Orders.DeliveryDate.ToString("dddd, dd.MM.yyyy", new CultureInfo("de")));
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddFormattedText(String.Format("{0}: ", labels.DeliveryTime), new Font()
            {
                Bold = true
            });
            pharmacyInfo.AddText(String.Format("{0} - {1}", reportData.Orders.DeliveryTimeFrom.ToString("HH:mm"), reportData.Orders.DeliveryTimeTo.ToString("HH:mm")));
            pharmacyInfo.AddLineBreak();

            if (!summary && !String.IsNullOrEmpty(reportData.Orders.HeaderComment))
            {
                pharmacyInfo.AddFormattedText(String.Format("{0}: ", labels.HeaderComment), new Font()
                {
                    Bold = true
                });
                pharmacyInfo.AddText(reportData.Orders.HeaderComment);
                pharmacyInfo.AddLineBreak();
            }
            pharmacyInfo.AddLineBreak();
            pharmacyInfo.AddLineBreak();

            var tableOverview = CreateNewTable();
            foreach (var column in tableColumns)
            {
                tableOverview.AddColumn(column.ColumnWidth);
            }

            var rowTableHeader = tableOverview.AddRow();
            rowTableHeader.HeadingFormat = true;

            for (var i = 0; i < tableColumns.Count; i++)
            {
                var column = tableColumns[i];
                var drugColumnHeader = rowTableHeader.Cells[i].AddParagraph();
                var columnName = column.ColumnName;

                drugColumnHeader.AddFormattedText(column.ColumnName, new Font()
                {
                    Bold = true
                });

                drugColumnHeader.Format.Alignment = column.Alignment;
            }

            foreach (var tableRow in tableContents)
            {
                var contentRow = tableOverview.AddRow();
                Paragraph paragraph = null;
                for (var i = 0; i < tableRow.Count; i++)
                {
                    var content = tableRow[i];
                    if (content.NewRow)
                    {
                        if (content.Value != null && !String.IsNullOrEmpty(content.Value.ToString()))
                        {
                            contentRow = tableOverview.AddRow();
                            contentRow.Cells[0].MergeRight = tableColumns.Count() - 1;
                            contentRow.Cells[0].Format.Alignment = content.Alignment;
                            contentRow.Format.Font.Size = 10;
                            paragraph = contentRow.Cells[0].AddParagraph();
                            paragraph.AddText(content.Value.ToString());
                        }
                        continue;
                    }
                    else
                    {

                        var value = content.Value;
                        contentRow.Format.Font.Size = 10;
                        paragraph = contentRow.Cells[i].AddParagraph();
                        paragraph.Format.KeepWithNext = true;
                        contentRow.Cells[i].Format.Alignment = content.Alignment;

                        if (typeof(bool) == value.GetType())
                        {
                            paragraph.AddFormattedText((bool)value ? "\u00fe" : "\u00A8", new Font("Wingdings"));
                        }
                        else
                        {
                            paragraph.AddText(value.ToString());
                        }
                    }
                }
            }

            if (summary)
            {
                var summaryParagraph = section.AddParagraph();
                summaryParagraph.AddLineBreak();
                summaryParagraph.Format.Alignment = ParagraphAlignment.Right;
                summaryParagraph.AddFormattedText(String.Format("{0} {1}: {2}", labels.TotalQuantity, heading, tableContents.Count), new Font() { Bold = true, Size = 10 });
            }
        }

        private Table CreateNewTable()
        {
            var tableOverview = section.AddTable();
            tableOverview.Borders.Top.Width = 0;
            tableOverview.Borders.Left.Width = 0;
            tableOverview.Borders.Right.Width = 0;
            tableOverview.Borders.Bottom.Width = 0.5;
            tableOverview.Format.Font.Size = 10;
            return tableOverview;
        }

        private void AddOrderParticipantInfo(Paragraph paragraph, OrderParticipantInformation info)
        {
            foreach (var prop in info.GetType().GetProperties())
            {
                var value = prop.GetValue(info);
                if (value != null)
                {
                    paragraph.AddText(value.ToString());
                    paragraph.AddLineBreak();
                }
            }
        }
    }

    internal class TableColumnConfig
    {
        public string ColumnName { get; set; }

        public string ColumnWidth { get; set; }

        public ParagraphAlignment Alignment { get; set; }
    }

    internal class TableContent
    {
        public object Value { get; set; }

        public ParagraphAlignment Alignment { get; set; }

        public bool NewRow { get; set; }
    }
}
