using CSV2Core.SessionSecurity;
using MMDocConnectDocAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppInterfaces
{
    public interface IDocumentationOnlyDataService
    {
        /// <summary>
        /// Saves documentation only cases and octs
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        void SaveDocumentationOnlyOpAndOctData(DocumentationOnlyOpAndOctData parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves existing documentation only octs and ops
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        DocumentationOnlyOpAndOctData GetExistingDocumentationOnlyCases(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves all existing submitted, non-cancelled IVOMs for patient
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        DocumentationOnlyOpAndOctData GetExistingCasesForPatient(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Deletes documentation only op case and transfers oct data to another op case
        /// </summary>
        /// <param name="op_ids_to_delete"></param>
        /// <param name="all_op_ids"></param>
        /// <param name="dbConnection"></param>
        /// <param name="dbTransaction"></param>
        /// <param name="securityTicket"></param>
        /// <param name="patient_id"></param>
        /// <param name="localization"></param>
        void DeleteOpData(List<Guid> op_ids_to_delete, IEnumerable<Guid> all_op_ids, DbConnection dbConnection, DbTransaction dbTransaction, SessionSecurityTicket securityTicket, Guid patient_id = default(Guid), string localization = null);
    }
}
