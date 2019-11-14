using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectDocAppInterfaces
{
    public interface ISettlementDataService
    {
        List<Settlement_Model> getSettlementData(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        String GetFS6CommentForDoctor(Guid case_id, Guid planned_action_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void CancelCase(Guid case_id, Guid planned_action_id, String reasonForCancelation, Guid authorizing_doctor_id, string caseType, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        settlementMultiResult MultiEditSaveCase(MultiEditSettlement param, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        settlementMultiResult ConfirmMultiEditSaveCase(MultiEditSettlement param, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        String SubmitCase(DateTime date_of_performed_action, bool is_treatment, Guid case_id, Guid planned_action_id,  Guid authorizing_doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null);
        Guid CreateCase(Case new_case, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null);
        Case GetCaseDetailsforCaseID(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null);
        String DownloadSubmissionReport(SubmissionReportParameter parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<Guid> GetEligibleSettlementsForSubmissionReport(SubmissionReportParameter parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        string DownloadAllNonDowloadedReports(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool IsDownloadAllNonDownloadedReportsVisible(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid EditAftercareInErrorCorrectionState(ErrorCorrectionAftercare aftercare, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
