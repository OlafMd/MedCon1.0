using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppModels
{
    public class MedicationModel
    {
        public Guid MedicationID { get; set; }
        public string Medication { get; set; }
        public bool ProprietaryDrug { get; set; }
        public string PZNScheme { get; set; }
        public int Dosage { get; set; }
        public string Unit { get; set; }
        public Guid HecDrugID { get; set; }
    }

    public class MedicationSort
    {
        public bool isAsc { get; set; }
        public string frKey { get; set; }
    }
}
