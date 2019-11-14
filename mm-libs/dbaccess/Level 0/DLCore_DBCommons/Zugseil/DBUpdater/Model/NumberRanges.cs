using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLCore_DBCommons.Zugseil.DBUpdater.Model
{
    public class NumberRange
    {
        public List<NumberRangeItem> NumberRanges { get; set; }
    }

    public class NumberRangeItem
    {
        public string Name { get; set; }
        public int CurrentValue { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public string FixedPrefix { get; set; }
        public int Length { get; set; }
        public string FillCharacter { get; set; }
        public string GlobalStaticMatchingID { get; set; }
    }
}
