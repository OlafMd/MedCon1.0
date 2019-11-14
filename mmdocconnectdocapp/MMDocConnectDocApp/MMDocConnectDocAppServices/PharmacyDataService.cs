using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval;
using MMDocConnectDBMethods.Pharmacy.Model;
using MMDocConnectDocAppInterfaces;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectDocAppServices
{
    public class PharmacyDataService : BaseVerification, IPharmacyDataServices
    {

        public IEnumerable<Pharmacy> GetPharmacies(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var dbPharmacies = cls_Get_Internal_Pharmacies.Invoke(connectionString, securityTicket).Result;
                var externalPharmacyGPMID = EPharmacyType.External.Value();

                var allPharmacies = dbPharmacies.Select(x => new Pharmacy(x.PharmacyID, x.PharmacyName, x.Contact_Email, x.Contact_Telephone, x.Contact_Fax,
                    x.Street_Name, x.Street_Number, x.ZIP, x.Town, x.PharmacyType.Equals(externalPharmacyGPMID), x.ContactPersonName));

                return allPharmacies.OrderBy(x => x.PharmacyName);
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
                return new List<Pharmacy>();
            }
        }

        public Pharmacy GetPharmacyInfoForName(string name, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            //This method is needed for atomated tests
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var dbPharmacies = cls_Get_Internal_Pharmacies.Invoke(connectionString, securityTicket).Result;
                var externalPharmacyGPMID = EPharmacyType.External.Value();

                var foundedPharmacy = dbPharmacies.First(x => x.PharmacyName == name);
                if (foundedPharmacy != null)
                {

                    return new Pharmacy(foundedPharmacy.PharmacyID, foundedPharmacy.PharmacyName, foundedPharmacy.Contact_Email, foundedPharmacy.Contact_Telephone,
                        foundedPharmacy.Contact_Fax, foundedPharmacy.Street_Name, foundedPharmacy.Street_Number, foundedPharmacy.ZIP, foundedPharmacy.Town,
                        foundedPharmacy.PharmacyType.Equals(externalPharmacyGPMID), foundedPharmacy.ContactPersonName);
                }
                else { return null; }

            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
                return null;
            }
        }

    }
}
