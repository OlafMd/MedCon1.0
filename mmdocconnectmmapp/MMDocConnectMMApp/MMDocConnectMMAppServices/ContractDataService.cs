using BOp.Exceptions;
using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CL1_CMN_CTR;
using CL1_USR;
using CSV2Core.SessionSecurity;
using CSV2Core_MySQL.Support;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Manipulation;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Manipulation;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectElasticSearchMethods.HIP.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;


namespace MMDocConnectMMAppServices
{
    public class ContractDataService : BaseVerification, IContractDataService
    {
        #region RETRIEVAL
        public List<ContractViewModel> GetAllContracts(string sort_by, bool ascending, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            List<ContractViewModel> response = new List<ContractViewModel>();

            try
            {
                Func<MD_GAC_1454, Object> orderByFunc = null;
                switch (sort_by)
                {
                    case "contract_name":
                        orderByFunc = item => item.ContractName;
                        break;
                    case "valid_from":
                        orderByFunc = item => item.ValidFrom;
                        break;
                    case "valid_through":
                        orderByFunc = item => item.ValidThrough;
                        break;
                    case "hip_names":
                        orderByFunc = item => item.HIPNames;
                        break;
                }

                var contracts = cls_Get_All_Contracts.Invoke(connectionString, securityTicket).Result.OrderBy(orderByFunc).ToList();
                if (contracts.Count() != 0)
                {
                    if (!ascending)
                        contracts.Reverse();

                    response = contracts.Select(ctr =>
                    {
                        var valid_through = ctr.ValidThrough == DateTime.MinValue ? "∞" : ctr.ValidThrough.ToString("dd.MM.yyyy");
                        return new ContractViewModel()
                        {
                            contract_id = ctr.ContractID,
                            contract_name = ctr.ContractName,
                            contract_valid_from = ctr.ValidFrom.ToString("dd.MM.yyyy"),
                            contract_valid_through = valid_through,
                            hip_names = String.IsNullOrEmpty(ctr.HIPNames) ? "-" : ctr.HIPNames
                        };
                    }).ToList();
                }
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
            }

            return response;
        }

        public ContractViewModel GetContractDetails(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest currentRequest = null)
        {
            var request = currentRequest ?? HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var ctr = cls_Get_Contract_Details_for_ContractID.Invoke(connectionString, new P_MD_GCDfCID_1518() { ContractID = id }, securityTicket).Result;
                if (ctr != null)
                {
                    var contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(connectionString, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        Contract_RefID = id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                    var contract_characteristic_id = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.CharacteristicID.Value());
                    var edifact_type = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.EdifactType.Value());
                    var encrypt_edifact = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.EncryptEdifact.Value());
                    var next_edifact_number = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.NextEdifactNumber.Value());
                    var valid_through = ctr.ValidThrough == DateTime.MinValue ? "∞" : ctr.ValidThrough.ToString("dd.MM.yyyy");

                    var contract_type = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.ContractType.Value());
                    var message_type = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MessageType.Value());
                    var merge_for_all_hips = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.MergeForAllHips.Value());
                    var use_k_for_correction = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.UseKForCorrection.Value());
                    var ik_number = contract_parameters.SingleOrDefault(t => t.ParameterName == EContractParameter.IKNumber.Value());

                    return new ContractViewModel()
                    {
                        contract_id = ctr.ContractID,
                        contract_name = ctr.ContractName,
                        contract_valid_from = ctr.ValidFrom.ToString("dd.MM.yyyy"),
                        contract_valid_through = valid_through,
                        gpos_data = GetGposData(id, "gpos_number", true, connectionString, sessionTicket, method, ipInfo, out transaction),
                        covered_drugs = GetDrugsData(id, sessionTicket, connectionString, method, ipInfo, out transaction),
                        covered_diagnoses = GetDiagnosesData(id, sessionTicket, connectionString, method, ipInfo, out transaction),
                        covered_insurance_companies = GetHipData(id, sessionTicket, connectionString, method, ipInfo, out transaction),
                        participating_doctors = GetParticipatingDoctorsData(id, sessionTicket, connectionString, method, ipInfo, out transaction),
                        contract_due_dates = GetDueDates(id, sessionTicket, connectionString, method, ipInfo, out transaction),
                        characteristic_id = contract_characteristic_id != null ? contract_characteristic_id.IfStringValue_Value : null,
                        encrypt_edifact = encrypt_edifact != null ? encrypt_edifact.IfBooleanValue_Value : false,
                        edifact_type = edifact_type != null && !string.IsNullOrEmpty(edifact_type.IfStringValue_Value) ? edifact_type.IfStringValue_Value : "3",
                        next_edifact_number = next_edifact_number != null ? Convert.ToInt32(next_edifact_number.IfNumericValue_Value) : 1,
                        contract_type = contract_type != null ? contract_type.IfStringValue_Value : "7",
                        ik_number = ik_number != null ? ik_number.IfStringValue_Value : null,
                        message_type = message_type != null ? message_type.IfStringValue_Value : "DIR73C",
                        merger_for_all_hips = merge_for_all_hips != null ? merge_for_all_hips.IfBooleanValue_Value : false,
                        use_k_for_correction = use_k_for_correction != null ? use_k_for_correction.IfBooleanValue_Value : true
                    };
                }
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
            }

            return null;
        }

        #region CONTRACT DATA RETRIVAL METHODS

        private ContractDueDates GetDueDates(Guid contract_id, string sessionTicket, string connectionString, MethodBase method, IPInfo ipInfo, out TransactionalInformation transaction)
        {
            List<CoveredItemModel> response = new List<CoveredItemModel>();
            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            try
            {
                var due_dates = cls_Get_Due_Dates_for_ContractID.Invoke(connectionString, new P_MD_GDDfCID_1544() { ContractID = contract_id }, securityTicket).Result;
                if (due_dates.Length != 0)
                {
                    var number_of_days_between_hip_response_and_rejection = due_dates.SingleOrDefault(dd => dd.Name == "Number of days between HIP response and rejection  - Days");
                    var participation_consent_duration = due_dates.SingleOrDefault(dd => dd.Name == "Duration of participation consent – Month");
                    var number_of_days_between_surgery_and_aftercare = due_dates.SingleOrDefault(dd => dd.Name == "Number of days between surgery and aftercare - Days");
                    var number_of_days_between_surgery_and_settlement_claim = due_dates.SingleOrDefault(dd => dd.Name == "Number of days between treatment and settlement claim - Days");
                    var number_of_days_between_submission_to_hip_and_reply = due_dates.SingleOrDefault(dd => dd.Name == "Number of days between submission to HIP and reply – Days");
                    var number_of_days_between_response_and_payment = due_dates.SingleOrDefault(dd => dd.Name == "Number of days between response and payment – Days");
                    var max_number_of_preexaminations = due_dates.SingleOrDefault(dd => dd.Name == "Max number of preexaminations");
                    var number_of_days_for_preexaminations = due_dates.SingleOrDefault(dd => dd.Name == "Preexaminations - Days");
                    var oct_max_number_of_days_before_op = due_dates.SingleOrDefault(dd => dd.Name == "OCT - Max number of days before OP");
                    var op_renews_patient_consent = due_dates.SingleOrDefault(dd => dd.Name == "OP renews patient consent");
                    var use_settlement_year = due_dates.SingleOrDefault(dd => dd.Name == "Use settlement year instead of treatment year");
                    var doctor_needs_certification = due_dates.SingleOrDefault(dd => dd.Name == "Doctor needs OCT certification");

                    return new ContractDueDates()
                    {
                        number_of_days_between_hip_response_and_rejection = new ContractDueDatesModel()
                        {
                            active = number_of_days_between_hip_response_and_rejection != null,
                            id = number_of_days_between_hip_response_and_rejection != null ? number_of_days_between_hip_response_and_rejection.ID : Guid.Empty,
                            value = number_of_days_between_hip_response_and_rejection != null ? number_of_days_between_hip_response_and_rejection.Value.ToString() : ""
                        },
                        number_of_days_between_response_and_payment = new ContractDueDatesModel()
                        {
                            active = number_of_days_between_response_and_payment != null,
                            id = number_of_days_between_response_and_payment != null ? number_of_days_between_response_and_payment.ID : Guid.Empty,
                            value = number_of_days_between_response_and_payment != null ? number_of_days_between_response_and_payment.Value.ToString() : ""
                        },
                        number_of_days_between_submission_to_hip_and_reply = new ContractDueDatesModel()
                        {
                            active = number_of_days_between_submission_to_hip_and_reply != null,
                            id = number_of_days_between_submission_to_hip_and_reply != null ? number_of_days_between_submission_to_hip_and_reply.ID : Guid.Empty,
                            value = number_of_days_between_submission_to_hip_and_reply != null ? number_of_days_between_submission_to_hip_and_reply.Value.ToString() : ""
                        },
                        number_of_days_between_surgery_and_aftercare = new ContractDueDatesModel()
                        {
                            active = number_of_days_between_surgery_and_aftercare != null,
                            id = number_of_days_between_surgery_and_aftercare != null ? number_of_days_between_surgery_and_aftercare.ID : Guid.Empty,
                            value = number_of_days_between_surgery_and_aftercare != null ? number_of_days_between_surgery_and_aftercare.Value.ToString() : ""
                        },
                        number_of_days_between_surgery_and_settlement_claim = new ContractDueDatesModel()
                        {
                            active = number_of_days_between_surgery_and_settlement_claim != null,
                            id = number_of_days_between_surgery_and_settlement_claim != null ? number_of_days_between_surgery_and_settlement_claim.ID : Guid.Empty,
                            value = number_of_days_between_surgery_and_settlement_claim != null ? number_of_days_between_surgery_and_settlement_claim.Value.ToString() : ""
                        },
                        participation_consent_duration = new ContractDueDatesModel()
                        {
                            active = participation_consent_duration != null,
                            id = participation_consent_duration != null ? participation_consent_duration.ID : Guid.Empty,
                            value = participation_consent_duration != null ? participation_consent_duration.Value.ToString() : ""
                        },
                        number_of_max_preexaminations_value = new ContractDueDatesModel()
                        {
                            active = max_number_of_preexaminations != null,
                            id = max_number_of_preexaminations != null ? max_number_of_preexaminations.ID : Guid.Empty,
                            value = max_number_of_preexaminations != null ? max_number_of_preexaminations.Value.ToString() : ""
                        },
                        number_of_max_preexaminations_days = new ContractDueDatesModel()
                        {
                            active = number_of_days_for_preexaminations != null,
                            id = number_of_days_for_preexaminations != null ? number_of_days_for_preexaminations.ID : Guid.Empty,
                            value = number_of_days_for_preexaminations != null ? number_of_days_for_preexaminations.Value.ToString() : ""
                        },
                        oct_max_number_of_days_before_op = new ContractDueDatesModel()
                        {
                            active = oct_max_number_of_days_before_op != null,
                            id = oct_max_number_of_days_before_op != null ? oct_max_number_of_days_before_op.ID : Guid.Empty,
                            value = oct_max_number_of_days_before_op != null ? oct_max_number_of_days_before_op.Value.ToString() : ""
                        },
                        op_renews_patient_consent = new ContractDueDatesModel()
                        {
                            id = op_renews_patient_consent != null ? op_renews_patient_consent.ID : Guid.Empty,
                            active = op_renews_patient_consent != null
                        },
                        use_settlement_year = new ContractDueDatesModel()
                        {
                            id = use_settlement_year != null ? use_settlement_year.ID : Guid.Empty,
                            active = use_settlement_year != null
                        },
                        doctor_needs_certification = new ContractDueDatesModel()
                        {
                            id = doctor_needs_certification != null ? doctor_needs_certification.ID : Guid.Empty,
                            active = doctor_needs_certification != null
                        }

                    };
                }
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
            }

            return null;
        }
        private List<CoveredItemModel> GetDrugsData(Guid contract_id, string sessionTicket, string connectionString, MethodBase method, IPInfo ipInfo, out TransactionalInformation transaction)
        {
            List<CoveredItemModel> response = new List<CoveredItemModel>();
            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            try
            {
                var drugs = cls_Get_All_Drugs_for_ContractID.Invoke(connectionString, new P_CAS_GADfCID_1220() { ContractID = contract_id }, securityTicket).Result;
                if (drugs.Length != 0)
                {
                    return drugs.Select(drug => { return new CoveredItemModel { name = drug.drug_name, id = drug.drug_id, expanded_name = drug.drug_name + " (" + drug.drug_pzn + ")" }; }).ToList();
                }
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
            }

            return response;
        }
        private List<ContractParticipatingDoctorModel> GetParticipatingDoctorsData(Guid contract_id, string sessionTicket, string connectionString, MethodBase method, IPInfo ipInfo, out TransactionalInformation transaction)
        {
            List<ContractParticipatingDoctorModel> response = new List<ContractParticipatingDoctorModel>();
            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            try
            {
                var doctor_ids = cls_Get_Participating_DoctorIDs_for_ContractID.Invoke(connectionString, new P_MD_GPDIDsfCID_1017() { ContractID = contract_id }, securityTicket).Result;
                if (doctor_ids.Length != 0)
                {
                    var doctors = Get_Practices_and_Doctors.Get_Doctors_for_ID_Array(Array.ConvertAll(doctor_ids.Select(d => d.DoctorID).ToArray(), x => x.ToString()), securityTicket);

                    Dictionary<Guid, Practice_Doctors_Model> doctorsCache = doctors.Select(doc =>
                    {
                        return new { doctorID = Guid.Parse(doc.id), doctorDetails = doc };
                    }).ToDictionary(t => t.doctorID, t => t.doctorDetails);

                    return doctor_ids.Select(doc =>
                    {
                        var valid_through = doc.ConsentEndDate == DateTime.MinValue ? "∞" : doc.ConsentEndDate.ToString("dd.MM.yyyy");
                        return new ContractParticipatingDoctorModel
                        {
                            sortable_name = doctorsCache[doc.DoctorID].name_untouched,
                            name = doctorsCache[doc.DoctorID].name,
                            lanr = doctorsCache[doc.DoctorID].bsnr_lanr,
                            doctor_id = doc.DoctorID,
                            id = doc.DoctorAssignmentID,
                            address = doctorsCache[doc.DoctorID].address,
                            city = doctorsCache[doc.DoctorID].zip + " " + doctorsCache[doc.DoctorID].city,
                            email = doctorsCache[doc.DoctorID].email,
                            phone = doctorsCache[doc.DoctorID].phone,
                            practice = doctorsCache[doc.DoctorID].practice_name_for_doctor,
                            expanded_name = doctorsCache[doc.DoctorID].name + " (" + doctorsCache[doc.DoctorID].bsnr_lanr + ") | " + doctorsCache[doc.DoctorID].practice_name_for_doctor,
                            is_consent_active = doc.IsConsentActive,
                            consent_date = "",
                            consent_start_date = doc.ConsentStartDate.ToString("dd.MM.yyyy"),
                            consent_end_date = valid_through,
                            consent_start_date_datetime = doc.ConsentStartDate,
                            consent_end_date_datetime = doc.ConsentEndDate
                        };
                    }).OrderBy(t => t.sortable_name).ToList();
                }
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
            }

            return response;
        }
        private List<CoveredItemModel> GetHipData(Guid contract_id, string sessionTicket, string connectionString, MethodBase method, IPInfo ipInfo, out TransactionalInformation transaction)
        {
            List<CoveredItemModel> response = new List<CoveredItemModel>();
            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            try
            {
                var hips = cls_Get_All_HIPs_for_ContractID.Invoke(connectionString, new P_MD_GAHIPsfCID_1905() { ContractID = contract_id }, securityTicket).Result;
                if (hips.Length != 0)
                {
                    return hips.Select(hip => { return new CoveredItemModel { name = hip.HipName, additional_info = hip.HipNumber, id = hip.HipBptID, expanded_name = hip.HipName + " (" + hip.HipNumber + ")" }; }).ToList();
                }
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
            }

            return response;
        }

        private List<CoveredItemModel> GetDiagnosesData(Guid contract_id, string sessionTicket, string connectionString, MethodBase method, IPInfo ipInfo, out TransactionalInformation transaction)
        {
            List<CoveredItemModel> response = new List<CoveredItemModel>();
            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            try
            {
                var diagnoses = cls_Get_All_Diagnoses_for_ContractID.Invoke(connectionString, new P_CAS_GADfCID_1306() { ContractID = contract_id }, securityTicket).Result;
                if (diagnoses.Length != 0)
                {
                    return diagnoses.Select(diagnose =>
                    {
                        return new CoveredItemModel
                        {
                            name = diagnose.diagnose_name,
                            additional_info = diagnose.diagnose_icd_10,
                            id = diagnose.diagnose_id,
                            expanded_name = diagnose.diagnose_name + " (" + diagnose.diagnose_icd_10 + ")"
                        };
                    }).ToList();
                }
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
            }

            return response;
        }

        private List<GposDetailModel> GetGposData(Guid contract_id, string sort_by, bool ascending, string connectionString, string sessionTicket, MethodBase method, IPInfo ipInfo, out TransactionalInformation transaction)
        {
            List<GposDetailModel> response = new List<GposDetailModel>();
            var securityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            try
            {
                Func<MD_GGPOSDfCID_1616, Object> orderByFunc = null;
                switch (sort_by)
                {
                    case "gpos_number":
                        orderByFunc = item => item.GposNumber;
                        break;
                    case "gpos_name":
                        orderByFunc = item => item.GposName;
                        break;
                    case "drug_names":
                        orderByFunc = item => item.DrugNames;
                        break;
                    case "diagnose_names":
                        orderByFunc = item => item.DiagnoseNames;
                        break;
                }

                var gposes = cls_Get_GPOS_Details_for_ContractID.Invoke(connectionString, new P_MD_GGPOSDfCID_1616() { ContractID = contract_id }, securityTicket).Result.OrderBy(orderByFunc).ToList();
                if (gposes.Count() != 0)
                {

                    var connectedDrugs = cls_Get_GPOS_DrugIDs_for_ContractID.Invoke(connectionString, new P_MD_GGPOSDIDsfCID_1629() { ContractID = contract_id }, securityTicket).Result;
                    var connectedDiagnoses = cls_Get_GPOS_DiagnoseIDs_for_ContractID.Invoke(connectionString, new P_MD_GGPOSDIDsfCID_1633() { ContractID = contract_id }, securityTicket).Result;

                    response = gposes.Select(gpos =>
                    {
                        return new GposDetailModel()
                        {
                            diagnose_names = String.IsNullOrEmpty(gpos.DiagnoseNames) ? "-" : gpos.DiagnoseNames,
                            drug_names = String.IsNullOrEmpty(gpos.DrugNames) ? "-" : gpos.DrugNames,
                            gpos_id = gpos.GposID,
                            gpos_number = gpos.GposNumber,
                            gpos_name = gpos.GposName,
                            gpos_type = gpos.GposType,
                            waive_with_order = gpos.WaiveWithOrder,
                            fee_value = gpos.FeeValue,
                            management_fee_value = gpos.ManagementFeeValue == "-" ? "0" : gpos.ManagementFeeValue,
                            from_injection = gpos.FromInjection > 1000000 ? "" : gpos.FromInjection.ToString(),
                            drugs = connectedDrugs.Where(drug => drug.GposID == gpos.GposID).Select(drug =>
                            {
                                return new CoveredItemModel
                                {
                                    id = drug.DrugID,
                                    name = drug.DrugName
                                };
                            }).ToList(),
                            diagnoses = connectedDiagnoses.Where(dia => dia.GposID == gpos.GposID).Select(dia =>
                            {
                                return new CoveredItemModel
                                {
                                    id = dia.DiagnoseID,
                                    expanded_name = dia.DiagnoseName,
                                    additional_info = dia.DiagnoseICD10,
                                    name = dia.DiagnoseShortName
                                };
                            }).ToList()
                        };
                    }).ToList();
                }
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

            }

            return response;
        }
        #endregion

        public IEnumerable<ContractParticipatingDoctorModel> GetDoctorsForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var doctors = Get_Practices_and_Doctors.Get_Doctors_for_SearchCriteria(search_criteria, securityTicket);

                return doctors.Select(doctor =>
                {
                    return new ContractParticipatingDoctorModel
                    {
                        sortable_name = doctor.name_untouched,
                        name = doctor.name,
                        lanr = doctor.bsnr_lanr,
                        id = Guid.Empty,
                        doctor_id = Guid.Parse(doctor.id),
                        address = doctor.address,
                        city = doctor.zip + " " + doctor.city,
                        email = doctor.email,
                        phone = doctor.phone,
                        practice = doctor.practice_name_for_doctor,
                        expanded_name = doctor.name + " (" + doctor.bsnr_lanr + ") | " + doctor.practice_name_for_doctor
                    };
                }).ToList();
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
            }

            return new List<ContractParticipatingDoctorModel>();
        }
        public IEnumerable<CoveredItemModel> GetDrugsForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var drugs = cls_Get_Drugs_for_SearchCriteria.Invoke(connectionString, new P_MD_GDfSC_1457() { SearchCriteria = search_criteria.ToLower() + "%" }, securityTicket).Result;
                if (drugs.Length != 0)
                {
                    return drugs.Select(drug =>
                    {
                        return new CoveredItemModel { id = drug.DrugID, name = drug.DrugName, additional_info = drug.DrugPZN, expanded_name = drug.DrugName + " (" + drug.DrugPZN + ")" };
                    }).ToList();
                }
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
            }

            return new List<CoveredItemModel>();
        }

        public IEnumerable<CoveredItemModel> GetDiagnosesForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var diagnoses = Get_Diagnoses.Get_Diagnoses_for_Search_Criteria(search_criteria);

                return diagnoses.Select(diag =>
                {
                    return new CoveredItemModel { name = diag.name, additional_info = diag.icd10, id = Guid.Parse(diag.id), expanded_name = diag.name + " (" + diag.icd10 + ")" };
                }).ToList();
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
            }

            return new List<CoveredItemModel>();
        }

        public IEnumerable<CoveredItemModel> GetHIPsForSearchCriteria(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var hips = Get_HIPs.Get_HIPs_for_Search_Criteria(search_criteria);


                return hips.Select(hip =>
                {
                    return new CoveredItemModel { name = hip.name, additional_info = hip.ik_number, id = Guid.Parse(hip.id), expanded_name = hip.name + " (" + hip.ik_number + ")" };
                }).ToList();

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
            }

            return new List<CoveredItemModel>();
        }
        #endregion

        #region MANIPULATION
        public Guid SaveContract(ContractViewModel contract, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

            var request = HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var dbConnection = DBSQLSupport.CreateConnection(connectionString);
                DbTransaction dbTransaction = null;

                try
                {
                    dbConnection.Open();
                    dbTransaction = dbConnection.BeginTransaction();

                    #region PARAMETER
                    var validThrough = DateTime.MinValue;
                    DateTime.TryParse(contract.contract_valid_through, culture, DateTimeStyles.AssumeLocal, out validThrough);

                    var Parameter = new P_MD_SC_1653()
                    {
                        ContractID = contract.contract_id,
                        ContractName = contract.contract_name,
                        ValidFrom = DateTime.Parse(contract.contract_valid_from, culture, DateTimeStyles.AssumeLocal),
                        ValidThrough = validThrough,
                    };

                    if (contract.covered_drugs != null)
                        Parameter.CoveredDrugIDs = contract.covered_drugs.Select(cd => cd.id).ToArray();

                    if (contract.covered_diagnoses != null)
                        Parameter.CoveredDiagnoseIDs = GetDiagnoseIDs(contract.covered_diagnoses, connectionString, securityTicket).ToArray();

                    if (contract.contract_due_dates != null)
                        Parameter.DueDates = GetDueDatesParameter(contract.contract_due_dates);

                    if (contract.participating_doctors != null)
                    {
                        Parameter.ParticipatingDoctors = contract.participating_doctors.Select(pd =>
                        {
                            var datetime = DateTime.MinValue;
                            DateTime.TryParse(pd.consent_date, culture, DateTimeStyles.AssumeLocal, out datetime);

                            return new P_MD_SCPD_1341_Doctors()
                            {
                                ConsentDate = datetime,
                                AssignmentID = pd.id,
                                DoctorID = pd.doctor_id,
                                IsParticipating = pd.is_participating
                            };
                        }).ToArray();
                    }

                    if (contract.covered_insurance_companies != null)
                        Parameter.ParticipatingHIPs = GetHealthInsuranceCompanyIDs(contract.covered_insurance_companies, connectionString, securityTicket).ToArray();

                    if (contract.gpos_data != null)
                    {
                        Parameter.GposData = new P_MD_SCGPOSD_1306()
                        {
                            GposData = contract.gpos_data.Select(gpos =>
                            {
                                return new P_MD_SCGPOSD_1306_Array()
                                {
                                    DiagnoseIDs = gpos.diagnoses != null ? GetDiagnoseIDs(gpos.diagnoses, connectionString, securityTicket).ToArray() : new Guid[] { },
                                    DrugIDs = gpos.drugs != null ? gpos.drugs.Select(drug => drug.id).ToArray() : new Guid[] { },
                                    FeeValue = gpos.fee_value,
                                    FromInjection = string.IsNullOrEmpty(gpos.from_injection) ? int.MaxValue : Convert.ToInt32(gpos.from_injection),
                                    GposID = gpos.gpos_id,
                                    GposName = gpos.gpos_name,
                                    GposNumber = gpos.gpos_number,
                                    GposType = gpos.gpos_type,
                                    ManagementFeeValue = gpos.management_fee_value,
                                    WaiveServiceFeeWithOrder = gpos.waive_with_order
                                };
                            }).ToArray()
                        };
                    }
                    #endregion

                    ContractViewModel previous_state = null;

                    if (contract.contract_id != Guid.Empty)
                    {
                        Thread detailsThread = new Thread(() => GetContractPreviousDetails(out previous_state, contract.contract_id, connectionString, sessionTicket, request));
                        detailsThread.Start();
                    }

                    var result = cls_Save_Contract.Invoke(dbConnection, dbTransaction, Parameter, securityTicket).Result;

                    #region Characteristic id
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.CharacteristicID.Value(),
                        ContractID = result,
                        StringValue = contract.characteristic_id
                    }, securityTicket);
                    #endregion

                    #region Next edifact number
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.NextEdifactNumber.Value(),
                        ContractID = result,
                        NumericValue = Convert.ToDouble(contract.next_edifact_number)
                    }, securityTicket);
                    #endregion

                    #region Edifact type
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.EdifactType.Value(),
                        ContractID = result,
                        StringValue = contract.edifact_type
                    }, securityTicket);
                    #endregion

                    #region IK Number
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.IKNumber.Value(),
                        ContractID = result,
                        StringValue = contract.ik_number
                    }, securityTicket);
                    #endregion

                    #region Encrypt edifact
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.EncryptEdifact.Value(),
                        ContractID = result,
                        BooleanValue = contract.encrypt_edifact
                    }, securityTicket);
                    #endregion

                    #region Contract type
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.ContractType.Value(),
                        ContractID = result,
                        StringValue = contract.contract_type
                    }, securityTicket);
                    #endregion

                    #region Message type
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.MessageType.Value(),
                        ContractID = result,
                        StringValue = contract.message_type
                    }, securityTicket);
                    #endregion

                    #region Merge all hips
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.MergeForAllHips.Value(),
                        ContractID = result,
                        BooleanValue = contract.merger_for_all_hips
                    }, securityTicket);
                    #endregion

                    #region Use k for correction
                    cls_Save_Contract_Parameter.Invoke(dbConnection, dbTransaction, new P_MD_SCP_1754()
                    {
                        Name = EContractParameter.UseKForCorrection.Value(),
                        ContractID = result,
                        BooleanValue = contract.use_k_for_correction
                    }, securityTicket);
                    #endregion

                    Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, contract, previous_state));

                    dbTransaction.Commit();

                    return result;
                }
                catch
                {
                    if (dbTransaction != null)
                    {
                        dbTransaction.Rollback();
                    }

                    throw;
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
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return Guid.Empty;
        }


        public Guid CopyContract(Guid contractIDToCopy, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest currentRequest = null)
        {
            var request = currentRequest ?? HttpContext.Current.Request;
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                ContractViewModel contractToCopy = null;

                if (contractIDToCopy != Guid.Empty)
                {
                    Thread detailsThread = new Thread(() => GetContractPreviousDetails(out contractToCopy, contractIDToCopy, connectionString, sessionTicket, request));
                    detailsThread.Start();
                }

                var result = cls_Copy_Contract.Invoke(connectionString, new P_MD_CC_1039() { ContractID = contractIDToCopy }, securityTicket).Result;

                ContractViewModel copiedContract = null;

                if (contractIDToCopy != Guid.Empty)
                {
                    Thread detailsThread = new Thread(() => GetContractPreviousDetails(out copiedContract, result, connectionString, sessionTicket, request));
                    detailsThread.Start();
                }

                if (result != Guid.Empty)
                {
                    Thread detailsThread = new Thread(() => LogCopiedContract(result, connectionString, sessionTicket, request, ipInfo, method, securityTicket, contractToCopy));
                    detailsThread.Start();
                }

                return result;
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
            }

            return Guid.Empty;
        }
        #endregion

        #region VALIDATION
        public IEnumerable<ContractOverlapsValidationResponse> ValidateContractOverlaps(DoctorContractConsent parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var doctorAssignments = cls_Get_Doctors_Assignments_on_Contract.Invoke(connectionString, new P_DO_GDAoC_1337() { ContractID = parameter.Contract.contractID, DoctorID = parameter.doctorID }, securityTicket).Result;
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
                        da.AssignmentID != parameter.assignmentID &&
                       (da.ConsentValidThrough > consentStartDate || da.ConsentValidThrough == DateTime.MinValue) &&
                       (da.ConsentValidFrom <= consentStartDate ||
                        da.ConsentValidFrom < consentEndDate) ||
                       (da.ConsentValidThrough == DateTime.MinValue && consentEndDate == DateTime.MaxValue)
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
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return new List<ContractOverlapsValidationResponse>();
        }
        public DateTime GetConsentStartDate(Guid contract_id, Guid doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var securityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var doctorsConsent = cls_Get_Doctors_ConsentStartDate_for_DoctorID_and_ContractID.Invoke(connectionString, new P_DO_GDCSDfDIDaCID_1411() { DoctorID = doctor_id, ContractID = contract_id }, securityTicket).Result;
                return doctorsConsent != null ? doctorsConsent.ConsentStartDate : DateTime.MinValue;
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
            }

            return DateTime.MinValue;
        }
        #endregion

        #region UTIL
        private P_MD_SCDD_1729_Array[] GetDueDatesParameter(ContractDueDates contractDueDates)
        {
            List<P_MD_SCDD_1729_Array> result = new List<P_MD_SCDD_1729_Array>();

            if (contractDueDates.number_of_days_between_hip_response_and_rejection != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.number_of_days_between_hip_response_and_rejection.id,
                    Name = "Number of days between HIP response and rejection  - Days",
                    IsActive = contractDueDates.number_of_days_between_hip_response_and_rejection.active,
                    Value = !contractDueDates.number_of_days_between_hip_response_and_rejection.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.number_of_days_between_hip_response_and_rejection.value) ? Convert.ToDouble(contractDueDates.number_of_days_between_hip_response_and_rejection.value) : 0
                });
            }

            if (contractDueDates.participation_consent_duration != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.participation_consent_duration.id,
                    Name = "Duration of participation consent – Month",
                    IsActive = contractDueDates.participation_consent_duration.active,
                    Value = !contractDueDates.participation_consent_duration.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.participation_consent_duration.value) ? Convert.ToDouble(contractDueDates.participation_consent_duration.value) : 0
                });
            }

            if (contractDueDates.number_of_days_between_surgery_and_aftercare != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.number_of_days_between_surgery_and_aftercare.id,
                    Name = "Number of days between surgery and aftercare - Days",
                    IsActive = contractDueDates.number_of_days_between_surgery_and_aftercare.active,
                    Value = !contractDueDates.number_of_days_between_surgery_and_aftercare.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.number_of_days_between_surgery_and_aftercare.value) ? Convert.ToDouble(contractDueDates.number_of_days_between_surgery_and_aftercare.value) : 0
                });
            }

            if (contractDueDates.number_of_days_between_surgery_and_settlement_claim != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.number_of_days_between_surgery_and_settlement_claim.id,
                    Name = "Number of days between treatment and settlement claim - Days",
                    IsActive = contractDueDates.number_of_days_between_surgery_and_settlement_claim.active,
                    Value = !contractDueDates.number_of_days_between_surgery_and_settlement_claim.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.number_of_days_between_surgery_and_settlement_claim.value) ? Convert.ToDouble(contractDueDates.number_of_days_between_surgery_and_settlement_claim.value) : 0
                });
            }

            if (contractDueDates.number_of_days_between_submission_to_hip_and_reply != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.number_of_days_between_submission_to_hip_and_reply.id,
                    Name = "Number of days between submission to HIP and reply – Days",
                    IsActive = contractDueDates.number_of_days_between_submission_to_hip_and_reply.active,
                    Value = !contractDueDates.number_of_days_between_submission_to_hip_and_reply.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.number_of_days_between_submission_to_hip_and_reply.value) ? Convert.ToDouble(contractDueDates.number_of_days_between_submission_to_hip_and_reply.value) : 0
                });
            }

            if (contractDueDates.number_of_days_between_response_and_payment != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.number_of_days_between_response_and_payment.id,
                    Name = "Number of days between response and payment – Days",
                    IsActive = contractDueDates.number_of_days_between_response_and_payment.active,
                    Value = !contractDueDates.number_of_days_between_response_and_payment.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.number_of_days_between_response_and_payment.value) ? Convert.ToDouble(contractDueDates.number_of_days_between_response_and_payment.value) : 0
                });
            }

            if (contractDueDates.number_of_max_preexaminations_value != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.number_of_max_preexaminations_value.id,
                    Name = "Max number of preexaminations",
                    IsActive = contractDueDates.number_of_max_preexaminations_value.active,
                    Value = !contractDueDates.number_of_max_preexaminations_value.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.number_of_max_preexaminations_value.value) ? Convert.ToDouble(contractDueDates.number_of_max_preexaminations_value.value) : 0
                });
            }

            if (contractDueDates.number_of_max_preexaminations_days != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.number_of_max_preexaminations_days.id,
                    Name = "Preexaminations - Days",
                    IsActive = contractDueDates.number_of_max_preexaminations_value.active,
                    Value = !contractDueDates.number_of_max_preexaminations_value.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.number_of_max_preexaminations_days.value) ? Convert.ToDouble(contractDueDates.number_of_max_preexaminations_days.value) : 0
                });
            }

            if (contractDueDates.oct_max_number_of_days_before_op != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.oct_max_number_of_days_before_op.id,
                    Name = "OCT - Max number of days before OP",
                    IsActive = contractDueDates.oct_max_number_of_days_before_op.active,
                    Value = !contractDueDates.oct_max_number_of_days_before_op.active ? double.MaxValue : !String.IsNullOrEmpty(contractDueDates.oct_max_number_of_days_before_op.value) ? Convert.ToDouble(contractDueDates.oct_max_number_of_days_before_op.value) : 0
                });
            }

            if (contractDueDates.op_renews_patient_consent != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.op_renews_patient_consent.id,
                    Name = "OP renews patient consent",
                    IsActive = contractDueDates.op_renews_patient_consent.active
                });
            }

            if (contractDueDates.use_settlement_year != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.use_settlement_year.id,
                    Name = "Use settlement year instead of treatment year",
                    IsActive = contractDueDates.use_settlement_year.active
                });
            }

            if (contractDueDates.doctor_needs_certification != null)
            {
                result.Add(new P_MD_SCDD_1729_Array()
                {
                    ID = contractDueDates.doctor_needs_certification.id,
                    Name = "Doctor needs OCT certification",
                    IsActive = contractDueDates.doctor_needs_certification.active
                });
            }

            return result.ToArray();
        }

        private void GetContractPreviousDetails(out ContractViewModel previous_state, Guid contract_id, string connectionString, string sessionTicket, HttpRequest request)
        {
            var transaction = new TransactionalInformation();
            previous_state = GetContractDetails(contract_id, connectionString, sessionTicket, out transaction, request);
        }
        private void LogCopiedContract(Guid contract_id, string connectionString, string sessionTicket, HttpRequest request,
            IPInfo ipInfo, MethodBase method, SessionSecurityTicket securityTicket, ContractViewModel contractToCopy)
        {
            var transaction = new TransactionalInformation();
            var copiedContract = GetContractDetails(contract_id, connectionString, sessionTicket, out transaction, request);
            Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, contractToCopy, copiedContract));
        }

        private IEnumerable<Guid> GetHealthInsuranceCompanyIDs(IEnumerable<CoveredItemModel> hips, string connectionString, SessionSecurityTicket securityTicket)
        {
            return cls_Save_New_Insurance_Companies_and_Return_New_IDs.Invoke(connectionString, hips.Select(hip =>
            {
                return new P_MD_SNICaRNIDs_1653()
                {
                    HIPName = hip.name,
                    IKNumber = hip.additional_info
                };
            }).ToArray(), securityTicket).Result;
        }

        private IEnumerable<Guid> GetDiagnoseIDs(IEnumerable<CoveredItemModel> diagnoses, string connectionString, SessionSecurityTicket securityTicket)
        {
            return cls_Save_New_Diagnoses_and_Return_New_IDs.Invoke(connectionString, diagnoses.Select(diag =>
            {
                return new P_MD_SNDaRNIDs_1412()
                {
                    DiagnoseICD10 = diag.additional_info,
                    DiagnoseName = diag.name
                };
            }).ToArray(), securityTicket).Result;
        }
        #endregion
    }
}
