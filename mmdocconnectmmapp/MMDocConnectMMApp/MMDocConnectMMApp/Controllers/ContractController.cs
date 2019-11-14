using BOp.Providers;
using MMDocConnectMMApp.Filters;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectMMAppServices;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace MMDocConnectMMApp.Controllers
{
    [RoutePrefix("api/contract")]
    public class ContractController : BaseApiController
    {
        IContractDataService ctrDataService;
        string connectionString;

        public ContractController()
        {
            ctrDataService = new ContractDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        #region GET
        [Route("GetAllContracts")]
        [HttpGet]
        public HttpResponseMessage GetAllContracts([FromUri]string sort_by, [FromUri]bool ascending)
        {
            var transaction = new TransactionalInformation();
            var response = ctrDataService.GetAllContracts(sort_by, ascending, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("GetContractDetails")]
        [HttpGet]
        public HttpResponseMessage GetContractDetails([FromUri]Guid id)
        {
            var transaction = new TransactionalInformation();
            var response = ctrDataService.GetContractDetails(id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("GetDrugsForSearchCriteria")]
        [HttpGet]
        public HttpResponseMessage GetDrugsForSearchCriteria([FromUri]string search_criteria)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var response = ctrDataService.GetDrugsForSearchCriteria(search_criteria, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, new { items = response });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetDoctorsForSearchCriteria")]
        [HttpGet]
        public HttpResponseMessage GetDoctorsForSearchCriteria([FromUri]string search_criteria)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var response = ctrDataService.GetDoctorsForSearchCriteria(search_criteria, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, new { items = response });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetDiagnosesForSearchCriteria")]
        [HttpGet]
        public HttpResponseMessage GetDiagnosesForSearchCriteria([FromUri]string search_criteria)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var response = ctrDataService.GetDiagnosesForSearchCriteria(search_criteria, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, new { items = response });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetHIPsForSearchCriteria")]
        [HttpGet]
        public HttpResponseMessage GetHIPsForSearchCriteria([FromUri]string search_criteria)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var response = ctrDataService.GetHIPsForSearchCriteria(search_criteria, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, new { items = response });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetConsentStartDate")]
        [HttpPost]
        public HttpResponseMessage GetConsentStartDate(ConsentStartDateParameter parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var doctor_id = Guid.Empty;
            if (Guid.TryParse(parameter.doctor_id, out doctor_id))
            {
                var response = ctrDataService.GetConsentStartDate(parameter.contract_id, doctor_id, connectionString, SessionToken, out transaction);

                if (transaction.ReturnStatus)
                    return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, DateTime.MinValue);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        #endregion

        #region POST
        [Route("SaveContract")]
        [HttpPost]
        public HttpResponseMessage SaveContract(ContractViewModel contract)
        {
            var transaction = new TransactionalInformation();
            var response = ctrDataService.SaveContract(contract, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("ValidateContractOverlaps")]
        [HttpPost]
        public HttpResponseMessage ValidateContractOverlaps(DoctorContractConsent parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = ctrDataService.ValidateContractOverlaps(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("CopyContract")]
        [HttpPost]
        public HttpResponseMessage CopyContract(ContractViewModel contract)
        {
            var transaction = new TransactionalInformation();
            var response = ctrDataService.CopyContract(contract.contract_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        #endregion
    }
}