using System;
using System.Collections.Generic;
using System.Linq;
using DLWebFormsTemplates.Templates;
using System.Data;
using DLWebFormsTemplates.Controls;
using System.Web.UI.WebControls;

namespace DLAPODemandCommons.Templates.Articles
{
    /// <summary>
    /// Base template for Article and ABDA templates.
    /// </summary>
    public abstract class APOArticleCommonTemplate : DLComponentTemplate
    {
        private const string VS_KEY_VisibleColumns = "VisbleColumns";

        #region EVENTS
        public event GridViewCommandEventHandler CustomRowCommand;
        public event EventHandler SelectionChanged;
        public event EventHandler<ProductEventArgs> ShowActiveComponents;
        #endregion

        public virtual List<Product> Products { get; set; }
        public virtual List<Product> SelectedProducts { get; set; }
        public virtual Product SelectedProduct
        {
            get { return SelectedProducts.Single(); }
        }
        protected abstract DLGridView Grid { get; }

        public bool HasAdditionalData { get; set; }
        /// <summary>
        /// Get or set the columns to be visible.
        /// If this property is null then default columns are visible.
        /// </summary>
        public List<ColumnType> VisibleColumns
        {
            get
            {
                if (ViewState[VS_KEY_VisibleColumns + ID] == null)
                {
                    return GetDefaultVisibleColumns();
                }
                return ViewState[VS_KEY_VisibleColumns + ID] as List<ColumnType>;
            }
            set
            {
                ViewState[VS_KEY_VisibleColumns + ID] = value;
            }
        }

        //##############################LIST_CONTROLS EVENTS#########################//
        #region LIST_CONTROLS EVENTS
        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "show-active-components":
                    var id = Grid.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                    OnShowActiveComponents(GetProductByID(id));
                    break;
                default:
                    OnCustomRowCommand(e);
                    break;
            }
        }
        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectionChanged();
        }
        #endregion

        //##############################SUPPORT METHODS#########################//
        #region SUPPORT METHODS
        protected virtual void OnCustomRowCommand(GridViewCommandEventArgs e)
        {
            if (CustomRowCommand != null)
            {
                CustomRowCommand(this, e);
            }
        }
        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }
        protected virtual void OnShowActiveComponents(Product product)
        {
            if (ShowActiveComponents != null)
            {
                ShowActiveComponents(this, new ProductEventArgs { Product = product });
            }
        }
        public virtual void BindData()
        {
            SetVisibleColumns();
        }
        protected virtual void FillGridView()
        {
            Products = Products ?? new List<Product>();


            
            // Create data table for grid view.
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId", typeof(Guid));
            dt.Columns.Add("ProductITL", typeof(string));
            dt.Columns.Add("ProductNumber", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("DosageFormName", typeof(string));
            dt.Columns.Add("UnitSymbol", typeof(string));
            dt.Columns.Add("UnitAmount", typeof(string));
            dt.Columns.Add("ABDAPrice", typeof(decimal));
            dt.Columns.Add("SalesPrice", typeof(decimal));
            dt.Columns.Add("CurrencySymbol", typeof(string));
            dt.Columns.Add("ActiveComponents", typeof(string));
            dt.Columns.Add("Producer", typeof(string));

            dt.Columns.Add("StoragePlace", typeof(string));
            dt.Columns.Add("StockQuantity", typeof(double));
            dt.Columns.Add("FreeStockQuantity", typeof(double));
            dt.Columns.Add("Supplier", typeof(string));
            dt.Columns.Add("MSR", typeof(double));

            // Fill data table with data.
            foreach (var product in Products)
            {
                var row = dt.NewRow();
                row["ProductId"] = product.ProductId;
                row["ProductITL"] = product.ProductITL;
                row["ProductNumber"] = product.ProductNumber;
                row["ProductName"] = product.ProductName;
                row["DosageFormName"] = product.DosageFormName;
                row["UnitSymbol"] = product.Unit;
                row["UnitAmount"] = product.UnitAmount;
                row["ABDAPrice"] = product.ABDAPrice;
                row["SalesPrice"] = product.SalesPrice;
                row["CurrencySymbol"] = product.CurrencySymbol;
                row["Producer"] = product.ProducerName;
                
                //additionalData
                if (HasAdditionalData)
                {
                    row["MSR"] = product.AdditionalData.MSR;
                    row["StoragePlace"] = product.AdditionalData.StoragePlace;
                    row["StockQuantity"] = product.AdditionalData.StockQuantity;
                    row["FreeStockQuantity"] = product.AdditionalData.FreeStockQuantity;
                    row["Supplier"] = product.AdditionalData.SupplierName;
                }

                // set list of substances
                var activeComponets = product.ActiveComponents.Take(5).ToList().Select(x => x.SubstanceName).ToList();
                row["ActiveComponents"] = string.Join(", ", activeComponets);

                dt.Rows.Add(row);
            }
            // Set data table to grid view.
            Grid.SetTableContent(dt.DefaultView);
        }
        protected List<ColumnType> GetDefaultVisibleColumns()
        {
            return new List<ColumnType>
            {
                ColumnType.ProductName,
                ColumnType.ProductNumber,
                ColumnType.DosageFormName,
                ColumnType.Unit,
                ColumnType.ABDAPrice,
                ColumnType.SalesPrice,
                ColumnType.CurrencySymbol,
                ColumnType.ActiveComponents
            };
        }
        protected void SetVisibleColumns()
        {
            List<int> skipIndex = new List<int>();
            if (Grid.EnabledMultipleSelection)
            {
                skipIndex.Add(Grid.Columns.Count - 1);
            }

            foreach (DataControlField column in Grid.Columns)
            {
                if (!skipIndex.Contains(Grid.Columns.IndexOf(column)))
                {
                    column.Visible = VisibleColumns.Any(x => x.ToString() == column.AccessibleHeaderText);
                }
            }
        }
        protected abstract Product GetProductByID(String id);
        #endregion
    }
}
