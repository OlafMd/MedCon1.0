using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class TreatmentMultiEditSubmitModel
    {
        public bool IsSubmit { get; set; }
        public Guid[] CaseIDs { get; set; }
        public Guid[] CaseIDsToSubmit { get; set; }
        public Guid PracticeID { get; set; }
        public Guid AuthorizingDoctorID { get; set; }
        public Guid TreatmentDoctorID { get; set; }
        public Guid AftercareDoctorID { get; set; }
    }
}
