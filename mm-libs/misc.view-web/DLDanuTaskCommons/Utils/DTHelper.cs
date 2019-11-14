using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace DLDanuTaskCommons.Utils
{
    public class DTHelper
    {

        //Generic Each function, which executes custom defined action foreach element in thhe list.
        public static void Each<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }

        //Preload data mappings shortcut. It creates a mapped Dictionary based on sent parameters. 
        public static Dictionary<E,G> PreloadDataMappings<E,G,S>(Dictionary<S, G> source, Dictionary<S, E> map) 
        {
            Dictionary<E, G> result = new Dictionary<E, G>();
            Each(source, s=>result.Add(map[s.Key], s.Value));
            return result;
        }

        public static String GetItemsInStringSeparatedByComma(List<String> Values)
        {
            String retVal = "";
            if (Values!= null && Values.Count > 0)
            {
                String LastVal = Values.Last();
                foreach (var temp in Values)
                {
                    retVal += temp;
                    if (temp != LastVal)
                        retVal += ", ";
                }
            }
            return retVal;
        }
    }
}
