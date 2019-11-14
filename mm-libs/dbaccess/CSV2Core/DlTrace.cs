using System;
using System.IO;

namespace CSV2Core
{
    public class DlTrace
    {
        static string outputFile = "out.txt";
        static string errorFile = "err.txt";

        public static void Trace(string format,params object[] parameters)
        {
            lock (outputFile)
            {
                string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, outputFile);
                int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                string text = String.Format("[{0:yyyy-MM-dd HH:mm:ss.ffffff}]\t[{1}]\t{2}\n", DateTime.Now,threadId, String.Format(format, parameters));
                System.IO.File.AppendAllText(logFile, text);
            }
        }

        public static void Trace(Exception ex)
        {
            lock (errorFile)
            {
                string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, errorFile);
                int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                string text = String.Format("[Exception Occured At:{0:yyyy-MM-dd HH:mm:ss.ffffff}]\tIn Thread[{1}]\n\rException Message:{2}\n\r{3}", 
                    DateTime.Now, 
                    threadId, 
                    ex.Message,
                    ex.ToString());
                System.IO.File.AppendAllText(logFile, text);
            }
        }
    }
}
