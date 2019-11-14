using System;
using System.Collections.Specialized;
using System.Configuration;

namespace DLAPODemandCommons.Utils
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
                    foreach (string value in data.GetValues(i))
                        values += "'" + value + "';";

                    content += data.GetKey(i) + " = " + values + "" + System.Environment.NewLine;
                }
            }
            catch (Exception ex)
            { }

            return content;
        }
    }
}
