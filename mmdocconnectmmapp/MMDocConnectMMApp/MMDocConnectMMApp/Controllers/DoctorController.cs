using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMApp.Filters;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectMMAppServices;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MMDocConnectMMApp.Controllers
{

    [RoutePrefix("api/doctor")]
    [AuthenticationFilter]
    public class DoctorController : BaseApiController
    {

        string connectionString;
        IDoctorDataService docDataService;
        public DoctorController()
        {
            docDataService = new DoctorDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;            
        }

        #region GET
        [Route("GetDoctorDetails")]
        [HttpGet]
        public HttpResponseMessage GetDoctorDetails([FromUri]Guid ID)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            DoctorDetailApiModel doctoApiModel = new DoctorDetailApiModel();
            DoctorDetail doctor_detail = docDataService.GetDoctorDetails(ID, connectionString, SessionToken, out transaction);
            doctoApiModel.doctor = doctor_detail;

            if (transaction.ReturnStatus)
                return Request.CreateResponse<DoctorDetailApiModel>(HttpStatusCode.OK, doctoApiModel);

            return Request.CreateResponse(HttpStatusCode.BadRequest, transaction);
            
        }

        [Route("GetDoctorsConsentDetails")]
        [HttpGet]
        public HttpResponseMessage GetDoctorsConsentDetails([FromUri]Guid assignmentID)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = docDataService.GetDoctorsConsentDetails(assignmentID, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest, transaction);
        }



        [Route("CheckLanrForMerge")]
        [HttpGet]
        public HttpResponseMessage CheckLanrForMerge([FromUri] string lanr, [FromUri] Guid practice_id)
        {
            var transaction = new TransactionalInformation();
            var response = docDataService.CheckLanrForMerge(lanr, practice_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetPracticeDetails")]
        [HttpGet]
        public HttpResponseMessage GetPracticeDetails([FromUri]Guid ID)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            PracticeDetailApiModel practiceApiModel = new PracticeDetailApiModel();
            PracticeDetails practice_detail = docDataService.GetPracticeDetails(ID, connectionString, SessionToken, out transaction);
            practiceApiModel.practice = practice_detail;

            if (transaction.ReturnStatus)
                return Request.CreateResponse<PracticeDetailApiModel>(HttpStatusCode.OK, practiceApiModel);

            return Request.CreateResponse(HttpStatusCode.BadRequest, transaction);
            
        }



        [Route("GetAllPractices")]
        [HttpGet]
        public HttpResponseMessage GetAllPractices()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            DO_GAPR_1342[] data = docDataService.GetAllPractices(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, data);

            return Request.CreateResponse(HttpStatusCode.BadRequest, transaction);
        }

        #endregion

        #region POST
        [Route("CreatePractice")]
        [HttpPost]
        public HttpResponseMessage CreatePractice(Practice practice)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            docDataService.CreatePractice(practice, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }



        [Route("CheckLoginEmail")]
        [HttpPost]
        public HttpResponseMessage CheckLoginEmail(ValidationParameter parameter)
        {
            var transaction = new TransactionalInformation();
            var exists = docDataService.CheckLoginEmail(parameter.ID, parameter.Type, parameter.ContentToValidate, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
            {
                if (exists)
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


        [Route("CheckBsnr")]
        [HttpPost]
        public HttpResponseMessage CheckBsnr(PracticeModel Parameter)
        {
            var transaction = new TransactionalInformation();
            var exists = docDataService.CheckBsnr(Parameter.PracticeID, Parameter.BSNR, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
            {
                if (exists)
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }


        [Route("CheckLanr")]
        [HttpPost]
        public HttpResponseMessage CheckLanr(DoctorModel doctor)
        {
            var transaction = new TransactionalInformation();
            var exists = docDataService.CheckLanr(doctor.DoctorID, doctor.PracticeID, doctor.LANR, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
            {
                if (exists)
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        [Route("CreateDoctor")]
        [HttpPost]
        public HttpResponseMessage CreateDoctor(Doctor doctor)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var doctor_id = docDataService.CreateDoctor(doctor, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.Created, doctor_id);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("GetContractsForDropDown")]
        [HttpGet]
        public HttpResponseMessage GetContractsForDropDown()
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var data = docDataService.ContractsForDropDown(connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, data);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("SaveDoctorsConsent")]
        [HttpPost]
        public HttpResponseMessage SaveDoctorsConsent(DoctorContractConsent parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = docDataService.SaveDoctorsConsent(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }

        [Route("ValidateContractOverlaps")]
        [HttpPost]
        public HttpResponseMessage ValidateContractOverlaps(DoctorContractConsent parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = docDataService.ValidateContractOverlaps(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("GetDoctorPracticesList")]
        [HttpPost]
        public HttpResponseMessage GetDoctorPracticesList(ElasticParameterObject sort_parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            List<Practice_Doctors_Model> data = docDataService.GetDoctorPracticesList(sort_parameter, connectionString, SessionToken, out transaction);

            var response = Request.CreateResponse(HttpStatusCode.OK, data);
            return response;
        }

        [Route("MergeDoctor")]
        [HttpPost]
        public HttpResponseMessage MergeDoctor(MergeDoctorParameter merge_doctor)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = docDataService.MergeDoctor(merge_doctor.doctor_id, merge_doctor.temporary_doctor_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


        [Route("GetBankAccountInfoforPracticeID")]
        [HttpPost]
        public HttpResponseMessage GetBankAccountInfoforPracticeID(Doctor doctor)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            P_DO_GBAfPR_1524 parameter = new P_DO_GBAfPR_1524();
            parameter.PracticeID = doctor.PracticeID;
            DO_GBAfPR_1524[] data = docDataService.GetBankAccountInfoforPracticeID(parameter, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, data);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("GetDoctorsforPracticeID")]
        [HttpPost]
        public HttpResponseMessage GetDoctorsforPracticeID(Practice_Parameter Parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            List<Practice_Doctors_Model> data = docDataService.GetDoctorsForPracticeID(Parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, data);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }


        [Route("GetContractsforDoctorID")]
        [HttpPost]
        public HttpResponseMessage GetContractsforDoctorID(objDoc ObjDoc)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            ContractsApiModel contractModelApi = new ContractsApiModel();
            List<objDoc> data = docDataService.Get_Contracts_for_DoctorID(ObjDoc, connectionString, SessionToken, out transaction);
            data.OrderBy(c => c.ContractName).ThenBy(n => n.ValidFrom);
            contractModelApi.Contracts = data;

            if (transaction.ReturnStatus)
                return Request.CreateResponse<ContractsApiModel>(HttpStatusCode.OK, contractModelApi);

            var badResponse = Request.CreateResponse<ContractsApiModel>(HttpStatusCode.BadRequest, contractModelApi);
            return badResponse;

        }

        [Route("IBanValidation")]
        [HttpPost]
        public HttpResponseMessage IBanValidation(IBAN_Parameter objiban)
        {
            var transaction = new TransactionalInformation();
            BicIbanApiModel BicIBan = new BicIbanApiModel();
            List<Bic_Iban_Codes> data = docDataService.CheckIban(objiban, connectionString, SessionToken, out transaction);
            BicIBan.BicIban = data;
            if (transaction.ReturnStatus)
                return Request.CreateResponse<BicIbanApiModel>(HttpStatusCode.OK, BicIBan);

            var badResponse = Request.CreateResponse<BicIbanApiModel>(HttpStatusCode.BadRequest, BicIBan);
            return badResponse;

        }
        [Route("BicBankValidation")]
        [HttpPost]
        public HttpResponseMessage BicBankValidation(Bic_Parameter objBic)
        {
            var transaction = new TransactionalInformation();
            BicIbanApiModel BicIBan = new BicIbanApiModel();
            List<Bic_Iban_Codes> data = docDataService.CheckBicBank(objBic, connectionString, SessionToken, out transaction);
            BicIBan.BicIban = data;
            if (transaction.ReturnStatus)
                return Request.CreateResponse<BicIbanApiModel>(HttpStatusCode.OK, BicIBan);

            var badResponse = Request.CreateResponse<BicIbanApiModel>(HttpStatusCode.BadRequest, BicIBan);
            return badResponse;

        }



        #endregion


    }
}