using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Medication.Atomic.Manipulation;
using MMDocConnectDBMethods.Medication.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectMMAppServices
{
    public class MedicationDataService : BaseVerification, IMedicationDataServices
    {

        #region MANIPULATION
        /// <summary>
        /// Save new medication or edit existing one
        /// </summary>
        /// <param name="medication"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        public void SaveMedication(MedicationModel medication, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            IEnumerable<IEnumerable<IElasticMapper>> elastic_backup = null;

            try
            {
                #region PARAMETER
                P_MC_SM_1132 medication_parameter = new P_MC_SM_1132();
                medication_parameter.MedicationID = medication.MedicationID;
                medication_parameter.Medication = medication.Medication;
                medication_parameter.ProprietaryDrug = medication.ProprietaryDrug;
                medication_parameter.PZNScheme = medication.PZNScheme;
                medication_parameter.Dosage = medication.Dosage;
                medication_parameter.Unit = medication.Unit;
                #endregion

                MedicationModel previous_state = null;

                if (medication.MedicationID != Guid.Empty)
                {
                    var detailsThread = new Thread(() => GetMedicationPreviousDetails(out previous_state, medication.MedicationID, connectionString, sessionTicket, request));
                    detailsThread.Start();

                    var medication_details = cls_Get_Medication_for_MedicationID.Invoke(connectionString, new P_MC_GMfMID_1433() { MedicationID = medication.MedicationID }, userSecurityTicket).Result;

                    if (medication_details != null && medication_details.Medication != medication.Medication)
                    {
                        elastic_backup = Elastic_Rollback.GetBackup(userSecurityTicket.TenantID.ToString(), medication.HecDrugID.ToString(), "drug");

                        var values = new string[] { medication.Medication };

                        var elastic_data = Elastic_Rollback.GetUpdatedData(userSecurityTicket.TenantID.ToString(), medication.HecDrugID.ToString(), "drug", values);

                        Elastic_Rollback.InsertDataIntoElastic(elastic_data, userSecurityTicket.TenantID.ToString());
                    }
                }

                cls_Save_Medication.Invoke(connectionString, medication_parameter, userSecurityTicket);

                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, medication, previous_state));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;

                if (elastic_backup != null)
                    Elastic_Rollback.InsertDataIntoElastic(elastic_backup, userSecurityTicket.TenantID.ToString());
            }
        }
        #endregion

        #region RETRIEVAL
        /// <summary>
        /// Get medications for list
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<MedicationModel> GetMedications(MedicationSort objSort, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            List<MedicationModel> medications = new List<MedicationModel>();
            List<MedicationModel> medicationsSorted = new List<MedicationModel>();
            try
            {
                MC_GM_1208[] medicationList = cls_Get_Medications.Invoke(connectionString, userSecurityTicket).Result;
                foreach (var medicationItem in medicationList)
                {
                    MedicationModel medication = new MedicationModel();
                    medication.MedicationID = medicationItem.MedicationID;
                    medication.Medication = medicationItem.Medication;
                    medication.ProprietaryDrug = medicationItem.ProprietaryDrug;
                    medication.HecDrugID = medicationItem.HecDrugID;
                    medication.PZNScheme = medicationItem.PZNScheme;
                    medications.Add(medication);

                }
                switch (objSort.frKey)
                {
                    case "Medication":
                        medicationsSorted = medications.OrderBy(pr => pr.Medication).ToList();
                        break;
                    case "ProprietaryDrug":
                        medicationsSorted = medications.OrderBy(pr => pr.ProprietaryDrug).ToList();
                        break;
                    case "PZNScheme":
                        medicationsSorted = medications.OrderBy(pr => pr.PZNScheme).ToList();
                        break;
                }
                if (!objSort.isAsc)
                    medicationsSorted.Reverse();

            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;

            }
            return medicationsSorted;
        }

        public MedicationModel GetMedicationforMedicationID(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null)
        {
            if (request == null)
                request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            MedicationModel medication = new MedicationModel();
            try
            {

                MC_GMfMID_1433 medicationFound = cls_Get_Medication_for_MedicationID.Invoke(connectionString, new P_MC_GMfMID_1433() { MedicationID = id }, userSecurityTicket).Result;
                medication.MedicationID = medicationFound.MedicationID;
                medication.Medication = medicationFound.Medication;
                medication.ProprietaryDrug = medicationFound.ProprietaryDrug;
                medication.PZNScheme = medicationFound.PZNScheme;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return medication;
        }
        #endregion

        #region UTIL
        private void GetMedicationPreviousDetails(out MedicationModel previous_state, Guid id, string connectionString, string sessionTicket, HttpRequest request)
        {
            var transaction = new TransactionalInformation();
            var md = new MedicationDataService();
            previous_state = md.GetMedicationforMedicationID(id, connectionString, sessionTicket, out transaction, request);
        }
        #endregion
    }
}
