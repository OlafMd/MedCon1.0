using System;
using System.Data.Common;
using System.Configuration;
using CSV2Core_MySQL.Support;
using System.IO;

namespace DLCore_DBCommons.DBUpdater
{
    public abstract class TransactionWraper
    {
        private const String logFolderPath = "C:/DBUpdaterLog/";
        private FileStream ostrm;
        private StreamWriter writer;
        private TextWriter oldOut = Console.Out;

        protected abstract void ExecuteMethod(DbConnection Connection, DbTransaction Transaction, params object[] args);

        public void OpenTransactionAndExecute(ConnectionStringSettings connectionStringSettings, String logFileName=null, params object[] args)
        {
            if (!GetChoice(connectionStringSettings.Name))
                return;

            DbConnection Connection = null;
            DbTransaction Transaction = null;

            try
            {
                if (logFileName!=null) 
                {
                    CreateFile(logFileName);
                    PersistLineInLog(String.Format("CreationTimestamp: {0}", DateTime.Now.ToString()));
                    PersistLineInLog(String.Format("Realm: {0}", connectionStringSettings.Name));
                    PersistLineInLog("");
                }

                Connection = DBSQLSupport.CreateConnection(connectionStringSettings.ConnectionString);
                Connection.Open();
  
                Transaction = Connection.BeginTransaction();

                ExecuteMethod(Connection, Transaction, args);

                Transaction.Commit();
                Connection.Close();

                if (logFileName != null)
                    CloseStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.StackTrace);
                
                try
                {
                    if (Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                try
                {
                    if (logFileName != null)
                        CloseStream();
                }
                catch { }
            }

            Console.WriteLine("Execution is finished!");
            Console.ReadLine();
        }

        private bool GetChoice(String connectionStringName) 
        {
            Console.WriteLine(String.Format("Do you want to run script on \"{0}\" server? [y/n]:", connectionStringName));

            var choice = Console.ReadLine();

            if (choice.ToLower() != "y")
                return false;

            return true;
        
        }

        public void PersistLineInLog(String text) 
        {
            Console.SetOut(writer);
            Console.WriteLine(text);
            Console.SetOut(oldOut);
            Console.WriteLine(text);
        }

        private void CreateFile(String fileName) 
        {
            try
            {
                bool isExists = Directory.Exists(logFolderPath);

                if (!isExists)
                    Directory.CreateDirectory(logFolderPath);

                var path = String.Format(@"{0}/{1}_{2}.txt", logFolderPath, fileName, DateTime.Now.ToString("yyyy-MM-dd"));

                ostrm = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Cannot open {0} for writing",fileName));
                Console.WriteLine(e.Message);
                return;
            }
        }

        private void CloseStream()
        {
            writer.Close();
            ostrm.Close();
        }
    }

}
