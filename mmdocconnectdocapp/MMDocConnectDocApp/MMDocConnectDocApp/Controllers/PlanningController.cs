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
    [RoutePrefix("api/planning")]
    [AuthenticationFilter]
    public class PlanningController : BaseApiController
    {
        string connectionString;
        IPlanningDataService planningService;
        IValidationService validationService;
        IMainData mainDataService;
        private static object lockobj = new object();

        public PlanningController()
        {
            planningService = new PlanningDataService();
            validationService = new ValidationService();
            mainDataService = new MainDataService();

            connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        #region GET
        [Route("GetIsPatientHipOnAnOctContract")]
        [HttpGet]
        public HttpResponseMessage GetIsPatientHipOnAnOctContract([FromUri] Guid patient_id)
        {
            var transaction = new TransactionalInformation();
            var result = planningService.GetIsPatientHipOnAnOctContract(patient_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetMissingIvomCaseExists")]
        [HttpGet]
        public HttpResponseMessage GetMissingIvomCaseExists([FromUri] Guid patient_id, [FromUri] bool is_left_eye)
        {
            var transaction = new TransactionalInformation();
            var result = planningService.MissingIvomCaseExists(patient_id, is_left_eye, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("GetIsPatientFeeWaived")]
        [HttpGet]
        public HttpResponseMessage GetIsPatientFeeWaived([FromUri] Guid patient_id, [FromUri] string date)
        {
            var transaction = new TransactionalInformation();
            var result = planningService.GetIsPatientFeeWaived(patient_id, date, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetCaseHasOctPending")]
        [HttpGet]
        public HttpResponseMessage CaseHasOctPending([FromUri] Guid case_id)
        {
            var transaction = new TransactionalInformation();
            var result = planningService.CaseHasOctPending(case_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetIsOrderSubmitted")]
        [HttpGet]
        public HttpResponseMessage GetIsOrderSubmitted([FromUri] Guid case_id)
        {
            var transaction = new TransactionalInformation();
            var result = planningService.IsOrderSubmitted(case_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetPracticeDefaultSettings")]
        [HttpGet]
        public HttpResponseMessage GetPracticeDefaultSettings()
        {
            var transaction = new TransactionalInformation();
            PracticeDefaultSettings settings = planningService.GetPracticeDefaultSettings(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, settings);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetPatientsForAutocomplete")]
        [HttpGet]
        public HttpResponseMessage GetPatientsForAutocomplete([FromUri]string search_criteria)
        {
            var transaction = new TransactionalInformation();

            var patients = planningService.GetPatientsForAutocomplete(search_criteria, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, new Autocomplete_Data<AutocompleteModel>() { items = patients.ToArray() });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetACDoctorsAndPractices")]
        [HttpGet]
        public HttpResponseMessage GetACDoctorsAndPractices([FromUri]string search_criteria)
        {
            var transaction = new TransactionalInformation();

            var doctors_practices = planningService.GetACDoctorsAndPracticesForAutocomplete(connectionString, search_criteria, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, new Autocomplete_Data<ACAutocompleteModel>() { items = new ACAutocompleteModel[] { doctors_practices } });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOctDoctors")]
        [HttpGet]
        public HttpResponseMessage GetOctDoctors([FromUri]string search_criteria, [FromUri]Guid? patient_id = null, [FromUri]string date = null)
        {
            var transaction = new TransactionalInformation();

            var doctors = planningService.GetOctDoctorsForAutocomplete(connectionString, search_criteria, patient_id.HasValue ? patient_id.Value : Guid.Empty, date, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, new Autocomplete_Data<ACAutocompleteModel>() { items = new ACAutocompleteModel[] { doctors } });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetAllDrugs")]
        [HttpGet]
        public HttpResponseMessage GetAllDrugs()
        {
            var transaction = new TransactionalInformation();

            var drugs = planningService.GetAllDrugsForDropdown(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, new Autocomplete_Data<AutocompleteModel>() { items = drugs.ToArray() });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetAllDiagnoses")]
        [HttpGet]
        public HttpResponseMessage GetAllDiagnoses([FromUri]Guid patient_id)
        {
            var transaction = new TransactionalInformation();
            var diagnoses = planningService.GetAllDiagnosesForDropdown(patient_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.OK, new Autocomplete_Data<AutocompleteModel>() { items = diagnoses.ToArray() });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetContractList")]
        [HttpGet]
        public HttpResponseMessage GetContractList([FromUri] Guid patient_id)
        {
            var transaction = new TransactionalInformation();
            var contract_list = planningService.GetContractList(patient_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, contract_list);


            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        #endregion

        #region POST
        [Route("CreateCase")]
        [HttpPost]
        public HttpResponseMessage CreateCase(Case new_case)
        {
            var transaction = new TransactionalInformation();

            lock (lockobj)
            {
                var new_case_id = planningService.CreateCase(new_case, connectionString, SessionToken, out transaction);

                if (transaction.ReturnStatus)
                    return Request.CreateResponse(HttpStatusCode.OK, new_case_id);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetWillOrderBeCancelled")]
        [HttpPost]
        public HttpResponseMessage GetWillOrderBeCancelled(Case new_case)
        {
            var transaction = new TransactionalInformation();
            var will_order_be_cancelled = planningService.WillOrderBeCancelled(new_case, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, will_order_be_cancelled);


            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetPreviousCaseDataforPatientID")]
        [HttpPost]
        public HttpResponseMessage GetPreviousCaseDataforPatientID(Case param)
        {
            var transaction = new TransactionalInformation();

            var case_data = planningService.GetPreviousCaseDataforPatientID(param.patient_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, case_data);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetCases")]
        [HttpPost]
        public HttpResponseMessage GetCases(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();

            var cases = planningService.GetAllCases(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, cases);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("VerifyTreatmentEligibility")]
        [HttpPost]
        public HttpResponseMessage VerifyTreatmentEligibility(Case param)
        {
            var transaction = new TransactionalInformation();

            var treatment_eligiblity = planningService.VerifyTreatmentEligibility(param.drug_id, param.patient_id, param.treatment_date, param.is_resubmit, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, treatment_eligiblity);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetCaseDetails")]
        [HttpPost]
        public HttpResponseMessage GetCaseDetails(Case case_param)
        {
            var transaction = new TransactionalInformation();

            var case_details = planningService.GetCaseDetailsforCaseID(case_param.case_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, case_details);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("SubmitCase")]
        [HttpPost]
        public HttpResponseMessage SubmitCase(SubmitCaseParameter case_param)
        {
            var transaction = new TransactionalInformation();

            lock (lockobj)
            {
                var reportUrl = planningService.SubmitCase(case_param.case_id, case_param.authorizing_doctor_id, connectionString, SessionToken, out transaction);

                if (transaction.ReturnStatus)
                    return Request.CreateResponse(HttpStatusCode.OK, reportUrl);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CancelCase")]
        [HttpPost]
        public HttpResponseMessage CancelCase(CancelCaseParameter case_param)
        {
            var transaction = new TransactionalInformation();

            var cancelled_case_id = planningService.CancelCase(case_param.case_id, case_param.cancel_treatment, case_param.cancel_drug_order, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, cancelled_case_id);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetCasesCount")]
        [HttpPost]
        public HttpResponseMessage GetCasesCount(ElasticParameterObject parameter)
        {
            var transaction = new TransactionalInformation();
            var result = planningService.GetCasesCount(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetDiagnosisIDForNameAndPatient")]
        [HttpGet]
        public HttpResponseMessage GetDiagnosisIDForNameAndPatient([FromUri]Guid patient_id, [FromUri]String diagnosis_name)
        {
            var transaction = new TransactionalInformation();
            var diagnosis_id = planningService.GetDiagnosisIDForNameAndPatient(patient_id, diagnosis_name, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, diagnosis_id);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetDrugIDForName")]
        [HttpGet]
        public HttpResponseMessage GetDrugIDForName([FromUri]String drug_name)
        {
            var transaction = new TransactionalInformation();

            var drug_id = planningService.GetDrugIDForName(drug_name, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, drug_id);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("MultiEditCase")]
        [HttpPost]
        public HttpResponseMessage MultiEditCase(MultiEditParameter parameter)
        {
            var transaction = new TransactionalInformation();

            var result = planningService.MultiEditCase(
                parameter.authorizing_doctor_id,
                parameter.ids_to_edit,
                parameter.ids_to_submit,
                parameter.ids_to_deselect,
                parameter.all_selected,
                parameter.primary_id,
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
            var transaction = new TransactionalInformation();
            var result = planningService.InitiateCaseMultiSubmit(parameter.ids_to_submit,
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

        [Route("ValidateConsents")]
        [HttpPost]
        public HttpResponseMessage ValidateConsents(Parameter param)
        {
            var transaction = new TransactionalInformation();

            List<ConsentValidationResponse> response = validationService.ValidateDoctorsAndPatientsParticipationConsent(param.case_id, true, true, param.id, param.secondary_id, param.tertiary_id, param.date_string, param.date, param.diagnose_id, param.drug_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<List<ConsentValidationResponse>>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("CreateTemporaryAftercareDoctor")]
        [HttpPost]
        public HttpResponseMessage CreateTemporaryAftercareDoctor(TemporaryAftercareDoctor param)
        {
            var transaction = new TransactionalInformation();

            var response = planningService.CreateTemporaryAftercareDoctor(param.name, param.street, param.house_number, param.zip, param.city, param.phone, param.fax, param.email, param.comment, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
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

        [Route("CheckIfAlreadyExistTreatment")]
        [HttpPost]
        public HttpResponseMessage CheckIfAlreadyExistTreatment(Case cas)
        {
            var transaction = new TransactionalInformation();

            var response = planningService.CheckIfAlreadyExistTreatment(cas.case_id, cas.patient_id, cas.treatment_date, cas.is_left_eye, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("SaveOrderMessageVisability")]
        [HttpPost]
        public HttpResponseMessage SaveOrderMessageVisability()
        {
            var transaction = new TransactionalInformation();

            planningService.SaveOrderMessageVisability(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("CanShowOrderMessage")]
        [HttpGet]
        public HttpResponseMessage CanShowOrderMessage()
        {
            var transaction = new TransactionalInformation();

            var result = planningService.CanShowOrderMessage(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CheckIfAlreadyExistAnyTreatment")]
        [HttpPost]
        public HttpResponseMessage CheckIfAlreadyExistAnyTreatment(MultiEditParameter parameter)
        {
            var transaction = new TransactionalInformation();

            var result = planningService.CheckIfAlreadyExistAnyTreatment(parameter.ids_to_submit, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<MulitiSubmitValidation>(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CheckIfOCTCanBeSubmitted")]
        [HttpPost]
        public HttpResponseMessage CheckIfOCTCanBeSubmitted(Case cas)
        {
            var transaction = new TransactionalInformation();
            var oct_doctor_id = cas.oct_doctor_id ?? Guid.Empty;

            var response = planningService.CheckIfOCTCanBeSubmitted(cas.case_id, oct_doctor_id, cas.patient_id, cas.treatment_date, cas.diagnose_id,
                cas.drug_id, cas.is_left_eye, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<OCTValidation>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CanSaveCaseAfterChangeLocalization")]
        [HttpPost]
        public HttpResponseMessage CanSaveCaseAfterChangeLocalization(Case cas)
        {
            var transaction = new TransactionalInformation();

            var response = planningService.CanSaveCaseAfterChangeLocalization(cas.case_id, cas.patient_id, cas.is_left_eye, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<bool>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion

        #region DELETE


        #endregion
    }
}
