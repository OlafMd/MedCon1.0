using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.Models
{
    public class TransmitionInformation
    {
        public bool isError { get; set; }
        public List<string> errorMessage { get; set;}

        public TransmitionInformation()
        {
            errorMessage = new List<string>();
        }
    }
}
