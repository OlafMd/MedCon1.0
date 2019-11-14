using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class AftercareMultiEditSubmitModel
    {
        public Guid[] CaseIDs { get; set; }
        public bool IsSubmit { get; set; }
        public Guid AuthorizedByID { get; set; }
        public Guid[] CaseIDsToSubmit { get; set; }
        public string AftercarePerformedDate { get; set; }
        public Guid AftercareDoctorID { get; set; }
    }
}
