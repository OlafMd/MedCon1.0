using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSwitcher
{
    [Serializable]
    public class Project
    {

        public Guid ID { get; set; }
        public string Name { get; set; }

    }
}
