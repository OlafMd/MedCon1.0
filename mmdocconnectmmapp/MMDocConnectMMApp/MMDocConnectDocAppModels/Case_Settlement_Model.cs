using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class Case_Settlement_Model
    {
        public Guid caseId { get; set; }
        public int CaseVolumeCount { get; set; }
        public DateTime oldest_case { get; set; }
        public int numberOdCases { get; set; }
        public int numberOfACCases { get; set; }
    }
}