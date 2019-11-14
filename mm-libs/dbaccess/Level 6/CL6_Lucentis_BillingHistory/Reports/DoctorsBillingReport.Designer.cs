namespace LucentisReports
{
    partial class DoctorsBillingReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorsBillingReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.parameter1 = new DevExpress.XtraReports.Parameters.Parameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrlPracticeName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlSelectedMonth = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrVorgangsNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlPosalCodeAndCity = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.tbCurrentDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlPracticeAddress = new DevExpress.XtraReports.UI.XRLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1});
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(650.9999F, 100F);
            this.xrSubreport1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrSubreport1_BeforePrint);
            // 
            // parameter1
            // 
            this.parameter1.Name = "parameter1";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 10F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 6F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.HeightF = 28.125F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlPracticeName,
            this.xrLabel5,
            this.xrlSelectedMonth,
            this.xrPictureBox1,
            this.xrLabel7,
            this.xrVorgangsNumber,
            this.xrlPosalCodeAndCity,
            this.xrLabel6,
            this.tbCurrentDate,
            this.xrLabel1,
            this.xrlPracticeAddress});
            this.ReportHeader.HeightF = 239.1666F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrlPracticeName
            // 
            this.xrlPracticeName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlPracticeName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrlPracticeName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 26.66664F);
            this.xrlPracticeName.Name = "xrlPracticeName";
            this.xrlPracticeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlPracticeName.SizeF = new System.Drawing.SizeF(295.8333F, 23F);
            this.xrlPracticeName.StylePriority.UseBorders = false;
            this.xrlPracticeName.StylePriority.UseFont = false;
            this.xrlPracticeName.Text = "xrlPracticeName";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(498.7498F, 133.25F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(41.25006F, 23F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.Text = "Berlin, ";
            // 
            // xrlSelectedMonth
            // 
            this.xrlSelectedMonth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            this.xrlSelectedMonth.CanShrink = true;
            this.xrlSelectedMonth.ForeColor = System.Drawing.Color.Black;
            this.xrlSelectedMonth.LocationFloat = new DevExpress.Utils.PointFloat(426.9999F, 199.0417F);
            this.xrlSelectedMonth.Name = "xrlSelectedMonth";
            this.xrlSelectedMonth.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrlSelectedMonth.SizeF = new System.Drawing.SizeF(216.0834F, 29.25002F);
            this.xrlSelectedMonth.StylePriority.UseBorderColor = false;
            this.xrlSelectedMonth.StylePriority.UseForeColor = false;
            this.xrlSelectedMonth.StylePriority.UsePadding = false;
            this.xrlSelectedMonth.Text = "xrlSelectedMonth";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(418.0837F, 26.66664F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(222.9164F, 69F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.CenterImage;
            this.xrPictureBox1.StylePriority.UseBorders = false;
            // 
            // xrLabel7
            // 
            this.xrLabel7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.CanShrink = true;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 199.0417F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(427F, 29.25002F);
            this.xrLabel7.StylePriority.UseBorderColor = false;
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.Text = "   anbei übersenden wir Ihnen die Übersicht der Abrechnungen für den Monat ";
            // 
            // xrVorgangsNumber
            // 
            this.xrVorgangsNumber.AutoWidth = true;
            this.xrVorgangsNumber.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrVorgangsNumber.CanShrink = true;
            this.xrVorgangsNumber.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrVorgangsNumber.LocationFloat = new DevExpress.Utils.PointFloat(122.9167F, 115.5417F);
            this.xrVorgangsNumber.Multiline = true;
            this.xrVorgangsNumber.Name = "xrVorgangsNumber";
            this.xrVorgangsNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrVorgangsNumber.SizeF = new System.Drawing.SizeF(275F, 22.99999F);
            this.xrVorgangsNumber.StylePriority.UseBorders = false;
            this.xrVorgangsNumber.StylePriority.UseFont = false;
            // 
            // xrlPosalCodeAndCity
            // 
            this.xrlPosalCodeAndCity.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlPosalCodeAndCity.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrlPosalCodeAndCity.LocationFloat = new DevExpress.Utils.PointFloat(0F, 72.66664F);
            this.xrlPosalCodeAndCity.Name = "xrlPosalCodeAndCity";
            this.xrlPosalCodeAndCity.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlPosalCodeAndCity.SizeF = new System.Drawing.SizeF(295.8334F, 23F);
            this.xrlPosalCodeAndCity.StylePriority.UseBorders = false;
            this.xrlPosalCodeAndCity.StylePriority.UseFont = false;
            this.xrlPosalCodeAndCity.Text = "xrlPosalCodeAndCity";
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189)))));
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel6.CanShrink = true;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0.04170736F, 167.7083F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(643.0416F, 31.33336F);
            this.xrLabel6.StylePriority.UseBorderColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "   Sehr geehrte Damen und Herren,";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // tbCurrentDate
            // 
            this.tbCurrentDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tbCurrentDate.LocationFloat = new DevExpress.Utils.PointFloat(539.9999F, 133.25F);
            this.tbCurrentDate.Name = "tbCurrentDate";
            this.tbCurrentDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(1, 2, 0, 0, 100F);
            this.tbCurrentDate.SizeF = new System.Drawing.SizeF(101.0002F, 23F);
            this.tbCurrentDate.StylePriority.UseBorders = false;
            this.tbCurrentDate.StylePriority.UsePadding = false;
            this.tbCurrentDate.StylePriority.UseTextAlignment = false;
            this.tbCurrentDate.Text = "tbCurrentDate";
            this.tbCurrentDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(2.083333F, 115.5417F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(120.8334F, 22.99998F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Vorgangsnummer [";
            // 
            // xrlPracticeAddress
            // 
            this.xrlPracticeAddress.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrlPracticeAddress.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrlPracticeAddress.LocationFloat = new DevExpress.Utils.PointFloat(0F, 49.66664F);
            this.xrlPracticeAddress.Name = "xrlPracticeAddress";
            this.xrlPracticeAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlPracticeAddress.SizeF = new System.Drawing.SizeF(295.8333F, 23F);
            this.xrlPracticeAddress.StylePriority.UseBorders = false;
            this.xrlPracticeAddress.StylePriority.UseFont = false;
            this.xrlPracticeAddress.Text = "streetNumber";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CL6_Lucentis_BillingHistory.Utils.TreatmentsByAOKStatusForSubReport);
            // 
            // DoctorsBillingReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader});
            this.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Margins = new System.Drawing.Printing.Margins(100, 99, 10, 6);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.parameter1});
            this.Version = "11.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.DoctorsBillingReport_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        //private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraReports.Parameters.Parameter parameter1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrlSelectedMonth;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrVorgangsNumber;
        private DevExpress.XtraReports.UI.XRLabel xrlPosalCodeAndCity;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel tbCurrentDate;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrlPracticeAddress;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.XRLabel xrlPracticeName;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
    }
}
