
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMApp.Filters;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppServices;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MMDocConnectMMApp.Controllers
{

    [RoutePrefix("api/treatment")]
    [AuthenticationFilter]
    public class TreatmentController : BaseApiController
    {

        string connectionString;
        ITreatmentDataService treatmentDataService;
        public TreatmentController()
        {
            treatmentDataService = new TreatmentDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;

        }

        #region GET
        #endregion

        #region POST
        [Route("GetSubmittedCases")]
        [HttpPost]
        public HttpResponseMessage GetSubmittedCases(ElasticParameterObject sort_parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var casesList = treatmentDataService.GetSubmittedCasesList(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, casesList);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetResponseFromHIP")]
        [HttpPost]
        public HttpResponseMessage GetSubmittedCases(Parameter param)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            string response = treatmentDataService.GetResponseFromHIP(param.id, param.secondary_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }


        [Route("SubmitCaseForErrorCorrection")]
        [HttpPost]
        public HttpResponseMessage SubmitCaseForErrorCorrection(Parameter param)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            Guid[] response = treatmentDataService.SubmitCaseForErrorCorrection(param.id, param.secondary_id, param.text, param.action_type, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetEligibleCases")]
        [HttpPost]
        public HttpResponseMessage GetEligibleCases(CaseStatusChangeParameter param)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = treatmentDataService.GetEligibleCases(
                param.all_selected,
                param.selected_action_ids,
                param.deselected_action_ids,
                param.filter_by,
                (CaseStatus?)param.case_status,
                connectionString,
                SessionToken,
                out transaction
            );

            if (transaction.ReturnStatus)
                return Request.CreateResponse<Guid[]>(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest, transaction);
        }

        [Route("ChangeCaseStatus")]
        [HttpPost]
        public HttpResponseMessage ChangeCaseStatus(CaseStatusChangeParameter param)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = treatmentDataService.ChangeCaseStatus(param.all_selected,
                param.selected_action_ids, param.deselected_action_ids, param.filter_by, param.eligible_cases_for_status_edit, param.is_management_fee_waived,
                (CaseStatus?)param.case_status, param.case_status_ground, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<Guid[]>(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetSubmittedCasesCount")]
        [HttpPost]
        public HttpResponseMessage GetSubmittedCasesCount(ElasticParameterObject parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var result = treatmentDataService.GetSubmittedCasesCount(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }
        #endregion
    }
}