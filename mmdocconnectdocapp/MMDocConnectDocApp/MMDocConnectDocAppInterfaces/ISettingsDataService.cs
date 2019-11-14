using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Complex.Retrieval;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectDocAppInterfaces
{
    public interface ISettingsDataService
    {
        /// <summary>
        /// Gets doctors details for My account page
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        DO_GPDD_1137 Get_Doctor_DetailData(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null);

        DO_GPDD_1700 Get_Practice_DetailData(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null);

        List<Bic_Iban_Codes> CheckIban(IBAN_Parameter Iban, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        /// <summary>
        /// Save account 
        /// </summary>
        /// <param name="doctor"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        void SaveAccount(Account doctor, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        DO_GBAfPR_1524[] GetBankAccountInfoforPracticeID(P_DO_GBAfPR_1524 parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<Bic_Iban_Codes> CheckBicBank(Bic_Parameter Bic, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void CreatePractice(Practice practice, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Boolean CheckIfAutentificationNeeded(bool isPracticeLoggedIn, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void RestartGracePeriod(string connectionString, string sessionTicket, out TransactionalInformation transaction);

    }
}
