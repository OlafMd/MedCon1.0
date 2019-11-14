using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class ACAutocompleteModel
    {
        public List<AutocompleteModel> last_used { get; set; }
        public List<AutocompleteModel> doctors { get; set; }
        public List<AutocompleteModel> practices { get; set; }
    }
}
