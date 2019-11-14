using Edifact_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edifact_API.EDIFACT_Segments
{
    public class Segment
    {
        private string name;
        private char[] delimiters = { '+', ':' };
        public FieldCollection Fields = new FieldCollection();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Segment(ref string segment)
        {		
            ParseSegment(ref segment);
        }

        private void ParseSegment(ref string _segment)
        {
            string[] strTemp;
            strTemp = _segment.Split(delimiters);

            for (int i = 0; i < strTemp.Length; i++)
            {
                if (i == 0)
                {	//Get Segment Name/Acronym
                    this.Name = strTemp[i];
                    continue;
                }

                Field fldTemp = new Field(strTemp[i]);
                Fields.Add(fldTemp);
            }
            strTemp = null;
        }
    }

    /// <summary>
    /// SegmentCollection is a collection of Segments.
    /// </summary>
    public class SegmentCollection : System.Collections.CollectionBase
    {
        public void Add(Segment segment)
        {
            List.Add(segment);
        }

        public void Remove(int index)
        {
            // Check to see if there is a field at the supplied index.
            if (index > Count - 1 || index < 0) return;
            else
                List.RemoveAt(index);
        }
        /// <summary>
  		/// Item accesses a field in the collection by its index value.
       	/// </summary>
        public Segment this[int index]
        {
            get { return (Segment)List[index]; }
            set { List[index] = (Segment)value; }
        }
    }


}
