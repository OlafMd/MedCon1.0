using System.Net.Mail;

namespace CSV2Core_Mail.DTO
{
    public class MailMessageWrapper
    {
        public MailMessage mailMessage { get; set; }
        public string filePath { get; set; }
        public string mailID { get; set; }
    }
}
