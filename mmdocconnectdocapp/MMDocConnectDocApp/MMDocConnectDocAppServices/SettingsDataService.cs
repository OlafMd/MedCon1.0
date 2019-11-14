using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Doctor.Atomic.Manipulation;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Complex.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Manipulation;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectDocAppServices
{
    public class SettingsDataService : BaseVerification, ISettingsDataService
    {
        #region RETRIEVAL
        public DO_GPDD_1137 Get_Doctor_DetailData(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null)
        {
            if (request == null)
                request = HttpContext.Current.Request;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            List<Guid> response = new List<Guid>();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            DO_GPDD_1137 doctor_detail = new DO_GPDD_1137();

            try
            {
                doctor_detail = cls_Get_Doctor_DetailData.Invoke(connectionString, new P_DO_GPDD_1137 { ID = id }, securityTicket).Result;
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
            return doctor_detail;
        }

        public DO_GPDD_1700 Get_Practice_DetailData(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null)
        {
            if (request == null)
                request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            List<Guid> response = new List<Guid>();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            DO_GPDD_1700 practice_detail = new DO_GPDD_1700();

            try
            {
                practice_detail = cls_Get_Practice_DetailData.Invoke(connectionString, new P_DO_GPDD_1700 { ID = id }, securityTicket).Result;
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
            return practice_detail;
        }
        public DO_GBAfPR_1524[] GetBankAccountInfoforPracticeID(P_DO_GBAfPR_1524 parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Guid> response = new List<Guid>();
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            DO_GBAfPR_1524[] data = new List<DO_GBAfPR_1524>().ToArray();

            try
            {
                data = cls_Get_BankInfo_for_Practice.Invoke(connectionString, parameter, securityTicket).Result;

            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return data;
        }
        #endregion

        #region VALIDATION

        public Boolean CheckIfAutentificationNeeded(bool isPracticeLoggedIn, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, userSecurityTicket).Result;
            var needAutentification = true;
            try
            {
                needAutentification = cls_Check_if_Autentification_Needed.Invoke(connectionString, new P_MD_CiAN_1313
                {
                    DoctorID = userData.DoctorID,
                    PracticeID = userData.PracticeID,
                    isPractice = isPracticeLoggedIn
                }, userSecurityTicket).Result;
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return needAutentification;
        }


        public List<Bic_Iban_Codes> CheckIban(IBAN_Parameter iban, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            List<Guid> response = new List<Guid>();

            List<Bic_Iban_Codes> data = new List<Bic_Iban_Codes>();
            try
            {
                data = Iban_Bic_Validation.Check_IBAN(iban, securityTicket);
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return data;
        }
        public List<Bic_Iban_Codes> CheckBicBank(Bic_Parameter Bic, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            List<Bic_Iban_Codes> data = new List<Bic_Iban_Codes>();

            try
            {
                data = Iban_Bic_Validation.CheckBicBank(Bic, securityTicket);
                return data;
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return data;
        }
        #endregion

        #region MANIPULATION
        public void SaveAccount(Account doctor, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            IEnumerable<IEnumerable<IElasticMapper>> elastic_backup = null;

            try
            {
                #region PARAMETER
                P_DO_SD_1026 parameter = new P_DO_SD_1026();
                var passwordForSave = "";
                if (!String.IsNullOrEmpty(doctor.inPassword))
                {
                    passwordForSave = Util.CalculateMD5Hash(doctor.inPassword);
                }

                parameter.Account_PasswordForEmail = doctor.inPassword;
                parameter.Account_Holder = doctor.account_holder;
                parameter.Account_Password = passwordForSave;
                parameter.Bank = doctor.bank_name;
                parameter.BIC = doctor.bic;
                parameter.Email = doctor.email;
                parameter.IBAN = doctor.iban;
                parameter.First_Name = doctor.first_name;
                parameter.Last_Name = doctor.last_name;
                parameter.LANR = doctor.lanr;
                parameter.Phone = doctor.phone;
                parameter.PracticeID = new Guid(doctor.practice_id);
                parameter.Salutation = doctor.salutation;
                parameter.Title = doctor.title;
                parameter.Login_Email = doctor.login_email;
                parameter.From_Practice_Bank = doctor.is_bank_inherited;
                parameter.DoctorID = new Guid(doctor.id);
                parameter.Account_Deactivated = false;
                #endregion

                Account previous_state = null;
                Thread detailsThread = new Thread(() => GetDoctorAccountPreviousDetails(out previous_state, Guid.Parse(doctor.id), connectionString, sessionTicket, request));
                detailsThread.Start();
                var doctor_id = Guid.Empty;
                Guid.TryParse(doctor.id, out doctor_id);

                #region UPDATE ELASTIC ON BASE CHANGE
                if (doctor_id != Guid.Empty)
                {
                    var doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(connectionString, new P_DO_GDDfDID_0823() { DoctorID = doctor_id }, securityTicket).Result.FirstOrDefault();
                    if (doctor_details != null)
                    {
                        if (doctor_details.first_name != doctor.first_name || doctor_details.last_name != doctor.last_name || doctor_details.lanr != doctor.lanr || doctor.title != doctor_details.title)
                        {
                            elastic_backup = Elastic_Rollback.GetBackup(securityTicket.TenantID.ToString(), doctor.id, "doctor");

                            var values = new string[] {
                                GenericUtils.GetDoctorName(doctor),
                                doctor.lanr
                            };

                            var elastic_data = Elastic_Rollback.GetUpdatedData(securityTicket.TenantID.ToString(), doctor.id, "doctor", values);

                            Elastic_Rollback.InsertDataIntoElastic(elastic_data, securityTicket.TenantID.ToString());
                        }
                    }
                }
                #endregion

                var id = cls_Save_Doctor.Invoke(connectionString, parameter, securityTicket).Result;

                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, doctor, previous_state), data.PracticeName);
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

                if (elastic_backup != null)
                    Elastic_Rollback.InsertDataIntoElastic(elastic_backup, securityTicket.TenantID.ToString());
            }
        }

        public void CreatePractice(Practice practice, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var userData = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            IEnumerable<IEnumerable<IElasticMapper>> elastic_backup = null;

            try
            {

                #region PARAMETER
                P_DO_SP_1547 parameter = new P_DO_SP_1547();

                if (!String.IsNullOrEmpty(practice.contact_person_name))
                {
                    string PersonFirstName = "";
                    string PersonLastName = "";

                    string personInfo = practice.contact_person_name;
                    int i = personInfo.IndexOf(' ');
                    if (i > 1)
                    {
                        PersonFirstName = personInfo.Substring(0, i);
                        PersonLastName = personInfo.Substring(i + 1);

                    }
                    else
                    {
                        PersonFirstName = practice.contact_person_name;
                        PersonLastName = " ";
                    }
                    parameter.Contact_PersonFirstName = PersonFirstName;
                    parameter.Contact_PersonLastName = PersonLastName;
                }
                var passwordForSave = "";

                if (!String.IsNullOrEmpty(practice.inPassword))
                {
                    passwordForSave = Util.CalculateMD5Hash(practice.inPassword);
                }

                parameter.PracticeID = new Guid(practice.id);
                parameter.Account_PasswordForEmail = practice.inPassword;
                parameter.Practice_Name = practice.name;
                parameter.BSNR = practice.bsnr;
                parameter.Street = practice.address;
                parameter.No = practice.No;
                parameter.Zip = practice.ZIP.ToString();
                parameter.City = practice.town;
                parameter.Main_Email = practice.email == null ? "" : practice.email;
                parameter.Main_Phone = practice.phone;
                parameter.Fax = practice.fax == null ? "" : practice.fax;
                parameter.Email = practice.contact_email == null ? "" : practice.contact_email;
                parameter.Phone = practice.phone == null ? "" : practice.phone;
                parameter.Account_Holder = practice.account_holder == null ? "" : practice.account_holder;
                parameter.BIC = practice.bic == null ? "" : practice.bic;
                parameter.IBAN = practice.iban == null ? "" : practice.iban;
                parameter.Bank = practice.bank == null ? "" : practice.bank;
                parameter.Login_Email = practice.login_email;
                parameter.Account_Password = passwordForSave;
                parameter.Surgery_Practice = practice.IsSurgeryPractice;
                parameter.Orders_Drugs = practice.IsOrderDrugs;
                parameter.Default_Shipping_Date_Offset = practice.default_shipping_date_offset.ToString();
                parameter.Only_Label_Required = practice.IsOnlyLabelRequired;
                parameter.Waive_Service_Fee = practice.isWaiveServiceFee;
                parameter.ShouldDownloadReportUponSubmission = practice.ShouldDownloadReportUponSubmission;
                parameter.PressEnterToSearch = practice.PressEnterToSearch;
                parameter.PracticeHasOctDevice = practice.PracticeHasOctDevice;
                parameter.DefaultPharmacy = String.IsNullOrEmpty(practice.DefaultPharmacy) ? Guid.Empty.ToString() : practice.DefaultPharmacy;
                parameter.IsQuickOrderActive = practice.IsQuickOrderActive;
                parameter.DeliveryDateFrom = practice.DeliveryDateFrom;
                parameter.DeliveryDateTo = practice.DeliveryDateTo;
                parameter.UseGracePeriod = practice.UseGracePeriod;
                #endregion

                Practice previous_state = null;
                Thread detailsThread = new Thread(() => GetPracticeAccountPreviousDetails(out previous_state, Guid.Parse(practice.id), connectionString, sessionTicket, request));

                #region UPDATE ELASTIC ON BASE CHANGE
                Guid practice_id = Guid.Empty;
                Guid.TryParse(practice.id, out practice_id);

                if (practice_id != Guid.Empty)
                {
                    var practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(connectionString, new P_DO_GPDfPID_1432() { PracticeID = practice_id }, securityTicket).Result.FirstOrDefault();
                    if (practice_details != null)
                    {
                        if (practice_details.practice_BSNR != practice.bsnr || practice_details.practice_name != practice.name)
                        {
                            elastic_backup = Elastic_Rollback.GetBackup(securityTicket.TenantID.ToString(), practice.id, "practice");

                            var values = new string[] {
                                practice.name,
                                practice.bsnr
                            };

                            var elastic_data = Elastic_Rollback.GetUpdatedData(securityTicket.TenantID.ToString(), practice.id.ToString(), "practice", values);

                            Elastic_Rollback.InsertDataIntoElastic(elastic_data, securityTicket.TenantID.ToString());
                        }
                    }
                }
                #endregion

                var data = cls_Save_Practice.Invoke(connectionString, parameter, securityTicket).Result;

                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, practice, previous_state), userData.PracticeName);
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), userData.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;

                if (elastic_backup != null)
                    Elastic_Rollback.InsertDataIntoElastic(elastic_backup, securityTicket.TenantID.ToString());
            }
        }

        public void RestartGracePeriod(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                if (data.DoctorID != Guid.Empty)
                {
                    cls_Save_Doctor_Grace_Period.Invoke(connectionString, new P_DO_SDGP_1639 { DoctorID = data.DoctorID, ResetGracePeriod = true }, securityTicket);
                }
                else
                {
                    cls_Save_Practice_Grace_Period.Invoke(connectionString, new P_DO_SPGP_0942 { PracticeID = data.PracticeID, ResetGracePeriod = true }, securityTicket);
                }
                
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, data), data.PracticeName);
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
        }
        #endregion

        #region UTIL
        private void GetDoctorAccountPreviousDetails(out Account previous_state, Guid id, string connectionString, string sessionTicket, HttpRequest request)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var data = Get_Doctor_DetailData(id, connectionString, sessionTicket, out transaction, request);

            previous_state = new Account()
            {
                account_holder = data.account_holder,
                address = data.address,
                bank_name = data.bank_name,
                bic = data.bic,
                email = data.email,
                first_name = data.first_name,
                iban = data.iban,
                id = data.id,
                is_bank_inherited = data.is_bank_inherited,
                lanr = data.lanr,
                last_name = data.last_name,
                login_email = data.login_email,
                password = data.password,
                phone = data.phone,
                practice = data.practice,
                practice_id = data.practice_id,
                salutation = data.salutation,
                title = data.title
            };
        }
        private void GetPracticeAccountPreviousDetails(out Practice previous_state, Guid id, string connectionString, string sessionTicket, HttpRequest request)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var data = Get_Practice_DetailData(id, connectionString, sessionTicket, out transaction, request);

            previous_state = new Practice()
            {
                account_holder = data.account_holder,
                address = data.address,
                bank = data.bank,
                bic = data.bic,
                bsnr = data.bsnr,
                contact_email = data.contact_email,
                contact_person_name = data.contact_person_name,
                contact_telephone = data.contact_telephone,
                default_shipping_date_offset = data.default_shipping_date_offset,
                email = data.email,
                fax = data.fax,
                iban = data.iban,
                id = data.id,
                IsOnlyLabelRequired = data.IsOnlyLabelRequired,
                IsOrderDrugs = data.IsOrderDrugs,
                IsSurgeryPractice = data.IsSurgeryPractice,
                isWaiveServiceFee = data.isWaiveServiceFee,
                login_email = data.login_email,
                name = data.name,
                No = data.address.Substring(data.address.LastIndexOf(' ') + 1),
                phone = data.phone,
                town = data.town.Substring(data.town.IndexOf(' ') + 1),
                ZIP = Convert.ToInt32(data.town.Substring(0, data.town.IndexOf(' '))),
                PressEnterToSearch = data.PressEnterToSearch,
                ShouldDownloadReportUponSubmission = data.ShouldDownloadReportUponSubmission,
                PracticeHasOctDevice = data.PracticeHasOctDevice
            };
        }
        #endregion
    }
}
