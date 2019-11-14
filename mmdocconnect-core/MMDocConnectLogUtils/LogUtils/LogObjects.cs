using CL1_USR;
using CSV2Core.SessionSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace LogUtils
{
    public class LogEntry
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public UserObject UserInfo { get; set; }
        public LogObject LogObjectInfo { get; set; }
        public string ApplicationVersion { get; set; }
        public LogEntry(string ip, string agent, string connectionString, MethodBase methodInfo, SessionSecurityTicket securityTicket, object currentObjectState = null, object previousObjectState = null, string message = null)

        {
            this.ClassName = methodInfo.DeclaringType.Name;
            this.MethodName = methodInfo.Name;
            this.Date = DateTime.Now.ToString("yyyy-MM-dd");
            this.Time = DateTime.Now.ToString("HH:mm");
            this.UserInfo = new UserObject(agent, ip, connectionString, securityTicket);
            if (currentObjectState == null && previousObjectState == null)
                this.LogObjectInfo = null;
            else
                this.LogObjectInfo = new LogObject(currentObjectState, previousObjectState);

            this.Message = message;
            this.ApplicationVersion = WebConfigurationManager.AppSettings["application-version"];
        }

        public LogEntry(string ip, string agent, MethodBase methodInfo, object currentObjectState)
        {
            this.ClassName = methodInfo.DeclaringType.Name;
            this.MethodName = methodInfo.Name;
            this.Date = DateTime.Now.ToString("yyyy-MM-dd");
            this.Time = DateTime.Now.ToString("HH:mm");
            this.LogObjectInfo = new LogObject(currentObjectState, null);
            this.UserInfo = new UserObject(agent, ip);
            this.ApplicationVersion = WebConfigurationManager.AppSettings["application-version"];
        }

        public LogEntry(MethodBase methodInfo, object currentObjectState = null, object previousObjectState = null, string message = null)
        {
            this.ClassName = methodInfo.DeclaringType.Name;
            this.MethodName = methodInfo.Name;
            this.Date = DateTime.Now.ToString("yyyy-MM-dd");
            this.Time = DateTime.Now.ToString("HH:mm");
            this.UserInfo = null;

            if (currentObjectState == null && previousObjectState == null)
                this.LogObjectInfo = null;
            else
                this.LogObjectInfo = new LogObject(currentObjectState, previousObjectState);

            this.Message = message;
            this.ApplicationVersion = WebConfigurationManager.AppSettings["application-version"];
        }

        public LogEntry(string message)
        {
            this.UserInfo = null;
            this.Date = DateTime.Now.ToString("yyyy-MM-dd");
            this.Time = DateTime.Now.ToString("HH:mm");
            this.LogObjectInfo = new LogObject(null, null);
            this.Message = message;
            this.ApplicationVersion = WebConfigurationManager.AppSettings["application-version"];
        }
    }

    public class LogObject
    {
        public object CurrentObjectState { get; set; }
        public object PreviousObjectState { get; set; }

        public LogObject(object CurrentObjectState, object PreviousObjectState)
        {
            this.CurrentObjectState = CurrentObjectState;
            this.PreviousObjectState = PreviousObjectState;
        }
    }

    public class UserObject
    {
        public string Username { get; set; }
        public string IP { get; set; }
        public string Browser { get; set; }
        public UserObject(string agent, string ip, string connectionString = null, SessionSecurityTicket securityTicket = null)
        {
            this.IP = ip;
            this.Browser = agent;
            if (connectionString != null && securityTicket != null)
            {
                this.Username = ORM_USR_Account.Query.Search(connectionString, new ORM_USR_Account.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    USR_AccountID = securityTicket.AccountID,
                    IsDeleted = false
                }).Single().AccountSignInEmailAddress;
            }
        }
    }

    public class CaseLogObject
    {
        public string CaseNumber { get; set; }
        public string BillPositionType { get; set; }
        public string BillPositionNumber { get; set; }
    }

    public class OrderLogObject
    {
        public double OrderNumber { get; set; }
        public int CurrentOrderStatus { get; set; }
    }
}
