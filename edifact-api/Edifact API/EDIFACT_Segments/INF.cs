using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public class INF : DataSegment
    {
        public DataElement Segment1 { get; set; }
        public DataElement Segment2 { get; set; }
        public DataElement Segment3 { get; set; }
        public ComponentDataElement Segment4 { get; set; }
    }
}
