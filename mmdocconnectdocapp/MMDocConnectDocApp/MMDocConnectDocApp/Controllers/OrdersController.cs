using MMDocConnectDBMethods.Order.Complex.Model;
using MMDocConnectDocApp.Filters;
using MMDocConnectDocApp.Models;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectDocAppServices;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace MMDocConnectDocApp.Controllers
{
    [RoutePrefix("api/order")]
    [AuthenticationFilter]
    public class OrdersController : BaseApiController
    {
        private IOrdersDataService ordersDataService;
        private string connectionString;

        public OrdersController()
        {
            ordersDataService = new OrdersDataService();
            connectionString = WebConfigurationManager.ConnectionStrings[WebConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
        }

        [Route("GetOrderDetails")]
        [HttpGet]
        public HttpResponseMessage GetOrderDetails([FromUri]Guid id)
        {
            var transaction = new TransactionalInformation();
            var order = ordersDataService.GetOrderDetails(id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, order);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOrderComment")]
        [HttpGet]
        public HttpResponseMessage GetOrderComment([FromUri]Guid order_id)
        {
            var transaction = new TransactionalInformation();
            var comment = ordersDataService.GetOrderComment(order_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, comment);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("GetOrderCount")]
        [HttpPost]
        public HttpResponseMessage GetOrderDetails(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();
            var result = ordersDataService.GetOrderCount(sort_parameter.search_params, sort_parameter.hip_name, sort_parameter.orders_from_date, sort_parameter.orders_to_date, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("GetOrderIDsToSubmit")]
        [HttpPost]
        public HttpResponseMessage GetOrderIDsToSubmit(MultiOrderSubmitParameter parameter)
        {
            var transaction = new TransactionalInformation();
            string hip_name = null; //TODO: Add hip name to MultiOrderSubmitparameter if needed
            var result = ordersDataService.GetOrderIDsToSubmit(parameter.search_criteria, parameter.all_selected, parameter.selected_ids, parameter.deselected_ids, hip_name, connectionString,
                SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOrders")]
        [HttpPost]
        public HttpResponseMessage GetOrders(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();
            var orders = ordersDataService.GetPracticeOrders(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, orders);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOrderStats")]
        [HttpPost]
        public HttpResponseMessage GetOrderStats(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();
            var stats = ordersDataService.GetOrderStats(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, stats);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }


        [Route("GetTreatmentDates")]
        [HttpPost]
        public HttpResponseMessage GetOrderDetails(OrdersParameter parameter)
        {
            var transaction = new TransactionalInformation();
            var dates = ordersDataService.GetTreatmentDates(parameter.order_ids, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, dates);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }



        [Route("GetAllOrders")]
        [HttpPost]
        public HttpResponseMessage GetAllOrders(ElasticParameterObject sort_parameter)
        {
            var transaction = new TransactionalInformation();
            var orders = ordersDataService.GetAllPracticeOrders(sort_parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, orders);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOrderIDForCaseID")]
        [HttpGet]
        public HttpResponseMessage GetOrderIDForCaseID([FromUri]Guid caseID)
        {
            var transaction = new TransactionalInformation();
            var orderID = ordersDataService.GetOrderIDForCaseID(caseID, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, orderID);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("GetOrderReportURL")]
        [HttpGet]
        public HttpResponseMessage GetOrderReportURL([FromUri]Guid order_id)
        {
            var transaction = new TransactionalInformation();
            var reportURL = ordersDataService.GetOrderReportURL(order_id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, reportURL);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("SaveOrderDetails")]
        [HttpPost]
        public HttpResponseMessage SaveOrderDetails(Order order)
        {
            var transaction = new TransactionalInformation();
            ordersDataService.SaveOrderDetails(order, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("SubmitOrders")]
        [HttpPost]
        public HttpResponseMessage SubmitOrders(OrderSubmitParameter parameter)
        {
            var transaction = new TransactionalInformation();
            var reportURL = ordersDataService.SubmitOrderToMM(parameter, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, reportURL);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("CancelDrugOrder")]
        [HttpDelete]
        public HttpResponseMessage CancelDrugOrder([FromUri]Guid id)
        {
            var transaction = new TransactionalInformation();
            ordersDataService.CancelDrugOrder(id, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }

        [Route("SubmitAllShoppingCartOrders")]
        [HttpPost]
        public HttpResponseMessage SubmitAllShoppingCartOrders(SubmitAllOrdersParameter data)
        {
            var transaction = new TransactionalInformation();
            ordersDataService.SubmitAllShoppingCartOrders(data.number_of_orders, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.InternalServerError, transaction);
        }
    }
}
