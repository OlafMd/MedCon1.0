using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    public class GposDrugDiagnose
    {
        public List<Guid> DrugIds { get; set; }

        public List<Guid> DiagnoseIds { get; set; }

        public GposDrugDiagnose()
        {
            DrugIds = new List<Guid>();
            DiagnoseIds = new List<Guid>();
        }
    }
}
