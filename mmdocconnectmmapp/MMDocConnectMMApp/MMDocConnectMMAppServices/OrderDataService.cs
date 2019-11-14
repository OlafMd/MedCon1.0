using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Order.Complex.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectMMAppInterfaces;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectMMAppServices
{
    public class OrderDataService : BaseVerification, IOrderDataServices
    {
        #region RETRIEVAL
        public List<Order_Model_Extended> GetOrderListData(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var OrderListData = new List<Order_Model_Extended>();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var results = Get_Orders.Get_All_Orders(sort_parameter, userSecurityTicket);
                OrderListData = results.Select(order =>
                {
                    var extended = new Order_Model_Extended();
                    extended.PopulateBase(order);
                    extended.delivery_date_string = extended.delivery_time_from.ToString("dd.MM.yyyy");
                    return extended;
                }).ToList();
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return OrderListData;
        }
        #endregion

        #region MANIPULATION
        public Order_Model rejectOrderStatus(Order_Model orderClicked, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            try
            {
                P_OR_COS_0840a parameter = new P_OR_COS_0840a();
                parameter.CaseID = Guid.Parse(orderClicked.case_id);
                parameter.Order_ID = Guid.Parse(orderClicked.id);
                parameter.Status_To = 4;
                parameter.Status_To_Str = "MO4";

                var data = cls_Change_Order_Status.Invoke(connectionString, new P_OR_COS_0840() { ParameterArray = new P_OR_COS_0840a[] { parameter } }, userSecurityTicket);
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, parameter));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return orderClicked;
        }
        #endregion
    }
}

