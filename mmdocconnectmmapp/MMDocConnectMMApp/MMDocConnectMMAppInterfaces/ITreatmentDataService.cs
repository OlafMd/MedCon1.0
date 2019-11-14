
using MMDocConnectElasticSearchMethods.Models;
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
    public interface ITreatmentDataService
    {
        List<Submitted_Case_Model> GetSubmittedCasesList(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        String GetResponseFromHIP(Guid case_id, Guid planned_action_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid[] SubmitCaseForErrorCorrection(Guid case_id, Guid planned_action_id, string comment, string action_type, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid[] GetEligibleCases(bool all_selected, Guid[] selected_action_ids, Guid[] deselected_action_ids, FilterObject filter, CaseStatus? case_status, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid[] ChangeCaseStatus(bool all_selected, Guid[] selected_action_ids, Guid[] deselected_action_ids, FilterObject filter, Guid[] case_ids, bool? is_management_fee_waived, CaseStatus? case_status, string case_status_ground, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        long GetSubmittedCasesCount(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}