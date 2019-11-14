using System;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace DLWebFormsTemplates.Utils
{
    interface IDLDictUtil
    {
        String GetCurrentLanguageContent(Dict dict);

        String GetCurrentLanguageContent(object dict);
    }
}
