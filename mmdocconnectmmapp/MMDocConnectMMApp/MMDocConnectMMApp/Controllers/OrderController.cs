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

    [RoutePrefix("api/order")]
    [AuthenticationFilter]
    public class OrderController : BaseApiController
    {

        string connectionString;
        IOrderDataServices orderDataService;
        public OrderController()
        {
            orderDataService = new OrderDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
            
        }

        #region POST
        [Route("getOrderData")]
        [HttpPost]
        public HttpResponseMessage getOrderData(ElasticParameterObject sort_parameter)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            OrderApiModel orderApiModel = new OrderApiModel();
            List<Order_Model_Extended> orderList = orderDataService.GetOrderListData(sort_parameter, connectionString, SessionToken, out transaction);
            orderApiModel.OrderData = orderList;

            if (transaction.ReturnStatus)
                return Request.CreateResponse<OrderApiModel>(HttpStatusCode.OK, orderApiModel);
            var badResponse = Request.CreateResponse<OrderApiModel>(HttpStatusCode.BadRequest, orderApiModel);
            return badResponse;
        }




        [Route("rejectOrderStatus")]
        [HttpPost]
        public HttpResponseMessage rejectOrderStatus(Order_Model orderClicked)
        {

            TransactionalInformation transaction = new TransactionalInformation();
            OrderApiModel orderApiModel = new OrderApiModel();
            List<Order_Model> orderList = new List<Order_Model>();
            orderDataService.rejectOrderStatus(orderClicked, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, "Status Changed");

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }





        #endregion
        #region GET
        #endregion
    }
}