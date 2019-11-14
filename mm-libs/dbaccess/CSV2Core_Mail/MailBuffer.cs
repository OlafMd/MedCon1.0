using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Net.Mail;
using System.IO;
using CSV2Core_Mail.DTO;
using CSV2Core_Mail.Configuration;

namespace CSV2Core_Mail
{
    public class MailBuffer
    {

        private BlockingCollection<MailMessageWrapper> mailMessages = new BlockingCollection<MailMessageWrapper>();
        public MailMessageWrapper TakeMessage()
        {
            return mailMessages.Take();
        }

        public void PutMessage(MailMessageWrapper mailMessage)
        {
            mailMessages.Add(mailMessage);
        }

        public void FillBufferWithInitialMessages()
        {
            var sortedFiles = new DirectoryInfo(@MailSettings.Settings.MailStorageTemp).GetFiles().OrderBy(f => f.LastWriteTime).ToList();

            foreach (var file in sortedFiles)
            {
                try
                {
                    MailRequest message = SerializationUtil.DeSerializeObject<MailRequest>(file.FullName);
                    MailMessageWrapper mailMessageWrapper = new MailMessageWrapper();
                    mailMessageWrapper.filePath = file.Name;
                    mailMessageWrapper.mailMessage = message.MailMessage;
                    mailMessageWrapper.mailID = message.MailMessageID;
                    mailMessages.Add(mailMessageWrapper);

                    string attachemntsFolder = @MailSettings.Settings.AttachmentsFolder + "/" + message.MailMessageID;
                    string linkedResourcesFolder = @MailSettings.Settings.LinkedResourcesFolder + "/" + message.MailMessageID;
                    if (Directory.Exists(attachemntsFolder))
                    {
                        string[] attachmentPaths = Directory.GetFiles(attachemntsFolder);
                        foreach (string attachmentPath in attachmentPaths)
                        {
                            Stream fileStream = File.OpenRead(@attachmentPath);
                            //Get attachment name without its ordinal (attachment.txt.1 -> attachment.txt)
                            string attachmentName = Path.GetFileNameWithoutExtension(attachmentPath);
                            Attachment newAttachment = new Attachment(fileStream, attachmentName);
                            mailMessageWrapper.mailMessage.Attachments.Add(newAttachment);
                        }
                    }
                    if (Directory.Exists(linkedResourcesFolder))
                    {
                        string[] linkedResourcesPaths = Directory.GetFiles(linkedResourcesFolder);
                        AlternateView altView = AlternateView.CreateAlternateViewFromString(mailMessageWrapper.mailMessage.Body, null, "text/html");
                        foreach (string rscPath in linkedResourcesPaths)
                        {
                            Stream fileStream = File.OpenRead(@rscPath);
                            string rscContentId = Path.GetFileNameWithoutExtension(rscPath);
                            LinkedResource rsc = new LinkedResource(fileStream);
                            rsc.ContentId = rscContentId;
                            altView.LinkedResources.Add(rsc);
                        }
                        mailMessageWrapper.mailMessage.AlternateViews.Add(altView);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("Exception occured in MailBuffer.FillBufferWithInitialMessages: ", ex);
                    File.Move(file.FullName, file.FullName.Replace("temp", "failed"));
                }
            }

        }
    }
}
