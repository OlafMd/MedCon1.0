using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public abstract class DataSegment
    {
        public DataSegment()
        {
            var properties = this.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (prop.PropertyType.IsSubclassOf(typeof(AbstractElement)))
                {
                    var value = prop.PropertyType.GetConstructors().First().Invoke(null);
                    prop.SetValue(this, value);
                }
            }
        }

        public override string ToString()
        {
            var result = this.GetType().Name;
            var properties = this.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var value = prop.GetValue(this);
                result += value.ToString();
            }

            result += "'\n";

            return result;
        }
    }
}
