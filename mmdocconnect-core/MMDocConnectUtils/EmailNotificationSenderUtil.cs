using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MMDocConnectUtils
{
    public class EmailNotificationSenderUtil
    {
        public static void SendEmail(String from, String emailTo, String subjectMail, String sbEmailTemplate)
        {

            MailMessage mailMessage = new MailMessage(from, emailTo, subjectMail, sbEmailTemplate);
            mailMessage.IsBodyHtml = true;
            SmtpClient SMTPClient = new SmtpClient();
#if !DEBUG
            SMTPClient.Send(mailMessage);
#endif
        }
    }

    public static class EmailTemplater
    {
        public static string SetTemplateData(String EmailTemplate, Object EmailData, String DelimiterStart, String DelimiterEnd)
        {
            var properties = EmailData.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = "";
                try
                {
                    value = property.GetValue(EmailData).ToString();
                }
                catch (Exception ex) { }

                EmailTemplate = EmailTemplate.Replace(DelimiterStart + property.Name + DelimiterEnd, value);
            }

            var loopKeyword = "<%loop ";
            var loopEndKeyword = "%>";
            var sb = new StringBuilder(EmailTemplate);

            if (EmailTemplate.Contains(loopKeyword))
            {
                var loopEndIndex = EmailTemplate.IndexOf(loopEndKeyword);
                var loopStartIndex = EmailTemplate.IndexOf(loopKeyword);
                var loopedCollection = EmailTemplate.Substring(loopStartIndex, loopEndIndex - loopStartIndex).Replace(loopKeyword, "").Replace(loopEndKeyword, "");
                var loopEndStatement = String.Format("<%end loop {0}%>", loopedCollection);
                var loopEndStatementIndex = EmailTemplate.IndexOf(loopEndStatement);
                var loopStatementIndex = loopEndIndex + loopEndKeyword.Length + 2;
                var loopStatement = EmailTemplate.Substring(loopStatementIndex, loopEndStatementIndex - loopStatementIndex);
                var collectionToIterate = ((IEnumerable<object>)properties.Single(t => t.Name == loopedCollection).GetValue(EmailData)).ToList();
                var i = 0;

                foreach (var item in collectionToIterate)
                {
                    var itemProperties = item.GetType().GetProperties();
                    var formattedLoopStatement = String.Copy(loopStatement);

                    foreach (var property in itemProperties)
                    {
                        var value = "";
                        try
                        {
                            value = property.GetValue(item).ToString();
                        }
                        catch (Exception ex) { }

                        formattedLoopStatement = formattedLoopStatement.Replace(DelimiterStart + property.Name + DelimiterEnd, value);
                    }
                    loopEndIndex = EmailTemplate.IndexOf(loopEndKeyword);
                    loopStatementIndex = loopEndIndex + loopEndKeyword.Length + 2;


                    loopStatementIndex = EmailTemplate.IndexOf(loopStatement);
                    sb.Remove(loopStatementIndex, loopStatement.Length);

                    var nextLoopStatementData = String.Format("{0}{1}", formattedLoopStatement, i++ < collectionToIterate.Count - 1 ? loopStatement : "");
                    sb.Insert(loopStatementIndex, nextLoopStatementData);

                    EmailTemplate = sb.ToString();
                }

                EmailTemplate = EmailTemplate.Replace(String.Format("{0}{1}", loopEndStatement, "\r\n"), "");
                EmailTemplate = EmailTemplate.Replace(String.Format("{0}{1}{2}\r\n", loopKeyword, loopedCollection, loopEndKeyword), "");
            }

            EmailTemplate = EmailTemplate.Replace("\n", "<br>");
            return new Regex(@" +").Replace(EmailTemplate, " ");
        }
    }
}
