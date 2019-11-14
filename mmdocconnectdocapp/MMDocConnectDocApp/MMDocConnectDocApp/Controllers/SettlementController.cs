using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDocApp.Filters;
using MMDocConnectDocApp.Models;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectDocAppServices;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MMDocConnectDocApp.Controllers
{
    [RoutePrefix("api/settlement")]
    [AuthenticationFilter]
    public class SettlementController : BaseApiController
    {
        ISettlementDataService settlementDataService;
        IValidationService validationService;
        string connectionString;
        public SettlementController()
        {
            settlementDataService = new SettlementDataService();
            validationService = new ValidationService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }
        #region GET
        [Route("DownloadAllNonDowloadedReports")]
        [HttpGet]
        public HttpResponseMessage DownloadAllNonDowloadedReports()
        {
            var transaction = new TransactionalInformation();
            var response = settlementDataService.DownloadAllNonDowloadedReports(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("IsDownloadAllNonDownloadedReportsVisible")]
        [HttpGet]
        public HttpResponseMessage IsDownloadAllNonDownloadedReportsVisible()
        {
            var transaction = new TransactionalInformation();
            var response = settlementDataService.IsDownloadAllNonDownloadedReportsVisible(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
        #endregion

        #region POST
        [Route("getSettlementItems")]
        [HttpPost]
        public HttpResponseMessage SettlementItems(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();
            var settlementAPi = new SettlementApiModel();
            sort_parameter.page_size = 100;

            var dataSettlement = settlementDataService.getSettlementData(sort_parameter, connectionString, SessionToken, out transaction);
            settlementAPi.settlement = dataSettlement;

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, settlementAPi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetFS6CommentForDoctor")]
        [HttpPost]
        public HttpResponseMessage GetFS6CommentForDoctor(Parameter param)
        {
            var transaction = new TransactionalInformation();
            var settlementAPi = new SettlementApiModel();
            var response = settlementDataService.GetFS6CommentForDoctor(param.id, param.secondary_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateConsents")]
        [HttpPost]
        public HttpResponseMessage ValidateConsents(Parameter param)
        {
            var transaction = new TransactionalInformation();

            var response = validationService.ValidateDoctorsAndPatientsParticipationConsent(param.case_id, param.flag, true,
                param.id, param.secondary_id, param.tertiary_id, param.date_string, param.date, param.diagnose_id, param.drug_id, connectionString, SessionToken, out transaction, true);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<List<ConsentValidationResponse>>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("DownloadSubmissionReport")]
        [HttpPost]
        public HttpResponseMessage DownloadSubmissionReport(SubmissionReportParameter parameter)
        {
            var transaction = new TransactionalInformation();
            var response = settlementDataService.DownloadSubmissionReport(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateConsentsMulti")]
        [HttpPost]
        public HttpResponseMessage ValidateConsentsMulti(Parameter param)
        {
            var transaction = new TransactionalInformation();
            var response = validationService.ValidateDoctorsAndPatientsParticipationConsentMulti(
                param.authorizing_doctor_id,
                true,
                param.type,
                param.flag,
                param.multi_ids,
                param.deselected_ids,
                param.secondary_flag,
                param.id,
                param.secondary_id,
                param.filter_by,
                "",
                connectionString,
                SessionToken,
                out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<Guid[]>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }



        [Route("multiEditSaveCase")]
        [HttpPost]
        public HttpResponseMessage multiEditSaveCase(MultiEditSettlement parameter)
        {
            var transaction = new TransactionalInformation();
            var settlementMultiEdit = new SettlementApiModelMultiEdit();
            var response = settlementDataService.MultiEditSaveCase(parameter, connectionString, SessionToken, out transaction);
            settlementMultiEdit.settlementChanged = response;

            if (transaction.ReturnStatus)
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, settlementMultiEdit);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("ConfirmMultiEditSaveCase")]
        [HttpPost]
        public HttpResponseMessage ConfirmMultiEditSaveCase(MultiEditSettlement parameter)
        {
            var transaction = new TransactionalInformation();
            var settlementMultiEdit = new SettlementApiModelMultiEdit();

            var response = settlementDataService.ConfirmMultiEditSaveCase(parameter, connectionString, SessionToken, out transaction);
            settlementMultiEdit.settlementChanged = response;
            if (transaction.ReturnStatus)
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, settlementMultiEdit);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("getSettlementitemsForMultiSelect")]
        [HttpPost]
        public HttpResponseMessage getSettlementitemsForMultiSelect(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();
            var settlementAPi = new SettlementApiModel();
            var dataSettlement = settlementDataService.getSettlementData(sort_parameter, connectionString, SessionToken, out transaction);
            settlementAPi.settlement = dataSettlement;

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, settlementAPi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CancelCase")]
        [HttpPost]
        public HttpResponseMessage CancelCase(CancelCaseParameterOnSettlementPage case_param)
        {
            var transaction = new TransactionalInformation();
            settlementDataService.CancelCase(case_param.case_id, case_param.planned_action_id, case_param.reasonForCancelation, case_param.authorizing_doctor_id, case_param.caseType, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("SubmitCase")]
        [HttpPost]
        public HttpResponseMessage SubmitCase(SubmitCaseParameter case_param)
        {
            var transaction = new TransactionalInformation();
            var submitted = settlementDataService.SubmitCase(case_param.datetime_of_performed_action, case_param.is_treatment, case_param.case_id, case_param.planned_action_id, case_param.authorizing_doctor_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, submitted);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CreateCase")]
        [HttpPost]
        public HttpResponseMessage CreateCase(Case new_case)
        {
            var transaction = new TransactionalInformation();
            var new_case_id = settlementDataService.CreateCase(new_case, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, new_case_id);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("EditAftercareInErrorCorrectionState")]
        [HttpPost]
        public HttpResponseMessage CreateCase(ErrorCorrectionAftercare aftercare)
        {
            var transaction = new TransactionalInformation();
            var new_case_id = settlementDataService.EditAftercareInErrorCorrectionState(aftercare, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, new_case_id);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }



        [Route("GetCaseDetails")]
        [HttpPost]
        public HttpResponseMessage GetCaseDetails(Case case_param)
        {
            var transaction = new TransactionalInformation();
            var case_details = settlementDataService.GetCaseDetailsforCaseID(case_param.case_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, case_details);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateAndSubmitPreexaminationData")]
        [HttpPost]
        public HttpResponseMessage ValidateAndSubmitPreexaminationData(Preexamination parameter)
        {
            var transaction = new TransactionalInformation();
            var response = new PreexaminationDataService().ValidateAndSubmitPreexaminationData(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        #endregion
    }
}