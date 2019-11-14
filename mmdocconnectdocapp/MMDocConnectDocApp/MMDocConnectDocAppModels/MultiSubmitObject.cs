using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class MultiSubmitObject
    {
        public Guid id { get; set; }
        public int count { get; set; }
    }

    public class MultiSubmitOctObject
    {
        public Guid doctor_id { get; set; }

        public IEnumerable<Guid> oct_ids { get; set; }

        public int count { get; set; }
    }
}
