using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace DLMVCTemplates.Utils
{
    class DLDictUtil : IDLDictUtil
    {
        public DLDictUtil()
        {

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
