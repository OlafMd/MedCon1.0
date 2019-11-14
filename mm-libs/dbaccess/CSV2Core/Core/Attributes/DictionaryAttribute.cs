using System;

namespace CSV2Core.Core.Attributes
{

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class DictionaryAttribute : Attribute
    {
        public string SourceTable { get; set; }
    }
}
