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
    [RoutePrefix("api/oct")]
    [AuthenticationFilter]
    public class OctController : BaseApiController
    {
        private IOctService octService;
        private IAftercareDataService aftercareDataService;

        private string connectionString;

        public OctController()
        {
            octService = new OctService();
            aftercareDataService = new AftercareDataService();
            connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        [Route("CheckIsSameOctDoctor")]
        [HttpGet]
        public HttpResponseMessage CheckIsSameOctDoctor([FromUri] Guid oct_doctor_id, [FromUri] Guid patient_id, [FromUri] bool is_left_eye, [FromUri] string treatment_date)
        {
            var transaction = new TransactionalInformation();
            var result = octService.CheckIsSameOctDoctor(oct_doctor_id, patient_id, is_left_eye, treatment_date, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOcts")]
        [HttpPost]
        public HttpResponseMessage GetOcts(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();
            var cases = octService.GetOcts(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, cases);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOctIDForCaseID")]
        [HttpGet]
        public HttpResponseMessage GetOctIDForCaseID([FromUri]Guid caseID)
        {
            var transaction = new TransactionalInformation();
            var octID = octService.GetOctIDForCaseID(caseID, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, octID);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOctCount")]
        [HttpPost]
        public HttpResponseMessage GetOctCount(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();
            var count = octService.GetOctCount(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, count);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateConsentsMulti")]
        [HttpPost]
        public HttpResponseMessage GetOcts(SubmitOctParameter parameter)
        {
            var transaction = new TransactionalInformation();
            var validOctIds = octService.ValidateConsentsMultiSubmit(parameter.oct_ids, parameter.date_of_performed_action, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, validOctIds);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("InitiateMultiSubmit")]
        [HttpPost]
        public HttpResponseMessage InitiateMultiSubmit(ElasticParameterObjectMultiSubmit parameter)
        {
            var transaction = new TransactionalInformation();
            var result = octService.InitiateOctMultiSubmit(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateConsents")]
        [HttpPost]
        public HttpResponseMessage ValidateConsents(Parameter param)
        {
            var transaction = new TransactionalInformation();
            var response = octService.ValidateOctSubmission(param.id, param.secondary_id, param.date, param.flag, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("SubmitOct")]
        [HttpPost]
        public HttpResponseMessage SubmitOct(SubmitOctParameter param)
        {
            var transaction = new TransactionalInformation();
            var response = octService.SubmitOct(param.oct_ids, param.date_of_performed_action, param.authorizing_doctor_id, param.is_resubmit, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ValidateOctDate")]
        [HttpPost]
        public HttpResponseMessage ValidateOctDate(SubmitOctParameter param)
        {
            var transaction = new TransactionalInformation();
            var response = octService.ValidateOctDate(param.date_of_performed_action, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("MultiEditOct")]
        [HttpPost]
        public HttpResponseMessage MultiEditOct(MultiEditOct param)
        {
            var transaction = new TransactionalInformation();
            octService.MultiEditOct(param.oct_ids, param.date_of_performed_action, param.oct_doctor_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("RejectOct")]
        [HttpPost]
        public HttpResponseMessage RejectOct(Parameter parameter)
        {
            var transaction = new TransactionalInformation();
            octService.RejectOct(parameter.id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("ErrorCorrectionEdit")]
        [HttpPost]
        public HttpResponseMessage UpdateOct(ErrorCorrectionOctEditParameter param)
        {
            var transaction = new TransactionalInformation();
            var result = octService.EditOctForErrorCorrection(param.id, param.surgery_date_string, param.treatment_doctor_id, param.is_left_eye, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetFS6CommentForDoctor")]
        [HttpGet]
        public HttpResponseMessage GetFS6CommentForDoctor([FromUri]Guid case_id, [FromUri]Guid oct_id)
        {
            var transaction = new TransactionalInformation();
            var comment = octService.GetFS6CommentForDoctor(case_id, oct_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, comment);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("EditOctDoctor")]
        [HttpPost]
        public HttpResponseMessage EditOctDoctor(EditOctDoctorParameter param)
        {
            var transaction = new TransactionalInformation();
            octService.EditOctDoctor(param.patient_id, param.is_left_eye, param.oct_doctor_id, param.withdraw_oct, param.oct_withdrawal_date, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CheckIfAlreadyExistOCT")]
        [HttpPost]
        public HttpResponseMessage CheckIfAlreadyExistOCT(SubmitOctParameter parameter)
        {
            var transaction = new TransactionalInformation();

            var response = octService.CheckIfAlreadyExistOCT(parameter.oct_ids, parameter.date_of_performed_action, parameter.is_resubmit, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<MulitiSubmitValidation>(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
    }
}
