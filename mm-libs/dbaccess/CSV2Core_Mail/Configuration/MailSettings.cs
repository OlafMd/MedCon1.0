using System.Configuration;

namespace CSV2Core_Mail.Configuration
{
    public class MailSettings : ConfigurationSection
    {
        private static MailSettings settings = ConfigurationManager.GetSection("MailSettings") as MailSettings;

        public static MailSettings Settings
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty("numberOfThreads", DefaultValue = 20, IsRequired = false)]
        [IntegerValidator(MinValue = 1, MaxValue = 100)]
        public int NumberOfThreads
        {
            get { return (int)this["numberOfThreads"]; }
            set { this["numberOfThreads"] = value; }
        }

        [ConfigurationProperty("maxRetryCount", DefaultValue = 20, IsRequired = false)]
        [IntegerValidator(MinValue = 1, MaxValue = 100)]
        public int MaxRetryCount
        {
            get { return (int)this["maxRetryCount"]; }
            set { this["maxRetryCount"] = value; }
        }

        [ConfigurationProperty("mailStorageSuccess", IsRequired = true)]
        public string MailStorageSuccess
        {
            get { return (string)this["mailStorageSuccess"]; }
            set { this["mailStorageSuccess"] = value; }
        }

        [ConfigurationProperty("mailStorageTemp", IsRequired = true)]
        public string MailStorageTemp
        {
            get { return (string)this["mailStorageTemp"]; }
            set { this["mailStorageTemp"] = value; }
        }
        [ConfigurationProperty("mailStorageFailed", IsRequired = true)]
        public string MailStorageFailed
        {
            get { return (string)this["mailStorageFailed"]; }
            set { this["mailStorageFailed"] = value; }
        }
        [ConfigurationProperty("attachmentsFolder", IsRequired = true)]
        public string AttachmentsFolder
        {
            get { return (string)this["attachmentsFolder"]; }
            set { this["attachmentsFolder"] = value; }
        }

        [ConfigurationProperty("linkedResourcesFolder", IsRequired = true)]
        public string LinkedResourcesFolder
        {
            get { return (string)this["linkedResourcesFolder"]; }
            set { this["linkedResourcesFolder"] = value; }
        }
    }
}
