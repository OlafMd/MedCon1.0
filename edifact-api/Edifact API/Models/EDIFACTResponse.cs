using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.Models
{
    public class EDIFACTResponse : TransmitionInformation
    {
        public string edifactFileOutput { get; set; }
        public string edifactName { get; set; }

    }
}
