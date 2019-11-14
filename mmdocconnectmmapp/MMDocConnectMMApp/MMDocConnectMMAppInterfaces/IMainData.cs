using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
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
    public interface IMainData
    {
        MD_GAI_1617 GetUserName(string connectionString, string sessionTicket, string groupID,  string Role, out TransactionalInformation transaction);
        bool ChangeAccountPassword(ChangePasswordModel pass, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool VerifyPassword(string email, string password, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        EmployeeVerificationObject GetEmployeesForRightID(string rightID, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        TileInfo GetNotificationData(string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
