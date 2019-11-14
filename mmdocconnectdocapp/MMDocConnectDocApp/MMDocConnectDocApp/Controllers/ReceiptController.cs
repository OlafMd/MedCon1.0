using MMDocConnectDocApp.Filters;
using MMDocConnectDocApp.Models;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppServices;
using MMDocConnectElasticSearchMethods.Models;
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
    [RoutePrefix("api/receipt")]
    [AuthenticationFilter]
    public class ReceiptController : BaseApiController
    {
        string connectionString;
        IReceiptDataService receiptDataService;

        public ReceiptController()
        {
            receiptDataService = new ReceiptDataService();

            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }


        [Route("GetReceiptItems")]
        [HttpPost]
        public HttpResponseMessage GetReceiptItems(ElasticParameterObject sort_parameter)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            List<Receipt_Model> ReceiptItems = receiptDataService.GetReceiptItems(sort_parameter, connectionString, SessionToken, out transaction);
              ReceiptApiModel receiptModel = new ReceiptApiModel();
              receiptModel.receipts = ReceiptItems;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, receiptModel);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("DownloadDocumentItem")]
        [HttpPost]
        public HttpResponseMessage DownloadDocumentItem(Receipt_Model item)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            string downloadURL = receiptDataService.GetDownloadURL(item, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, downloadURL);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);


        }
    }
}