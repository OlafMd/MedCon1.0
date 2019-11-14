using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Doctor.Model
{
    public enum EDoctorPropertyType
    {
        [Description("mm.docconnect.doctor.customer.number")]
        CustomerNumber,
        [Description("mm.docconnect.doctor.oct.certificated")]
        OctCertificated,
        [Description("mm.docconnect.doctor.oct.valid.from.date")]
        OctValidFrom
    }
}
