using MMDocConnectMMApp.Models;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectMMAppInterfaces
{
    public interface IContractDataService
    {
        List<ContractViewModel> GetAllContracts(string sort_by, bool ascending, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        ContractViewModel GetContractDetails(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest currentRequest = null);
        Guid SaveContract(ContractViewModel contract, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<CoveredItemModel> GetDrugsForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<CoveredItemModel> GetDiagnosesForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<CoveredItemModel> GetHIPsForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<ContractParticipatingDoctorModel> GetDoctorsForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid CopyContract(Guid contractIDToCopy, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest currentRequest = null);
        IEnumerable<ContractOverlapsValidationResponse> ValidateContractOverlaps(DoctorContractConsent parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        DateTime GetConsentStartDate(Guid contract_id, Guid doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
