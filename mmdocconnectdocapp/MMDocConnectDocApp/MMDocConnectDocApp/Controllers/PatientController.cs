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
using System.Web.Http;


namespace MMDocConnectDocApp.Controllers
{
    [RoutePrefix("api/patient")]
    [AuthenticationFilter]
    public class PatientController : BaseApiController
    {
        string connectionString;
        IPatientDataService patientDataService;
        IMainData mainDataservice;

        public PatientController()
        {
            mainDataservice = new MainDataService();
            patientDataService = new PatientDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        #region GET

        [Route("CheckIfHINumberIsUnique")]
        [HttpGet]
        public HttpResponseMessage CheckIfHINumberIsUnique([FromUri] string hi_number, string first_name, string last_name, string birthday, string health_insuracne_status, int sex, string patient_id, bool isOldValidationPHIS)
        {
            var transaction = new TransactionalInformation();
            var data = new HealthInsuranceCheckApiModel();
            var patientID = string.IsNullOrEmpty(patient_id) ? Guid.Empty : new Guid(patient_id);

            var healthInsuranceCheck = patientDataService.Check_if_HINumberUnique(isOldValidationPHIS, patientID, first_name, last_name, hi_number, birthday, health_insuracne_status, sex, connectionString, SessionToken, out transaction);

            data.healthInsuranceCheck = healthInsuranceCheck;
            if (transaction.ReturnStatus)
                return Request.CreateResponse<HealthInsuranceCheckApiModel>(HttpStatusCode.OK, data);

            var badResponse = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
            return badResponse;
        }

        [Route("GetHIPsForSearchCriteria")]
        [HttpGet]
        public HttpResponseMessage GetHIPsForSearchCriteria([FromUri]string search_criteria)
        {
            var transaction = new TransactionalInformation();
            var response = patientDataService.GetHIPsForSearchCriteria(search_criteria, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, new Autocomplete_Data<ACAutocompleteModel>() { items = new ACAutocompleteModel[] { response } });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("CheckPatientFeeWaiverForYear")]
        [HttpGet]
        public HttpResponseMessage CheckPatientFeeWaiverForYear([FromUri]string issue_date, [FromUri]Guid patient_id)
        {
            var transaction = new TransactionalInformation();
            var response = patientDataService.CheckPatientFeeWaiverForYear(patient_id, issue_date, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetContractsWhereHIPisParticipating")]
        [HttpGet]
        public HttpResponseMessage GetContractsWhereHIPisParticipating([FromUri]string ik_number)
        {
            var transaction = new TransactionalInformation();

            var response = patientDataService.GetContractsWhereHIPisParticipating(ik_number, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("Get_PatientDataWithInitalData")]
        [HttpGet]
        public HttpResponseMessage Get_PatientDataWithInitalData([FromUri]Guid patientID)
        {
            var transaction = new TransactionalInformation();
            var data = new InitalPatientDataApiModel();

            if (transaction.ReturnStatus)
            {
                var dataList = patientDataService.Get_PatientDataWithInitalData(patientID, connectionString, SessionToken, out transaction);
                data.InitalPatientData = dataList;
                if (transaction.ReturnStatus)
                    return Request.CreateResponse<InitalPatientDataModel>(HttpStatusCode.OK, data.InitalPatientData);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CanChangeHIP")]
        [HttpGet]
        public HttpResponseMessage CanChangeHIP([FromUri]Guid patientID)
        {
            var transaction = new TransactionalInformation();

            var response = patientDataService.CanChangeHIP(patientID, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("GetPatients")]
        [HttpGet]
        public HttpResponseMessage GetPatients([FromUri]ElasticParameterObject parameters)
        {
            var transaction = new TransactionalInformation();
            if (transaction.ReturnStatus)
            {
                var data = patientDataService.GetPatients(parameters, connectionString, SessionToken, out transaction);
                PatientApiModel patientApiModel = new PatientApiModel();
                patientApiModel.patient = data;

                if (transaction.ReturnStatus)
                    return Request.CreateResponse<PatientApiModel>(HttpStatusCode.OK, patientApiModel);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("Get_PatientDetails")]
        [HttpGet]
        public HttpResponseMessage Get_PatientDetails([FromUri]Guid ID, string sort_by, bool isAsc, int start_row_index)
        {
            var transaction = new TransactionalInformation();
            var patientApiModel = new PatientDetailsApiModel();
            var patientDetailList = new List<PatientDetailViewModelExtended>();

            var data = patientDataService.Get_PatientDetails(ID, connectionString, SessionToken, out transaction);
            patientApiModel.patient = data.patient;
            patientApiModel.contract_list = data.ContractList;

            if (!transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);

            var parameters = new ElasticParameterObject
            {
                isAsc = isAsc,
                sort_by = sort_by,
                start_row_index = start_row_index
            };
            patientDetailList = patientDataService.Get_PatientCasesAndParticipationConsents(parameters, ID, SessionToken, connectionString, out transaction);
            patientApiModel.patient_details_list = patientDetailList;
            if (!transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);


            return Request.CreateResponse<PatientDetailsApiModel>(HttpStatusCode.OK, patientApiModel);
        }

        [Route("CheckNewKVNRValidation")]
        [HttpGet]
        public HttpResponseMessage CheckNewKVNRValidation([FromUri] string insuranceNumber)
        {
            var transaction = new TransactionalInformation();
            var isKVNRValid = patientDataService.CheckIfKVNRIsValid(insuranceNumber, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse<bool>(HttpStatusCode.OK, isKVNRValid);
            var badResponse = Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
            return badResponse;
        }

        [Route("Get_contractID")]
        [HttpGet]
        public HttpResponseMessage Get_contractID([FromUri]Guid participationID)
        {
            var transaction = new TransactionalInformation();

            var contractId = patientDataService.Get_ContractIDForParticipationID(participationID, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse<string>(HttpStatusCode.OK, contractId.ToString());

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetUsedHips")]
        [HttpGet]
        public HttpResponseMessage GetUsedHips()
        {
            var transaction = new TransactionalInformation();
            var hips = patientDataService.GetUsedHips(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, hips);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion

        #region POST

        [Route("CreatePatient")]
        [HttpPost]
        public HttpResponseMessage CreatePatient(Patient patient)
        {
            var transaction = new TransactionalInformation();

            if (transaction.ReturnStatus)
            {
                var new_patient_id = patientDataService.CreatePatient(patient, connectionString, SessionToken, out transaction);
                if (transaction.ReturnStatus)
                    return Request.CreateResponse<Guid>(HttpStatusCode.Created, new_patient_id);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("SavePatientParticipationConsent")]
        [HttpPost]
        public HttpResponseMessage SavePatientParticipationConsent(ParticipationConsent participation_consent)
        {
            var transaction = new TransactionalInformation();
            if (transaction.ReturnStatus)
            {
                patientDataService.SaveParticipationConsent(participation_consent, connectionString, SessionToken, out transaction);
                if (transaction.ReturnStatus)
                    return Request.CreateResponse<Guid>(HttpStatusCode.Created, participation_consent.patient_id);
            }
            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("SavePatientFeeWaiver")]
        [HttpPost]
        public HttpResponseMessage SavePatientFeeWaiver(PatientFeeWaiver fee_waiver)
        {
            var transaction = new TransactionalInformation();

            patientDataService.SavePatientFeeWaiver(fee_waiver.patient_id, fee_waiver.issue_date, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion

        #region DELETE
        [Route("DeletePatientFeeWaiver")]
        [HttpDelete]
        public HttpResponseMessage DeletePatientFeeWaiver([FromUri]Guid id)
        {
            var transaction = new TransactionalInformation();
            patientDataService.DeletePatientFeeWaiver(id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("DeleteDocumentationCase")]
        [HttpDelete]
        public HttpResponseMessage DeleteDocumentationCase([FromUri]Guid case_id)
        {
            var transaction = new TransactionalInformation();
            patientDataService.DeleteAutoGeneratedMissingIvom(case_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion
    }
}
