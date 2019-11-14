using MMDocConnectMMApp.Models;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppInterfaces
{
    public interface IDashboardDataServices
    {
        TileInfo GetTilesInfo(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Case_Settlement_Model getAllCasesInStatus(string[] status, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        OrdersChangeInfo shipDrugOrders(List<int> ordersForShipping, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void changeOrderStatus(List<OrderForStatusChange> orders, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void CreateReportAndChangeStatusToFs2(DateTime? dateFrom, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        PositioveResponseCaseModel positiveResponse(List<PositiveResponseModel> PositiveResponseL, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void positiveResponseConfirm(List<PositiveResponseModel> PositiveResponse, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void NegativeResponseConfirm(NegativeResponseCaseModel negativeResponse, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<string> CasesWithNonEligibleStatuses(List<string> negativeCaseNumberIDs, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool ChangeCasesPayment(Payment_Model payment, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Case_Settlement_Model getAllCasesReport(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        string createReportAndDownloadIt(string connectionString, string sessionTicket, out TransactionalInformation transaction, bool? ShowOnlyAok = null);
        TemporaryDoctorDashboardTileModel GetTemporaryAcDoctorsCount(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Order_Model_for_Tile GetOrderForTile(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        string changeAllOrderStatus(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        string createCompleteOrdersReport(string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
