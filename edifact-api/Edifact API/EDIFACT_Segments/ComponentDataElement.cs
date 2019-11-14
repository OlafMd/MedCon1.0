using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public class ComponentDataElement : AbstractElement
    {
        protected override string Separator
        {
            get
            {
                return ":";
            }
        }

        public static implicit operator ComponentDataElement(string val)
        {
            return new ComponentDataElement()
            {
                Value = val
            };
        }
    }
}
