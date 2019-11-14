using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CL3_ABDA.Utils
{
    [DataContract]
    public class ArticleMainTableModel
    {
        [DataMember]
        public string ProductITL { get; set; }
        [DataMember]
        public Guid ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductNumber { get; set; }
        [DataMember]
        public string ProducerName { get; set; }
        [DataMember]
        public Guid DosageFormID { get; set; }
        [DataMember]
        public string DosageFormName { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public string UnitAmount { get; set; }
        [DataMember]
        public decimal ABDAPrice { get; set; }
        [DataMember]
        public decimal SalesPrice { get; set; }
        [DataMember]
        public string TaxRate { get; set; }
        [DataMember]
        public double FreeStockQuantity { get; set; }
        [DataMember]
        public List<ActiveComponents> ActiveComponents { get; set; }
    }

    [DataContract]
    public class ActiveComponents
    {
        [DataMember]
        public string SubstanceName { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
    }
}
