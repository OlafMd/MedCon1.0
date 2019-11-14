using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using DLMVCTemplates.Templates;

namespace DLMVCTemplates.Utils
{
    interface IDLDictUtil
    {
        String GetCurrentLanguageContent(Dict dict);

        String GetCurrentLanguageContent(object dict);
    }
}
