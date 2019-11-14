using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DLCore_DBCommons.Zugseil.DBUpdater
{
    public class ReadFromFile
    {
        public static string LoadContentFromFile(string fileName)
        {
            string baseDirectory = "DLCore_DBCommons.Zugseil.DBUpdater.Json.";
            string content = String.Empty;

            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(baseDirectory + fileName)))
            {
                content = reader.ReadToEnd();
            }

            return content;
        }
    }
}
