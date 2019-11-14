using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;

namespace Core_ClassLibrarySupport.Utils
{
    public class EmailUtils
    {
        public static void sendMailNotifier(string emailFrom, List<string> emailTo, string subject, string body, List<Attachment> attachments = null)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(emailFrom);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
				if(attachments != null)
					foreach(var a in attachments)
						mailMessage.Attachments.Add(a); 
                // add recipients
                emailTo.ForEach(x => mailMessage.To.Add(new MailAddress(x)));

                smtpClient.Send(mailMessage);
            }
        }

        public static void SendMail(string[] emailTo, string subject, string body, List<Attachment> attachments = null)
        {
            sendMailNotifier("noreply@danulabs.com",
                                            emailTo.ToList(),
                                            subject,
                                            body,
                                            attachments
                                            );

        }

        public static void SendMail(string emailFrom, List<string> emailTo, string subject, string body)
        {
            Thread emailThread = new Thread(() =>
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(emailFrom);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    // add recipients
                    emailTo.ForEach(x => mailMessage.To.Add(new MailAddress(x)));

                    smtpClient.Send(mailMessage);
                }
            });
            emailThread.Start();
        }
    }


    public static class EmailFactory
    {
        public static IEmail BasicEmail()
        {
            return new BasicEmail();
        }

    }

    public interface IEmail
    {
        void sendMailNotifier(List<string> emailTo, string subject, string body, List<Attachment> attachments = null);
    }

    public class BasicEmail : IEmail
    {
        public void sendMailNotifier(List<string> emailTo, string subject, string body, List<Attachment> attachments = null)
        {
            EmailUtils.SendMail("noreply@danulabs.com",
                                            emailTo,
                                            subject,
                                            body
                                            );
        }
    }
}