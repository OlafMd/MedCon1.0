using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.PCH
{
    public enum EPrintJobStatus
    {
        SUBMITTED, 
        QUEUED, 
        PRINTING, 
        PRINTED, 
        FAILED, 
        CANCELED, 
        ABANDONED
    }
}
