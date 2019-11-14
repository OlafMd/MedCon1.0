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
    [RoutePrefix("api/doctor")]
    public class DoctorController : BaseApiController
    {
        IDoctorDataService doctorService;
        IMainData mainDataservice;
        string connectionString;

        public DoctorController()
        {
            doctorService = new DoctorDataService();
            mainDataservice = new MainDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        [Route("GetDoctorInformation")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetDoctorInformation()
        {
            var transaction = new TransactionalInformation();
            var response = doctorService.GetDoctorInformation(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetDoctorsFromDifferentPractice")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetDoctorsFromDifferentPractice()
        {
            var transaction = new TransactionalInformation();
            var response = doctorService.GetDoctorsFromDifferentPractice(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("GetDoctorsFromDifferentPracticeWithOctContract")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetDoctorsFromDifferentPracticeWithOctContract()
        {
            var transaction = new TransactionalInformation();
            var response = doctorService.GetDoctorsFromDifferentPracticeWithOctContract(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetDoctorInfoForDoctorName")]
        [HttpGet]
        [AuthenticationFilter]
        public HttpResponseMessage GetDoctorInfoForDoctorName([FromUri]string doctorName)
        {
            var transaction = new TransactionalInformation();

            var response = doctorService.GetDoctorInfoForDoctorName(doctorName, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, transaction);
        }
    }
}