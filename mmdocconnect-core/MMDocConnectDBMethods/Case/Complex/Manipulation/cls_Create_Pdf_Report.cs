/* 
 * Generated on 12/20/16 17:34:53
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.IO;
using BOp.Providers;
using System.Web;
using PdfSharp.Drawing;
using System.Net;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Archive.Atomic.Manipulation;
using System.Globalization;
using MMDocConnectDBMethods.Archive.Complex.Manipulation;
using MMDocConnectUtils;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Receipt.Manipulation;
using System.Text;
using System.Web.Configuration;
using System.Threading;
using CL1_BIL;
using MMDocConnectDBMethods.Archive.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using System.Configuration;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_HEC_CRT;
using CL1_CMN_CTR;
using System.Reflection;
using MMDocConnectDBMethods.Case.Models;
using MMDocConnectDocApp;

namespace MMDocConnectDBMethods.Case.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Create_Pdf_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Create_Pdf_Report
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_CPR_1050 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CPR_1050 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_CPR_1050();

            //Put your code here
            DateTime DateForElastic = DateTime.Now;

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            var cancellationStatuses = new int[] { 8, 10 };
            var casesGroupedByDoctor = Parameter.cases.OrderBy(t => t.TreatmentDay.Month).GroupBy(t => t.DoctorID).Select(t => new { SurgeryDoctor = t.Key, casesDoc = t.ToList() }).ToList();
            var casesForChangeStatus = Parameter.cases.Where(t => cancellationStatuses.Any(r => r == t.FsStatus)).ToList();
            foreach (var caseItem in casesForChangeStatus)
            {
                var StatusForCase = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                {
                    IsDeleted = false,
                    IsActive = true,
                    Tenant_RefID = securityTicket.TenantID,
                    BIL_BillPosition_TransmitionStatusID = caseItem.TransmitionStatusID
                }).SingleOrDefault();

                if (StatusForCase != null)
                {
                    StatusForCase.Modification_Timestamp = DateTime.Now;
                    StatusForCase.IsActive = false;
                    StatusForCase.Save(Connection, Transaction);

                    var NewStatusForCase = new ORM_BIL_BillPosition_TransmitionStatus();
                    NewStatusForCase.Modification_Timestamp = DateTime.Now;
                    NewStatusForCase.Tenant_RefID = securityTicket.TenantID;
                    NewStatusForCase.IsActive = true;
                    NewStatusForCase.BillPosition_RefID = StatusForCase.BillPosition_RefID;
                    NewStatusForCase.TransmitionCode = caseItem.FsStatus == 8 ? Convert.ToInt32(17) : Convert.ToInt32(18);
                    NewStatusForCase.TransmittedOnDate = DateTime.Now;
                    NewStatusForCase.TransmissionDataXML = StatusForCase.TransmissionDataXML;
                    NewStatusForCase.TransmitionStatusKey = StatusForCase.TransmitionStatusKey;

                    NewStatusForCase.Save(Connection, Transaction);
                }
            }

            var pdfReports = new List<PdfReportParameter>();
            var PDFNumber = cls_Get_Numbers_of_PDF_reports.Invoke(Connection, Transaction, securityTicket).Result.numbersOfPDFReports;

            foreach (var docData in casesGroupedByDoctor)
            {
                var renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
                var document = new Document();
                var docRenderer = new DocumentRenderer(document);
                PDFNumber++;
                var amount = 0d;
                var period = "";
                var doctor = docData.casesDoc.First();
                document = new Document();
                docRenderer = new DocumentRenderer(document);

                PageSetup pageSetup = new PageSetup();
                pageSetup.PageFormat = PageFormat.A4;
                pageSetup.TopMargin = Unit.FromCentimeter(2.5);
                pageSetup.BottomMargin = Unit.FromCentimeter(2.0);
                pageSetup.LeftMargin = Unit.FromCentimeter(2.5);
                pageSetup.RightMargin = Unit.FromCentimeter(2.0);
                document.Info.Title = "vorgange rechnung";

                Section section = document.AddSection();
                section.PageSetup = pageSetup;

                //style
                Style style = document.Styles["Normal"];
                style.Font.Name = "Calibri";
                style.Font.Size = 9;


                ////footer
                try
                {
                    Paragraph paragraphFooter = section.Footers.Primary.AddParagraph();
                    paragraphFooter.AddText(Properties.Resources.footerFrom + " ");
                    paragraphFooter.AddPageField();
                    paragraphFooter.AddText(" " + Properties.Resources.footerTo + " ");
                    paragraphFooter.AddNumPagesField();
                    paragraphFooter.Format.Font.Size = 9;
                    paragraphFooter.Format.Alignment = ParagraphAlignment.Right;
                }
                catch
                {
                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("footer"));
                    throw;
                }
                //header

                //logo
                Paragraph ParagraphimageLogo = section.Headers.Primary.AddParagraph();
                ParagraphimageLogo.Format.Alignment = ParagraphAlignment.Right;
                Image imageLogo = ParagraphimageLogo.AddImage(HttpContext.Current.Server.MapPath("~/Content/images/medioslogo.jpg"));
                imageLogo.Width = new Unit(5.803, UnitType.Centimeter);
                imageLogo.Height = new Unit(1.43, UnitType.Centimeter);
                imageLogo.LockAspectRatio = true;


                Table tableHeader = section.AddTable();
                tableHeader.Borders.Width = 0;
                Column tableColumnLeft = tableHeader.AddColumn("8.25cm");
                tableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                Column tableColumnRight = tableHeader.AddColumn("8.25cm");
                tableColumnRight.Format.Alignment = ParagraphAlignment.Right;
                Row row = tableHeader.AddRow();
                try
                {
                    Paragraph adressParagraph = row.Cells[0].AddParagraph();
                    adressParagraph.Format.SpaceBefore = "1cm";
                    adressParagraph.Format.SpaceAfter = "0.5cm";
                    adressParagraph.AddText(WebConfigurationManager.AppSettings["mediosmanagementFullAddress"]);
                    adressParagraph.Format.Font.Size = 7;
                    adressParagraph.Format.Alignment = ParagraphAlignment.Left;
                }
                catch
                {
                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("address"));
                    throw;
                }

                Paragraph Infoparagraph = row.Cells[0].AddParagraph();
                Infoparagraph.AddText(doctor.PracticeName);
                Infoparagraph.AddLineBreak();
                Infoparagraph.AddText(GenericUtils.GetDoctorNamePrefixPascal(doctor));
                Infoparagraph.AddLineBreak();
                Infoparagraph.AddText(doctor.Address);
                Infoparagraph.Format.Font.Size = 12;
                Infoparagraph.Format.Alignment = ParagraphAlignment.Left;
                Paragraph InfoparagraphCity = row.Cells[0].AddParagraph();
                InfoparagraphCity.Format.SpaceBefore = "0.5cm";
                InfoparagraphCity.AddText(doctor.City);
                InfoparagraphCity.Format.Font.Size = 11.5;
                InfoparagraphCity.Format.Alignment = ParagraphAlignment.Left;

                try
                {
                    Paragraph InfoparagraphBankContact = row.Cells[1].AddParagraph();
                    InfoparagraphBankContact.Format.SpaceBefore = "1cm";
                    InfoparagraphBankContact.Format.Font.Size = 7;
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagement"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementAddress"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementTelefon"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementFax"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementEmail"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementWeb"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementCEO"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementHRB"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementAddress2"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementBank"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementIBAN"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementBIC"]);
                    InfoparagraphBankContact.AddLineBreak();
                    InfoparagraphBankContact.AddText(WebConfigurationManager.AppSettings["mediosmanagementUST"]);
                    InfoparagraphBankContact.Format.Alignment = ParagraphAlignment.Right;
                }
                catch
                {
                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("bank info paragraph"));
                    throw;
                }

                try
                {

                    Paragraph paragraphTableInfo = section.AddParagraph();
                    paragraphTableInfo.AddText(Properties.Resources.invoiceFrom + ": " + DateTime.Now.ToString("dd.MM.yyyy"));
                    paragraphTableInfo.AddLineBreak();
                    paragraphTableInfo.Format.Alignment = ParagraphAlignment.Left;


                    string PDFNumberStr = DateTime.Now.ToString("yyMM") + "-" + PDFNumber.ToString("D4");
                    paragraphTableInfo.AddText(Properties.Resources.invoiceNumber + ": " + PDFNumberStr);
                    paragraphTableInfo.Format.Font.Size = 12;
                    paragraphTableInfo.Format.SpaceBefore = "2cm";
                    paragraphTableInfo.Format.SpaceAfter = "1cm";

                    Table tableOverview = section.AddTable();
                    tableOverview.Borders.Top.Width = 0;
                    tableOverview.Borders.Left.Width = 0;
                    tableOverview.Borders.Right.Width = 0;
                    tableOverview.Borders.Bottom.Width = 1;
                    tableOverview.Format.Font.Size = 12;
                    Column ColumnDate = tableOverview.AddColumn("9cm");
                    tableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                    Column ColumnCount = tableOverview.AddColumn("2cm");
                    tableColumnRight.Format.Alignment = ParagraphAlignment.Right;
                    Column ColumnAmount = tableOverview.AddColumn("2.5cm");
                    tableColumnRight.Format.Alignment = ParagraphAlignment.Right;
                    Row rowTableHeader = tableOverview.AddRow();
                    rowTableHeader.HeadingFormat = true;
                    rowTableHeader.Cells[0].AddParagraph(Properties.Resources.InvoicePeriod);
                    rowTableHeader.Format.Font.Color = Color.Parse("0xFF1C384F");
                    rowTableHeader.Format.Font.Size = 16;
                    rowTableHeader.Format.SpaceBefore = "0.5cm";
                    rowTableHeader.Format.SpaceAfter = "0.3cm";

                    var monthly = docData.casesDoc.GroupBy(dt => dt.TreatmentDay.Month).Select(group2 => new { TreatmentDate = group2.Key, Monthly = group2.ToList() }).ToList();
                    var sumComplete = 0d;
                    foreach (var item in monthly)
                    {
                        Row row1 = tableOverview.AddRow();
                        row1.Format.Font.Size = 12;
                        row1.Cells[0].AddParagraph(item.Monthly.First().TreatmentDay.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)));
                        period = period == "" ? period + item.Monthly.First().TreatmentDay.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)) : period + ", " + item.Monthly.First().TreatmentDay.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                        row1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        row1.Cells[1].AddParagraph(item.Monthly.Count().ToString());
                        row1.Cells[1].Format.Alignment = ParagraphAlignment.Right;

                        var sumPlus = (from sum in item.Monthly select sum.AmountForThisGPOS).Sum();
                        var sumMinus = (from sum in item.Monthly.Where(st => st.FsStatus == 8 || st.FsStatus == 10) select sum.AmountForThisGPOS).Sum();
                        var sumCalculated = sumPlus - sumMinus;
                        sumComplete = sumComplete + sumCalculated;
                        row1.Cells[2].AddParagraph(string.Format("{0:n}", sumCalculated, new System.Globalization.CultureInfo("de", true)) + " €");
                        row1.Cells[2].Format.Alignment = ParagraphAlignment.Right;

                    }

                    Row rowTableFooter = tableOverview.AddRow();
                    rowTableFooter.Format.SpaceBefore = "0.5cm";
                    rowTableFooter.Cells[0].AddParagraph(Properties.Resources.InvoiceSumme);
                    rowTableFooter.Cells[1].AddParagraph("");
                    rowTableFooter.Cells[2].AddParagraph(string.Format("{0:n}", sumComplete, new System.Globalization.CultureInfo("de", true)) + " €");
                    rowTableFooter.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                    rowTableFooter.Format.Font.Size = 12;
                    rowTableFooter.Format.Font.Bold = true;

                    Paragraph paragraphdoctorBankInfo = section.AddParagraph();
                    paragraphdoctorBankInfo.Format.SpaceBefore = "1cm";
                    paragraphdoctorBankInfo.AddText(Properties.Resources.InvoiceForAccount);
                    paragraphdoctorBankInfo.AddLineBreak();
                    paragraphdoctorBankInfo.Format.Font.Size = 12;
                    paragraphdoctorBankInfo.AddText(doctor.IBAN + " (" + doctor.BankName + "/" + doctor.BIC + ")");
                    paragraphdoctorBankInfo.AddLineBreak();
                    paragraphdoctorBankInfo.AddText(Properties.Resources.InvoiceRemitted);


                    foreach (var month in monthly)
                    {


                        Section sectionMonth = document.AddSection();
                        sectionMonth.PageSetup = pageSetup.Clone(); ;
                        sectionMonth.Add(tableHeader.Clone());
                        sectionMonth.Add(paragraphTableInfo.Clone());
                        Paragraph logoHeader = sectionMonth.Headers.Primary.AddParagraph();
                        logoHeader.Add(imageLogo.Clone());
                        logoHeader.Format.Alignment = ParagraphAlignment.Right;
                        Table tableMonthlyDetailed = sectionMonth.AddTable();
                        tableMonthlyDetailed.Borders.Top.Width = 0;
                        tableMonthlyDetailed.Borders.Left.Width = 0;
                        tableMonthlyDetailed.Borders.Right.Width = 0;
                        tableMonthlyDetailed.Borders.Bottom.Width = 1;
                        tableMonthlyDetailed.Format.Font.Size = 12;
                        Column ColumnPosition = tableMonthlyDetailed.AddColumn("9cm");
                        tableColumnLeft.Format.Alignment = ParagraphAlignment.Left;
                        Column ColumnCountDetailed = tableMonthlyDetailed.AddColumn("2cm");
                        tableColumnRight.Format.Alignment = ParagraphAlignment.Right;
                        Column ColumnAmountDetailed = tableMonthlyDetailed.AddColumn("2.5cm");
                        tableColumnRight.Format.Alignment = ParagraphAlignment.Right;
                        Row rowTableHeaderDetailed = tableMonthlyDetailed.AddRow();
                        rowTableHeaderDetailed.HeadingFormat = true;
                        rowTableHeaderDetailed.Cells[0].MergeRight = 2;
                        rowTableHeaderDetailed.Cells[0].AddParagraph(Properties.Resources.InvoicePeriod2begin + " " + month.Monthly.FirstOrDefault().TreatmentDay.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)) + " " + Properties.Resources.InvoicePeriod2end);
                        rowTableHeaderDetailed.Format.Font.Color = Color.Parse("0xFF1C384F");
                        rowTableHeaderDetailed.Format.Font.Size = 16;
                        rowTableHeaderDetailed.Format.SpaceAfter = "0.3cm";
                        var position = month.Monthly.GroupBy(dt => dt.CaseType).Select(group2 => new { CodeName = group2.Key, Monthly = group2.ToList() }).ToList();
                        var sum = 0d;

                        foreach (var positionItem in position)
                        {
                            Row row1 = tableMonthlyDetailed.AddRow();
                            row1.Borders.Bottom.Width = 1;
                            row1.Cells[0].AddParagraph(positionItem.CodeName);
                            row1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                            row1.Cells[1].AddParagraph(positionItem.Monthly.Where(cd => cd.CaseType == positionItem.CodeName && cd.FsStatus == 7).ToList().Count().ToString());
                            row1.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                            row1.Cells[2].AddParagraph(string.Format("{0:n}", positionItem.Monthly.Sum(itm => itm.AmountForThisGPOS), new System.Globalization.CultureInfo("de", true)) + " €");
                            row1.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                            sum = sum + positionItem.Monthly.Sum(itm => itm.AmountForThisGPOS);
                        }

                        if (month.Monthly.Any(fs => fs.FsStatus == 8))
                        {
                            Row row1 = tableMonthlyDetailed.AddRow();
                            row1.Borders.Bottom.Width = 1;
                            row1.Cells[0].AddParagraph(Properties.Resources.Deleted);
                            row1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                            row1.Cells[1].AddParagraph(month.Monthly.Where(cd => cd.FsStatus == 8).ToList().Count().ToString());
                            row1.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                            row1.Cells[2].AddParagraph("-" + string.Format("{0:n}", month.Monthly.Where(cd => cd.FsStatus == 8).ToList().Sum(it => it.AmountForThisGPOS), new System.Globalization.CultureInfo("de", true)) + " €");
                            row1.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                            sum = sum - month.Monthly.Where(cd => cd.FsStatus == 8).ToList().Sum(it => it.AmountForThisGPOS);
                        }

                        if (month.Monthly.Any(fs => fs.FsStatus == 10))
                        {
                            Row row1 = tableMonthlyDetailed.AddRow();
                            row1.Borders.Bottom.Width = 1;
                            row1.Cells[0].AddParagraph(Properties.Resources.Reclaimed);
                            row1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                            row1.Cells[1].AddParagraph(month.Monthly.Where(cd => cd.FsStatus == 10).ToList().Count().ToString());
                            row1.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                            row1.Cells[2].AddParagraph("-" + string.Format("{0:n}", month.Monthly.Where(cd => cd.FsStatus == 10).ToList().Sum(it => it.AmountForThisGPOS), new System.Globalization.CultureInfo("de", true)) + " €");
                            row1.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                            sum = sum - month.Monthly.Where(cd => cd.FsStatus == 10).ToList().Sum(it => it.AmountForThisGPOS);
                        }

                        Row rowTablePositionFooter = tableMonthlyDetailed.AddRow();
                        rowTablePositionFooter.Format.SpaceBefore = "0.5cm";
                        rowTablePositionFooter.HeadingFormat = true;
                        rowTablePositionFooter.Cells[0].AddParagraph(Properties.Resources.InvoiceSumme);
                        rowTablePositionFooter.Cells[1].AddParagraph("");
                        amount += sum;
                        rowTablePositionFooter.Cells[2].AddParagraph(string.Format("{0:n}", sum, new System.Globalization.CultureInfo("de", true)) + " €");
                        rowTablePositionFooter.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                        rowTablePositionFooter.Format.Font.Size = 12;
                        rowTablePositionFooter.Format.Font.Bold = true;

                        Paragraph detailedPosition = paragraphTableInfo.Clone();
                        detailedPosition.AddLineBreak();
                        detailedPosition.AddText(Properties.Resources.PeriodOfInvoice + " " + month.Monthly.FirstOrDefault().TreatmentDay.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)));
                        detailedPosition.Format.Font.Size = 10;
                        detailedPosition.Format.Alignment = ParagraphAlignment.Right;
                        detailedPosition.Format.SpaceBefore = "1cm";
                        detailedPosition.Format.SpaceAfter = "1cm";

                        Section sectionDetailed = document.AddSection();
                        sectionDetailed.PageSetup = pageSetup.Clone();
                        sectionDetailed.PageSetup.TopMargin = Unit.FromCentimeter(5.5);
                        Paragraph logoCloned = sectionDetailed.Headers.Primary.AddParagraph();
                        logoCloned.Add(imageLogo.Clone());
                        logoCloned.Format.Alignment = ParagraphAlignment.Right;
                        Paragraph detailedPositionCl = detailedPosition.Clone();
                        detailedPositionCl.Format.Alignment = ParagraphAlignment.Right;
                        sectionDetailed.Headers.Primary.Add(detailedPositionCl.Clone());

                        Paragraph TableTitle = sectionDetailed.AddParagraph();
                        TableTitle.AddText(Properties.Resources.DetailedInfoForInvoice + " " + month.Monthly.FirstOrDefault().TreatmentDay.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true)));
                        TableTitle.Format.Font.Color = Color.Parse("0xFF1C384F");
                        TableTitle.Format.Font.Size = 16;

                        var aokGroup = month.Monthly.Where(st => st.FsStatus != 8 && st.FsStatus != 10).GroupBy(gr => gr.HIP).Select(group => new { PatientHIP = group.Key, aok = group.ToList() }).ToList();
                        var aokGroupStornirung = month.Monthly.Where(st => st.FsStatus == 8).ToList();
                        var aokGroupReclaimed = month.Monthly.Where(st => st.FsStatus == 10).ToList();
                        foreach (var aokItem in aokGroup)
                        {
                            Paragraph tableAOKName = sectionDetailed.AddParagraph();
                            tableAOKName.Format.SpaceBefore = "1cm";
                            tableAOKName.Format.SpaceAfter = "0.3cm";
                            tableAOKName.Format.Font.Bold = true;
                            try
                            {
                                tableAOKName.AddText(aokItem.PatientHIP);
                            }
                            catch
                            {
                                LogUtils.Logger.LogInfo(new LogUtils.LogEntry("patient hip"));
                                throw;
                            }
                            tableAOKName.Format.Font.Size = 12;
                            tableAOKName.Format.KeepWithNext = true;

                            docRenderer.PrepareDocument();
                            int pageCountAfterParagraph = docRenderer.FormattedDocument.PageCount;

                            Table tablePositionDetailed = sectionDetailed.AddTable();
                            tablePositionDetailed.Format.Font.Size = 10;
                            tablePositionDetailed.Borders.Top.Width = 1;
                            tablePositionDetailed.Borders.Bottom.Width = 1;
                            tablePositionDetailed.SetEdge(0, 0, tablePositionDetailed.Rows.Count, 0, Edge.Bottom, BorderStyle.Dot, 1, Colors.Black);
                            Column ColumnDateDetailed = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnDateDetailed.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnPatientDetailed = tablePositionDetailed.AddColumn("3.5cm");
                            ColumnPatientDetailed.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnDiagnose = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnDiagnose.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnGPOS = tablePositionDetailed.AddColumn("6.5cm");
                            ColumnGPOS.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnCaseNumber = tablePositionDetailed.AddColumn("2cm");
                            ColumnCaseNumber.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnAmountEuro = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnAmountEuro.Format.Alignment = ParagraphAlignment.Right;
                            Row rowHeader = tablePositionDetailed.AddRow();
                            rowHeader.Style = "bold";
                            rowHeader.HeadingFormat = true;
                            rowHeader.Format.Font.Bold = true;
                            rowHeader.Cells[0].AddParagraph(Properties.Resources.Date);
                            Paragraph patientDetailsHeader = rowHeader.Cells[1].AddParagraph();
                            patientDetailsHeader.AddText(Properties.Resources.Patient);
                            patientDetailsHeader.AddLineBreak();
                            patientDetailsHeader.AddText(Properties.Resources.PatientBirthDate);
                            patientDetailsHeader.AddLineBreak();
                            patientDetailsHeader.AddText(Properties.Resources.PatientInsuranceNumber);
                            Paragraph diagLokalDetailsHeader = rowHeader.Cells[2].AddParagraph();
                            diagLokalDetailsHeader.AddText(Properties.Resources.Diagnose);
                            diagLokalDetailsHeader.AddLineBreak();
                            diagLokalDetailsHeader.AddText(Properties.Resources.Localization);
                            rowHeader.Cells[3].AddParagraph(Properties.Resources.GPOS);
                            rowHeader.Cells[4].AddParagraph(Properties.Resources.referenceNumber);
                            Paragraph AmountHeader = rowHeader.Cells[5].AddParagraph();
                            AmountHeader.AddText(Properties.Resources.Amount);
                            AmountHeader.AddLineBreak();
                            AmountHeader.AddText(Properties.Resources.Euro);
                            AmountHeader.Format.Alignment = ParagraphAlignment.Right;


                            var pageCountAfterheader = docRenderer.FormattedDocument.PageCount;
                            if (pageCountAfterParagraph != pageCountAfterheader)
                            {
                                var idx = sectionDetailed.Elements.IndexOf(tableAOKName);
                                sectionDetailed.Elements.InsertObject(idx, new PageBreak());

                            }

                            var sumGPOS = 0d;
                            var caseGroup = aokItem.aok.GroupBy(gr => gr.CaseNumber).Select(group => new { CaseNumber = group.Key, casegroup = group.ToList() }).ToList();

                            foreach (var caseItem in caseGroup)
                            {
                                foreach (var caseitem in caseItem.casegroup)
                                {
                                    Row rowDetailed = tablePositionDetailed.AddRow();
                                    rowDetailed.Cells[0].AddParagraph(caseitem.TreatmentDay.ToString("dd.MM"));
                                    rowDetailed.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                                    Paragraph patientDetails = rowDetailed.Cells[1].AddParagraph();
                                    try
                                    {
                                        patientDetails.AddText(caseitem.PatientLastName + ", " + caseitem.PatientFirstName);
                                        patientDetails.AddLineBreak();
                                        patientDetails.AddText(caseitem.PatientBirthday.ToString("dd.MM.yyyy"));
                                        patientDetails.AddLineBreak();
                                        patientDetails.AddText(caseitem.PatientInsuranceNumber);
                                    }
                                    catch
                                    {
                                        LogUtils.Logger.LogInfo(new LogUtils.LogEntry("patient base data"));
                                        throw;
                                    }
                                    rowDetailed.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                                    var diagnoseCode = caseitem.DiagnoseCode ?? "-";
                                    rowDetailed.Cells[2].AddParagraph(diagnoseCode + "/" + caseitem.Localization);
                                    rowDetailed.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                                    Paragraph gpos = rowDetailed.Cells[3].AddParagraph();
                                    rowDetailed.Cells[3].Format.Alignment = ParagraphAlignment.Left;

                                    Paragraph amountGpos = rowDetailed.Cells[5].AddParagraph();
                                    rowDetailed.Cells[5].Format.Alignment = ParagraphAlignment.Right;

                                    var caseNum = caseitem.InvoiceNumberForTheHIP;
                                    rowDetailed.Cells[4].AddParagraph(caseNum.ToString());
                                    rowDetailed.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                                    try
                                    {
                                        gpos.AddText(caseitem.CaseType);
                                    }
                                    catch
                                    {
                                        LogUtils.Logger.LogInfo(new LogUtils.LogEntry("case code name"));
                                        throw;
                                    }
                                    gpos.AddLineBreak();
                                    amountGpos.AddText(string.Format("{0:n}", caseitem.AmountForThisGPOS, new System.Globalization.CultureInfo("de", true)));
                                    amountGpos.AddLineBreak();
                                    sumGPOS = sumGPOS + caseitem.AmountForThisGPOS;
                                }
                            }

                            Row rowFooter = tablePositionDetailed.AddRow();
                            rowFooter.Format.SpaceBefore = "0.5cm";
                            rowFooter.Format.Font.Bold = true;
                            rowFooter.Cells[0].AddParagraph(Properties.Resources.SumFor + " " + aokItem.PatientHIP);
                            rowFooter.Cells[0].MergeRight = 3;
                            rowFooter.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                            rowFooter.Cells[4].AddParagraph(string.Format("{0:n}", sumGPOS, new System.Globalization.CultureInfo("de", true)));
                            rowFooter.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                            rowFooter.Cells[4].MergeRight = 1;
                        }

                        if (aokGroupStornirung.Any())
                        {

                            Paragraph tableAOKName = sectionDetailed.AddParagraph();
                            tableAOKName.AddText(Properties.Resources.Deleted);
                            tableAOKName.Format.Font.Size = 12;
                            tableAOKName.Format.SpaceBefore = "0.5cm";
                            tableAOKName.Format.SpaceAfter = "0.3cm";
                            tableAOKName.Format.Font.Bold = true;

                            docRenderer.PrepareDocument();
                            int pageCountAfterParagraph = docRenderer.FormattedDocument.PageCount;

                            Table tablePositionDetailed = sectionDetailed.AddTable();
                            tablePositionDetailed.Format.Font.Size = 10;
                            tablePositionDetailed.Borders.Top.Width = 1;
                            tablePositionDetailed.Borders.Bottom.Width = 1;
                            tablePositionDetailed.SetEdge(0, 0, tablePositionDetailed.Rows.Count, 0, Edge.Bottom, BorderStyle.Dot, 1, Colors.Black);
                            Column ColumnDateDetailed = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnDateDetailed.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnPatientDetailed = tablePositionDetailed.AddColumn("3.5cm");
                            ColumnPatientDetailed.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnDiagnose = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnDiagnose.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnGPOS = tablePositionDetailed.AddColumn("6.5cm");
                            ColumnGPOS.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnCaseNumber = tablePositionDetailed.AddColumn("2cm");
                            ColumnCaseNumber.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnAmountEuro = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnAmountEuro.Format.Alignment = ParagraphAlignment.Right;
                            Row rowHeader = tablePositionDetailed.AddRow();
                            rowHeader.HeadingFormat = true;
                            rowHeader.Format.Font.Bold = true;
                            rowHeader.Cells[0].AddParagraph(Properties.Resources.Date);
                            Paragraph patientDetailsHeader = rowHeader.Cells[1].AddParagraph();
                            patientDetailsHeader.AddText(Properties.Resources.Patient);
                            patientDetailsHeader.AddLineBreak();
                            patientDetailsHeader.AddText(Properties.Resources.PatientBirthDate);
                            patientDetailsHeader.AddLineBreak();
                            patientDetailsHeader.AddText(Properties.Resources.PatientInsuranceNumber);
                            Paragraph diagLokalDetailsHeader = rowHeader.Cells[2].AddParagraph();
                            diagLokalDetailsHeader.AddText(Properties.Resources.Diagnose);
                            diagLokalDetailsHeader.AddLineBreak();
                            diagLokalDetailsHeader.AddText(Properties.Resources.Localization);
                            rowHeader.Cells[3].AddParagraph(Properties.Resources.GPOS);
                            rowHeader.Cells[4].AddParagraph(Properties.Resources.referenceNumber);
                            Paragraph AmountHeader = rowHeader.Cells[5].AddParagraph();
                            AmountHeader.AddText(Properties.Resources.Amount);
                            AmountHeader.AddLineBreak();
                            AmountHeader.AddText(Properties.Resources.Euro);
                            AmountHeader.Format.Alignment = ParagraphAlignment.Right;

                            docRenderer.PrepareDocument();
                            int pageCountAfterheader = docRenderer.FormattedDocument.PageCount;
                            if (pageCountAfterParagraph != pageCountAfterheader)
                            {
                                int idx = sectionDetailed.Elements.IndexOf(tableAOKName);
                                sectionDetailed.Elements.InsertObject(idx, new PageBreak());

                            }
                            var sumGPOS = 0d;

                            foreach (var caseItem in aokGroupStornirung)
                            {
                                Row rowDetailed = tablePositionDetailed.AddRow();
                                rowDetailed.Cells[0].AddParagraph(caseItem.TreatmentDay.ToString("dd.MM"));
                                rowDetailed.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                                Paragraph patientDetails = rowDetailed.Cells[1].AddParagraph();
                                rowDetailed.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                                try
                                {
                                    patientDetails.AddText(caseItem.PatientLastName + ", " + caseItem.PatientFirstName);
                                    patientDetails.AddLineBreak();
                                    patientDetails.AddText(caseItem.PatientBirthday.ToString("dd.MM.yyyy"));
                                    patientDetails.AddLineBreak();
                                    patientDetails.AddText(caseItem.PatientInsuranceNumber);
                                }
                                catch
                                {
                                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("patient base data line 709"));
                                    throw;
                                }
                                var diagnoseCode = caseItem.DiagnoseCode ?? "-";
                                rowDetailed.Cells[2].AddParagraph(diagnoseCode + "/" + caseItem.Localization);
                                rowDetailed.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                                Paragraph gpos = rowDetailed.Cells[3].AddParagraph();
                                rowDetailed.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                                var caseNum = caseItem.InvoiceNumberForTheHIP;
                                rowDetailed.Cells[4].AddParagraph(caseNum.ToString());

                                //  rowDetailed.Cells[4].AddParagraph(caseItem.PositionNumber);
                                rowDetailed.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                                Paragraph amountGpos = rowDetailed.Cells[5].AddParagraph();
                                rowDetailed.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                                try
                                {
                                    gpos.AddText(caseItem.CaseType);
                                }
                                catch
                                {
                                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("case code name 723 line"));
                                    throw;
                                }
                                gpos.AddLineBreak();
                                amountGpos.AddText("-" + string.Format("{0:n}", caseItem.AmountForThisGPOS, new System.Globalization.CultureInfo("de", true)));
                                amountGpos.AddLineBreak();
                                sumGPOS = sumGPOS + caseItem.AmountForThisGPOS;

                            }

                            Row rowFooter = tablePositionDetailed.AddRow();
                            rowFooter.Format.SpaceBefore = "0.5cm";
                            rowFooter.Format.Font.Bold = true;
                            rowFooter.Cells[0].AddParagraph(Properties.Resources.SumForDeleted);
                            rowFooter.Cells[0].MergeRight = 3;
                            rowFooter.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                            rowFooter.Cells[4].AddParagraph("-" + string.Format("{0:n}", sumGPOS, new System.Globalization.CultureInfo("de", true)));
                            rowFooter.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                            rowFooter.Cells[4].MergeRight = 1;

                        }
                        //reclaimed 

                        if (aokGroupReclaimed.Any())
                        {

                            Paragraph tableAOKName = sectionDetailed.AddParagraph();
                            tableAOKName.AddText(Properties.Resources.Reclaimed);
                            tableAOKName.Format.Font.Size = 12;
                            tableAOKName.Format.SpaceBefore = "0.5cm";
                            tableAOKName.Format.SpaceAfter = "0.3cm";
                            tableAOKName.Format.Font.Bold = true;

                            docRenderer.PrepareDocument();
                            int pageCountAfterParagraph = docRenderer.FormattedDocument.PageCount;

                            Table tablePositionDetailed = sectionDetailed.AddTable();
                            tablePositionDetailed.Format.Font.Size = 10;
                            tablePositionDetailed.Borders.Top.Width = 1;
                            tablePositionDetailed.Borders.Bottom.Width = 1;
                            tablePositionDetailed.SetEdge(0, 0, tablePositionDetailed.Rows.Count, 0, Edge.Bottom, BorderStyle.Dot, 1, Colors.Black);
                            Column ColumnDateDetailed = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnDateDetailed.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnPatientDetailed = tablePositionDetailed.AddColumn("3.5cm");
                            ColumnPatientDetailed.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnDiagnose = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnDiagnose.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnGPOS = tablePositionDetailed.AddColumn("6.5cm");
                            ColumnGPOS.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnCaseNumber = tablePositionDetailed.AddColumn("2cm");
                            ColumnCaseNumber.Format.Alignment = ParagraphAlignment.Left;
                            Column ColumnAmountEuro = tablePositionDetailed.AddColumn("1.5cm");
                            ColumnAmountEuro.Format.Alignment = ParagraphAlignment.Right;
                            Row rowHeader = tablePositionDetailed.AddRow();
                            rowHeader.HeadingFormat = true;
                            rowHeader.Format.Font.Bold = true;
                            rowHeader.Cells[0].AddParagraph(Properties.Resources.Date);
                            Paragraph patientDetailsHeader = rowHeader.Cells[1].AddParagraph();
                            patientDetailsHeader.AddText(Properties.Resources.Patient);
                            patientDetailsHeader.AddLineBreak();
                            patientDetailsHeader.AddText(Properties.Resources.PatientBirthDate);
                            patientDetailsHeader.AddLineBreak();
                            patientDetailsHeader.AddText(Properties.Resources.PatientInsuranceNumber);
                            Paragraph diagLokalDetailsHeader = rowHeader.Cells[2].AddParagraph();
                            diagLokalDetailsHeader.AddText(Properties.Resources.Diagnose);
                            diagLokalDetailsHeader.AddLineBreak();
                            diagLokalDetailsHeader.AddText(Properties.Resources.Localization);
                            rowHeader.Cells[3].AddParagraph(Properties.Resources.GPOS);
                            Paragraph GPOSHeader = rowHeader.Cells[4].AddParagraph();
                            GPOSHeader.AddText(Properties.Resources.CaseNum1);
                            GPOSHeader.AddLineBreak();
                            GPOSHeader.AddText(Properties.Resources.CaseNum2);
                            GPOSHeader.Format.Alignment = ParagraphAlignment.Left;
                            Paragraph AmountHeader = rowHeader.Cells[5].AddParagraph();
                            AmountHeader.AddText(Properties.Resources.Amount);
                            AmountHeader.AddLineBreak();
                            AmountHeader.AddText(Properties.Resources.Euro);
                            AmountHeader.Format.Alignment = ParagraphAlignment.Right;

                            docRenderer.PrepareDocument();
                            int pageCountAfterheader = docRenderer.FormattedDocument.PageCount;
                            if (pageCountAfterParagraph != pageCountAfterheader)
                            {
                                int idx = sectionDetailed.Elements.IndexOf(tableAOKName);
                                sectionDetailed.Elements.InsertObject(idx, new PageBreak());

                            }
                            var sumGPOS = 0d;

                            foreach (var caseItem in aokGroupReclaimed)
                            {

                                Row rowDetailed = tablePositionDetailed.AddRow();

                                rowDetailed.Cells[0].AddParagraph(caseItem.TreatmentDay.ToString("dd.MM"));

                                rowDetailed.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                                Paragraph patientDetails = rowDetailed.Cells[1].AddParagraph();
                                rowDetailed.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                                try
                                {
                                    patientDetails.AddText(caseItem.PatientLastName + ", " + caseItem.PatientFirstName);
                                    patientDetails.AddLineBreak();
                                    patientDetails.AddText(caseItem.PatientBirthday.ToString("dd.MM.yyyy"));
                                    patientDetails.AddLineBreak();
                                    patientDetails.AddText(caseItem.PatientInsuranceNumber);
                                }
                                catch
                                {
                                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("patient base data line 828"));
                                    throw;
                                }
                                var diagnoseCode = caseItem.DiagnoseCode ?? "-";
                                rowDetailed.Cells[2].AddParagraph(diagnoseCode + "/" + caseItem.Localization);
                                rowDetailed.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                                Paragraph gpos = rowDetailed.Cells[3].AddParagraph();
                                rowDetailed.Cells[3].Format.Alignment = ParagraphAlignment.Left;

                                var caseNum = caseItem.InvoiceNumberForTheHIP;
                                rowDetailed.Cells[4].AddParagraph(caseNum.ToString());
                                // rowDetailed.Cells[4].AddParagraph(caseItem.PositionNumber);
                                rowDetailed.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                                Paragraph amountGpos = rowDetailed.Cells[5].AddParagraph();
                                rowDetailed.Cells[5].Format.Alignment = ParagraphAlignment.Right;
                                try
                                {
                                    gpos.AddText(caseItem.CaseType);
                                }
                                catch
                                {
                                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("case code name line 852"));
                                    throw;
                                }
                                gpos.AddLineBreak();
                                amountGpos.AddText("-" + string.Format("{0:n}", caseItem.AmountForThisGPOS, new System.Globalization.CultureInfo("de", true)));
                                amountGpos.AddLineBreak();
                                sumGPOS = sumGPOS + caseItem.AmountForThisGPOS;

                            }

                            Row rowFooter = tablePositionDetailed.AddRow();
                            rowFooter.Format.SpaceBefore = "0.5cm";
                            rowFooter.Format.Font.Bold = true;
                            rowFooter.Cells[0].AddParagraph(Properties.Resources.SumForReclaimed);
                            rowFooter.Cells[0].MergeRight = 3;
                            rowFooter.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                            rowFooter.Cells[4].AddParagraph("-" + string.Format("{0:n}", sumGPOS, new System.Globalization.CultureInfo("de", true)));
                            rowFooter.Cells[4].Format.Alignment = ParagraphAlignment.Right;
                            rowFooter.Cells[4].MergeRight = 1;
                        }


                    }
                }
                catch
                {
                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("invoice"));
                    throw;
                }

                //save and download document
                renderer.Document = document;
                renderer.RenderDocument();
                var caseSortedByDate = docData.casesDoc.OrderBy(dt => dt.TreatmentDay).ToList();
                string dateFrom = caseSortedByDate.First().TreatmentDay.ToString("dd.MM.yyyy");
                string dateTo = caseSortedByDate.Last().TreatmentDay.ToString("dd.MM.yyyy");
                string filename = " Vorgänge von " + dateFrom + " - " + dateTo;

                int page = renderer.PdfDocument.Pages.Count;

                //Add lines to document
                for (int i = 0; i < page; i++)
                {
                    PdfPage pagePdf = renderer.PdfDocument.Pages[i];

                    XGraphics gfx = XGraphics.FromPdfPage(pagePdf);
                    gfx.DrawLine(XPens.Black, new Unit(0, UnitType.Centimeter), new Unit(10.5, UnitType.Centimeter), new Unit(1.08, UnitType.Centimeter), new Unit(10.5, UnitType.Centimeter));
                    gfx.DrawLine(XPens.Black, new Unit(0, UnitType.Centimeter), new Unit(15, UnitType.Centimeter), new Unit(1.08, UnitType.Centimeter), new Unit(15, UnitType.Centimeter));
                }
                MemoryStream stream = new MemoryStream();
                renderer.Save(stream, false);
                byte[] bytes = stream.ToArray();

                pdfReports.Add(new PdfReportParameter()
                {
                    Amount = amount,
                    Doctor = new PdfReportDoctor()
                    {
                        Title = doctor.DoctorTitle,
                        FirstName = doctor.DoctorFirstName,
                        LastName = doctor.DoctorLastName,
                        Id = doctor.DoctorID,
                        Email = doctor.DoctorEmail
                    },
                    DocumentBytes = bytes,
                    FileName = filename,
                    Period = period
                });
            }

            var documentProvider = ProviderFactory.Instance.CreateDocumentServiceProvider();
            var uploadedFrom = HttpContext.Current.Request.UserHostAddress;

            foreach (var doc in pdfReports)
            {
                var mime = UtilMethods.GetMimeType(doc.FileName + ".pdf");
                Guid documentID = documentProvider.UploadDocument(doc.DocumentBytes, doc.FileName + ".pdf", securityTicket.SessionTicket, uploadedFrom);

                //upload pdf report to archive MM 
                P_ARCH_UD_1326 parameterDoc = new P_ARCH_UD_1326();
                parameterDoc.DocumentID = documentID;
                parameterDoc.Mime = UtilMethods.GetMimeType(doc.FileName + ".pdf");
                parameterDoc.DocumentName = Properties.Resources.InvoiceDocumentName;
                parameterDoc.DocumentDate = DateForElastic;
                parameterDoc.Receiver = String.Format("{0} {1} {2}", doc.Doctor.Title, doc.Doctor.FirstName, doc.Doctor.LastName);
                parameterDoc.Description = doc.FileName;
                cls_Upload_Report.Invoke(Connection, Transaction, parameterDoc, securityTicket);

                //upload pdf report to receipt DOC 
                P_ARCH_UPD_1434 parameterPDF = new P_ARCH_UPD_1434();
                parameterPDF.DocumentID = documentID;
                parameterPDF.Mime = UtilMethods.GetMimeType(doc.FileName + ".pdf");
                parameterPDF.DocumentName = Properties.Resources.InvoiceDocumentName;
                parameterPDF.DocumentDate = DateForElastic;
                parameterPDF.Description = doc.Period;
                parameterPDF.RecepiantID = doc.Doctor.Id;
                parameterPDF.Amount = string.Format("{0:n}", doc.Amount, new System.Globalization.CultureInfo("de", true)) + " €";
                parameterPDF.AmountNo = Convert.ToInt32(doc.Amount);
                parameterPDF.DocumentID = documentID;
                parameterPDF.Receiver = String.Format("{0} {1} {2}", doc.Doctor.Title, doc.Doctor.LastName, doc.Doctor.FirstName);
                cls_Upload_PDF_Report.Invoke(Connection, Transaction, parameterPDF, securityTicket);

                string emailTo = doc.Doctor.Email;
                string appName = WebConfigurationManager.AppSettings["docAppUrl"];
                var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";

                var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/PdfReceiptEmailTemplate.html"));
                var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                dynamic subjects = Newtonsoft.Json.JsonConvert.DeserializeObject(subjectsJson);
                var subjectMail = subjects["PdfReceiptSubject"].ToString();

                email_template = EmailTemplater.SetTemplateData(email_template, new
                {
                    title = doc.Doctor.Title,
                    last_name = doc.Doctor.LastName,
                    first_name = doc.Doctor.FirstName,
                    doc_app_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName,
                    medios_connect_logo_url = imageUrl
                }, "{{", "}}");

                try
                {
                    string mailFrom = WebConfigurationManager.AppSettings["mailFrom"];
                    EmailNotificationSenderUtil.SendEmail(mailFrom, emailTo, subjectMail, email_template);
                }
                catch { }
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_CPR_1050 Invoke(string ConnectionString, P_CAS_CPR_1050 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_CPR_1050 Invoke(DbConnection Connection, P_CAS_CPR_1050 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_CPR_1050 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CPR_1050 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_CPR_1050 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CPR_1050 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_CPR_1050 functionReturn = new FR_CAS_CPR_1050();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method cls_Create_Pdf_Report", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_CPR_1050 : FR_Base
    {
        public CAS_CPR_1050 Result { get; set; }

        public FR_CAS_CPR_1050() : base() { }

        public FR_CAS_CPR_1050(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_CPR_1050 for attribute P_CAS_CPR_1050
    [DataContract]
    public class P_CAS_CPR_1050
    {
        //Standard type parameters
        [DataMember]
        public MMDocConnectUtils.ExcelTemplates.CaseForReportModel[] cases { get; set; }

    }
    #endregion
    #region SClass CAS_CPR_1050 for attribute CAS_CPR_1050
    [DataContract]
    public class CAS_CPR_1050
    {
        //Standard type parameters
        [DataMember]
        public String PdfUploaded { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CPR_1050 cls_Create_Pdf_Report(,P_CAS_CPR_1050 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CPR_1050 invocationResult = cls_Create_Pdf_Report.Invoke(connectionString,P_CAS_CPR_1050 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Case.Complex.Manipulation.P_CAS_CPR_1050();
parameter.cases = ...;

*/
