using System;
using System.Net.Mail;
using System.Threading;
using CSV2Core_Mail.DTO;
using System.IO;
using CSV2Core_Mail.Configuration;

namespace CSV2Core_Mail
{
    public class MailSender
    {
        private static int retryTimeout = 1000;
        private MailBuffer mailBuffer;
        private static MailSender _instance;
        private FileSystemWatcher watcher;
        private MailSender()
        {
            //Create folders if they do not exist
            Directory.CreateDirectory(@MailSettings.Settings.MailStorageSuccess);
            Directory.CreateDirectory(@MailSettings.Settings.MailStorageTemp);
            Directory.CreateDirectory(@MailSettings.Settings.MailStorageFailed);
            Directory.CreateDirectory(@MailSettings.Settings.AttachmentsFolder);
            Directory.CreateDirectory(@MailSettings.Settings.LinkedResourcesFolder);


            mailBuffer = new MailBuffer();
            watcher = new FileSystemWatcher();
            watcher.Filter = "*.mail";
            watcher.Renamed += new RenamedEventHandler(WatcherFileCreated);
            watcher.Path = @MailSettings.Settings.MailStorageTemp;
            watcher.EnableRaisingEvents = true;
        }
        /// <summary>
        /// Method is used to send mail message with attachemnts
        /// </summary>
        /// <param name="mailMessage"></param>
        public void SendMailMessage(MailMessage mailMessage)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.Address_From = mailMessage.From.Address;
            if (mailMessage.From.DisplayName != null)
            {
                mailRequest.Address_From_DisplayName = mailMessage.From.DisplayName;
            }
            string[] toArray = { mailMessage.To.ToString() };
            mailRequest.Address_To = toArray;
            mailRequest.Body = mailMessage.Body;
            string[] ccArray = { mailMessage.CC.ToString() };
            mailRequest.Address_CC = ccArray;
            string[] bccArray = { mailMessage.Bcc.ToString() };
            mailRequest.Address_BCC = bccArray;
            mailRequest.IsBodyHTML = mailMessage.IsBodyHtml;
            mailRequest.Subject = mailMessage.Subject;
            mailRequest.MailMessageID = Guid.NewGuid().ToString();

            //Save attachment to file
            foreach (Attachment attachment in mailMessage.Attachments)
            {
                string attachmentFodlerPath = MailSettings.Settings.AttachmentsFolder + "/" + mailRequest.MailMessageID;
                Directory.CreateDirectory(@attachmentFodlerPath);
                string attachmentName = attachment.Name;
                //If there are multiple attachments with same name add index of attachment to fileName)

                attachmentName += "." + mailMessage.Attachments.IndexOf(attachment);

                using (FileStream fileStream = File.Create(@attachmentFodlerPath + "/" + attachmentName))
                {
                    byte[] bytesInStream = new byte[attachment.ContentStream.Length];
                    attachment.ContentStream.Read(bytesInStream, 0, bytesInStream.Length);
                    fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                }

            }

            if (mailMessage.AlternateViews.Count > 0)
            {
                foreach (LinkedResource rsc in mailMessage.AlternateViews[0].LinkedResources)
                {
                    string linkedResourceFolderPath = MailSettings.Settings.LinkedResourcesFolder + "/" + mailRequest.MailMessageID;
                    Directory.CreateDirectory(@linkedResourceFolderPath);
                    string resourceContentId = rsc.ContentId;

                    using (FileStream fileStream = File.Create(@linkedResourceFolderPath + "/" + resourceContentId))
                    {
                        byte[] bytesInStream = new byte[rsc.ContentStream.Length];
                        rsc.ContentStream.Read(bytesInStream, 0, bytesInStream.Length);
                        fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                    }

                }
            }

            SendMailMessage(mailRequest);

        }


        public void SendMailMessage(MailRequest mailRequest)
        {
            if (mailRequest.MailMessageID == null)
            {
                mailRequest.MailMessageID = Guid.NewGuid().ToString();
            }
            string fileName = MailSettings.Settings.MailStorageTemp + "/" + mailRequest.MailMessageID;
            String filePath = fileName + ".temp";
            CSV2Core_Mail.SerializationUtil.SerializeObject<MailRequest>(mailRequest, filePath);
            File.Move(fileName + ".temp", fileName + ".mail");
        }


        public void StartMailing()
        {
            mailBuffer.FillBufferWithInitialMessages();
            InitializeMailerThreads();
        }

        public static MailSender Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MailSender();
                }
                return _instance;
            }
        }

        private void WatcherFileCreated(object sender, RenamedEventArgs e)
        {
            try
            {
                MailRequest mailRequst = SerializationUtil.DeSerializeObject<MailRequest>(e.FullPath);
                if (mailRequst == null)
                    return;
                MailMessageWrapper wrapper = new MailMessageWrapper();
                wrapper.filePath = e.Name;
                wrapper.mailMessage = mailRequst.MailMessage;
                wrapper.mailID = mailRequst.MailMessageID;
                //Load attachemnts if any
                string attachmentsFolder = @MailSettings.Settings.AttachmentsFolder + "/" + mailRequst.MailMessageID;
                if (Directory.Exists(attachmentsFolder))
                {
                    string[] attachmentPaths = Directory.GetFiles(attachmentsFolder);
                    foreach (string attachmentPath in attachmentPaths)
                    {
                        Stream fileStream = File.OpenRead(@attachmentPath);

                        string attachmentName = Path.GetFileNameWithoutExtension(attachmentPath);
                        Attachment newAttachment = new Attachment(fileStream, attachmentName);
                        wrapper.mailMessage.Attachments.Add(newAttachment);

                        //Get attachment name without its ordinal (attachment.txt.1 -> attachment.txt)

                    }
                }

                string linkedResourcesFolder = @MailSettings.Settings.LinkedResourcesFolder + "/" + mailRequst.MailMessageID;
                if (Directory.Exists(linkedResourcesFolder))
                {
                    AlternateView altView = AlternateView.CreateAlternateViewFromString(wrapper.mailMessage.Body, null, "text/html");
                    string[] resourceFolderPaths = Directory.GetFiles(linkedResourcesFolder);
                    foreach (string resourcePath in resourceFolderPaths)
                    {
                        Stream fileStream = File.OpenRead(@resourcePath);
                        string contentId = Path.GetFileNameWithoutExtension(resourcePath);
                        LinkedResource rsc = new LinkedResource(fileStream);
                        rsc.ContentId = contentId;
                        altView.LinkedResources.Add(rsc);
                    }
                    wrapper.mailMessage.AlternateViews.Add(altView);
                }

                mailBuffer.PutMessage(wrapper);
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception occured in MailBuffer.FillBufferWithInitialMessages: ", ex);
                File.Move(e.FullPath, e.FullPath.Replace("temp", "failed"));
            }
        }

        private void InitializeMailerThreads()
        {
            Logger.Instance.Info("MailSender Thread(s) started.");
            int num = MailSettings.Settings.NumberOfThreads;
            ThreadPool.SetMaxThreads(num, num);
            ThreadPool.QueueUserWorkItem(new WaitCallback(DeliverMessage), mailBuffer);
        }


        private static void DeliverMessage(Object mailBuffer)
        {

            while (true)
            {
                MailMessageWrapper mailMessageWrapper = ((MailBuffer)mailBuffer).TakeMessage();
                MailMessage message = mailMessageWrapper.mailMessage;



                int maxRetryCount = MailSettings.Settings.MaxRetryCount;
                SmtpClient smtpClient = null;
                try
                {
                    smtpClient = new SmtpClient();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Fatal("SMTPClient error:", ex);
                }
                do
                {

                    try
                    {

                        smtpClient.Send(message);
                        File.Move(MailSettings.Settings.MailStorageTemp + "/" + mailMessageWrapper.filePath, MailSettings.Settings.MailStorageSuccess + "/" + mailMessageWrapper.filePath);
                        
                        //success
                        Logger.Instance.Info("Successfully sent mail:" + message.Subject);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (maxRetryCount <= 0)
                        {
                            Logger.Instance.Error("Failed to send message with subject:" + message.Subject, ex);
                            File.Move(MailSettings.Settings.MailStorageTemp + "/" + mailMessageWrapper.filePath, MailSettings.Settings.MailStorageFailed + "/" + mailMessageWrapper.filePath);
                            break;
                        }
                        else
                        {
                            Logger.Instance.Warn(String.Format("Sending of message failed, retrying {0} more times", maxRetryCount), ex);
                            Thread.Sleep(retryTimeout);
                        }
                    }

                } while (maxRetryCount-- > 0);
                //Clean up attachments (if any) and dispose of mail message
                cleanUpAttachments(mailMessageWrapper);

            }
        }
        private static void cleanUpAttachments(MailMessageWrapper wrapper)
        {
            wrapper.mailMessage.Dispose();
            DirectoryInfo attachmentDir = new DirectoryInfo(MailSettings.Settings.AttachmentsFolder + "/" + wrapper.mailID);
            DirectoryInfo linkedResourceDir = new DirectoryInfo(MailSettings.Settings.LinkedResourcesFolder + "/" + wrapper.mailID);
            if (attachmentDir.Exists)
            {
                try
                {
                    foreach (FileInfo attachment in attachmentDir.GetFiles())
                    {
                        attachment.Delete();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("Exception in cleanUpAttachments method:", ex);
                }
                try
                {
                    attachmentDir.Delete();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("Exception in cleanUpAttachments method:", ex);
                }
            }

            if(linkedResourceDir.Exists)
            {
                try
                {
                    foreach (FileInfo rsc in linkedResourceDir.GetFiles())
                    {
                        rsc.Delete();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("Exception in cleanUpAttachments method on LinkedResource cleanUp:", ex);
                }
                try
                {
                    linkedResourceDir.Delete();
                }
                catch (Exception ex)
                {
                    Logger.Instance.Error("Exception in cleanUpAttachments method on LinkedResource cleanUp:", ex);
                }
            }
        }
    }
}
