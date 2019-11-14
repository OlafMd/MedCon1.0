using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace DLDanuTaskCommons.Utils
{
    public class CopyAppSettingsToLog
    {
        public static string CoppyAppSettings()
        {
            string content = string.Empty;
            try
            {
                NameValueCollection data = ConfigurationManager.AppSettings;
                string values = string.Empty;

                for (int i = 0; i < data.Count; i++)
                {
                    values = string.Empty;
                    DTHelper.Each(
                        data.GetValues(i),
                        v => values += "'" + v + "';"
                        );
                    content += data.GetKey(i) + " = " + values + "" + System.Environment.NewLine;
                }
            }
            catch (Exception ex)
            { }
            return content;
        }
    }
}
