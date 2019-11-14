using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.Models
{
    public class AUFResponse : TransmitionInformation
    {
        public string aufFileOutput { get; set; }
        public string aufName { get; set; }
    }
}
