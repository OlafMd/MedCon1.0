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
    public interface IPreexaminationDataService
    {
        object ValidateAndSubmitPreexaminationData(Preexamination preexaminationData, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void SavePreexamination(Case preexamination, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
