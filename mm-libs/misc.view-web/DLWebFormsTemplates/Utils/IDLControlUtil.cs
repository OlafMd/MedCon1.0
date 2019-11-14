using System;

namespace DLWebFormsTemplates.Utils
{
    interface IDLControlUtil
    {
        String GetWarningPopUpString(String WarningString_Resource, bool returnFalse = true);

        String GetConfirmPopUpString(String ConfirmString_Resource, String textParam = "", String[] buttons = null, bool cancelEventPropagation = false);
        
    }
}
