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
    [RoutePrefix("api/patient")]
    [AuthenticationFilter]
    public class PatientController : BaseApiController
    {
        string connectionString;
        IPatientDataServices patientDataService;

        public PatientController()
        {
            patientDataService = new PatientDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;

        }

        #region GET
        [Route("GetIsPatientHipOnAnOctContract")]
        [HttpGet]
        public HttpResponseMessage GetIsPatientHipOnAnOctContract([FromUri] Guid patient_id)
        {
            var transaction = new TransactionalInformation();
            var result = patientDataService.GetIsPatientHipOnAnOctContract(patient_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
        #endregion

        #region POST

        [Route("getPatients")]
        [HttpPost]
        public HttpResponseMessage GetPatients(ElasticParameterObject sort_parameter)
        {

            TransactionalInformation transaction = new TransactionalInformation();

            var patients = patientDataService.GetPatients(sort_parameter, connectionString, SessionToken, out transaction);


            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, new { patients = patients });

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("getPatientDetails")]
        [HttpGet]
        public HttpResponseMessage getPatientDetails([FromUri]Guid ID, string sort_by, bool isAsc, int start_row_index)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            PatientDetailsApiModel patientApiModel = new PatientDetailsApiModel();
            List<PatientDetailViewModelExtended> patientDetailList = new List<PatientDetailViewModelExtended>();


            var data = patientDataService.Get_PatientDetails(ID, connectionString, SessionToken, out transaction);
            patientApiModel.patient = data.patient;

            if (!transaction.ReturnStatus)
                return Request.CreateResponse<PatientDetailsApiModel>(HttpStatusCode.BadRequest, patientApiModel);

            ElasticParameterObject parameters = new ElasticParameterObject
            {
                isAsc = isAsc,
                sort_by = sort_by,
                start_row_index = start_row_index
            };
            patientDetailList = patientDataService.Get_PatientCasesAndParticipationConsents(parameters, ID, connectionString, SessionToken, out transaction);
            patientApiModel.patient_details_list = patientDetailList;
            if (!transaction.ReturnStatus)
                return Request.CreateResponse<PatientDetailsApiModel>(HttpStatusCode.BadRequest, patientApiModel);

            return Request.CreateResponse<PatientDetailsApiModel>(HttpStatusCode.OK, patientApiModel);
        }

        #endregion
    }
}