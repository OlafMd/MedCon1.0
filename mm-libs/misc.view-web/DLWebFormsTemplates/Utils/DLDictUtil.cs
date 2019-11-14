using System;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using Danulabs.Utils;

namespace DLWebFormsTemplates.Utils
{
    public class DLDictUtil:IDLDictUtil
    {
        public DLDictUtil() {

        }

        public String GetCurrentLanguageContent(Dict dict)
        {
            return dict.GetContent(SessionGlobal.Instance.LanguageID);
        }

        public String GetCurrentLanguageContent(object dict)
        {
            if (dict is Dict)
                return GetCurrentLanguageContent((Dict)dict);
            else
                return "[invalid object]";
        }
    }
}
