using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    public class CaseModel
    {
        public string patientFirstName { get; set; }
        public string patientLastName { get; set; }
        public string hip { get; set; }
        public string treatmentDate { get; set; }
        public string drugName { get; set; }
        public string pzn { get; set; }
        public string icd10 { get; set; }
        public string localization { get; set; }
        public string opDocFirstName { get; set; }
        public string opDocLastName { get; set; }
        public string opDocLANR { get; set; }
        public string acDocFirstName { get; set; }
        public string acDocLastName { get; set; }
        public string acDocLANR { get; set; }
        public string op1 { get; set; }
        public string op2 { get; set; }
        public string op5 { get; set; }
        public string op6 { get; set; }
        public string op7 { get; set; }
        public string op8 { get; set; }
        public string op10 { get; set; }
        public string ac1 { get; set; }
        public string ac2 { get; set; }
        public string ac6 { get; set; }
        public string ac7 { get; set; }
        public string ac8 { get; set; }
        public string ac9 { get; set; }
        public string ac11 { get; set; }
        public string opSettlementNumber { get; set; }
        public FS opFSStatuses { get; set; }
        public string acSettlementNumber { get; set; }
        public FS acFSStatuses { get; set; }
        public string bevacizumabSettlementNumber { get; set; }
        public FS bevacizumabFSStatuses { get; set; }
        public string managementFeeSettlementNumber { get; set; }
        public FS managementFeeFSStatuses { get; set; }
        public Practice treatmentPractice { get; set; }
        public Practice aftercarePractice { get; set; }
        public bool isValid { get; set; }
        public string validationMessages { get; set; }
        public HipComment comments { get; set; }

        public CaseModel() {
            treatmentPractice = new Practice();
            aftercarePractice = new Practice();
            opFSStatuses = new FS();
            acFSStatuses = new FS();
            bevacizumabFSStatuses = new FS();
            managementFeeFSStatuses = new FS();
            validationMessages = "";
            isValid = true;
            comments = new HipComment();
        }
    }

    public class FS
    {
        public string fs1 { get; set; }
        public string fs2 { get; set; }
        public string fs4 { get; set; }
        public string fs5 { get; set; }
        public string fs7 { get; set; }
        public string fs8 { get; set; }
        public string gpos { get; set; }
        public string primaryComment { get; set; }
        public string secondaryComment { get; set; }
    }

    public class Practice
    {
        public string BSNR { get; set; }
        public string Name { get; set; }
    }

    public class HipComment
    {
        public string opPrimaryComment { get; set; }
        public string opSecondaryComment { get; set; }
        public string acPrimaryComment { get; set; }
        public string acSecondaryComment { get; set; }
        public string bevaPrimaryComment { get; set; }
        public string bevaSecondaryComment { get; set; }
        public string manPrimaryComment { get; set; }
        public string manSecondaryComment { get; set; }
    }

}
