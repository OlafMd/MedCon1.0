using System;
using System.Collections.Generic;

namespace DLAPODemandCommons.Templates.Articles
{
    #region EVENTS CLASSES
    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; set; }
    }
    #endregion

    public enum ProductField { NAME, DOSAGE_FORM, CODE, UNIT, PRODUCER, IS_PART_OF_DEFAULT_STOCK }
    public enum SortingOrder { ASC, DESC }

    [Serializable]
    public class SearchOrder
    {
        public ProductField field { get; set; }
        public SortingOrder order { get; set; }
    }

    [Serializable]
    public class SearchCondition
    {
        public String query { get; set; }
        public ProductField field { get; set; }
    }

    public class SearchParameter
    {
        public string MainSearch { get; set; }
        public string ProducerName { get; set; }
        public string DossageFormName { get; set; }
        public string Unit { get; set; }
        public Guid UnitId { get; set; }
        public string ProductNumber { get; set; }
        public bool InDefaultStock { get; set; }
    }

    public enum ColumnType
    {
        ProductName,
        ProductDescription,
        ProductNumber,
        Producer,
        Supplier,
        DosageFormName,
        Unit,
        StockQuantity,
        FreeStockQuantity,
        ABDAPrice,
        SalesPrice,
        StoragePlace,
        CurrencySymbol,
        ActiveComponents,
        Actions,
        MSR
    }

    [Serializable]
    public class Product
    {
        public string ProductITL { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductNumber { get; set; }
        public string ProducerName { get; set; }
        public Guid DosageFormID { get; set; }
        public string DosageFormName { get; set; }
        public Guid UnitID { get; set; }
        public string Unit { get; set; }
        public string UnitAmount { get; set; }
        public decimal ABDAPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string CurrencyIso { get; set; }
        public string CurrencySymbol { get; set; }
        public string TaxRate { get; set; }
        public List<ActiveComponents> ActiveComponents { get; set; }
        public AdditionalProductData AdditionalData { get; set; }
    }

    [Serializable]
    public class AdditionalProductData
    {
        public AdditionalProductData()
        {
            SupplierName = String.Empty;
            SupplierID = new Guid();
            StockQuantity = 0.0;
            FreeStockQuantity = 0.0;
            StoragePlace = String.Empty;
            HasExpectedDelivery = false;
            MSR = 0.0;
        }

        public string SupplierName { get; set; }
        public Guid SupplierID { get; set; }
        public double StockQuantity { get; set; }
        public double FreeStockQuantity { get; set; }
        public string StoragePlace { get; set; }
        public bool HasExpectedDelivery { get; set; }
        public double MSR { get; set; }
    }

    [Serializable]
    public class ActiveComponents
    {
        public string ComponentName { get; set; }
        public string SubstanceName { get; set; }
        public bool IsActive { get; set; }
    }

    public interface IAPOArticleTemplate
    {
        int SelectedIndex { get; set; }
        List<Product> SelectedProducts { get; }
        Product SelectedProduct { get; }
        List<Product> Products { get; set; }
        List<ColumnType> VisibleColumns { get; set; }
        bool IsExtern { get; }
        bool EnabledMultipleSelection { get; set; }
        int VirtualPageIndex { get; set; }
        List<SearchCondition> SearchConditions { get; set; }

        void BindData();

        // Single row
        void SelectItemByID(String id);
        void SelectItemsByIDs(List<String> ids);

        void Show();
        void Hide();

        void GetArticlesFromBegin();
        void GetArticles();

        Guid ImportSelectedProduct();
        List<Product> ImportSelectedProducts();

        void ClearSearchConditions();
        void AddSearchConditions(SearchCondition condition);
    }
}
