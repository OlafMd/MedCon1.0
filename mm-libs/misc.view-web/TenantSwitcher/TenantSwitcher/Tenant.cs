using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalComponents
{

    [Serializable]
    public class Tenant
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid LanguageID { get; set; }

    }
}
