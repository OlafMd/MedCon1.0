using System;

namespace CSV2Core.Core
{
    public enum DanuFieldType
    {
        Regular,
        Identificator,
        Dictionary,
        CreationTimestamp,
        TenantReference,
        LogicalDeletionField
    }

    [Obsolete("Obsolete due to moving to CSV2Core_Generator",true)]
    public class DBColumn
    {
        public string Name { get; set; }
        public string Table { get; set; }
        public string Schema { get; set; }
        public string DataType { get; set; }
        public string SQLType { get; set; }
        public DanuFieldType FieldType { get; set; }



        #region GeneratorGetter

        public string AdditionalAttributes
        {
            get
            {
                switch (FieldType)
                {
                    case DanuFieldType.Regular:
                        return "";
                    case DanuFieldType.Identificator:
                        return "IsObjectPrimaryKey=\"true\"";
                    case DanuFieldType.Dictionary:
                        return String.Format("Source_DBField=\"{0}_DictID\" OriginTable=\"{1}\"", Name, Table);
                    case DanuFieldType.CreationTimestamp:
                        return "IsDateOfCreationField=\"true\"";
                    case DanuFieldType.TenantReference:
                        return "IsTenantField=\"true\"";
                    case DanuFieldType.LogicalDeletionField:
                        return "IsDeletedField=\"true\"";
                    default:
                        return "";

                }
            }
        }

        #endregion
    }



}
