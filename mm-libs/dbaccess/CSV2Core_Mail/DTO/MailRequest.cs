using System;
using System.Text;
using System.Runtime.Serialization;
using System.Net.Mail;

namespace CSV2Core_Mail.DTO
{
    [DataContract]
    public class MailRequest
    {
        [DataMember]
        public string Address_From { get; set; }
        [DataMember]
        public string Address_From_DisplayName { get; set; }
        [DataMember]
        public string[] Address_To { get; set; }
        [DataMember]
        public string[] Address_CC { get; set; }
        [DataMember]
        public string[] Address_BCC { get; set; }

        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public bool IsBodyHTML { get; set; }

        [DataMember]
        public string MailMessageID { get; set; }


        public MailMessage MailMessage
        {
            get
            {
                try
                {
                    MailMessage message = new MailMessage();
                    if (Address_From_DisplayName != null)
                        message.From = new MailAddress(Address_From, Address_From_DisplayName);
                    else
                        message.From = new MailAddress(Address_From);

                    if (Address_To != null && Address_To.Length > 0)
                    {
                        message.To.Add(string.Join(" , ", Address_To));
                    }

                    if (Address_CC != null && Address_CC.Length > 0)
                    {
                        if (!(Address_CC.Length == 1 && Address_CC[0] == ""))
                            message.CC.Add(string.Join(" , ", Address_CC));
                    }

                    if (Address_BCC != null && Address_BCC.Length > 0)
                    {
                        if (!(Address_BCC.Length == 1 && Address_BCC[0] == ""))
                            message.Bcc.Add(string.Join(" , ", Address_BCC));
                    }
                    message.BodyEncoding = Encoding.UTF8;
                    message.SubjectEncoding = Encoding.UTF8;

                    message.IsBodyHtml = IsBodyHTML;
                    message.Subject = Subject;
                    message.Body = Body;

                    return message;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
