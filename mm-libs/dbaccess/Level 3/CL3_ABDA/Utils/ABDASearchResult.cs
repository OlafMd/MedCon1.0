using System;
using System.Collections.Generic;
using BOp.CatalogAPI.data;
using CL3_Price.Complex.Retrieval;

namespace CL3_ABDA.Utils
{
    public class ABDASearchResult
    {
        public ABDASearchResult()
        {
            Products = new List<ABDAProduct>();
        }

        public List<ABDAProduct> Products { get; set; }
        public int hitCount { get; set; }
    }

    public class ABDAProduct
    {
        public Product Product { get; set; }
        public L3PR_GSPfPIL_1645 Prices { get; set; }
        public decimal? ABDAPrice { get; set; }
        public String CurrencySymbol { get; set; }
        public string Producer { get; set; }
    }
}
