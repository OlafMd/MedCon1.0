using System;

namespace DictTextBox
{
    [Serializable]
    public class Language
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid TenantID { get; set; }
    }
}
