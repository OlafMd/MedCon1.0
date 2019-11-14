using System;

namespace GlobalComponents
{

    [Serializable]
    public class Tenant
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid LanguageID { get; set; }

    }

    [Serializable]
    public class UserInfo
    {
        public string Name { get; set; }
        public string AvatarUrl { get; set; }

    }
}
