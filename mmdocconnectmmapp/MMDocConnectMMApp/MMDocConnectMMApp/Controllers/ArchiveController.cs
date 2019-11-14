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
    [RoutePrefix("api/archive")]
    [AuthenticationFilter]
    public class ArchiveController : BaseApiController
    {
        string connectionString;
        IArchiveDataServices archiveDataService;
        public ArchiveController()
        {
            archiveDataService = new ArchiveDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;            
        }

        #region POST
        [Route("GetArchivedItems")]
        [HttpPost]
        public HttpResponseMessage GetArchivedItems(ElasticParameterObject sort_parameter)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            List<Archive_Model> ArchiveItems = archiveDataService.GetAllItemsForArchive(sort_parameter, connectionString, SessionToken, out transaction);
            ArchiveModelsApi archModel = new ArchiveModelsApi();
            archModel.ArchItem = ArchiveItems;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, archModel);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("DownloadDocumentItem")]
        [HttpPost]
        public HttpResponseMessage DownloadDocumentItem(Archive_Model item)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            string downloadURL = archiveDataService.GetDownloadURL(item, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, downloadURL);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }
        #endregion
    }
}