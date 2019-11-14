using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CL6_Lucentis_BillingHistory.Utils
{
    /*
     * @deep copy of the list for a reference type list
     * */
    public class UtilMethods
    {
        public static List<DoctorsBilling_Excel> DeepCopy(List<DoctorsBilling_Excel> data)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, data);

            ms.Position = 0;
            return (List<DoctorsBilling_Excel>)bf.Deserialize(ms);
        }
    }
}
