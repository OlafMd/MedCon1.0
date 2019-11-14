/* 
 * Generated on 8/19/2015 9:14:42 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_HEC_ACT;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectUtils.ExcelTemplates;
using CL1_BIL;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_HEC_HIS;
using MMDocConnectUtils;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using CL1_CMN_BPT;
using MMDocConnectDocApp;
using System.IO;
using BOp.Providers;
using MMDocConnectDBMethods.Archive.Complex.Manipulation;
using System.Web;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectDBMethods.Case.Models;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using CL1_CMN_CTR;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using System.Globalization;
using System.Threading;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Change_Case_to_Status_Error.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Change_Case_to_Status_Error
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CCtSE_1100 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            //Get statuses from Resources
            var FS1 = Properties.Resources.FS1;
            var FS2 = Properties.Resources.FS2;
            var FS3 = Properties.Resources.FS3;
            var FS4 = Properties.Resources.FS4;
            var FS5 = Properties.Resources.FS5;
            var FS6 = Properties.Resources.FS6;
            var FS7 = Properties.Resources.FS7;
            var FS8 = Properties.Resources.FS8;
            var FS9 = Properties.Resources.FS9;
            var FS10 = Properties.Resources.FS10;
            var FS11 = Properties.Resources.FS11;
            Guid treatment_performed_action_type_id = Guid.Empty;

            var treatment_performed_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, new ORM_HEC_ACT_ActionType.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.treatment"
            }).SingleOrDefault();

            if (treatment_performed_action_type == null)
            {
                treatment_performed_action_type = new ORM_HEC_ACT_ActionType();
                treatment_performed_action_type.GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.treatment";
                treatment_performed_action_type.Creation_Timestamp = DateTime.Now;
                treatment_performed_action_type.Modification_Timestamp = DateTime.Now;
                treatment_performed_action_type.Tenant_RefID = securityTicket.TenantID;

                treatment_performed_action_type.Save(Connection, Transaction);

                treatment_performed_action_type_id = treatment_performed_action_type.HEC_ACT_ActionTypeID;
            }
            else
            {
                treatment_performed_action_type_id = treatment_performed_action_type.HEC_ACT_ActionTypeID;
            }

            List<Submitted_Case_Model> allCases = Get_All_Cases_With_Custom_Status.Get_All_Submited_Cases_With_Custom_Status("FS2", securityTicket);
            List<Submitted_Case_Model> allCases_FS11 = Get_All_Cases_With_Custom_Status.Get_All_Submited_Cases_With_Custom_Status("FS11", securityTicket);
            List<Submitted_Case_Model> newCaseList = new List<Submitted_Case_Model>();
            List<Settlement_Model> settlements = new List<Settlement_Model>();
            List<PatientDetailViewModel> patientDetailList = new List<PatientDetailViewModel>();
            List<DateTime> OldTransmitionDateList = new List<DateTime>();
            Dictionary<Guid, int> consentValidToCache = new Dictionary<Guid, int>();
            //List<Guid> casesToChange = new List<Guid>();
            //List<string> typeList = new List<string>();
            List<NegativeResponseModel> NegativeResponseList = new List<NegativeResponseModel>();
            var preexaminationsCache = cls_Get_Patient_Preexaminations_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.GroupBy(c => c.Localization).ToDictionary(d => d.Key, d => d));

            DateTime DateForElastic = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
            var casesForReport = cls_Get_Cases_For_Report.Invoke(Connection, Transaction, new P_CAS_GCFR_0910() { Status = 2 }, securityTicket).Result;
            var casesForReport_FS11 = cls_Get_Cases_For_Report.Invoke(Connection, Transaction, new P_CAS_GCFR_0910() { Status = 11 }, securityTicket).Result;
            Dictionary<string, string> serviceFeeValueCache = new Dictionary<string, string>();
            List<CaseForReportModel> caseModelList = new List<CaseForReportModel>();

            foreach (var item in Parameter.CasesToBeChanged)
            {
                try
                {
                    var errorCase = casesForReport.SingleOrDefault(i => int.Parse(i.PositionNumber) == int.Parse(item.bill_number));
                    bool shouldChangeToFS8 = false;

                    if (errorCase == null)
                    {
                        errorCase = casesForReport_FS11.SingleOrDefault(i => int.Parse(i.PositionNumber) == int.Parse(item.bill_number));
                        shouldChangeToFS8 = true;
                    }

                    var management_fee_value = "-";
                    if (!string.IsNullOrEmpty(errorCase.BillingCode))
                    {

                        if (!serviceFeeValueCache.ContainsKey(errorCase.BillingCode))
                        {
                            var service_fee_value = cls_Get_ServiceFeeValue_for_BillingCode.Invoke(Connection, Transaction, new P_CAS_GSFVfBC_1721() { BillingCode = errorCase.BillingCode }, securityTicket).Result;
                            if (service_fee_value != null)
                                serviceFeeValueCache.Add(errorCase.BillingCode, service_fee_value.service_fee);
                        }

                        management_fee_value = serviceFeeValueCache[errorCase.BillingCode];
                    }

                    var negativeTransmitionQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                    negativeTransmitionQuery.Tenant_RefID = securityTicket.TenantID;
                    negativeTransmitionQuery.IsDeleted = false;
                    negativeTransmitionQuery.BillPosition_RefID = errorCase.StatusID;

                    var negativeTransmition = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, negativeTransmitionQuery).ToList();

                    var caseStatusQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                    caseStatusQuery.Tenant_RefID = securityTicket.TenantID;
                    caseStatusQuery.IsDeleted = false;
                    caseStatusQuery.IsActive = true;
                    caseStatusQuery.BIL_BillPosition_TransmitionStatusID = errorCase.StatusID;

                    var caseStatusOld = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, caseStatusQuery).SingleOrDefault();

                    if (caseStatusOld == null)
                        throw new Exception("Transmition status not found for id: " + errorCase.StatusID);

                    OldTransmitionDateList.Add(caseStatusOld.TransmittedOnDate);
                    caseStatusOld.IsActive = false;
                    caseStatusOld.Save(Connection, Transaction);

                    var caseStatus = new ORM_BIL_BillPosition_TransmitionStatus();
                    caseStatus.IsDeleted = false;
                    caseStatus.Creation_Timestamp = DateTime.Now;
                    caseStatus.Modification_Timestamp = DateTime.Now;
                    caseStatus.Tenant_RefID = securityTicket.TenantID;
                    caseStatus.IsActive = true;
                    caseStatus.PrimaryComment = item.error_message;
                    caseStatus.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                    caseStatus.BillPosition_RefID = caseStatusOld.BillPosition_RefID;
                    caseStatus.TransmitionCode = 5;
                    caseStatus.TransmittedOnDate = DateTime.Now;// should we use from edifact?
                    caseStatus.TransmitionStatusKey = caseStatusOld.TransmitionStatusKey;
                    caseStatus.Save(Connection, Transaction);

                    if (shouldChangeToFS8)
                    {
                        caseStatus.IsActive = false;
                        caseStatus.Save(Connection, Transaction);


                        var caseStatus2 = new ORM_BIL_BillPosition_TransmitionStatus();
                        caseStatus2.IsDeleted = false;
                        caseStatus2.Creation_Timestamp = DateTime.Now;
                        caseStatus2.Modification_Timestamp = DateTime.Now;
                        caseStatus2.Tenant_RefID = securityTicket.TenantID;
                        caseStatus2.IsActive = true;
                        caseStatus2.PrimaryComment = item.error_message;
                        caseStatus2.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                        caseStatus2.BillPosition_RefID = caseStatusOld.BillPosition_RefID;
                        caseStatus2.TransmitionCode = 8;
                        caseStatus2.TransmittedOnDate = DateTime.Now;// should we use from edifact?
                        caseStatus2.TransmitionStatusKey = caseStatusOld.TransmitionStatusKey;
                        caseStatus2.Save(Connection, Transaction);
                    }

                    Guid caseID = errorCase.CaseID;
                    NegativeResponseModel negativeResponse = new NegativeResponseModel();

                    negativeResponse.caseID = caseID;
                    //casesToChange.Add(caseID);
                    if (caseStatusOld.TransmitionStatusKey == "aftercare")
                    {
                        negativeResponse.plannedActionID = errorCase.IsAftercareID;
                        negativeResponse.type = "ac";
                    }

                    //typeList.Add("ac");
                    else if (caseStatusOld.TransmitionStatusKey == "treatment")
                    {
                        negativeResponse.plannedActionID = errorCase.IsTreatmentID;
                        negativeResponse.type = "op";
                    }
                    else
                    {
                        negativeResponse.plannedActionID = errorCase.IsTreatmentID;
                        negativeResponse.type = caseStatusOld.TransmitionStatusKey;
                    }
                    //typeList.Add("op");

                    NegativeResponseList.Add(negativeResponse);

                    P_PA_GPDfPID_1124 patientData = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = errorCase.Patient_RefID }, securityTicket).Result;


                    #region Report data

                    CaseForReportModel caseModel = new CaseForReportModel();
                    caseModel.HIP = patientData.health_insurance_provider;
                    caseModel.ContractID = patientData.contractID;
                    caseModel.HIP_IK = patientData.HealthInsurance_IKNumber;
                    caseModel.PatientInsuranceNumber = patientData.insurance_id;
                    caseModel.PatientGender = patientData.gender;
                    caseModel.PatientStatusNumber = patientData.insurance_status;
                    caseModel.PatientFirstName = patientData.patient_first_name;
                    caseModel.PatientLastName = patientData.patient_last_name;
                    caseModel.PatientBirthday = patientData.birthday;
                    try
                    {
                        if (!consentValidToCache.ContainsKey(patientData.contractID))
                        {
                            double DurationOfParticipationConsentinMonths = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                            {
                                IsDeleted = false,
                                Tenant_RefID = securityTicket.TenantID,
                                ParameterName = "Duration of participation consent – Month",
                                Contract_RefID = patientData.contractID

                            }).SingleOrDefault().IfNumericValue_Value;
                            consentValidToCache.Add(patientData.contractID, Convert.ToInt32(DurationOfParticipationConsentinMonths));
                        }

                        DateTime participationConsentValidTo = patientData.ParticipationConsent.OrderBy(dt => dt.participation_consent_issue_date).FirstOrDefault().participation_consent_issue_date.AddMonths(consentValidToCache[patientData.contractID]);
                        caseModel.PatientParticipationConsentValidUntil = participationConsentValidTo;
                    }
                    catch (Exception ex)
                    {
                        caseModel.PatientParticipationConsentValidUntil = DateTime.MinValue;
                    }

                    caseModel.CaseNumber = Convert.ToInt32(errorCase.CaseNumber);
                    caseModel.CaseType = errorCase.CodeName;

                    try
                    {
                        caseModel.Drug = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = errorCase.DrugID }, securityTicket).Result.drug_name;

                    }
                    catch (Exception ex)
                    {
                        caseModel.Drug = "-";
                    }

                    caseModel.Diagnose = errorCase.IM_PotentialDiagnosis_Name;
                    caseModel.DiagnoseCode = errorCase.IM_PotentialDiagnosis_Code;
                    caseModel.Localization = errorCase.IM_PotentialDiagnosisLocalization_Code;

                    P_CAS_GTCfPIDaDIDaLC_1008 parameterDia = new P_CAS_GTCfPIDaDIDaLC_1008();
                    parameterDia.PatientID = errorCase.Patient_RefID;
                    parameterDia.DiagnoseID = errorCase.CodeForType == "treatment" || errorCase.CodeForType == "preexamination" ? errorCase.TreatmentPerformedDiganoseID : errorCase.AftercasePerformedDiagnoseID;
                    parameterDia.LocalizationCode = errorCase.IM_PotentialDiagnosisLocalization_Code;
                    parameterDia.PerformedDate = errorCase.CodeForType == "treatment" || errorCase.CodeForType == "preexamination" ? errorCase.TreatmentDate : errorCase.AfterCareDate;
                    parameterDia.ActionTypeID = treatment_performed_action_type_id;
                    if (errorCase.CodeForType == "preexamination")
                    {
                        if (preexaminationsCache.ContainsKey(errorCase.Patient_RefID) && preexaminationsCache[errorCase.Patient_RefID].ContainsKey(errorCase.IM_PotentialDiagnosisLocalization_Code))
                            caseModel.TreatmentCount = preexaminationsCache[errorCase.Patient_RefID][errorCase.IM_PotentialDiagnosisLocalization_Code].Count(c => c.PreexaminationDate.Date <= errorCase.TreatmentDate.Date);
                    }
                    else
                    {
                        caseModel.TreatmentCount = cls_Get_Treatment_Count_for_PatientID_And_DiagnoseID_and_LocalizationCode.Invoke(Connection, Transaction, parameterDia, securityTicket).Result.treatment_count;
                    }

                    caseModel.GPOS = errorCase.BillingCode;
                    caseModel.TreatmentDay = errorCase.CodeForType == "treatment" || errorCase.CodeForType == "preexamination" ? errorCase.TreatmentDate : errorCase.AfterCareDate;
                    if (errorCase.CodeForType == "treatment")
                    {
                        caseModel.SurgeryDateForThisCase = errorCase.TreatmentDate;
                    }
                    else if (errorCase.CodeForType == "preexamination")
                    {
                        caseModel.SurgeryDateForThisCase = DateTime.MinValue;
                    }
                    else
                    {
                        CAS_GTdfA_0936 Trdate = cls_Get_Treatment_Date_for_Aftercare.Invoke(Connection, Transaction, new P_CAS_GTdfA_0936() { CaseID = errorCase.CaseID }, securityTicket).Result;
                        if (Trdate != null)
                        {
                            caseModel.SurgeryDateForThisCase = Trdate.TreatmentDate;
                        }
                    }

                    switch (patientData.gender)
                    {
                        case 0:
                            caseModel.PatientSalutation = "Herr";
                            break;
                        case 1:
                            caseModel.PatientSalutation = "Frau";
                            break;
                        default:
                            caseModel.PatientSalutation = "-";
                            break;
                    }

                    if (!shouldChangeToFS8)
                        caseModel.CurrentStatus = FS5;
                    else
                        caseModel.CurrentStatus = FS8;
                    caseModel.DateOfCurrentStatus = DateTime.Now;
                    if (!shouldChangeToFS8)
                        caseModel.PreCurrentStatus = FS2;
                    else
                        caseModel.PreCurrentStatus = FS11;
                    caseModel.DateOfPreCurrentStatus = caseStatusOld.TransmittedOnDate;

                    caseModel.InvoiceNumberForTheHIP = Convert.ToInt32(errorCase.PositionNumber);

                    caseModel.AmountForThisGPOS = errorCase.NumberForPayment;
                    caseModel.NumberOfNegativeTry = negativeTransmition.Count.ToString();
                    caseModel.DateOfTheSubmissionToTheHIP = Parameter.transferToHIPDate;
                    caseModel.FeedBackOfTheHIP = item.transmition_date;
                    caseModel.PaymentDate = DateTime.MinValue;

                    caseModel.DrugOrdered = (errorCase.orderId != Guid.Empty && int.Parse(errorCase.orderStatusCode) != 6) ? "Ja" : "Nein";
                    caseModel.NoFee = errorCase.IsPatientFeeWaived ? "Ja" : "Nein";
                    caseModel.InvoiceToPractice = errorCase.SendInvoiceToPractice ? "Ja" : "Nein";
                    caseModel.OnlyLabelRequired = errorCase.isLabelOnly ? "Ja" : "Nein";

                    var gposAssignmentCount = cls_Get_Gpos_AssignmentCount_for_GposID.Invoke(Connection, Transaction, new P_CAS_GGPOSACfGPOSID_1252() { GposID = errorCase.GposID }, securityTicket).Result;
                    if (gposAssignmentCount.AssignmentCount != 0)
                    {
                        var is_management_fee_waived = cls_Get_Management_Fee_Property_Value_for_CaseID_and_GposID.Invoke(Connection, Transaction, new P_CAS_GMFPVfCIDaGPOSTID_1749() { CaseID = errorCase.CaseID, GposID = errorCase.GposID }, securityTicket).Result;
                        caseModel.ManagementFee = is_management_fee_waived == null ? "-" : is_management_fee_waived.PropertyValue == "waived" ? "-" : management_fee_value;
                    }
                    else
                    {
                        caseModel.ManagementFee = "-";
                    }

                    Guid DocID = errorCase.CodeForType == "treatment" || errorCase.CodeForType == "preexamination" ? errorCase.SurgeryDoctor : errorCase.AfterCareDoctor;

                    DO_GDDfDID_0823 doctorData = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = DocID }, securityTicket).Result.First();

                    caseModel.BSNR = doctorData.BSNR;
                    caseModel.PracticeName = doctorData.practice;
                    caseModel.DocName = doctorData.first_name + " " + doctorData.last_name;
                    caseModel.LANR = doctorData.lanr;
                    caseModel.BankAccountHolder = string.IsNullOrEmpty(doctorData.OwnerText) ? "-" : doctorData.OwnerText;
                    caseModel.BankName = doctorData.BankName == null ? "-" : doctorData.BankName;
                    caseModel.IBAN = doctorData.IBAN == null ? "-" : doctorData.IBAN;
                    caseModel.BIC = doctorData.BICCode == null ? "-" : doctorData.BICCode;

                    caseModelList.Add(caseModel);


                    #endregion
                }
                catch (Exception ex)
                {
                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry(ex.StackTrace));
                    throw new Exception("Bill position: " + item.bill_number, ex);
                }
            }

            //Change in Elastic---------------------------------------------------------------------------------

            for (int k = 0; k < NegativeResponseList.Count; k++)
            {
                var errorCase = allCases.SingleOrDefault(i => i.case_id == NegativeResponseList[k].caseID.ToString() && i.type == NegativeResponseList[k].type);
                if (errorCase == null)
                {
                    errorCase = allCases_FS11.SingleOrDefault(i => i.case_id == NegativeResponseList[k].caseID.ToString() && i.type == NegativeResponseList[k].type);
                    if (errorCase == null)
                        continue;

                    errorCase.status = "FS8";
                    //Change settlement from Stornierung anhängig to storniert
                    Settlement_Model settlement = Get_Settlement.GetSettlementForID(NegativeResponseList[k].plannedActionID.ToString(), securityTicket);
                    settlement.status = "FS8";
                    settlements.Add(settlement);
                    PatientDetailViewModel patient_detail = Retrieve_Patients.Get_PatientDetaiForID(settlement.id, securityTicket);
                    if (patient_detail != null)
                    {
                        patient_detail.status = "FS8";
                        patientDetailList.Add(patient_detail);
                    }
                }
                else
                {
                    errorCase.status = "FS5";
                }

                errorCase.status_date = DateTime.Now;
                errorCase.status_date_string = DateTime.Now.ToString("dd.MM.yyyy");
                newCaseList.Add(errorCase);
            }

            if (settlements.Count > 0)
                Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements, securityTicket.TenantID.ToString());

            if (patientDetailList.Count > 0)
                Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());

            if (newCaseList.Count > 0)
            {
                Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(newCaseList, securityTicket.TenantID.ToString());

                List<Documents> documentList = new List<Documents>();


                string hipID = Parameter.hipId;

                var healthInsuranceCompanyQuery = new ORM_HEC_HIS_HealthInsurance_Company.Query();
                healthInsuranceCompanyQuery.IsDeleted = false;
                healthInsuranceCompanyQuery.Tenant_RefID = securityTicket.TenantID;
                healthInsuranceCompanyQuery.HealthInsurance_IKNumber = hipID;

                var helathInsurance = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, healthInsuranceCompanyQuery).Single();

                var businessParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                businessParticipantQuery.CMN_BPT_BusinessParticipantID = helathInsurance.CMN_BPT_BusinessParticipant_RefID;
                businessParticipantQuery.IsDeleted = false;
                businessParticipantQuery.Tenant_RefID = securityTicket.TenantID;

                var businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQuery).Single();
                //Save Edifact
                string edi_path = System.IO.Path.GetTempPath() + Parameter.edi_name;
                System.IO.File.WriteAllText(edi_path, Parameter.edi_message);
                List<string> files = new List<string>();
                files.Add(edi_path);

                string zipPath = System.IO.Path.GetTempPath() + Parameter.edi_name + ".zip";
                ZipFIlesUtils.AddToArchive(zipPath, files);

                string earliestDate = OldTransmitionDateList.OrderBy(d => d).First().ToString("dd.MM.yyyy");
                string lastDate = OldTransmitionDateList.OrderBy(d => d).Last().ToString("dd.MM.yyyy");
                Documents documentEdifact = new Documents();
                documentEdifact.documentName = "Import von " + earliestDate + " - " + lastDate;
                documentEdifact.documentOutputLocation = zipPath;
                documentEdifact.receiver = businessParticipant.DisplayName;
                documentEdifact.mimeType = "Application/Edifact_Error";
                documentList.Add(documentEdifact);

                Documents documentExcel = new Documents();

                documentExcel.documentName = "ExcelReport" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm");
                documentExcel.documentOutputLocation = GenerateReportCases.CreateCaseXlsReport(caseModelList, documentExcel.documentName);
                documentExcel.mimeType = UtilMethods.GetMimeType(documentExcel.documentOutputLocation);
                documentExcel.receiver = "MM";
                documentList.Add(documentExcel);

                foreach (var item in documentList)
                {
                    MemoryStream ms = new MemoryStream(File.ReadAllBytes(item.documentOutputLocation));

                    byte[] byteArrayFile = ms.ToArray();
                    var _providerFactory = ProviderFactory.Instance;
                    var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                    var uploadedFrom = HttpContext.Current.Request.UserHostAddress;
                    Guid documentID = documentProvider.UploadDocument(byteArrayFile, item.documentOutputLocation, securityTicket.SessionTicket, uploadedFrom);
                    string downloadURL = documentProvider.GenerateImageThumbnailLink(documentID, securityTicket.SessionTicket, false, 200);

                    P_ARCH_UD_1326 parameterDoc = new P_ARCH_UD_1326();
                    parameterDoc.DocumentID = documentID;
                    parameterDoc.Mime = item.mimeType;
                    parameterDoc.DocumentName = item.documentName;
                    parameterDoc.DocumentDate = DateForElastic;
                    parameterDoc.Receiver = item.receiver;
                    parameterDoc.ContractID = item.ContractID;

                    if (parameterDoc.Mime == "Application/Edifact_Error")
                        parameterDoc.Description = parameterDoc.DocumentName;
                    else
                        parameterDoc.Description = "KV Fehler";

                    cls_Upload_Report.Invoke(Connection, Transaction, parameterDoc, securityTicket);
                }


            }


            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_CCtSE_1100 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_CCtSE_1100 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CCtSE_1100 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CCtSE_1100 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method cls_Change_Case_to_Status_Error", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_CCtSE_1100 for attribute P_CAS_CCtSE_1100
    [DataContract]
    public class P_CAS_CCtSE_1100
    {
        [DataMember]
        public P_CAS_CCtSE_1100_Cases[] CasesToBeChanged { get; set; }

        //Standard type parameters
        [DataMember]
        public String edi_message { get; set; }
        [DataMember]
        public String edi_name { get; set; }
        [DataMember]
        public String hipId { get; set; }
        [DataMember]
        public DateTime transferToHIPDate { get; set; }

    }
    #endregion
    #region SClass P_CAS_CCtSE_1100_Cases for attribute CasesToBeChanged
    [DataContract]
    public class P_CAS_CCtSE_1100_Cases
    {
        //Standard type parameters
        [DataMember]
        public String bill_number { get; set; }
        [DataMember]
        public String error_message { get; set; }
        [DataMember]
        public DateTime transmition_date { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Change_Case_to_Status_Error(,P_CAS_CCtSE_1100 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Change_Case_to_Status_Error.Invoke(connectionString,P_CAS_CCtSE_1100 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CCtSE_1100();
parameter.CasesToBeChanged = ...;

parameter.edi_message = ...;
parameter.edi_name = ...;
parameter.hipId = ...;
parameter.transferToHIPDate = ...;

*/
