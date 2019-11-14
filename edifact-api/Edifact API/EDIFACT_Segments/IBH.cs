using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public class IBH : DataSegment
    {
        public DataElement Segment1 { get; set; }
        public DataElement Segment2 { get; set; }
    }
}
