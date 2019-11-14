using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public abstract class AbstractElement
    {
        public string Value { get; set; }

        protected virtual string Separator
        {
            get
            {
                return "";
            }
        }

        public override string ToString()
        {
            var result = "";
            if (Value != null)
            {
                result = String.Format("{0}{1}", Separator, Value);
            }

            return result;
        }
    }
}
