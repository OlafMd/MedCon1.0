using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Complex.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Manipulation;
using MMDocConnectDBMethods.Patient.Complex.Retrieval;
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
    [RoutePrefix("api/settings")]
    [AuthenticationFilter]
    public class SettingsController : BaseApiController
    {
        string connectionString;
        ISettingsDataService dataService;
        IMainData mainDataService;

        public SettingsController()
        {
            mainDataService = new MainDataService();
            dataService = new SettingsDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        /*******************************************************************************
         * GET Methods
         *******************************************************************************/

        [Route("GetAccountDetails")]
        [HttpGet]
        public HttpResponseMessage GetAccountDetails()
        {
            var transaction = new TransactionalInformation();
            var userInfo = mainDataService.GetUserName(connectionString, SessionToken, Properties.Settings.Default.DocAppGroup, out transaction);
            if (transaction.ReturnStatus)
            {
                var isPracticeLoggedIn = userInfo.AccountInformation.role == Properties.Settings.Default.OPPracticeAccountDocApp ? true : false;
                var ID = isPracticeLoggedIn ? userInfo.PracticeID : userInfo.DoctorID;

                if (isPracticeLoggedIn)
                    return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);

                var details = dataService.Get_Doctor_DetailData(ID, connectionString, SessionToken, out transaction);

                var account = new DoctorApiModel();
                account.isPracticeLoggedIn = isPracticeLoggedIn;
                account.doctor = details;

                if (transaction.ReturnStatus)
                    return Request.CreateResponse<DoctorApiModel>(HttpStatusCode.OK, account);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);

        }
        [Route("GetBankAccountInfoforPracticeID")]
        [HttpGet]
        public HttpResponseMessage GetBankAccountInfoforPracticeID([FromUri]  string id)
        {
            var transaction = new TransactionalInformation();
            var parameter = new P_DO_GBAfPR_1524();
            parameter.PracticeID = new Guid(id);
            var data = dataService.GetBankAccountInfoforPracticeID(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse<DO_GBAfPR_1524[]>(HttpStatusCode.OK, data);

            return Request.CreateResponse(HttpStatusCode.InternalServerError, data);
        }

        [Route("GetPracticeDetails")]
        [HttpGet]
        public HttpResponseMessage GetPracticeDetails()
        {
            var transaction = new TransactionalInformation();
            var userInfo = mainDataService.GetUserName(connectionString, SessionToken, Properties.Settings.Default.DocAppGroup, out transaction);
            if (transaction.ReturnStatus)
            {
                var isPracticeLoggedIn = userInfo.AccountInformation.role == Properties.Settings.Default.OPPracticeAccountDocApp;

                var details = dataService.Get_Practice_DetailData(userInfo.PracticeID, connectionString, SessionToken, out transaction);

                var account = new PracticeApiModel();
                account.isPracticeLoggedIn = isPracticeLoggedIn;
                account.practice = details;

                if (transaction.ReturnStatus)
                    return Request.CreateResponse<PracticeApiModel>(HttpStatusCode.OK, account);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);

        }

        [Route("CheckIfAutentificationNeeded")]
        [HttpGet]
        public HttpResponseMessage CheckIfAutentificationNeeded()
        {
            var transaction = new TransactionalInformation();
            var userInfo = mainDataService.GetUserName(connectionString, SessionToken, Properties.Settings.Default.DocAppGroup, out transaction);
            if (transaction.ReturnStatus)
            {

                var isPracticeLoggedIn = userInfo.AccountInformation.role == Properties.Settings.Default.OPPracticeAccountDocApp;

                var autentificationNeeded = dataService.CheckIfAutentificationNeeded(isPracticeLoggedIn, connectionString, SessionToken, out transaction);

                if (transaction.ReturnStatus)
                    return Request.CreateResponse(HttpStatusCode.OK, autentificationNeeded);
            }

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);

        }


        [Route("RestartGracePeriodForLoggedUser")]
        [HttpGet]
        public HttpResponseMessage RestartGracePeriodForLoggedUser()
        {
            var transaction = new TransactionalInformation();
            dataService.RestartGracePeriod(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);
            
            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);

        }
        /*******************************************************************************
         * POST Methods
         *******************************************************************************/
        [Route("IBanValidation")]
        [HttpPost]
        public HttpResponseMessage IBanValidation(IBAN_Parameter objiban)
        {
            var transaction = new TransactionalInformation();
            var BicIBan = new BicIbanApiModel();
            var data = dataService.CheckIban(objiban, connectionString, SessionToken, out transaction);
            BicIBan.BicIban = data;
            if (transaction.ReturnStatus)
                return Request.CreateResponse<BicIbanApiModel>(HttpStatusCode.OK, BicIBan);

            return Request.CreateResponse<BicIbanApiModel>(HttpStatusCode.InternalServerError, BicIBan);
        }

        [Route("SaveAccount")]
        [HttpPost]
        public HttpResponseMessage SaveAccount(Account doctor)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            dataService.SaveAccount(doctor, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("BicBankValidation")]
        [HttpPost]
        public HttpResponseMessage BicBankValidation(Bic_Parameter objBic)
        {
            var transaction = new TransactionalInformation();
            var BicIBan = new BicIbanApiModel();
            var data = dataService.CheckBicBank(objBic, connectionString, SessionToken, out transaction);
            BicIBan.BicIban = data;

            if (transaction.ReturnStatus)
                return Request.CreateResponse<BicIbanApiModel>(HttpStatusCode.OK, BicIBan);

            return Request.CreateResponse<BicIbanApiModel>(HttpStatusCode.InternalServerError, BicIBan);
        }

        [Route("CreatePractice")]
        [HttpPost]
        public HttpResponseMessage CreatePractice(Practice practice)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            dataService.CreatePractice(practice, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
