using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using DLCore_TokenVerification;
using MMDocConnectDBMethods.Doctor.Atomic.Manipulation;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Complex.Manipulation;
using MMDocConnectDBMethods.Patient.Atomic.Manipulation;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using CSV2Core.SessionSecurity;
using System.Web;
using System.Diagnostics;
using LogUtils;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using CL1_HEC_CRT;
using Newtonsoft.Json.Linq;
using MMDocConnectMMApp.Models;
using MMDocConnectDBMethods.Doctor.Model;

namespace MMDocConnectMMAppServices
{
    public class DoctorDataService : BaseVerification, IDoctorDataService
    {
        #region MANIPULATION
        public void CreatePractice(Practice practice, string connectionString, string sessionTicket, out TransactionalInformation transaction)
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
                P_DO_SP_1547 parameter = new P_DO_SP_1547();

                if (!String.IsNullOrEmpty(practice.ContactPerson))
                {
                    string PersonFirstName = "";
                    string PersonLastName = "";
                    string personInfo = practice.ContactPerson;

                    int i = personInfo.IndexOf(' ');
                    if (i > 1)
                    {
                        PersonFirstName = personInfo.Substring(0, i);
                        PersonLastName = personInfo.Substring(i + 1);

                    }
                    else
                    {
                        PersonFirstName = practice.ContactPerson;
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

                parameter.PracticeID = practice.PracticeID;
                parameter.Account_PasswordForEmail = practice.inPassword;
                parameter.Practice_Name = practice.PracticeName;
                parameter.BSNR = practice.BSNR;
                parameter.Street = practice.Street;
                parameter.No = practice.No;
                parameter.Zip = practice.Zip;
                parameter.City = practice.City;
                parameter.Main_Email = practice.MainEmail == null ? "" : practice.MainEmail;
                parameter.Main_Phone = practice.MainPhone;
                parameter.Fax = practice.Fax == null ? "" : practice.Fax;
                parameter.Email = practice.Email == null ? "" : practice.Email;
                parameter.Phone = practice.Phone == null ? "" : practice.Phone;
                parameter.Account_Holder = practice.AccountHolder == null ? "" : practice.AccountHolder;
                parameter.BIC = practice.Bic == null ? "" : practice.Bic;
                parameter.IBAN = practice.IBAN == null ? "" : practice.IBAN;
                parameter.Bank = practice.Bank == null ? "" : practice.Bank;
                parameter.Login_Email = practice.LoginEmail;
                parameter.Account_Password = passwordForSave;
                parameter.Surgery_Practice = practice.IsSurgeryPractice;
                parameter.Orders_Drugs = practice.IsOrderDrugs;
                parameter.Default_Shipping_Date_Offset = practice.DefaultShippingDateOffset;
                parameter.Only_Label_Required = practice.IsOnlyLabelRequired;
                parameter.Waive_Service_Fee = practice.isWaiveServiceFee;
                parameter.Account_Deactivated = practice.IsAccountDeactivated;
                parameter.Change_Doctor_Account_Statuses = practice.Change_Doctor_Account_Statuses;
                parameter.ShouldDownloadReportUponSubmission = practice.ShouldDownloadReportUponSubmission;
                parameter.PressEnterToSearch = practice.PressEnterToSearch;
                parameter.DefaultPharmacy = practice.DefaultPharmacy;
                parameter.IsQuickOrderActive = practice.IsQuickOrderActive;
                parameter.DeliveryDateFrom = practice.DeliveryDateFrom;
                parameter.DeliveryDateTo = practice.DeliveryDateTo;
                parameter.UseGracePeriod = practice.UseGracePeriod;
                #endregion

                Practice previous_state = null;

                if (practice.PracticeID != Guid.Empty)
                {
                    Thread detailsThread = new Thread(() => GetPracticePreviousDetails(out previous_state, parameter.PracticeID, connectionString, sessionTicket, request));
                    detailsThread.Start();
                }

                #region UPDATE ELASTIC ON BASE CHANGE
                if (practice.PracticeID != Guid.Empty)
                {
                    var practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(connectionString, new P_DO_GPDfPID_1432() { PracticeID = practice.PracticeID }, userSecurityTicket).Result.FirstOrDefault();
                    if (practice_details != null)
                    {
                        if (practice_details.practice_BSNR != practice.BSNR || practice_details.practice_name != practice.PracticeName)
                        {
                            elastic_backup = Elastic_Rollback.GetBackup(userSecurityTicket.TenantID.ToString(), practice.PracticeID.ToString(), "practice");

                            var values = new string[] {
                                practice.PracticeName,
                                practice.BSNR
                            };

                            var elastic_data = Elastic_Rollback.GetUpdatedData(userSecurityTicket.TenantID.ToString(), practice.PracticeID.ToString(), "practice", values);

                            Elastic_Rollback.InsertDataIntoElastic(elastic_data, userSecurityTicket.TenantID.ToString());
                        }
                    }
                }
                #endregion

                var data = cls_Save_Practice.Invoke(connectionString, parameter, userSecurityTicket).Result;
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, practice, previous_state));
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


        public Guid CreateDoctor(Doctor doctor, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            Guid result = Guid.Empty;
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
                parameter.Account_Holder = doctor.AccountHolder;
                parameter.Account_Password = passwordForSave;
                parameter.Bank = doctor.Bank;
                parameter.BIC = doctor.Bic;
                parameter.Email = doctor.Email;
                parameter.IBAN = doctor.Iban;
                parameter.First_Name = doctor.FirstName;
                parameter.Last_Name = doctor.LastNAme;
                parameter.LANR = doctor.LANR;
                parameter.Phone = doctor.Phone;
                parameter.PracticeID = doctor.PracticeID;
                parameter.Salutation = doctor.Salutation;
                parameter.Title = doctor.Title;
                parameter.Login_Email = doctor.LoginEmail;
                parameter.From_Practice_Bank = doctor.IsUserPRacticeBank;
                parameter.DoctorID = doctor.DoctorID;
                parameter.Account_Deactivated = doctor.IsAccountDeactivated;
                parameter.TemporaryDoctorID = doctor.TemporaryDoctorID;
                parameter.CustomerNumber = doctor.CustomerNumber;
                parameter.IsCertificatedForOCT = doctor.IsCertificatedForOCT;
                parameter.OctValidFrom = doctor.OctValidFrom;
                #endregion

                Doctor previous_state = null;

                if (doctor.DoctorID != Guid.Empty)
                {
                    Thread detailsThread = new Thread(() => GetDoctorPreviousDetails(out previous_state, parameter.DoctorID, connectionString, sessionTicket, request));
                    detailsThread.Start();
                }

                #region UPDATE ELASTIC ON BASE CHANGE
                if (doctor.DoctorID != Guid.Empty)
                {
                    var doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(connectionString, new P_DO_GDDfDID_0823() { DoctorID = doctor.DoctorID }, userSecurityTicket).Result.FirstOrDefault();
                    if (doctor_details != null)
                    {
                        if (doctor_details.first_name != doctor.FirstName || doctor_details.last_name != doctor.LastNAme || doctor_details.lanr != doctor.LANR || doctor_details.title != doctor.Title)
                        {

                            elastic_backup = Elastic_Rollback.GetBackup(userSecurityTicket.TenantID.ToString(), doctor.DoctorID.ToString(), "doctor");

                            var values = new string[] {
                            doctor.Title + " " + doctor.FirstName + " " + doctor.LastNAme,
                            doctor.LANR.ToString()
                        };

                            var elastic_data = Elastic_Rollback.GetUpdatedData(userSecurityTicket.TenantID.ToString(), doctor.DoctorID.ToString(), "doctor", values);

                            Elastic_Rollback.InsertDataIntoElastic(elastic_data, userSecurityTicket.TenantID.ToString());
                        }
                    }
                }
                #endregion

                result = cls_Save_Doctor.Invoke(connectionString, parameter, userSecurityTicket).Result;

                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, doctor, previous_state));

                #region UPDATE LAST USED AFTERCARE DOCTORS LIST
                var types = Elastic_Utils.GetAllTypes(userSecurityTicket.TenantID.ToString());

                HashSet<string> last_used_types = new HashSet<string>();

                var newTypes = types.Replace(userSecurityTicket.TenantID.ToString(), "allData");

                dynamic data = JObject.Parse(newTypes);
                var mappings = data.allData.mappings;
                foreach (var mappping in mappings)
                {
                    if (mappping.Name.Contains("user_"))
                    {
                        last_used_types.Add(mappping.Name);
                    }
                };

                foreach (var type in last_used_types)
                {
                    Practice_Doctor_Last_Used_Model last_used = new Practice_Doctor_Last_Used_Model();
                    try
                    {
                        last_used = Get_Practices_and_Doctors.GetLastUsedDoctorPracticeForID(doctor.DoctorID.ToString(), type, userSecurityTicket);
                        last_used.display_name = doctor.Title + " " + doctor.FirstName + " " + doctor.LastNAme + " (" + doctor.LANR + ")";

                        Add_New_Practice_Last_Used.Import_Practice_Last_Used_Data_to_ElasticDB(new List<Practice_Doctor_Last_Used_Model>() { last_used }, userSecurityTicket.TenantID.ToString(), type.Substring(5));
                    }
                    catch (Exception ex)
                    {
                        // left empty because it's not really an exception, rather a check whether object with given id exists 
                    }
                }
                #endregion
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

            return result;
        }

        public Guid MergeDoctor(Guid doctor_id, Guid temporary_doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            Guid result = Guid.Empty;
            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                Doctor previous_state = null;

                Thread previousDetailsThread = new Thread(() => GetDoctorPreviousDetails(out previous_state, doctor_id, connectionString, sessionTicket, request));
                previousDetailsThread.Start();

                result = cls_Merge_Doctor.Invoke(connectionString, new P_DO_MD_1321() { DoctorID = doctor_id, TemporaryDoctorID = temporary_doctor_id }, userSecurityTicket).Result;

                Thread logThread = new Thread(() => LogMergedDoctor(doctor_id, previous_state, ipInfo, method, userSecurityTicket, connectionString, sessionTicket, request));
                logThread.Start();
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

            return result;
        }

        public Guid SaveDoctorsConsent(DoctorContractConsent parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            var data = cls_Check_Doctor_Contracts_Dates.Invoke(connectionString, new P_DO_CDCD_1505() { DoctorID = parameter.doctorID }, userSecurityTicket).Result;

            try
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
                var consentStartDate = DateTime.Parse(parameter.consentStartDate, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                var consentEndDate = DateTime.MinValue;
                DateTime.TryParse(parameter.consentEndDate, culture, System.Globalization.DateTimeStyles.AssumeLocal, out consentEndDate);

                P_DO_SDtC_1228 doctorContractParameter = new P_DO_SDtC_1228();
                doctorContractParameter.ContractID = parameter.Contract.contractID;
                doctorContractParameter.DoctorID = parameter.doctorID;
                doctorContractParameter.ValidFrom = consentStartDate;
                doctorContractParameter.ValidThrough = consentEndDate == DateTime.MinValue ? parameter.Contract.ValidThrough == DateTime.MinValue ? DateTime.MinValue : parameter.Contract.ValidThrough : consentEndDate;
                doctorContractParameter.DoctorAssignment = parameter.assignmentID;

                var result = cls_Save_Doctor_to_Contract.Invoke(connectionString, doctorContractParameter, userSecurityTicket).Result;

                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, parameter, parameter.assignmentID != Guid.Empty ? data.Where(ctr => ctr.DoctorAssignment == parameter.assignmentID) : null));

                return result;
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

            return Guid.Empty;
        }
        #endregion

        #region RETRIEVAL
        public DoctorContractConsent GetDoctorsConsentDetails(Guid assignmentID, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var assignment = cls_Get_Doctors_Consent_Details_for_AssignmentID.Invoke(connectionString, new P_DO_GDCDfAID_1532() { AssignmentID = assignmentID }, userSecurityTicket).Result;
                if (assignment != null)
                {
                    return new DoctorContractConsent()
                    {
                        assignmentID = assignmentID,
                        consentStartDate = assignment.ConsentValidFrom.ToString("dd.MM.yyyy"),
                        consentEndDate = assignment.ConsentValidThrough == DateTime.MinValue ? "∞" : assignment.ConsentValidThrough.ToString("dd.MM.yyyy"),
                        doctorID = assignment.DoctorID,
                        contractName = assignment.ContractName,
                        Contract = new ContractDetails()
                        {
                            contractID = assignment.ContractID,
                            ContractName = assignment.ContractName,
                            ValidFrom = assignment.ContractValidFrom,
                            ValidThrough = assignment.ContractValidThrough
                        }
                    };
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
            }

            return new DoctorContractConsent();
        }
        public DO_GAPR_1342[] GetAllPractices(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            DO_GAPR_1342[] data = new DO_GAPR_1342[] { };
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                data = cls_Get_all_Practices.Invoke(connectionString, userSecurityTicket).Result;
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

            return data;
        }

        public List<Practice_Doctors_Model> GetDoctorPracticesList(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var data = new List<Practice_Doctors_Model>();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                data = Get_Practices_and_Doctors.Get_Doctors_and_PracticesList(sort_parameter, userSecurityTicket);
                return data;
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

            return data;
        }

        public List<Practice_Doctors_Model> GetDoctorsForPracticeID(Practice_Parameter Parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Practice_Doctors_Model> data = new List<Practice_Doctors_Model>();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                data = Get_Doctors_for_PracticeID.Get_Doctors_for_PracticeIDList(Parameter, userSecurityTicket);
                return data;
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

            return data;
        }

        public DO_GBAfPR_1524[] GetBankAccountInfoforPracticeID(P_DO_GBAfPR_1524 parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            DO_GBAfPR_1524[] data = new DO_GBAfPR_1524[] { };
            transaction = new TransactionalInformation();

            try
            {
                data = cls_Get_BankInfo_for_Practice.Invoke(connectionString, parameter, userSecurityTicket).Result;
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

            return data;

        }

        public DoctorDetail GetDoctorDetails(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest PreviousDetailsRequest = null)
        {
            var request = PreviousDetailsRequest != null ? PreviousDetailsRequest : HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            DoctorDetail doctor_detail = new DoctorDetail();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var data = cls_Get_Doctor_Details_for_DoctorID.Invoke(connectionString, new P_DO_GDDfDID_0823 { DoctorID = id }, userSecurityTicket).Result.Single();

                doctor_detail.address = data.address;
                doctor_detail.practice = data.practice;
                doctor_detail.bank_name = data.BankName;
                doctor_detail.bic = data.BICCode;
                if (data.DoctorComunication.Where(k => k.Type == "Phone").SingleOrDefault() != null)
                    doctor_detail.phone = data.DoctorComunication.Where(k => k.Type == "Phone").Single().Content;
                doctor_detail.fax = data.fax;
                doctor_detail.iban = data.IBAN;
                doctor_detail.id = data.id.ToString();
                doctor_detail.lanr = data.lanr;
                doctor_detail.name = data.name;
                doctor_detail.first_name = data.first_name;
                doctor_detail.town = data.town;
                doctor_detail.practice_id = data.practice_id;
                doctor_detail.salutation = data.salutation;
                doctor_detail.last_name = data.last_name;
                doctor_detail.title = data.title;

                if (data.DoctorComunication.Where(k => k.Type == "Email").SingleOrDefault() != null)
                    doctor_detail.email = data.DoctorComunication.Where(k => k.Type == "Email").Single().Content;

                var practice_bank_info = cls_Get_BankInfo_for_Practice.Invoke(connectionString, new P_DO_GBAfPR_1524() { PracticeID = data.practice_id }, userSecurityTicket).Result.FirstOrDefault();

                if (practice_bank_info != null)
                {
                    var doctor_bank_info = cls_Get_BankInfo_for_DoctorID.Invoke(connectionString, new P_DO_BBIfDID_1424() { DoctorID = data.id }, userSecurityTicket).Result;

                    if (doctor_bank_info != null)
                        doctor_detail.is_bank_inherited = doctor_bank_info.BankAccountID == practice_bank_info.BankAccountID;
                }

                doctor_detail.bank_name = data.BankName;
                doctor_detail.iban = data.IBAN;
                doctor_detail.bic = data.BICCode;
                doctor_detail.account_holder = data.OwnerText;
                doctor_detail.login_email = data.sign_in_email;

                var account = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(connectionString, new P_DO_GDAIDfDID_1549 { DoctorID = data.id }, userSecurityTicket).Result;
                if (account != null)
                {
                    IAccountServiceProvider accountService;
                    var _providerFactory = ProviderFactory.Instance;
                    accountService = _providerFactory.CreateAccountServiceProvider();

                    doctor_detail.account_deactivated = accountService.GetAccountStatusHistory(userSecurityTicket.TenantID, account.accountID).OrderBy(st => st.CreationTimestamp).Reverse().FirstOrDefault().Status == EAccountStatus.BANNED;
                }
                doctor_detail.is_temp = data.doctor_account_id == Guid.Empty;
                if (doctor_detail.is_temp)
                {

                    var comment = cls_Get_Temporary_Doctor_Comment_for_DoctorID.Invoke(connectionString, new P_DO_GTDCfDID_1452() { DoctorID = id }, userSecurityTicket).Result;
                    doctor_detail.comment = comment != null ? comment.Comment : "";
                }

                var doctor_properties = cls_Get_Doctors_Properties_for_DoctorID.Invoke(connectionString, new P_DO_GDPfDID_1016 { DoctorID = id }, userSecurityTicket).Result;

                var customer_number = doctor_properties.SingleOrDefault(x => x.GlobalPropertyMatchingID == EDoctorPropertyType.CustomerNumber.Value()); 
                doctor_detail.customer_number = customer_number != null ? customer_number.Value_String : null;

                var is_certificated_for_oct = doctor_properties.SingleOrDefault(x => x.GlobalPropertyMatchingID == EDoctorPropertyType.OctCertificated.Value()); 
                doctor_detail.is_certificated_for_oct = is_certificated_for_oct != null ? is_certificated_for_oct.Value_Boolean : false;

                var oct_valid_from = doctor_properties.SingleOrDefault(x => x.GlobalPropertyMatchingID == EDoctorPropertyType.OctValidFrom.Value());
                doctor_detail.oct_valid_from = oct_valid_from != null ? oct_valid_from.Value_String : null;
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

            return doctor_detail;
        }


        public PracticeDetails GetPracticeDetails(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest PreviousDetailsRequest = null)
        {
            HttpRequest request = null;
            if (PreviousDetailsRequest == null)
                request = HttpContext.Current.Request;
            else
                request = PreviousDetailsRequest;

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            PracticeDetails practice_details = new PracticeDetails();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var data = cls_Get_Practice_Details_for_PracticeID.Invoke(connectionString, new P_DO_GPDfPID_1432 { PracticeID = id }, userSecurityTicket).Result;

                foreach (var practice in data)
                {
                    if (practice.is_company)
                    {
                        practice_details.address = practice.practice_address;
                        practice_details.bank = practice.practice_bank_name;
                        practice_details.bic = practice.practice_bank_BIC;
                        practice_details.bsnr = practice.practice_BSNR;

                        practice_details.email = practice.contact_email;
                        practice_details.fax = practice.contact_fax;
                        practice_details.iban = practice.practice_IBAN;
                        practice_details.id = practice.practiceID.ToString();
                        practice_details.phone = practice.contact_telephone;
                        practice_details.name = practice.practice_name;
                        practice_details.town = practice.practice_town;
                        practice_details.account_holder = practice.account_holder;

                        if (practice.IsValue_Number)
                        {
                            if (practice.PropertyName.Equals("Default Shipping Date Offset"))
                                practice_details.default_shipping_date_offset = practice.Value_Number;
                        }

                        if (practice.IsValue_Boolean)
                        {
                            if (practice.PropertyName.Equals("Waive Service Fee"))
                                practice_details.is_waive_service_fee = practice.Value_Boolean;
                            if (practice.PropertyName.Equals("Order Drugs"))
                                practice_details.is_order_drugs = practice.Value_Boolean;
                            if (practice.PropertyName.Equals("Surgery Practice"))
                                practice_details.is_surgery_practice = practice.Value_Boolean;
                            if (practice.PropertyName.Equals("Only Label Required"))
                                practice_details.is_only_label_required = practice.Value_Boolean;
                        }
                    }
                    else
                    {
                        practice_details.contact = new contact_person()
                        {
                            email = practice.contact_email,
                            name = practice.contact_person_name,
                            phone = practice.contact_telephone
                        };
                    }
                }
                var shouldDownloadReportProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString, new P_DO_GPPVfPNaPID_0916() { PracticeID = id, PropertyName = "Download Report Upon Submission" }, userSecurityTicket).Result;
                if (shouldDownloadReportProperty != null)
                    practice_details.shouldDownloadReportUponSubmission = shouldDownloadReportProperty.BooleanValue;

                var pressEnterToSearchProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString, new P_DO_GPPVfPNaPID_0916() { PracticeID = id, PropertyName = "Press enter to search" }, userSecurityTicket).Result;
                if (pressEnterToSearchProperty != null)
                {
                    practice_details.pressEnterToSearch = pressEnterToSearchProperty.BooleanValue;
                }

                #region pharmacy
                var defaultPharmacyProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString, new P_DO_GPPVfPNaPID_0916()
                {
                    PracticeID = id,
                    PropertyName = "Default pharmacy"
                }, userSecurityTicket).Result;
                if (defaultPharmacyProperty != null)
                {
                    practice_details.defaultPharmacy = string.IsNullOrEmpty(defaultPharmacyProperty.TextValue) ? Guid.Empty.ToString() : defaultPharmacyProperty.TextValue;
                }
                else
                {
                    practice_details.defaultPharmacy = Guid.Empty.ToString();
                }

                var quickOrderProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString, new P_DO_GPPVfPNaPID_0916()
                {
                    PracticeID = id,
                    PropertyName = "Quick order"
                }, userSecurityTicket).Result;
                if (quickOrderProperty != null)
                {
                    practice_details.isQuickOrderActive = quickOrderProperty.BooleanValue;
                }

                var deliveryDateFromProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString, new P_DO_GPPVfPNaPID_0916()
                {
                    PracticeID = id,
                    PropertyName = "Delivery date from"
                }, userSecurityTicket).Result;
                if (quickOrderProperty != null)
                {
                    practice_details.deliveryDateFrom = deliveryDateFromProperty.TextValue;
                }

                var deliveryDateToProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString, new P_DO_GPPVfPNaPID_0916()
                {
                    PracticeID = id,
                    PropertyName = "Delivery date to"
                }, userSecurityTicket).Result;
                if (quickOrderProperty != null)
                {
                    practice_details.deliveryDateTo = deliveryDateToProperty.TextValue;
                }

                var gracePeriodProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(connectionString, new P_DO_GPPVfPNaPID_0916()
                {
                    PracticeID = id,
                    PropertyName = "Grace period"
                }, userSecurityTicket).Result;
                if (gracePeriodProperty != null)
                {
                    practice_details.useGracePeriod = gracePeriodProperty.BooleanValue;
                }

                #endregion

                var accountID = cls_Get_Practice_AccountID_for_PracticeID.Invoke(connectionString, new P_DO_GPAIDfPID_1351() { PracticeID = id }, userSecurityTicket).Result.accountID;

                IAccountServiceProvider accountService;
                var _providerFactory = ProviderFactory.Instance;
                accountService = _providerFactory.CreateAccountServiceProvider();

                practice_details.login_email = data.First().sign_in_email;
                practice_details.account_deactivated = accountService.GetAccountStatusHistory(userSecurityTicket.TenantID, accountID).OrderBy(st => st.CreationTimestamp).Reverse().FirstOrDefault().Status == EAccountStatus.BANNED;
                practice_details.practice_has_doctors = cls_Get_DoctorIDs_for_PracticeID.Invoke(connectionString, new P_DO_GDIDsfPID_1635() { PracticeID = id }, userSecurityTicket).Result.FirstOrDefault() != null;
                practice_details.doctor_count = Get_Doctors_for_PracticeID.Get_Doctors_Count(id.ToString(), userSecurityTicket);
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

            return practice_details;
        }


        public DO_GCfD_1548[] ContractsForDropDown(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            DO_GCfD_1548[] data = new DO_GCfD_1548[] { };
            try
            {
                data = cls_Get_Contracts_for_Doctor.Invoke(connectionString, userSecurityTicket).Result.OrderBy(pr => pr.ContractName).ToArray();
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
            return data;
        }
        public List<objDoc> Get_Contracts_for_DoctorID(objDoc ObjDoc, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            DO_GDfCL_0902[] data;
            List<objDoc> DoctorContractsList = new List<objDoc>();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                P_DO_GDfCL_0902 Parameter = new P_DO_GDfCL_0902();
                Parameter.DoctorID = ObjDoc.DocId;
                Guid ContractID = Guid.NewGuid();
                data = cls_Get_Doctor_Contract_for_List.Invoke(connectionString, Parameter, userSecurityTicket).Result;
                if (data.Length > 0)
                {
                    foreach (var item in data)
                    {
                        ContractID = item.CMN_CTR_ContractID;

                        objDoc DoctorContracts = new objDoc();
                        DoctorContracts.ContractName = item.ContractName;
                        DoctorContracts.ValidFrom = item.ValidFrom;
                        DoctorContracts.ValidThrough = item.ValidThrough;
                        DoctorContracts.ContractID = ContractID;
                        DoctorContracts.DoctorAssignment = item.DoctorAssignment;
                        DoctorContracts.ContractAssignment = item.HEC_CRT_InsuranceToBrokerContractID;

                        if (item.HIP.Length == 0)
                            DoctorContracts.HIP = "-";

                        foreach (var hip in item.HIP)
                        {
                            if (DoctorContracts.HIP == null)
                            {
                                DoctorContracts.HIP = hip.DisplayName;
                            }
                            else
                            {
                                DoctorContracts.HIP = DoctorContracts.HIP + ", " + hip.DisplayName;
                            }
                        }
                        DoctorContractsList.Add(DoctorContracts);

                    }
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
            }

            return DoctorContractsList;
        }
        #endregion

        #region VALIDATION
        public bool CheckBsnr(Guid practice_id, string Bsnr, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            bool exists = false;
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                P_DO_CB_1453 ParameterCheckBsnr = new P_DO_CB_1453();
                ParameterCheckBsnr.Bsnr = Bsnr;
                ParameterCheckBsnr.PracticeID = practice_id;

                exists = cls_Check_Bsnr.Invoke(connectionString, ParameterCheckBsnr, userSecurityTicket).Result.FirstOrDefault() != null;
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

            return exists;
        }


        public bool CheckLanr(Guid doctor_id, Guid practice_id, string Lanr, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                P_DO_CL_1212 ParameterCheckLanr = new P_DO_CL_1212();
                ParameterCheckLanr.Lanr = Lanr;
                ParameterCheckLanr.DoctorID = doctor_id;
                ParameterCheckLanr.PracticeID = practice_id;

                return cls_Check_Lanr.Invoke(connectionString, ParameterCheckLanr, userSecurityTicket).Result != null;
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

            return false;
        }

        public bool CheckLoginEmail(Guid id, string type, string login_email, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            bool result = false;
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {

                result = cls_Check_LoginEmail.Invoke(connectionString, new P_DO_CLE_1414()
                {
                    LoginEmail = login_email,
                    ID = id,
                    Type = type
                }, userSecurityTicket).Result.EMailExists;
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

            return result;
        }

        public List<Bic_Iban_Codes> CheckIban(IBAN_Parameter iban, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Bic_Iban_Codes> data = new List<Bic_Iban_Codes>();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                data = Iban_Bic_Validation.Check_IBAN(iban, userSecurityTicket);
                return data;
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

            return data;
        }
        // List<Bic_Iban_Codes> CheckBicBank(Bic_Parameter Bic, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        public List<Bic_Iban_Codes> CheckBicBank(Bic_Parameter Bic, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {

            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Bic_Iban_Codes> data = new List<Bic_Iban_Codes>();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                data = Iban_Bic_Validation.CheckBicBank(Bic, userSecurityTicket);
                return data;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.IsAuthenicated = true;
                transaction.IsException = true;
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }

            return data;
        }


        public LanrValidationResponse CheckLanrForMerge(string lanr, Guid practice_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            LanrValidationResponse response = new LanrValidationResponse();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var doctors = cls_Check_Lanr_for_Merge.Invoke(connectionString, new P_DO_CLfM_1152() { Lanr = lanr, PracticeID = practice_id }, userSecurityTicket).Result;

                if (doctors.Length != 0)
                {
                    response.exists = true;
                    response.doctors = doctors.Select(doc =>
                    {
                        var doctor = new LanrValidationDoctorDetails()
                        {
                            doctor_id = doc.doctor_id,
                            doctor_name = doc.doctor_name,
                            practice_name = doc.practice_name
                        };

                        return doctor;
                    }).ToArray();
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
            }

            return response;
        }

        public IEnumerable<ContractOverlapsValidationResponse> ValidateContractOverlaps(DoctorContractConsent parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var doctorAssignments = cls_Get_Doctors_Assignments_on_Contract.Invoke(connectionString, new P_DO_GDAoC_1337() { ContractID = parameter.Contract.contractID, DoctorID = parameter.doctorID }, userSecurityTicket).Result;
                if (doctorAssignments.Length == 0)
                {
                    return new List<ContractOverlapsValidationResponse>();
                }
                else
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
                    var consentStartDate = DateTime.Parse(parameter.consentStartDate, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    var consentEndDate = DateTime.MaxValue;
                    if (!DateTime.TryParse(parameter.consentEndDate, culture, System.Globalization.DateTimeStyles.AssumeLocal, out consentEndDate))
                        consentEndDate = DateTime.MaxValue;

                    var overlaps = doctorAssignments.Where(da =>
                        da.AssignmentID != parameter.assignmentID && (
                       (da.ConsentValidThrough > consentStartDate || da.ConsentValidThrough == DateTime.MinValue) &&
                       (da.ConsentValidFrom <= consentStartDate ||
                        da.ConsentValidFrom < consentEndDate) ||
                       (da.ConsentValidThrough == DateTime.MinValue && consentEndDate == DateTime.MaxValue))
                    ).ToArray();

                    return overlaps.Select(overlap =>
                    {
                        return new ContractOverlapsValidationResponse()
                        {
                            consentContractName = overlap.ConsentContractName,
                            consentValidFrom = overlap.ConsentValidFrom.ToString("dd.MM.yyyy"),
                            consentValidThrough = overlap.ConsentValidThrough == DateTime.MinValue ? "∞" : overlap.ConsentValidThrough.ToString("dd.MM.yyyy")
                        };
                    }).ToList();
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
            }

            return new List<ContractOverlapsValidationResponse>();
        }
        #endregion

        #region UTIL
        private static void GetDoctorPreviousDetails(out Doctor previous_state, Guid id, string connectionString, string sessionTicket, HttpRequest request)
        {
            var transaction = new TransactionalInformation();
            var dd = new DoctorDataService();

            var previous_details = dd.GetDoctorDetails(id, connectionString, sessionTicket, out transaction, request);
            previous_state = new Doctor()
            {
                AccountHolder = previous_details.account_holder,
                Bank = previous_details.bank_name,
                Bic = previous_details.bic,
                DoctorID = id,
                Email = previous_details.email,
                FirstName = previous_details.first_name,
                LastNAme = previous_details.last_name,
                Iban = previous_details.iban,
                IsAccountDeactivated = previous_details.account_deactivated,
                IsUserPRacticeBank = previous_details.is_bank_inherited,
                LANR = previous_details.lanr,
                LoginEmail = previous_details.login_email,
                Phone = previous_details.phone,
                PracticeID = previous_details.practice_id,
                Salutation = previous_details.salutation,
                TemporaryDoctorID = previous_details.is_temp ? Guid.Parse(previous_details.id) : Guid.Empty,
                Title = previous_details.title
            };
        }

        private static void GetPracticePreviousDetails(out Practice previous_state, Guid id, string connectionString, string sessionTicket, HttpRequest request)
        {
            var transaction = new TransactionalInformation();
            var dd = new DoctorDataService();

            var previous_details = dd.GetPracticeDetails(id, connectionString, sessionTicket, out transaction, request);
            previous_state = new Practice()
            {
                AccountHolder = previous_details.account_holder,
                Bank = previous_details.bank,
                Bic = previous_details.bic,
                BSNR = previous_details.bsnr,
                City = previous_details.town,
                ContactPerson = previous_details.contact.name,
                DefaultShippingDateOffset = previous_details.default_shipping_date_offset.ToString(),
                Email = previous_details.contact.email,
                Fax = previous_details.fax,
                IBAN = previous_details.iban,
                IsAccountDeactivated = previous_details.account_deactivated,
                IsOnlyLabelRequired = previous_details.is_only_label_required,
                IsOrderDrugs = previous_details.is_order_drugs,
                IsSurgeryPractice = previous_details.is_surgery_practice,
                isWaiveServiceFee = previous_details.is_waive_service_fee,
                LoginEmail = previous_details.login_email,
                MainEmail = previous_details.email,
                MainPhone = previous_details.phone,
                Phone = previous_details.contact.phone,
                PracticeID = id,
                PracticeName = previous_details.name,
                Street = previous_details.address.Substring(0, previous_details.address.LastIndexOf(' ')),
                No = previous_details.address.Substring(previous_details.address.LastIndexOf(' ') + 1)
            };
        }

        private void LogMergedDoctor(Guid doctor_id, Doctor previous_state, IPInfo ipInfo, MethodBase method, SessionSecurityTicket userSecurityTicket, string connectionString, string sessionTicket, HttpRequest request)
        {
            Doctor current_state = null;
            GetDoctorPreviousDetails(out current_state, doctor_id, connectionString, sessionTicket, request);

            Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, current_state, previous_state));
        }

        #endregion
    }
}
