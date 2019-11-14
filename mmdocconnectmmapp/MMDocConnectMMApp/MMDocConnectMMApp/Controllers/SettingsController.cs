using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMApp.Filters;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppServices;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MMDocConnectMMApp.Controllers
{
    [RoutePrefix("api/settings")]
    [AuthenticationFilter]
    public class SettingsController : BaseApiController
    {
        string connectionString;
        ISettingsService settingsDataService;
        public SettingsController()
        {
            settingsDataService = new SettingsDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
            
        }


        [Route("getUsers")]
        [HttpGet]
        public HttpResponseMessage getUsers()
        {
            TransactionalInformation transaction = new TransactionalInformation();

            UsersApiModel usersM = new UsersApiModel();

            List<Employee_Model> users = settingsDataService.GetUsers(connectionString, SessionToken, out transaction);
            usersM.users = users;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, usersM);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetCompanySettings")]
        [HttpGet]
        public HttpResponseMessage GetCompanySettings()
        {
            TransactionalInformation transaction = new TransactionalInformation();

            AppSettingsModelApi SettingsApi = new AppSettingsModelApi();

            AppSettings settings = settingsDataService.GetCompanySettings(connectionString, SessionToken, out transaction);
            SettingsApi.appSettings = settings;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, SettingsApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetEmployees")]
        [HttpPost]
        public HttpResponseMessage GetEmployees(ElasticParameterObject sort_parameter)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var employees = settingsDataService.GetEmployees(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, employees);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("AddUser")]
        [HttpPost]
        public HttpResponseMessage AddUser(User user)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            string data = settingsDataService.AddUser(user, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, data);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("SaveAppSettings")]
        [HttpPost]
        public HttpResponseMessage SaveAppSettings(AppSettings settings)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            string settingsSaved = settingsDataService.SaveAppSettings(settings, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, settingsSaved);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetUserForAccountID")]
        [HttpPost]
        public HttpResponseMessage GetUserForAccountID(User userData)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            UsersApiModel usersM = new UsersApiModel();
            User user = settingsDataService.GetUserForAccountID(userData.id, connectionString, SessionToken, out transaction);
            usersM.user = user;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, usersM);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetUserForMyAccount")]
        [HttpGet]
        public HttpResponseMessage GetUserForMyAccount()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            UsersApiModel usersM = new UsersApiModel();
            User user = settingsDataService.GetUserForMyAccount(connectionString, SessionToken, out transaction);
            usersM.user = user;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, usersM);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }
    }
}