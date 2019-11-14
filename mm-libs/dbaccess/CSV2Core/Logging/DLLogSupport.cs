using System;
using System.Text;

namespace CSV2Core.Logging
{
    public enum DLLogSeverity
    {
        /// <summary>
        /// System health is affected (member of error level)
        /// </summary>
        CRITICAL = 1,
        /// <summary>
        /// An operation did not succeed (member of error level)
        /// </summary>
        SERIOUS = 2,
        /// <summary>
        /// General error (default type on error-Level)
        /// </summary>
        ERROR = 3,
        /// <summary>
        /// Problem not affecting the current process, but should be fixed.  (member of warning level)
        /// </summary>
        WARNING = 4,
        /// <summary>
        /// Configuration error / missing. (member of warning level)
        /// </summary>
        CONFIG = 5,
        /// <summary>
        /// Information (for debugging, member of info level)
        /// </summary>
        INFO = 6,
        /// <summary>
        ///  Detailed information (for debugging, member of info level). 
        /// </summary>
        DEBUG = 7
    }

    public static class DLLogSupport
    {

        public static string GenerateLogString(string Message, Exception _Ex)
        {
            StringBuilder Builder= new StringBuilder();
            try
            {
                Builder.AppendLine("Message : "+Message);
                Builder.AppendLine("Source  : "+_Ex.Source.ToString().Trim());
                Builder.AppendLine("Method  : "+_Ex.TargetSite.Name.ToString());
                Builder.AppendLine("Date    : "+DateTime.Now);
                Builder.AppendLine("Computer: "+System.Environment.MachineName);
                Builder.AppendLine("Error   : "+_Ex.Message.ToString().Trim());
                Builder.AppendLine("Exception:\n"+_Ex.ToString().Trim());
            }
            catch (Exception ex)
            {
                Builder.AppendLine(ex.ToString());
            }
            return Builder.ToString();
        }

    }
}
