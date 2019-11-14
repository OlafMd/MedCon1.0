using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API
{
    public class FileUtils
    {
        public static string Read(string filename)
        {
            try
            {
                string data;

                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                data = sr.ReadToEnd();
                sr.Close();
                fs.Close();
                return data;
            }
            catch (Exception e)
            {
               
                return e.Message;
            }
        }

        public static string Read(Stream fs)
        {
            try
            {
                string data;
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                data = sr.ReadToEnd();
                sr.Close();
                fs.Close();
                return data;
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
