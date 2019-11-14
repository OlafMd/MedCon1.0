using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class FieldValueParameter
    {
        public string FieldName { get; set; }

        public string FieldValue { get; set; }

        public string RangeConfig { get; set; }

        public bool Negation { get; set; }
    }
}
