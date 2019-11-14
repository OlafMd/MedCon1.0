using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Pharmacy.Model
{
    public enum EPharmacyType
    {
        [Description("mm.docconnect.pharmacy.external")]
        External,
        [Description("mm.docconnect.pharmacy.internal")]
        Internal
    } 
}
