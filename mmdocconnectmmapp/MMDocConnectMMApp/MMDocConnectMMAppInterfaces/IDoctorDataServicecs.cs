using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMDocConnectMMAppModels;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using MMDocConnectMMApp.Models;
using System.Web;

namespace MMDocConnectMMAppInterfaces
{
    public interface IDoctorDataService
    {
        void CreatePractice(Practice practice, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool CheckBsnr(Guid practice_id, string Bsnr, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool CheckLanr(Guid doctor_id, Guid practice_id, string Lanr, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        LanrValidationResponse CheckLanrForMerge(string lanr, Guid practice_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool CheckLoginEmail(Guid id, string type, string login_email, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid CreateDoctor(Doctor doctor, string connectionString, string sessionTicket, out TransactionalInformation tranasction);
        DO_GAPR_1342[] GetAllPractices(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        DO_GBAfPR_1524[] GetBankAccountInfoforPracticeID(P_DO_GBAfPR_1524 parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<Practice_Doctors_Model> GetDoctorPracticesList(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        DoctorDetail GetDoctorDetails(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest PreviousDetailsRequest = null);
        PracticeDetails GetPracticeDetails(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest PreviousDetailsRequest = null);
        DO_GCfD_1548[] ContractsForDropDown(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid SaveDoctorsConsent(DoctorContractConsent objDoca, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        DoctorContractConsent GetDoctorsConsentDetails(Guid assignmentID, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<Practice_Doctors_Model> GetDoctorsForPracticeID(Practice_Parameter Parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<objDoc> Get_Contracts_for_DoctorID(objDoc ObjDoc, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<Bic_Iban_Codes> CheckIban(IBAN_Parameter Iban, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<Bic_Iban_Codes> CheckBicBank(Bic_Parameter Bic, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid MergeDoctor(Guid doctor_id, Guid temporary_doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<ContractOverlapsValidationResponse> ValidateContractOverlaps(DoctorContractConsent parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        
    }
}
