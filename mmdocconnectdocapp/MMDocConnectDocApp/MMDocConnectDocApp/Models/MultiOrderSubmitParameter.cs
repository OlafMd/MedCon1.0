using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class MultiOrderSubmitParameter
    {
        public string search_criteria { get; set; }

        public IEnumerable<Guid> selected_ids { get; set; }

        public IEnumerable<Guid> deselected_ids { get; set; }

        public bool all_selected { get; set; }
    }
}