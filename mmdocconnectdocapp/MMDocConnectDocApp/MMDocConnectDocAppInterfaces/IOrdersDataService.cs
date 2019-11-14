using CSV2Core.SessionSecurity;
using MMDocConnectDBMethods.Order.Complex.Model;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppInterfaces
{
    public interface IOrdersDataService
    {
        /// <summary>
        /// Retrieves all open orders in logged in users practice.
        /// </summary>
        /// <param name="sort_parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        object GetPracticeOrders(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);


        /// <summary>
        /// Retrieves all orders in logged in users practice.
        /// </summary>
        /// <param name="sort_parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Return_Order_Model GetAllPracticeOrders(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Submits an order to MM.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        String SubmitOrderToMM(OrderSubmitParameter parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Cancels an order.
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        void CancelDrugOrder(Guid order_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves basic order details.
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Order GetOrderDetails(Guid order_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Updates order details;
        /// </summary>
        /// <param name="order"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        void SaveOrderDetails(Order order, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves order count based on the search criteria
        /// </summary>
        /// <param name="search_criteria"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        long GetOrderCount(string search_params, string hip_name, DateTime orders_from_date, DateTime orders_to_date, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves order ids for multi submit based on search criteria
        /// </summary>
        /// <param name="search_criteria"></param>
        /// <param name="all_selected"></param>
        /// <param name="selected_ids"></param>
        /// <param name="deselected_ids"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<Guid> GetOrderIDsToSubmit(string search_criteria, bool all_selected, IEnumerable<Guid> selected_ids, IEnumerable<Guid> deselected_ids, string hip_name, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves existing order comment for order id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        string GetOrderComment(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves order id for case id
        /// </summary>
        /// <param name="case_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Guid GetOrderIDForCaseID(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves orders statistics
        /// </summary>
        /// <param name="sort_parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<object> GetOrderStats(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Submit all orders from shopping cart page
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        void SubmitAllShoppingCartOrders(int number_of_orders, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Get default shipping date offset
        /// </summary>
        /// <param name="practice_id"></param>
        /// <param name="dbConnection"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="securityTicket"></param>
        /// <returns></returns>
        double GetDefaultShippingDateOffset(Guid practice_id, DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket);

        /// <summary>
        /// Get uploaded report download URL for order id
        /// </summary>
        /// <param name="order_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        String GetOrderReportURL(Guid order_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves treatment dates for those orders connected to a treatment.
        /// </summary>
        /// <param name="order_ids"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<DateTime> GetTreatmentDates(IEnumerable<Guid> order_ids, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
