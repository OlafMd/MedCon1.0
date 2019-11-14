using CSV2Core.SessionSecurity;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDocAppInterfaces;
using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Linq;
using CL1_HEC_CRT;
using CL1_CMN_CTR;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;

namespace MMDocConnectDocAppServices
{
    [Obsolete("Use OctService instead, this class should be used only if there were some issues with first octs (pre-examinations)")]
    public class PreexaminationDataService : BaseVerification, IPreexaminationDataService
    {
        IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

        #region MANIPULATION
        public void SavePreexamination(Case preexamination, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                Case previousPreexaminationData = null;
                if (preexamination.case_id != Guid.Empty)
                {
                    previousPreexaminationData = new SettlementDataService().GetCaseDetailsforCaseID(preexamination.case_id, connectionString, sessionTicket, out transaction);
                }

                cls_Save_Preexamination.Invoke(connectionString, new P_CAS_SP_1436()
                {
                    case_id = preexamination.case_id,
                    treatment_date = DateTime.Parse(preexamination.treatment_date, culture, System.Globalization.DateTimeStyles.AssumeLocal),
                    is_left_eye = preexamination.is_left_eye,
                    patient_id = preexamination.patient_id,
                    treatment_doctor_id = preexamination.treatment_doctor_id
                }, securityTicket);

                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, preexamination, previousPreexaminationData), data.PracticeName);
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

        #region VALIDATION
        public object ValidateAndSubmitPreexaminationData(Preexamination preexaminationData, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            try
            {
                List<object> reasons = new List<object>();
                if (preexaminationData.shouldSubmit && !preexaminationData.isResubmit)
                {
                    var passwordTransaction = new TransactionalInformation();
                    var password_verified = new MainDataService().VerifyDoctorPassword(connectionString, preexaminationData.password, preexaminationData.doctor_id, sessionTicket, out passwordTransaction);

                    if (!password_verified)
                    {
                        reasons.Add(new { label = "LABEL_CREDENTIALS_NOT_VERIFIED" });
                        return new { canSubmit = false, reasons = reasons };
                    }
                }

                var preexaminationDate = DateTime.Parse(preexaminationData.date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                if (preexaminationDate.Date > DateTime.Now.Date)
                {
                    reasons.Add(new { label = "LABEL_PREEXAMINATION_DATE_CANNOT_BE_IN_THE_FUTURE" });
                    return new { canSubmit = false, reasons = reasons };
                }

                var contracts = cls_Get_InsuranceToBrokerContractIDs_for_Contracts_with_Preexamination.Invoke(connectionString, securityTicket).Result;

                reasons.AddRange(DoctorHasConsent(contracts, preexaminationData.doctor_id, preexaminationDate, connectionString, securityTicket));
                reasons.AddRange(PatientHasConsent(contracts, preexaminationData.patient_id, preexaminationDate, connectionString, securityTicket));

                if (!preexaminationData.isResubmit)
                    reasons.AddRange(PatientExceededPreexaminationLimit(contracts, preexaminationData.patient_id, preexaminationDate, preexaminationData.is_left_eye ? "L" : "R", connectionString, securityTicket));

                if (reasons.Any())
                    return new { canSubmit = !reasons.Any(), reasons = reasons };

                var downloadUrl = "";

                if (preexaminationData.shouldSubmit)
                {
                    downloadUrl = cls_Submit_Preexamination.Invoke(connectionString, new P_CAS_SPE_1805()
                     {
                         date = preexaminationDate,
                         doctor_id = preexaminationData.doctor_id,
                         patient_id = preexaminationData.patient_id,
                         localization = preexaminationData.is_left_eye ? "L" : "R",
                         case_id = preexaminationData.case_id,
                         isResubmit = preexaminationData.isResubmit
                     }, securityTicket).Result.ReportUrl;
                }

                return new { canSubmit = true, downloadUrl = downloadUrl };
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

        #region Validation util
        private IEnumerable<object> DoctorHasConsent(MD_GITBCIDSfCwPE_1558[] contracts, Guid doctor_id, DateTime date, string connectionString, SessionSecurityTicket securityTicket)
        {
            var doctorHasNoConsentOnAnyPreexaminationContract = true;
            List<object> consentTimespanErrors = new List<object>();
            foreach (var contract in contracts)
            {
                var consents = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query.Search(connectionString, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    InsuranceToBrokerContract_RefID = contract.InsuranceToBrokerContractID,
                    Doctor_RefID = doctor_id
                });

                if (!consents.Any())
                    continue;

                doctorHasNoConsentOnAnyPreexaminationContract = false;
                var hasConsent = consents.Any(t =>
                {
                    var validThrough = t.ValidThrough == DateTime.MinValue ? DateTime.MaxValue : t.ValidThrough;
                    return t.ValidFrom <= date && validThrough >= date;
                });

                if (!hasConsent)
                {
                    var consentTimespan = "-";
                    var filteredConsentsThatStartBefore = consents.Where(t => t.ValidFrom <= date);
                    ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctor consent = null;
                    if (filteredConsentsThatStartBefore.Any())
                    {
                        filteredConsentsThatStartBefore = filteredConsentsThatStartBefore.OrderBy(t => t.ValidFrom);
                        consent = filteredConsentsThatStartBefore.Where(t => t.ValidThrough == DateTime.MinValue || t.ValidThrough >= date).FirstOrDefault();
                        if (consent == null)
                            consent = filteredConsentsThatStartBefore.Last();

                    }
                    else
                    {
                        consent = consents.OrderBy(t => t.ValidFrom).First();
                    }

                    var validThrough = consent.ValidThrough != DateTime.MinValue ? consent.ValidThrough.ToString("dd.MM.yyyy") : "∞";
                    consentTimespan = consent.ValidFrom.ToString("dd.MM.yyyy") + " - " + validThrough;

                    consentTimespanErrors.Add(
                        new
                        {
                            label = "LABEL_DOCTOR_HAS_NO_CONSENT_ON_CONTRACT_WITH_PREEXAMINATION_ON_SELECTED_DATE",
                            values = new
                            {
                                consentTimespan = consentTimespan
                            }
                        }
                    );
                }
                else
                {
                    return Enumerable.Empty<object>();
                }
            }
            if (!doctorHasNoConsentOnAnyPreexaminationContract)
                return Enumerable.Empty<object>();

            if (consentTimespanErrors.Any())
                return consentTimespanErrors.Take(1);

            return new List<object>() 
                    { 
                        new { 
                            label = "LABEL_DOCTOR_HAS_NO_CONSENT_ON_CONTRACT_WITH_PREEXAMINATION", 
                            values = new { 
                                consentTimespan = "-"
                            } 
                        } 
                    };
        }

        private IEnumerable<object> PatientHasConsent(MD_GITBCIDSfCwPE_1558[] contracts, Guid patient_id, DateTime date, string connectionString, SessionSecurityTicket securityTicket)
        {
            var patientHasNoConsentOnAnyPreexaminationContract = true;
            List<object> consentTimespanErrors = new List<object>();
            foreach (var contract in contracts)
            {
                var consents = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(connectionString, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    InsuranceToBrokerContract_RefID = contract.InsuranceToBrokerContractID,
                    Patient_RefID = patient_id
                });

                if (!consents.Any())
                    continue;

                patientHasNoConsentOnAnyPreexaminationContract = false;

                var hasConsent = consents.Any(t =>
                {
                    var ctrParameter = cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID.Invoke(connectionString, new P_MD_GCPVfITBCID_1647()
                    {
                        ParameterName = "Duration of participation consent – Month",
                        InsuranceToBrokerContractID = t.InsuranceToBrokerContract_RefID
                    }, securityTicket).Result;

                    var validThrough = ctrParameter == null || ctrParameter.ConsentValidForMonths == double.MaxValue ? DateTime.MaxValue : t.ValidFrom.AddMonths(Convert.ToInt32(ctrParameter.ConsentValidForMonths));
                    return t.ValidFrom <= date && validThrough >= date;
                });

                if (!hasConsent)
                {
                    var consentTimespan = "-";
                    var filteredConsentsThatStartBefore = consents.Where(t => t.ValidFrom <= date);
                    ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient consent = null;
                    if (filteredConsentsThatStartBefore.Any())
                    {
                        filteredConsentsThatStartBefore = filteredConsentsThatStartBefore.OrderBy(t => t.ValidFrom);
                        consent = filteredConsentsThatStartBefore.Where(t => t.ValidThrough == DateTime.MinValue || t.ValidThrough >= date).FirstOrDefault();
                        if (consent == null)
                            consent = filteredConsentsThatStartBefore.Last();

                    }
                    else
                    {
                        consent = consents.OrderBy(t => t.ValidFrom).First();
                    }

                    var ctrParameter = cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID.Invoke(connectionString, new P_MD_GCPVfITBCID_1647()
                    {
                        ParameterName = "Duration of participation consent – Month",
                        InsuranceToBrokerContractID = consent.InsuranceToBrokerContract_RefID
                    }, securityTicket).Result;

                    var validThrough = ctrParameter != null && ctrParameter.ConsentValidForMonths != Double.MaxValue ? consent.ValidFrom.AddMonths(Convert.ToInt32(ctrParameter.ConsentValidForMonths)).ToString("dd.MM.yyyy") : "∞";
                    consentTimespan = consent.ValidFrom.ToString("dd.MM.yyyy") + " - " + validThrough;

                    consentTimespanErrors.Add(
                        new
                        {
                            label = "LABEL_PATIENT_HAS_NO_CONSENT_ON_CONTRACT_WITH_PREEXAMINATION_ON_SELECTED_DATE",
                            values = new
                            {
                                consentTimespan = consentTimespan
                            }
                        }
                    );
                }
                else
                {
                    return Enumerable.Empty<object>();
                }
            }

            if (!patientHasNoConsentOnAnyPreexaminationContract)
                return Enumerable.Empty<object>();

            if (consentTimespanErrors.Any())
                return consentTimespanErrors.Take(1);

            return new List<object>() 
            { 
                new { 
                        label = "LABEL_PATIENT_HAS_NO_CONSENT_ON_CONTRACT_WITH_PREEXAMINATION", 
                        values = new { 
                        consentTimespan = "-"
                    } 
                } 
            };
        }

        private IEnumerable<object> PatientExceededPreexaminationLimit(MD_GITBCIDSfCwPE_1558[] contracts, Guid patient_id, DateTime date, string localization_code, string connectionString, SessionSecurityTicket securityTicket)
        {
            var preexaminationDates = cls_Get_PreexaminationDates_for_PatientID_And_Localization.Invoke(connectionString, new P_PA_GPDfPIDaL_1559 { Localization = localization_code, PatientID = patient_id }, securityTicket).Result;
            if (preexaminationDates.Any())
            {
                var contract_id = Guid.Empty;
                foreach (var ctr in contracts)
                {
                    var consents = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(connectionString, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                    {
                        Patient_RefID = patient_id,
                        InsuranceToBrokerContract_RefID = ctr.InsuranceToBrokerContractID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    if (consents.Any(t => t.ValidFrom.Date <= date.Date))
                    {
                        contract_id = ORM_HEC_CRT_InsuranceToBrokerContract.Query.Search(connectionString, new ORM_HEC_CRT_InsuranceToBrokerContract.Query()
                        {
                            HEC_CRT_InsuranceToBrokerContractID = ctr.InsuranceToBrokerContractID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single().Ext_CMN_CTR_Contract_RefID;
                    }
                }

                if (contract_id != Guid.Empty)
                {
                    var due_dates = cls_Get_Due_Dates_for_ContractID.Invoke(connectionString, new P_MD_GDDfCID_1544() { ContractID = contract_id }, securityTicket).Result;
                    var max_number_of_preexaminations = due_dates.SingleOrDefault(dd => dd.Name == "Max number of preexaminations");
                    var number_of_days_for_preexaminations = due_dates.SingleOrDefault(dd => dd.Name == "Preexaminations - Days");
                    if (max_number_of_preexaminations != null && number_of_days_for_preexaminations != null && max_number_of_preexaminations.Value != double.MaxValue && number_of_days_for_preexaminations.Value != double.MaxValue)
                    {
                        Dictionary<DateTime, List<DateTime>> allTimespans = new Dictionary<DateTime, List<DateTime>>();
                        var e = preexaminationDates.GetEnumerator();
                        e.MoveNext();
                        var firstPreexamination = ((PA_GPDfPIDaL_1559)e.Current).PreexaminationDate.Date;
                        var timespan = firstPreexamination.AddDays(Convert.ToInt32(number_of_days_for_preexaminations.Value));
                        allTimespans.Add(firstPreexamination, new List<DateTime>() { firstPreexamination });

                        while (e.MoveNext())
                        {
                            if (((PA_GPDfPIDaL_1559)e.Current).PreexaminationDate.Date <= timespan)
                            {
                                allTimespans[firstPreexamination].Add(((PA_GPDfPIDaL_1559)e.Current).PreexaminationDate.Date);
                            }
                            else
                            {
                                firstPreexamination = timespan = timespan.AddDays(Convert.ToInt32(number_of_days_for_preexaminations.Value));
                                allTimespans.Add(firstPreexamination, new List<DateTime>() { ((PA_GPDfPIDaL_1559)e.Current).PreexaminationDate.Date });
                            }
                        }

                        var preDateTimespans = allTimespans.Where(t => t.Key <= date && t.Key.AddDays(Convert.ToInt32(number_of_days_for_preexaminations.Value)) >= date).ToDictionary(t => t.Key, t => t.Value);
                        var afterDateTimespan = allTimespans.FirstOrDefault(t => date <= t.Key.Date);

                        foreach (var t in preDateTimespans)
                        {
                            if (t.Key.Date.AddDays(Convert.ToInt32(number_of_days_for_preexaminations.Value)) >= date.Date || date.Date.AddDays(Convert.ToInt32(number_of_days_for_preexaminations.Value)) >= t.Key)
                            {
                                if (t.Value.Count >= max_number_of_preexaminations.Value)
                                {
                                    return new List<object>() 
                                    { 
                                        new 
                                        { 
                                            label = "LABEL_PATIENT_PREEXAMINATION_LIMIT_EXCEEDED", 
                                            values = new 
                                            { 
                                                consentTimespan = "-"
                                            }    
                                        } 
                                    };
                                }
                            }
                        }

                        if (afterDateTimespan.Value != null && afterDateTimespan.Key <= date.AddDays(Convert.ToInt32(number_of_days_for_preexaminations.Value)) && afterDateTimespan.Value.Count >= max_number_of_preexaminations.Value)
                        {
                            return new List<object>() 
                                { 
                                    new 
                                    { 
                                        label = "LABEL_PATIENT_PREEXAMINATION_LIMIT_EXCEEDED", 
                                        values = new 
                                        { 
                                            consentTimespan = "-"
                                        } 
                                    } 
                                };

                        }
                    }
                }
            }

            return Enumerable.Empty<object>();
        }

        #endregion

        #endregion


    }
}
