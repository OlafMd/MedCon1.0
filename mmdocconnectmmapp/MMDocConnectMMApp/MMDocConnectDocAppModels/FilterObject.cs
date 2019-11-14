using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMAppModels
{
    public class FilterObject
    {
        public string sort_by { get; set; }
        public bool isAsc { get; set; }
        public int start_row_index { get; set; }
        public string search_params { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public FilterBy filter_by { get; set; }

        public FilterObject()
        {
            filter_by = new FilterBy();
        }
    }

    public class FilterBy
    {
        public string[] filter_type { get; set; }
        public string[] filter_status { get; set; }

    }

}