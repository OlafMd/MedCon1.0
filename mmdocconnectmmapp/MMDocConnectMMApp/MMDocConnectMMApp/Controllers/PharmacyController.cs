using MMDocConnectDBMethods.Pharmacy.Model;
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
    [RoutePrefix("api/pharmacy")]
    [AuthenticationFilter]
    public class PharmacyController : BaseApiController
    {
        string connectionString;
        IPharmacyDataServices pharmacyDataService;
        public PharmacyController()
        {
            pharmacyDataService = new PharmacyDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }
        #region SavePharmacy
        [Route("SavePharmacy")]
        [HttpPost]
        public HttpResponseMessage SavePharmacy(Pharmacy pharmacy)
        {
            var transaction = new TransactionalInformation();
            pharmacyDataService.SavePharmacy(pharmacy, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }
        #endregion

        #region GetPharmacies
        [Route("GetPharmacies")]
        [HttpPost]
        public HttpResponseMessage GetMedications(SortPharmacy sortParameters)
        {
            var transaction = new TransactionalInformation();
            var pharmacies = pharmacyDataService.GetPharmacies(sortParameters, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, pharmacies);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }
        #endregion

        #region DeletePharmacy
        [Route("DeletePharmacy")]
        [HttpPost]
        public HttpResponseMessage DeletePharmacy(DeletePharmacy parameters)
        {
            var transaction = new TransactionalInformation();
            var isDeleted = pharmacyDataService.DeletePharmacy(parameters.pharmacyID, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, isDeleted);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }
        #endregion
    }   
}