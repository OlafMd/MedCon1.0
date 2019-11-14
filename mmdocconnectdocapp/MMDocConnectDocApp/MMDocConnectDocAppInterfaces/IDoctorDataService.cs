using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppInterfaces
{
    public interface IDoctorDataService
    {
        DO_GDBIfLD_1031 GetDoctorInformation(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<DO_GDBIfDfDP_1525> GetDoctorsFromDifferentPractice(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<DO_GDBIfDfDP_1525> GetDoctorsFromDifferentPracticeWithOctContract(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        DO_GDBIfLD_1031 GetDoctorInfoForDoctorName(String doctorFullName,string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
