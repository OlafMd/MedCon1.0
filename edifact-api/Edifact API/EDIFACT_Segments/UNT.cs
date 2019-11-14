using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public class UNT : DataSegment
    {
        public DataElement Segment1 { get; set; }
        public DataElement Segment2 { get; set; }
    }
}
