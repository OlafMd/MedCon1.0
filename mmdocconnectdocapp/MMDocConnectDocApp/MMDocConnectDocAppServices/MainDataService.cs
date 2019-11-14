using BOp.Exceptions;
using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CL1_CMN_CTR;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CL1_USR;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Manipulation;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Model;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Receipt.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace MMDocConnectDocAppServices
{
    public class MainDataService : BaseVerification, IMainData
    {
        #region RETRIEVAL
        public MD_GAR_1201 GetAccountRole(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;
            var account_role = new MD_GAR_1201();

            try
            {
                account_role = cls_Get_Account_Role.Invoke(connectionString, securityTicket).Result;
                if (account_role == null)
                {
                    throw new Exception(String.Format("Account role not found, user account: {0}", securityTicket.AccountID));
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), "Authentication exceptions");

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return account_role;
        }

        public MD_GAIwPID_1629 GetUserName(string connectionString, string sessionTicket, string groupID, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;

            try
            {
                if (data.AccountInformation.group_id != groupID)
                {
                    transaction.ReturnMessage = new List<string>();
                    string errorMessage = "Zugriff nicht gestattet.";
                    transaction.ReturnStatus = false;
                    transaction.IsAuthenicated = false;
                    transaction.ReturnMessage.Add(errorMessage);
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return data;

        }
        public List<AutocompleteModel> GetDoctorsForDropdown(string connectionString, Guid id, bool is_practice, string SessionToken, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(SessionToken);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            List<AutocompleteModel> doctors = new List<AutocompleteModel>();

            try
            {
                var doctors_practices_elastic = Get_Doctors_for_PracticeID.Get_Doctors_That_Work_In_Practice_for_PracticeID(new Practice_Parameter() { practice_id = id, account_status = true }, securityTicket);

                foreach (var doctor_practice in doctors_practices_elastic)
                {
                    doctors.Add(new AutocompleteModel()
                    {
                        id = Guid.Parse(doctor_practice.id),
                        display_name = doctor_practice.autocomplete_name,
                        lanr = doctor_practice.bsnr_lanr,
                        secondary_display_name = doctor_practice.practice_name_for_doctor
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return doctors;
        }

        public int GetNumberOfOCTsPerYear(string contractName, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();

            var response = new TileInfo();

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;

            try
            {
                var numberOfOCTsPerYear = cls_Get_Number_of_OCTs_per_Treatment_Year_for_Contract_Name.Invoke(connectionString, new P_MD_GNoOpTYfCN_1033
                {
                    ContractName = contractName
                }, securityTicket).Result.NumberOfOCTs;

                return numberOfOCTsPerYear;
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(null, null, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return -1;
        }
        public TileInfo GetNotificationData(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();

            var response = new TileInfo();

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;

            try
            {
                var rejectionProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(connectionString, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                {
                    GlobalPropertyMatchingID = ECaseProperty.HasRejectedOct.Value(),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (rejectionProperty != null)
                {
                    response.settlementTile.numberOfCases = cls_Get_Cases_with_Property_Count_for_PracticeID.Invoke(connectionString, new P_CAS_GCwPCfPID_1140()
                    {
                        CaseUniversalPropertyID = rejectionProperty.HEC_CAS_Case_UniversalPropertyID,
                        PracticeID = data.PracticeID
                    }, securityTicket).Result.case_count.ToString();
                }

                response.errorCorrectionsTile.numberOfCases = Get_Settlement.GetNumberOfFSCasesInDoctorsPractice(data.PracticeID.ToString(), "fs6", securityTicket).ToString();
                response.paymentTile.numberOfCases = Retrieve_Receipts.GetNonViewedRecepiptsCount(data.DoctorID.ToString(), securityTicket).ToString();
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(null, null, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return response;
        }

        public bool CanAddPreexaminations(Guid practiceID, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                using (var dbConnection = DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();
                    var dbTransaction = dbConnection.BeginTransaction();
                    var isPracticeLoggedIn = data.AccountInformation.role.Contains("practice");

                    var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(dbConnection, dbTransaction, new ORM_CMN_CTR_Contract_Parameter.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
                    if (isPracticeLoggedIn)
                    {
                        var allPotetntialDoctors = cls_Get_DoctorIDs_with_Oct_Contract_for_Practice.Invoke(dbConnection, dbTransaction, new P_DO_GDIDswOCfP_1736 { PracticeID = data.PracticeID }, securityTicket).Result;
                        var allContractIDs = allPotetntialDoctors.Select(x => x.ContractID);
                        allContractParameters = allContractParameters.Where(x => allContractIDs.Contains(x.Contract_RefID)).ToList();

                        var allContractsWithCertificate = allContractParameters.Where(x => x.ParameterName == EContractParameter.DoctorNeedCertification.Value()).Select(x => x.Contract_RefID);
                        var allContractsWithoutCertificate = allContractIDs.Where(x => !allContractsWithCertificate.Contains(x));

                        if (allContractsWithoutCertificate.Any())
                        {
                            return true;
                        }

                        if (allContractsWithCertificate.Any())
                        {
                            foreach (var doc in allPotetntialDoctors)
                            {
                                //TODO: Create cls_Get_Is_Doctor_Certificated_for_OCT for doctorIDs
                                var is_certificated_for_oct = cls_Get_Is_Doctor_Certificated_for_OCT.Invoke(dbConnection, dbTransaction, new P_DO_GIDCfOCT_1729 { DoctorID = doc.DoctorID }, securityTicket).Result;
                                if (is_certificated_for_oct != null ? is_certificated_for_oct.IsDoctorCertificated : false)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    else
                    {
                        var doctor_insurance = cls_Get_Doctor_InsuranceToBrokerContract_with_Oct_for_DoctorID.Invoke(dbConnection, dbTransaction, new P_DO_GDOTBCwOfDID_1518 { DoctorID = data.DoctorID }, securityTicket).Result;
                        if (doctor_insurance != null)
                        {
                            var allContractIDs = doctor_insurance.Select(x => x.ContractID).Distinct();
                            allContractParameters = allContractParameters.Where(x => allContractIDs.Contains(x.Contract_RefID)).ToList();

                            var allContractsWithCertificate = allContractParameters.Where(x => x.ParameterName == EContractParameter.DoctorNeedCertification.Value()).Select(x => x.Contract_RefID);
                            var allContractsWithoutCertificate = allContractIDs.Where(x => !allContractsWithCertificate.Contains(x));

                            if (allContractsWithoutCertificate.Any())
                            {
                                return true;
                            }

                            if (allContractsWithCertificate.Any())
                            {
                                var is_certificated_for_oct = cls_Get_Is_Doctor_Certificated_for_OCT.Invoke(dbConnection, dbTransaction, new P_DO_GIDCfOCT_1729 { DoctorID = data.DoctorID }, securityTicket).Result;
                                return is_certificated_for_oct != null ? is_certificated_for_oct.IsDoctorCertificated : false;
                            }
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return false;
        }

        public PracticeAddress GetPracticeAddressAndBacisInfo(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;
                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();
                    var practice_address = cls_Get_Practice_Address_for_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPAfPID_0845()
                    {
                        PracticeID = data.PracticeID
                    }, securityTicket).Result;

                    var default_pharmacy = cls_Get_Default_Pharmacy_for_Practice.Invoke(dbConnection, dbTransaction, new P_PH_GDPfP_1421
                    {
                        PracticeID = data.PracticeID
                    }, securityTicket).Result;

                    dbTransaction.Commit();

                    var deliveryDateFrom = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPPVfPNaPID_0916()
                    {
                        PracticeID = data.PracticeID,
                        PropertyName = "Delivery date from"
                    }, securityTicket).Result;

                    var deliveryDateTo = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(dbConnection, dbTransaction, new P_DO_GPPVfPNaPID_0916()
                    {
                        PracticeID = data.PracticeID,
                        PropertyName = "Delivery date to"
                    }, securityTicket).Result;

                    if (practice_address != null)
                    {
                        var address = new PracticeAddress()
                        {
                            city = practice_address.city,
                            number = practice_address.number,
                            street = practice_address.street,
                            zip = practice_address.zip,
                            name = practice_address.name,
                            default_pharmacy = default_pharmacy == null || default_pharmacy.DefaultPharmacy == null ? Guid.Empty.ToString() : default_pharmacy.DefaultPharmacy,
                            delivery_date_from = deliveryDateFrom == null ? "08:00" : deliveryDateFrom.TextValue,
                            delivery_date_to = deliveryDateTo == null ? "18:00" : deliveryDateTo.TextValue
                        };

                        return address;
                    }
                }
                finally
                {
                    if (dbConnection.State == System.Data.ConnectionState.Open)
                    {
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return null;

        }
        #endregion

        #region MANIPULATION
        public bool ChangeAccountPassword(ChangePasswordModel pass, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                cls_Change_Password.Invoke(connectionString, new P_DO_CP_1724() { ID = pass.ID, password = pass.password, type = pass.type }, securityTicket);
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, pass), data.PracticeName);
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;

            }

            return true;
        }
        #endregion

        #region VALIDATION
        public bool VerifyDoctorPassword(string connectionString, string password, Guid doctor_id, string SessionToken, out TransactionalInformation transaction)
        {
            bool password_verified = false;
            transaction = new TransactionalInformation();
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var securityTicket = VerifySessionToken(SessionToken);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                if (String.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException("Password cannot be empty!");
                }

                var accountService = ProviderFactory.Instance.CreateAccountServiceProvider();
                ChangePasswordRequest request = new ChangePasswordRequest();
                request.NewPassword = password;
                request.OldPassword = password;
                request.TenantID = securityTicket.TenantID;

                var account = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(connectionString, new P_DO_GDAIDfDID_1549() { DoctorID = doctor_id }, securityTicket).Result;

                if (account != null)
                {
                    var doctor_account = accountService.GetAllAccountsForTenant(securityTicket.TenantID).FirstOrDefault(acc => acc.ID == account.accountID);

                    if (doctor_account != null)
                    {
                        request.Email = doctor_account.Email;
                        password_verified = accountService.ChangePassword(request).ChangedAccounts.Any();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SDKServiceException)
                {
                    transaction.ReturnMessage = new List<string>();
                    ServiceErrror errorMessage = (ServiceErrror)new JavaScriptSerializer().Deserialize(ex.Message, typeof(ServiceErrror));

                    if (errorMessage.Code == 70211)
                    {
                        transaction.ReturnStatus = true;
                        password_verified = true;
                    }
                    else
                    {
                        transaction.ReturnStatus = false;
                        transaction.ReturnMessage.Add(errorMessage.DeveloperMessage);
                        transaction.IsAuthenicated = true;
                        transaction.IsException = true;
                        password_verified = false;
                    }

                    return password_verified;
                }
                else
                {
                    Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                    transaction.ReturnMessage = new List<string>();
                    string errorMessage = ex.Message;
                    transaction.ReturnStatus = false;
                    transaction.ReturnMessage.Add(errorMessage);
                    transaction.IsAuthenicated = true;
                    transaction.IsException = true;
                }
            }

            return password_verified;
        }
        #endregion
    }
}
