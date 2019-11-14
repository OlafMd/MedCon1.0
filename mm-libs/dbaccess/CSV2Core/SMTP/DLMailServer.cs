using System;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Threading;

namespace CSV2Core.SMTP
{
    /// <summary>
    /// Configured in the Web.config of the web-server
    /// 
    /// Example configuration is given in the comment below
    /// </summary>
    //<system.net>
    //  <mailSettings>
    //    <smtp from="danutask.danulabs@gmail.com" >
    //      <network host="smtp.gmail.com" 
    //               enableSsl="true"
    //               port="587"
    //               userName="danutask.danulabs@gmail.com"
    //               password="danulabs"
    //               />
    //    </smtp>
    //  </mailSettings>
    //</system.net>
    public class DLMailServer
    {
        private static DLMailServer instance = new DLMailServer();

        private SmtpSection settings = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

        private SmtpClient smtpClient;

        private DLMailServer()
        {
            smtpClient = new System.Net.Mail.SmtpClient();
            var networkSettings = settings.Network;
            smtpClient.Host = networkSettings.Host;
            smtpClient.Port = networkSettings.Port;
            smtpClient.EnableSsl = networkSettings.EnableSsl;
            smtpClient.Credentials =  new System.Net.NetworkCredential(networkSettings.UserName, networkSettings.Password);
        }


        public static bool SendEmail(string to, string subject, string body, bool isBodyHtml, int timeout=15000)
        {
            return SendEmail(new string[] { to }, subject, body, isBodyHtml, timeout);
        }

        public static bool SendEmail(string[] to, string subject, string body, bool isBodyHtml, int timeout=15000)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(instance.settings.From);
            message.IsBodyHtml = isBodyHtml;
            message.Body = body;
            message.Subject = subject;
            
            try
            {
                foreach (string toAddress in to)
                {
                    message.To.Add(toAddress);
                }
            }
            catch { }

            try
            {
                //HAX Should be in a buffer that sends out emails, but currently acts as a buffer
                var messageThread = new MailMessageThread(message, instance.smtpClient);
                Thread mailThread = new Thread(messageThread.execute);
                mailThread.Start();
            }
            catch (Exception ex)
            {
                CSV2Core.Logging.DLSystemLog.add(ex);
                return false;
            }

            return true;
        }
    }


    class MailMessageThread
    {
        private MailMessage message;
        private  SmtpClient client;


        public MailMessageThread(MailMessage message, SmtpClient smtpClient)
        {
            this.message = message;
            this.client = smtpClient;
        }

        public void execute()
        {
            lock (client)
            {
                client.Send(message);
            }
        }
    }
}