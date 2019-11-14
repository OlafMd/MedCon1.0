using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CL6_Lucentis_BillingHistory.Utils;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;

namespace CL6_Lucentis_BillingHistory.Reports
{
    public partial class DocSubReport : DevExpress.XtraReports.UI.XtraReport
    {
        private List<TreatmentsByAOKStatusForSubReport> TreatmentsList;
        private String SelectedMonth;
        public DocSubReport()
        {
            InitializeComponent();
        }

        public void initData(List<TreatmentsByAOKStatusForSubReport> TreatmentsList, String selectedMonth)
        {
            this.TreatmentsList = TreatmentsList;
            this.SelectedMonth = selectedMonth;
        }

        // The following code makes the table span to the entire page width.
        void table_BeforePrint(object sender, PrintEventArgs e)
        {
            XRTable table = ((XRTable)sender);
            table.WidthF = this.PageWidth - this.Margins.Left - this.Margins.Right;
        }

        private void DocSubReport_BeforePrint(object sender, PrintEventArgs e)
        {
            int RowCount = 0;
            foreach (var Treatments in TreatmentsList)
            {
                foreach(var item in Treatments.Treatments)
                {
                    RowCount += item.GPOS.Count + 4;//+2 because of non GPOS data + 1 emty row X2
                }
            }
            this.Detail.Controls.Add(CreateXRTable(5,RowCount));
        }

        private XRTable CreateXRTable(int cellsInRow, int rowsCount)
        {
            float rowHeight = 25f;

            XRTable table = new XRTable();
            table.Borders = DevExpress.XtraPrinting.BorderSide.All;
            table.BeginInit();

            foreach (var list in TreatmentsList)
            {
                var Treatments = list.Treatments.ToList();

                //add Header
                XRTableRow rowHeader = new XRTableRow();
                rowHeader.HeightF = rowHeight;
                XRTableCell cellHeader = new XRTableCell();
                cellHeader.Borders = (DevExpress.XtraPrinting.BorderSide.None);
                cellHeader.Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Bold);
                if (list.isAOKConfirmedTreatments)
                    cellHeader.Text = "Übersicht abgerechneter Behandlungen des Monats " + SelectedMonth;
                else
                    cellHeader.Text = "Übersicht noch nicht abgerechneter Behandlungen des Monats " + SelectedMonth;
                rowHeader.Cells.Add(cellHeader);
                table.Rows.Add(rowHeader);

                rowHeader = new XRTableRow();
                rowHeader.HeightF = rowHeight;
                cellHeader = new XRTableCell();
                cellHeader.Borders = (DevExpress.XtraPrinting.BorderSide.Bottom);
                cellHeader.Text = " ";
                rowHeader.Cells.Add(cellHeader);
                table.Rows.Add(rowHeader);

                //add tableHeader
                XRTableRow rowTableHeader = new XRTableRow();
                rowHeader.HeightF = rowHeight;
                for (int j = 0; j < cellsInRow; j++)
                {
                    XRTableCell cellTableHeader = new XRTableCell();
                    cellTableHeader.Borders = (DevExpress.XtraPrinting.BorderSide.All);
                    cellTableHeader.Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Bold);
                    switch (j)
                    {
                        case 0:
                            cellTableHeader.Text = "Injektionsdatum";
                            break;
                        case 1:
                            cellTableHeader.Text = "Name";
                            break;
                        case 2:
                            cellTableHeader.Text = "Vorname";
                            break;
                        case 3:
                            cellTableHeader.Text = "Geburtsdatum";
                            break;
                        case 4:
                            cellTableHeader.Text = "Medikament";
                            break;
                    }
                    rowTableHeader.Cells.Add(cellTableHeader);
                }
                table.Rows.Add(rowTableHeader);

                double summ = 0;
                foreach (var treatment in Treatments)
                {
                    XRTableRow row = new XRTableRow();
                    row.HeightF = rowHeight;
                    for (int j = 0; j < cellsInRow; j++)
                    {
                        XRTableCell cell = new XRTableCell();
                        cell.Borders = (DevExpress.XtraPrinting.BorderSide.All);
                        cell.Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Regular);
                        switch (j)
                        {
                            case 0:
                                cell.Text = treatment.Date;
                                break;
                            case 1:
                                cell.Text = treatment.LastName;
                                break;
                            case 2:
                                cell.Text = treatment.FirstName;
                                break;
                            case 3:
                                cell.Text = treatment.Birthday;
                                break;
                            case 4:
                                cell.Text = treatment.Article;
                                break;
                        }
                        row.Cells.Add(cell);
                    }
                    table.Rows.Add(row);
                    row = new XRTableRow();
                    row.HeightF = rowHeight;
                    table.Rows.Add(row);//empty row

                    foreach (var item in treatment.GPOS)
                    {
                        XRTableRow row1 = new XRTableRow();
                        row1.HeightF = rowHeight;
                        XRTableCell cell = new XRTableCell();
                        if (treatment.GPOS[treatment.GPOS.Count - 1].ID == item.ID)
                        {
                            cell.Borders = (DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom);
                        }
                        else
                        {
                            cell.Borders = (DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right);
                        }
                        row1.Cells.Add(cell);
                        for (int j = 0; j < 3; j++)
                        {
                            cell = new XRTableCell();
                            cell.Borders = (DevExpress.XtraPrinting.BorderSide.All);
                            cell.Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Regular);
                            switch (j)
                            {
                                case 0:
                                    cell.Text = item.Number;
                                    break;
                                case 1:
                                    cell.Text = item.Text;
                                    break;
                                case 2:
                                    cell.Text = "+ " + item.Price.ToString("0.##") + " €";
                                    summ += item.Price;
                                    break;
                            }
                            row1.Cells.Add(cell);
                        }
                        table.Rows.Add(row1);
                        cell = new XRTableCell();
                        if (treatment.GPOS[treatment.GPOS.Count - 1].ID == item.ID)
                        {
                            cell.Borders = (DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom);
                        }
                        else
                        {
                            cell.Borders = (DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right);
                        }
                        row1.Cells.Add(cell);
                        table.Rows.Add(row);
                    }
                }
                XRTableRow rowSumme = new XRTableRow();
                rowSumme.HeightF = rowHeight;

                XRTableCell cellSumme = new XRTableCell();
                cellSumme.Borders = (DevExpress.XtraPrinting.BorderSide.All);
                rowSumme.Cells.Add(cellSumme);

                cellSumme = new XRTableCell();
                cellSumme.Borders = (DevExpress.XtraPrinting.BorderSide.All);
                rowSumme.Cells.Add(cellSumme);

                cellSumme = new XRTableCell();
                cellSumme.Borders = (DevExpress.XtraPrinting.BorderSide.All);
                cellSumme.Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Bold);
                cellSumme.Text = "SUMME";
                rowSumme.Cells.Add(cellSumme);


                cellSumme = new XRTableCell();
                cellSumme.Borders = (DevExpress.XtraPrinting.BorderSide.All);
                cellSumme.Font = new System.Drawing.Font("Times New Roman", 11.25f, FontStyle.Bold);
                cellSumme.Text = "=" + summ.ToString("0.##") +" €";
                rowSumme.Cells.Add(cellSumme);

                cellSumme = new XRTableCell();
                cellSumme.Borders = (DevExpress.XtraPrinting.BorderSide.All);
                rowSumme.Cells.Add(cellSumme);

                table.Rows.Add(rowSumme);

                //Add 2 emty rows
                for (int i = 0; i < 2; i++)
                {
                    rowHeader = new XRTableRow();
                    rowHeader.HeightF = rowHeight;
                    cellHeader = new XRTableCell();
                    cellHeader.Borders = (DevExpress.XtraPrinting.BorderSide.None);
                    cellHeader.Text = " ";
                    rowHeader.Cells.Add(cellHeader);
                    table.Rows.Add(rowHeader);
                }
            }
                table.BeforePrint += new PrintEventHandler(table_BeforePrint);
            table.EndInit();
            return table;
        }
    }
}
