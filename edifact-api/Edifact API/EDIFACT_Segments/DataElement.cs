using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public class DataElement : AbstractElement
    {
        protected override string Separator
        {
            get
            {
                return "+";
            }
        }

        public static implicit operator DataElement(string val)
        {
            return new DataElement()
            {
                Value = val
            };
        }
    }
}
