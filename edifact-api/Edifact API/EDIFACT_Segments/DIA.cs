using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public class DIA : DataSegment
    {
        public DataElement Segment1 { get; set; }
        public ComponentDataElement Segment2 { get; set; }
        public ComponentDataElement Segment3 { get; set; }
    }
}
