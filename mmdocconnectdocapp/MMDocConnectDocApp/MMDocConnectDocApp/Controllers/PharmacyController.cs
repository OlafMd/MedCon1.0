using MMDocConnectDocApp.Filters;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppServices;
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
    [RoutePrefix("api/pharmacy")]
    [AuthenticationFilter]
    public class PharmacyController : BaseApiController
    {
        string connectionString;
        IMainData mainDataService;
        IPharmacyDataServices pharmacyService;

        public PharmacyController()
        {
            mainDataService = new MainDataService();
            pharmacyService = new PharmacyDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        [Route("GetPharmacies")]
        [HttpGet]
        public HttpResponseMessage GetPharmacies()
        {
            var transaction = new TransactionalInformation();
            var pharmacies = pharmacyService.GetPharmacies(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, pharmacies);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }


        [Route("GetPharmacyInfoForName")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetPharmacyInfoForName([FromUri]string pharmacyName)
        {
            var transaction = new TransactionalInformation();
            var pharmacyID = pharmacyService.GetPharmacyInfoForName(pharmacyName, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, pharmacyID);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }
    }
}