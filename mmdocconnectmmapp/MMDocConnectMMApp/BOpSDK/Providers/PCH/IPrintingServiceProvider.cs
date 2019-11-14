using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BOp.Providers.PCH
{
    public interface IPrintingServiceProvider
    {
        ResponseMessage SubmitPrintJob(PrintJobRequest job, string sessionToken);
        void CancelPrintJob(Guid jobId, string sessionToken);
        PrintJobStatus GetPrintJobLatestStatus(Guid jobID, string sessionToken);
        List<PrintJobStatus> GetPrintJobStatuses(Guid jobID, string sessionToken);
        List<PrintingAgent> GetPrintingAgents(Guid tenantID);
        PrintingAgent GetPrintingAgent(Guid agentId);
        List<LogicalPrinter> GetLogicalPrintersForTenant(Guid tenantID);
        byte[] GeneratePrintJobPreview(PrintPreviewRequest job, string sessionToken);
    }
}
