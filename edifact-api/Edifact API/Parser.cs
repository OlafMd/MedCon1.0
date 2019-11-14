using Edifact_API.EDIFACT_Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API
{
    public class Parser
    {
        private char[] DelList = { '\r', '\n' };
        private Segment[] arSegments;

        /// <summary>
		/// Primary constructor, used for receiving a reference to a string representation of an
		/// EDIFACT message.
		/// </summary>
		/// <param name="rawMessage"></param>
		public Parser( ref string rawMessage)
        {
            arSegments = ParseDocument(ref rawMessage);
        }


        public Segment [] ParseDocument(ref string ediMessage)
        {
            string [] tempSegments;
            Segment[] segments;
            char[] delim = new char[] { '\'' }; 

            for (int j = 0; j < ediMessage.Length;j++ )
            {
                if(IsDelimiter(ediMessage[j]))
                {
                    ediMessage = ediMessage.Remove(j, 1);
                    --j;
                }
            }
            ediMessage = ediMessage.Trim(delim);
            tempSegments = ediMessage.Split(delim);
            segments = new Segment[tempSegments.Length];

            for (int i = 0; i < tempSegments.Length; i++)
            {
                segments[i] = new Segment(ref tempSegments[i]);
            }
            
            return segments;
        }


        public Segment [] GetSegments()
        {
            return arSegments;
        }

        private bool IsDelimiter(char c)
        {
            foreach (var ch in DelList)
            {
                if(c.Equals(ch))
                    return true;
            }
            return false;
        }


    }
}
