using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    public class KeyValueModel
    {
        public string key { get; set; }
        public string value { get; set; }
        public bool isValid { get; set; }
        public string validationMessage { get; set; }
    }


}
