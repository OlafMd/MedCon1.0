using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edifact_API;
using Edifact_API.Models;
using Edifact_API.EDIFACT_Segments;

namespace Edifact_API
{
    public class EDIFACT
    {
        public string Una { get; set; }

        public UNB Unb { get; set; }

        public UNZ Unz { get; set; }

        public string mmIkNumber { get; set; }

        public string hipIkNumber { get; set; }

        public string FileName { get; set; }

        public long encryptedFileSize { get; set; }

        public long decryptedFileSize { get; set; }

        /// <summary>
        /// List of Messages that are sent
        /// </summary>
        public List<TransmitionMessage> transmitionMessages { get; set; }

        public EDIFACT()
        {
            transmitionMessages = new List<TransmitionMessage>();
            Unb = new UNB();
            Unz = new UNZ();
        }
    }





}
