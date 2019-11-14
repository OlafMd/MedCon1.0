using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Doctor.Model
{
    public enum EGracePeriod
    {
        [Description("mm.docconnect.doctor.pasword-grace-period")]
        DoctorGracePeriod,

        [Description("mm.docconnect.practice.pasword-grace-period")]
        PracticeGracePeriod
    }
}
