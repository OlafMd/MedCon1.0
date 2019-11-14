using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class MultiEditParameter
    {
        public Guid[] ids_to_edit { get; set; }
        public Guid[] ids_to_deselect { get; set; }
        public Guid[] ids_to_submit { get; set; }
        public Guid primary_id { get; set; }
        public Guid secondary_id { get; set; }
        public bool flag { get; set; }
        public bool all_selected { get; set; }
        public FilterObject filter_by { get; set; }
        public string type { get; set; }
        public string date_string { get; set; }
        public Guid authorizing_doctor_id { get; set; }
        public string sort_by { get; set; }
        public bool isAsc { get; set; }
    }
}
