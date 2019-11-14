using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDocAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppInterfaces
{
    public interface IMainData
    {
        MD_GAIwPID_1629 GetUserName(string connectionString, string sessionTicket, string groupID, out TransactionalInformation transaction);
        bool VerifyDoctorPassword(string connectionString, string password, Guid doctor_id, string SessionToken, out TransactionalInformation transaction);
        List<AutocompleteModel> GetDoctorsForDropdown(string connectionString, Guid id, bool is_practice, string SessionToken, out TransactionalInformation transaction);
        bool ChangeAccountPassword(ChangePasswordModel pass, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        TileInfo GetNotificationData(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool CanAddPreexaminations(Guid practiceID, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves practice address of the currently logged in user.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        PracticeAddress GetPracticeAddressAndBacisInfo(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        int GetNumberOfOCTsPerYear(string contractName, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        MD_GAR_1201 GetAccountRole(string connectionString, string sessionTicket, out TransactionalInformation transaction);

    }
}
