using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Pharmacy.Atomic.Manipulation;
using MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval;
using MMDocConnectDBMethods.Pharmacy.Model;
using MMDocConnectMMAppInterfaces;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectMMAppServices
{
    public class PharmacyDataService : BaseVerification, IPharmacyDataServices
    {
        public void SavePharmacy(Pharmacy pharmacy, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                cls_Save_Pharmacy.Invoke(connectionString, new P_PH_SP_1124
                {
                    Pharmacy = pharmacy
                }, userSecurityTicket);

                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, pharmacy));
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
        }

        public IEnumerable<Pharmacy> GetPharmacies(SortPharmacy sortParameters, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            //TODO: Dodati sortiranje 

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var dbPharmacies = cls_Get_Internal_Pharmacies.Invoke(connectionString, userSecurityTicket).Result;
                var externalPharmacyGPMID = EPharmacyType.External.Value();

                var allPharmacies = dbPharmacies.Select(x => new Pharmacy(x.PharmacyID, x.PharmacyName, x.Contact_Email, x.Contact_Telephone, x.Contact_Fax,
                    x.Street_Name, x.Street_Number, x.ZIP, x.Town, x.PharmacyType.Equals(externalPharmacyGPMID), x.ContactPersonName));

                if (sortParameters != null)
                {
                    switch (sortParameters.sortBy)
                    {
                        case ("name"):
                            allPharmacies = allPharmacies.OrderBy(x => x.PharmacyName);
                            break;
                        case ("contactPersonName"):
                            allPharmacies = allPharmacies.OrderBy(x => x.ContactPersonName);
                            break;
                        case ("email"):
                            allPharmacies = allPharmacies.OrderBy(x => x.Email);
                            break;
                    }

                    return sortParameters.isAsc ? allPharmacies : allPharmacies.Reverse();
                }
                else
                {
                    return allPharmacies.OrderBy(x => x.PharmacyName);
                }
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
                return new List<Pharmacy>();
            }
        }

        public Boolean DeletePharmacy(Guid pharmacyID, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                return cls_Delete_Pharmacy.Invoke(connectionString, new P_PH_DP_1523 { PharmacyID = pharmacyID }, userSecurityTicket).Result;
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
                return false;
            }
        }
    }
}
