using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.Models
{
    /// <summary>
    /// A field represents a single piece of information in a segment.
    /// </summary>
    public class Field
    {
        private string fldValue;

        public string Value
        {
            get { return fldValue; }
            set { fldValue = value; }
        }

        public Field(string Value)
        {
            fldValue = Value;
        }
    }

    /// <summary>
    /// A collection of field elements.
    /// </summary>
    public class FieldCollection : System.Collections.CollectionBase
    {
        public void Add(Field aField)
        {
            List.Add(aField);
        }

        public void Remove(int index)
        {
            // Check to see if there is a field at the supplied index.
            if (index > Count - 1 || index < 0) return;
            else
                List.RemoveAt(index);
        }

        public Field Item(int Index)
        {
            return (Field)List[Index];
        }
    }
}
