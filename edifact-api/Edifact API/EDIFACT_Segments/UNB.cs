using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public class UNB : DataSegment
    {
        public DataElement Segment1 { get; set; }
        public ComponentDataElement Segment2 { get; set; }
        public DataElement Segment3 { get; set; }
        public DataElement Segment4 { get; set; }
        public DataElement Segment5 { get; set; }
        public ComponentDataElement Segment6{ get; set; }
        public DataElement Segment7 { get; set; }
        public DataElement Segment8 { get; set; }
        public DataElement Segment9 { get; set; }
    }
}
