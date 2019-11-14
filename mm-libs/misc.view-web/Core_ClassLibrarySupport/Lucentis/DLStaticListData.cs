using System;

namespace Core_ClassLibrarySupport.Lucentis
{

    public class STLD_ORD_CUO_CustomerOrder_Status
    {
        public static readonly Guid NotOrdered = Guid.Parse("9B0DA8ED-F33B-4335-8B12-019ECE873F1F");
        public static readonly Guid Ordered = Guid.Parse("4621085A-E747-4645-AA61-FA4CE1A8E646");
        public static readonly Guid OrderConfirmed = Guid.Parse("1712AF34-6E74-4A3D-9E97-5A90A88692B6");
        public static readonly Guid Shipped = Guid.Parse("D2FDEBAE-865D-4DB2-B15F-7396C6CCBD8E");
        public static readonly Guid Billed = Guid.Parse("ABF393AC-96CA-4154-B21E-57B20119C291");
    }

}
