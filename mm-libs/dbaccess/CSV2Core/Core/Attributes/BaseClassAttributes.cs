using System;
using System.Linq;

namespace CSV2Core.Core.Attributes
{
    /// <summary>
    /// Base Attribute for all the base classes to make code more elegant and readable
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class BaseTable : Attribute
    {
        public BaseTable()
        {
            QueryTimeout = 60;
        }

               public string TableName { get; set; }
        public int QueryTimeout { get; set; }


        public static BaseTable GetAttribute(object instance)
        {
            return GetAttribute(instance.GetType());
        }

        public static BaseTable GetAttribute(Type type)
        {
            return type.GetCustomAttributes(typeof(BaseTable), true).FirstOrDefault() as BaseTable;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class Identificator : Attribute
    {

    }

    
}
