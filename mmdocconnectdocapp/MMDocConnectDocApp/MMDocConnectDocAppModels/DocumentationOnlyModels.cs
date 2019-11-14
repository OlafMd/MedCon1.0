using MMDocConnectDocApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class DocumentationOnlyOpAndOctData
    {
        public Guid patient_id { get; set; }

        public DocumentationOnlyEye left_eye { get; set; }

        public DocumentationOnlyEye right_eye { get; set; }
    }

    public class DocumentationOnlyEye
    {
        private DateTime _treatment_year_start_date;

        public DateTime treatment_year_start_date
        {
            get
            {
                return _treatment_year_start_date.ToLocalTime();
            }
            set
            {
                _treatment_year_start_date = value.ToUniversalTime();
            }
        }

        public IEnumerable<DocumentationOnlyOct> octs { get; set; }

        public IEnumerable<DocumentationOnlyOp> ops { get; set; }

        public DocumentationOnlyOp latest_ivom { get; set; }

        public DocumentationOnlyEye()
        {
            octs = new List<DocumentationOnlyOct>();
            ops = new List<DocumentationOnlyOp>();
        }
    }

    public class DocumentationOnlyOct : DocumentationOnlyEntity
    {

    }

    public class DocumentationOnlyOp : DocumentationOnlyEntity
    {
        public Guid drug_id { get; set; }

        public Guid diagnose_id { get; set; }

        public bool is_regular_op { get; set; }
    }

    public abstract class DocumentationOnlyEntity
    {
        private DateTime _date;

        public Guid id { get; set; }

        public DateTime date
        {
            get
            {
                return _date.ToLocalTime();
            }
            set
            {
                _date = value.ToUniversalTime();
            }
        }

        public AutocompleteModel doctor { get; set; }
    }
}
