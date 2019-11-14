using Edifact_API.EDIFACT_Segments;
using Edifact_API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API
{
    public static class SegmentSetMethods
    {
        public static EDIFACTResponse GetEdifact(this EDIFACT edifact)
        {
            var edifactResponse = new EDIFACTResponse();
            edifactResponse.edifactName = edifact.FileName;
            edifactResponse.edifactFileOutput = edifact.GetEDIFACTFileOutput();

            return edifactResponse;
        }

        public static AUFResponse GetAufFile(this EDIFACT edifact)
        {
            var aufResponse = new AUFResponse();
            aufResponse.aufFileOutput = String.Format("5000000100000348000{0}RG140{1}      {1}      {2}      {2}      000000000000{0}   {3}0000010000000000000000000000000000000000000000000000000{4}{5}I8000000   0000000000000 0000000000000000000                                                                                                       ",
                edifact.FileName,
                edifact.mmIkNumber,
                edifact.hipIkNumber,
                DateTime.Now.ToString("yyyyMMdd"),
                edifact.decryptedFileSize.ToString("D12"),
                edifact.encryptedFileSize.ToString("D12"));

            aufResponse.aufName = edifact.FileName + ".auf";
            return aufResponse;
        }

        private static string GetEDIFACTFileOutput(this EDIFACT edifact)
        {
            var edifactFileOutput = edifact.Una;
            edifactFileOutput += edifact.Unb.ToString();

            foreach (var message in edifact.transmitionMessages)
            {
                edifactFileOutput += message.ToString();
            }

            edifactFileOutput += edifact.Unz.ToString();

            return edifactFileOutput;
        }
    }
}
