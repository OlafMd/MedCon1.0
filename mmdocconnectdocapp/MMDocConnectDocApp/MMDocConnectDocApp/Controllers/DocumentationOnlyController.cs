using MMDocConnectDocApp.Filters;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectDocAppServices;
using MMDocConnectUtils;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MMDocConnectDocApp.Controllers
{
    [RoutePrefix("api/documentationOnly")]
    [AuthenticationFilter]
    public class DocumentationOnlyController : BaseApiController
    {
        string connectionString;
        IDocumentationOnlyDataService documentationOnlyService;

        public DocumentationOnlyController()
        {
            documentationOnlyService = new DocumentationOnlyDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        #region GET
        [Route("GetDocumentationOnlyOpAndOctData")]
        [HttpGet]
        public HttpResponseMessage GetDocumentationOnlyOpAndOctData([FromUri]Guid patient_id)
        {
            var transaction = new TransactionalInformation();
            var response = documentationOnlyService.GetExistingDocumentationOnlyCases(patient_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("GetExistingCasesForPatient")]
        [HttpGet]
        public HttpResponseMessage GetExistingCasesForPatient([FromUri]Guid patient_id)
        {
            var transaction = new TransactionalInformation();
            var response = documentationOnlyService.GetExistingCasesForPatient(patient_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion

        #region POST
        [Route("SaveDocumentationOnlyOpAndOctData")]
        [HttpPost]
        public HttpResponseMessage SaveDocumentationOnlyOpAndOctData(DocumentationOnlyOpAndOctData parameter)
        {
            var transaction = new TransactionalInformation();
            documentationOnlyService.SaveDocumentationOnlyOpAndOctData(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion

    }
}
