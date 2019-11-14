using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.Models
{
    public class TransmitionHeaderInformation
    {
        /// <summary>
        /// ID number of the organisation which is sending the EDIFACT file. 
        /// </summary>
        public string  	interchangeSenderIdentification { get; set; }
        /// <summary>
        ///  ID number of the organisation which is receiving the EDIFACT file. 
        /// </summary>
        public string interchangeRecipientIdentification { get; set; }
        /// <summary>
        /// <para>This represents a  continuous number of deliveries between senders and recipients.</para> 
        /// <para>You could say that it represents a "delivery ID". </para>
        /// <para>Beginning with "1".</para>
        /// </summary>
        public uint  interchangeControlReference { get; set; }
        /// <summary>
        /// <para>Indicates if EDIFACT is used for test.</para>
        /// <para>Default value true.</para>
        /// </summary>
        public bool isTestData { get; set; }

        public TransmitionHeaderInformation()
        {
            this.isTestData = true;
        }
    }
}
