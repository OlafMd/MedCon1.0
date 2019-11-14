using System;
using System.IO;

namespace CSV2Core.Support
{
    public class DLSystemSupport
    {
        public static readonly string DEFAULT_DIR = "CIv2";

        public static void OpenDirectory(String directory)
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = windir + @"\explorer.exe";
            prc.StartInfo.Arguments = directory;
            prc.Start();

        }

        public static string CreateTemporaryDirectory()
        {
            
            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            if (Directory.Exists(tempPath) == false)
            {
                Directory.CreateDirectory(tempPath);
            }
            return tempPath;
        }
    }
}
