using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDocApp.Filters;
using MMDocConnectDocApp.Models;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectDocAppServices;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MMDocConnectDocApp.Controllers
{
    [RoutePrefix("api/aftercare")]
    [AuthenticationFilter]
    public class AftercareController : BaseApiController
    {
        string connectionString;
        IAftercareDataService aftercareDataService;
        IValidationService validationService;

        public AftercareController()
        {
            aftercareDataService = new AftercareDataService();
            validationService = new ValidationService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        #region GET
        [Route("GetACDoctorsAndPractices")]
        [HttpGet]
        public HttpResponseMessage GetACDoctorsAndPractices([FromUri]string search_criteria)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var doctors_practices = aftercareDataService.GetACDoctorsAndPracticesForAutocomplete( search_criteria, SessionToken, connectionString, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, new Autocomplete_Data<ACAutocompleteModel>() { items = new ACAutocompleteModel[] { doctors_practices } });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
        
        [Route("GetACIDForCaseID")]
        [HttpGet]
        public HttpResponseMessage GetACIDForCaseID([FromUri]Guid case_id)
        {
            TransactionalInformation transaction = new TransactionalInformation();
                                                                
            var aftercare_id = aftercareDataService.GetACIDForCaseID( case_id, SessionToken, connectionString, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, aftercare_id);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        #endregion

        #region POST
        [Route("GetAftercares")]
        [HttpPost]
        public HttpResponseMessage GetAftercares(ElasticParameterObject sort_parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var aftercares = aftercareDataService.GetAllAftercares(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, aftercares);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("SubmitAftercare")]
        [HttpPost]
        public HttpResponseMessage SubmitAftercare(SubmitCaseParameter aftercare_param)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var reportUrl = aftercareDataService.SubmitAftercare(aftercare_param.authorizing_doctor_id, aftercare_param.case_id, aftercare_param.date_of_performed_action, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, reportUrl);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateConsents")]
        [HttpPost]
        public HttpResponseMessage ValidateConsents(Parameter param)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            List<ConsentValidationResponse> response = validationService.ValidateDoctorsAndPatientsParticipationConsent(param.case_id, false, false, param.id, param.secondary_id, param.tertiary_id, param.date_string, param.date, param.diagnose_id, param.drug_id, connectionString, SessionToken, out transaction, true);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<List<ConsentValidationResponse>>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateAftercareDate")]
        [HttpPost]
        public HttpResponseMessage ValidateAftercareDate(MultiEditParameter param)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var response = aftercareDataService.ValidateAftercareDateForMultiEdit(param.ids_to_edit, param.ids_to_deselect, param.date_string, param.all_selected, param.flag, param.filter_by, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<Guid[]>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetAftercaresCount")]
        [HttpPost]
        public HttpResponseMessage GetAftercaresCount(ElasticParameterObject parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var result = aftercareDataService.GetAftercaresCount(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateConsentsMulti")]
        [HttpPost]
        public HttpResponseMessage ValidateConsentsMulti(Parameter param)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var response = validationService.ValidateDoctorsAndPatientsParticipationConsentMulti(
                param.authorizing_doctor_id,
                false,
                param.type,
                param.flag,
                param.multi_ids,
                param.deselected_ids,
                param.secondary_flag,
                param.id,
                param.secondary_id,
                param.filter_by,
                param.date_string,
                connectionString,
                SessionToken,
                out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<Guid[]>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("MultiEditAftercare")]
        [HttpPost]
        public HttpResponseMessage MultiEditAftercare(MultiEditParameter parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var result = aftercareDataService.MultiEditSubmitAftercare(
                parameter.authorizing_doctor_id,
                parameter.ids_to_edit,
                parameter.ids_to_submit,
                parameter.ids_to_deselect,
                parameter.all_selected,
                parameter.date_string,
                parameter.secondary_id,
                parameter.flag,
                parameter.filter_by,
                connectionString,
                SessionToken,
                out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("InitiateMultiSubmit")]
        [HttpPost]
        public HttpResponseMessage InitiateMultiSubmit(MultiEditParameter parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var result = aftercareDataService.InitiateAftercareMultiSubmit(parameter.ids_to_submit,
                parameter.ids_to_deselect,
                parameter.all_selected,
                parameter.filter_by,
                parameter.sort_by,
                parameter.isAsc,
                connectionString,
                SessionToken,
                out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion

        #region DELETE


        #endregion

        #region VALIDATION
        [Route("CheckIfAlreadyExistAftercare")]
        [HttpPost]
        public HttpResponseMessage CheckIfAlreadyExistAftercare(MultiEditParameter param)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var response = aftercareDataService.CheckIfAlreadyExistAftercare(param.ids_to_submit, param.date_string, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<MulitiSubmitValidation>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion

    }
}
