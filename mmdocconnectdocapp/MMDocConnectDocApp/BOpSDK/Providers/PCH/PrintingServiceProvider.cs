using BOp.Services.Rest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BOp.Providers.PCH
{
    class PrintingServiceProvider : BaseProvider, IPrintingServiceProvider
    {
        public PrintingServiceProvider(IRestClient client) : base(client) { }

        public ResponseMessage SubmitPrintJob(PrintJobRequest job, string sessionToken)
        {
            job.SessionToken = sessionToken;
            job.Template = HttpUtility.HtmlEncode(job.Template);
            job.Data = HttpUtility.HtmlEncode(job.Data);
            job.SessionToken = sessionToken;
            var url = "api/v3/printjobs/";
            var request = new JSONRestRequest(url, Method.POST);
            request.AddBody(job);
            var response = Execute<ResponseMessage>(request, System.Net.HttpStatusCode.Created);
            return response.Data;

        }

        public void CancelPrintJob(Guid jobID, string sessionToken)
        {
            var url = string.Format("api/v3/printjobs/{0}/", jobID);
            var request = new JSONRestRequest(url, Method.DELETE);
            request.AddParameter("sessionToken", sessionToken);
            Execute<ResponseMessage>(request, System.Net.HttpStatusCode.OK);

        }

        public PrintJobStatus GetPrintJobLatestStatus(Guid jobID, string sessionToken)
        {
            var url = string.Format("api/v3/printjobs/{0}/statuses/latest", jobID);
            var request = new JSONRestRequest(url, Method.GET);
            request.AddParameter("sessionToken", sessionToken);
            var result = Execute<PrintJobStatus>(request, System.Net.HttpStatusCode.OK);
            return result.Data;
        }

        public List<PrintJobStatus>GetPrintJobStatuses(Guid jobID, string sessionToken)
        {
            var url = string.Format("api/v3/printjobs/{0}/statuses/", jobID);
            var request = new JSONRestRequest(url, Method.GET);
            request.AddParameter("sessionToken", sessionToken);
            var result = Execute<List<PrintJobStatus>>(request, System.Net.HttpStatusCode.OK);
            return result.Data;
        }

        public List<PrintingAgent> GetPrintingAgents(Guid tenantID) {
            var url = "api/v3/agents/";
            var request = new JSONRestRequest(url);
            request.AddParameter("tenant", tenantID);
            var result = Execute<List<PrintingAgent>>(request, System.Net.HttpStatusCode.OK);
            return result.Data;
        }

        public PrintingAgent GetPrintingAgent(Guid agentId)
        {
            var url = string.Format("api/v3/agents/{0}", agentId);
            var request = new JSONRestRequest(url);
            var result = Execute<PrintingAgent>(request, System.Net.HttpStatusCode.OK);
            return result.Data;
        }

        public List<LogicalPrinter> GetLogicalPrintersForTenant(Guid tenantID) {
            var url = string.Format("api/v3/logical-printers/");
            var request = new JSONRestRequest(url);
            request.AddParameter("tenant", tenantID);
            var result = Execute<List<LogicalPrinter>>(request, System.Net.HttpStatusCode.OK);
            return result.Data;
        }

        public byte[] GeneratePrintJobPreview(PrintPreviewRequest job, string sessionToken)
        {
            var request = new JSONRestRequest("api/v3/printjobs/preview", Method.POST);
            job.SessionToken = sessionToken;
            request.AddBody(job);

            var response = this.Download(request);
            return response;
        }
    }
}
