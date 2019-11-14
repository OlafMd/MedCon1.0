using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class SubmissionReportParameter
    {
        public List<CaseData> CaseParameters { get; set; }
        public bool IsAllSelected { get; set; }
    }

    public class CaseData
    {
        public Guid CaseID { get; set; }
        public bool IsTreatment { get; set; }
    }
}
