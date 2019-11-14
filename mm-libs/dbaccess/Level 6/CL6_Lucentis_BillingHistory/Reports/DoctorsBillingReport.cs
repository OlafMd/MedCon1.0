using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using System.Collections.Generic;
using System.IO;
using CL6_Lucentis_BillingHistory.Utils;
using System.Globalization;
using System.Linq;
using CL6_Lucentis_BillingHistory.Reports;


namespace LucentisReports
{
    public partial class DoctorsBillingReport : DevExpress.XtraReports.UI.XtraReport, IReport
    {
        List<TreatmentData> AOKConfirmTreatments;
        List<TreatmentData> NOTAOKConfirmTreatments;
        List<TreatmentsByAOKStatusForSubReport> DataSource = new List<TreatmentsByAOKStatusForSubReport>();
        private Dictionary<String, Object> _context;

        public void SetContext(Dictionary<String, Object> context)
        {
            InitializeComponent();
            _context = context;

            /*
             * @static data
             * */

            string languageCode = context["LanguageCode"] as string;
            if (languageCode == "de")
                tbCurrentDate.Text = "[ "+DateTime.Now.ToString("dd.MM.yyyy", new CultureInfo("de-DE")) +" ]";
            else
                tbCurrentDate.Text = "[ " + DateTime.Now.ToShortDateString() + " ]";

            WordReportData treatmentDataList = context["WordReportData"] as WordReportData;

            xrlSelectedMonth.Text = treatmentDataList.SelectedMonth;
            xrlPracticeName.Text = treatmentDataList.PracticeName;
            xrlPracticeAddress.Text = treatmentDataList.PracticeAddress;
            xrlPosalCodeAndCity.Text = treatmentDataList.PracticePostalCodeAndCity;

            string VorgangsNumber = "";
            foreach (var item in treatmentDataList.Treatments)
            {
                VorgangsNumber += item.Vorgassnumber + " ";
            }
            xrVorgangsNumber.Text = VorgangsNumber+"]";

            /*
             * Split treatments that are AOK confirmed ant those that are not
             * */

          
          NOTAOKConfirmTreatments = treatmentDataList.Treatments.Where(i => i.isAOKConfirmedStatus == false).ToList();           
          AOKConfirmTreatments = treatmentDataList.Treatments.Where(i=>i.isAOKConfirmedStatus==true).ToList();

          if (NOTAOKConfirmTreatments.Count > 0)
          {
              TreatmentsByAOKStatusForSubReport NotAOKConfirmed = new TreatmentsByAOKStatusForSubReport();
              NotAOKConfirmed.Treatments = NOTAOKConfirmTreatments;
              NotAOKConfirmed.isAOKConfirmedTreatments = false;
              NotAOKConfirmed.SelectedMonth = treatmentDataList.SelectedMonth;
              DataSource.Add(NotAOKConfirmed);
          }
          if (AOKConfirmTreatments.Count > 0)
          {
              TreatmentsByAOKStatusForSubReport AOKConfirmed = new TreatmentsByAOKStatusForSubReport();
              AOKConfirmed.Treatments = AOKConfirmTreatments;
              AOKConfirmed.isAOKConfirmedTreatments = true;
              AOKConfirmed.SelectedMonth = treatmentDataList.SelectedMonth;
              DataSource.Add(AOKConfirmed);
          }
        }

        public void ExportToFile(string f)
        {
            try
            {
                switch (_context["ReportType"].ToString())
                {
                    case "XLS":
                        this.ExportToXls(f);
                        break;

                    case "HTML":
                        this.ExportToHtml(f);
                        break;

                    case "PDF":
                        this.ExportToPdf(f);
                        break;

                    case "XLSX":
                        this.ExportToXlsx(f);
                        break;

                    default:
                        this.ExportToPdf(f);
                        break;
                }
            }
            catch (Exception e)
            {
                //ServerLog.Instance.Error("Application error occured", e);
            }
        }

        public System.IO.MemoryStream ExportToMemoryStream()
        {
            MemoryStream memStream = new MemoryStream();

            try
            {
                switch (_context["ReportType"].ToString())
                {
                    case "RTF":
                        this.ExportToRtf(memStream);
                        break;

                    case "XLS":
                        this.ExportToXls(memStream);
                        break;

                    case "HTML":
                        this.ExportToHtml(memStream);
                        break;

                    case "PDF":
                        this.ExportToPdf(memStream);
                        break;

                    case "XLSX":
                        this.ExportToXlsx(memStream);
                        break;

                    default:
                        this.ExportToXls(memStream);
                        break;
                }
            }
            catch (Exception e)
            {
                //ServerLog.Instance.Error("Application error occured", e);
            }
            return memStream;
        }

        public void PrintOn(string printer)
        {
            this.ShowPrintStatusDialog = true;
            this.ReportPrintTool.Print(printer);
            this.Print(printer);
        }

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void DoctorsBillingReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        
        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {                    
               ((XRSubreport)sender).ReportSource = new DocSubReport();
               ((DocSubReport)(((XRSubreport)sender).ReportSource)).initData(DataSource, DataSource[0].SelectedMonth);                           
        }     
       




    }
}
