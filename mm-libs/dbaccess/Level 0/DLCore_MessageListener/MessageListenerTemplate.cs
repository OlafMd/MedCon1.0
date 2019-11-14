using System;
using System.Data.Common;
using DLCore_MessageListener.Log;
using System.Xml.Linq;
using DLUtils_Common.UrgentFailure;


namespace DLCore_MessageListener
{
    public enum EBCHandlerStatus { Ok, Error, Spam, Ping, Unknown  }

    public abstract class MessageListenerTemplate : System.Web.Services.WebService
    {
        abstract public string receiveMessage(string payload, string messageType, string version);

        protected string ReceiveMessageHandler(string payload, string messageType, string version, string connectionString)
        {
            payload = Server.UrlDecode(payload);
            payload = System.Web.HttpUtility.HtmlDecode(payload);

            ServerLog.Instance.Info(String.Format("MESSAGE: {0} \r\n {1} ", messageType, XElement.Parse(payload).ToString()));

            MessageStatus status = new MessageStatus(EBCHandlerStatus.Ok);

            var Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString);
            Connection.Open();
            var Transaction = Connection.BeginTransaction();

            try
            {
                status = ProcessMessage(Connection, Transaction, payload, messageType, version);
                
                if(status.Status == EBCHandlerStatus.Error)
                    throw new Exception(status.Message);

                Transaction.Commit();
                Connection.Close();

            }
            catch (Exception ex)
            {
                try
                {
                    Transaction.Rollback();
                    Connection.Close();
                }
                catch { }

                var stackTrace = String.Format(
                    "Exception:\r\n {0} \r\n InnerException:\r\n {1}",
                    Environment.NewLine,
                    ex.StackTrace,
                    Environment.NewLine,
                    ex.InnerException.StackTrace);

                UrgentFailureHandler.Instance.SendEmail(stackTrace);

                ServerLog.Instance.Error(stackTrace);

                status = new MessageStatus(EBCHandlerStatus.Error, ex.Message);
            }


            if (status.Status != EBCHandlerStatus.Ping || status.Status != EBCHandlerStatus.Spam)
                ServerLog.Instance.Info("Status message: " + status.Message);

            return status.Message;
        }

        abstract protected MessageStatus ProcessMessage(DbConnection Connection, DbTransaction Transaction, string payload, string messageType, string version);
        
    }

    public class MessageStatus{

        public EBCHandlerStatus Status {get; set;} 
        public String Message {get; set;}

        public MessageStatus(EBCHandlerStatus status, String message)
        {
            Status = status;
            Message = message;
        }

        public MessageStatus(EBCHandlerStatus status)
        {
            Status = status;
            Message = "Ok";
        }
    }
}
