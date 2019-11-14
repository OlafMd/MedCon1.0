using MMDocConnectMMApp.Filters;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
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
    [RoutePrefix("api/medication")]
    [AuthenticationFilter]
    public class MedicationController : BaseApiController
    {
        string connectionString;
        IMedicationDataServices medicationDataService;
        public MedicationController()
        {
            medicationDataService = new MedicationDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
            
        }

        #region GET
        [Route("getMedicationforMedicationID")]
        [HttpGet]
        public HttpResponseMessage GetMedicationforMedicationID([FromUri]Guid ID)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            MedicationApiModel medicationApi = new MedicationApiModel();
            MedicationModel medication = medicationDataService.GetMedicationforMedicationID(ID, connectionString, SessionToken, out transaction);
            medicationApi.medication = medication;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, medicationApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);

        }
        #endregion

        #region POST
        [Route("SaveMedication")]
        [HttpPost]
        public HttpResponseMessage SaveMedication(MedicationModel medication)
        {

            TransactionalInformation transaction = new TransactionalInformation();

            medicationDataService.SaveMedication(medication, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, "ok");

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }
        [Route("GetMedications")]
        [HttpPost]
        public HttpResponseMessage GetMedications(MedicationSort objSort)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            MedicationApiModel medicationApi = new MedicationApiModel();
            List<MedicationModel> medications = medicationDataService.GetMedications(objSort, connectionString, SessionToken, out transaction);
            medicationApi.medications = medications;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, medicationApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }


        #endregion        
    }
}