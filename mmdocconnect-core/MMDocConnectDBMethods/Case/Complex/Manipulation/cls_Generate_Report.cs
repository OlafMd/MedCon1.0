/* 
 * Generated on 08/30/17 10:31:21
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
#define OLAF

using CL1_CMN;
using CL1_CMN_CTR;
using CL1_HEC_ACT;
using CL1_HEC_CAS;
using CL1_HEC_CRT;
using CSV2Core.Core;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Case.Models;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectUtils;
using MMDocConnectUtils.ExcelTemplates;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Configuration;

namespace MMDocConnectDBMethods.Case.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Generate_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Generate_Report
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_GR_1608 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_GR_1608 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null, bool? ShowOnlyAok = null)
        {
            #region UserCode
            //Put your code here
            var returnValue = new FR_CAS_GR_1608();


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var cases = new List<CaseForReportModel>();

            #region DATA PRE-FETCHING

            LogUtils.Logger.LogInfo(new LogUtils.LogEntry("DATA PRE-FETCHING"));

            // todo: retrieve only in status
            var languageId = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false }).First().CMN_LanguageID;
            // 105
            Dictionary<Guid, List<DateTime>> allPerformedOpDates =
                cls_Get_PerformedOpDates_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.Select(x => x.treatment_date).ToList());

            LogTime(stopWatch, "");

            // 24
            var gposes = cls_Get_GposNames_on_Tenant.Invoke(Connection, Transaction, new P_CAS_GGposNoT_1525() { LanguageID = languageId }, securityTicket).Result.GroupBy(t => t.gpos_id).ToDictionary(t => t.Key, t => t.Single().gpos_name);

#if OLAF
            List<CaseBillingData> caseBillPositionData = null;
            if (Parameter.statuses != null && Parameter.statuses.Any())
            {


                // 266405
                caseBillPositionData = cls_Get_Case_BillingData_on_Tenant_for_Status.Invoke(Connection, Transaction,
                new P_CAS_GCBDoTfS_1405() { Statuses = Array.ConvertAll<int, string>(Parameter.statuses, t => t.ToString()) }, securityTicket).Result.Select(t => new CaseBillingData()
                {
                    bill_position_id = t.bill_position_id,
                    bill_position_number = t.bill_position_number,
                    case_id = t.case_id,
                    case_number = t.case_number,
                    fs_status_code = t.fs_status_code,
                    fs_status_id = t.fs_status_id,
                    fs_status_key = t.fs_status_key,
                    gpos_code = t.gpos_code,
                    gpos_id = t.gpos_id,
                    gpos_price = t.gpos_price,
                    gpos_type = t.gpos_type,
                    hec_bill_position_id = t.hec_bill_position_id
                })
                .Where(t => Parameter.position_numbers != null && Parameter.position_numbers.Any()
                ? Parameter.position_numbers.Any(x => !String.IsNullOrEmpty(t.bill_position_number) && x == Double.Parse(t.bill_position_number)) : true)
                .ToList();
                LogTime(stopWatch, "2");
            }
            else
            {
                // 266405
                caseBillPositionData = cls_Get_Case_BillingData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Select(t => new CaseBillingData()
                {
                    bill_position_id = t.bill_position_id,
                    bill_position_number = t.bill_position_number,
                    case_id = t.case_id,
                    case_number = t.case_number,
                    fs_status_code = t.fs_status_code,          // Not used
                    fs_status_id = t.fs_status_id,
                    fs_status_key = t.fs_status_key,
                    gpos_code = t.gpos_code,
                    gpos_id = t.gpos_id,
                    gpos_price = t.gpos_price,
                    gpos_type = t.gpos_type,
                    hec_bill_position_id = t.hec_bill_position_id
                })
                .ToList();
                LogTime(stopWatch, "3");
            }


#else
            var caseBillPositionData = Parameter.statuses != null && Parameter.statuses.Any() ?
                cls_Get_Case_BillingData_on_Tenant_for_Status.Invoke(Connection, Transaction, 
                new P_CAS_GCBDoTfS_1405() { Statuses = Array.ConvertAll<int, string>(Parameter.statuses, t => t.ToString()) }, securityTicket).Result.Select(t => new CaseBillingData()
                {
                    bill_position_id = t.bill_position_id,
                    bill_position_number = t.bill_position_number,
                    case_id = t.case_id,
                    case_number = t.case_number,
                    fs_status_code = t.fs_status_code,
                    fs_status_id = t.fs_status_id,
                    fs_status_key = t.fs_status_key,
                    gpos_code = t.gpos_code,
                    gpos_id = t.gpos_id,
                    gpos_price = t.gpos_price,
                    gpos_type = t.gpos_type,
                    hec_bill_position_id = t.hec_bill_position_id
                }).Where(t => Parameter.position_numbers != null && Parameter.position_numbers.Any() ? Parameter.position_numbers.Any(x => !String.IsNullOrEmpty(t.bill_position_number) && x == Double.Parse(t.bill_position_number)) : true)
                .ToList() :
                cls_Get_Case_BillingData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Select(t => new CaseBillingData()
                {
                    bill_position_id = t.bill_position_id,
                    bill_position_number = t.bill_position_number,
                    case_id = t.case_id,
                    case_number = t.case_number,
                    fs_status_code = t.fs_status_code,
                    fs_status_id = t.fs_status_id,
                    fs_status_key = t.fs_status_key,
                    gpos_code = t.gpos_code,
                    gpos_id = t.gpos_id,
                    gpos_price = t.gpos_price,
                    gpos_type = t.gpos_type,
                    hec_bill_position_id = t.hec_bill_position_id
                }).ToList();
#endif

#if OLAF
            // 8
            CAS_GDOCIDsoT_1543[] fake_case_ids = cls_Get_DocumentationOnly_CaseIDs_on_Tenant.Invoke(Connection, Transaction, new P_CAS_GDOCIDsoT_1543() { PropertyGpmID = ECaseProperty.FakeCase.Value() }, securityTicket).Result;
            LogTime(stopWatch, "4");
#else
            var fake_case_ids = cls_Get_DocumentationOnly_CaseIDs_on_Tenant.Invoke(Connection, Transaction,
                new P_CAS_GDOCIDsoT_1543() { PropertyGpmID = ECaseProperty.FakeCase.Value() }, securityTicket)
                .Result;
#endif
            //266405    
            caseBillPositionData = caseBillPositionData.Where(t => t.gpos_type != EGposType.Operation.Value() || (t.gpos_type == EGposType.Operation.Value() && !fake_case_ids.Any(r => r.case_id == t.case_id))).ToList();
            LogTime(stopWatch, "5");

#if OLAF
            // Nicht optimierbar, nur keys
            IEnumerable<IGrouping<Guid, CAS_GCBDoT_0911>> caseBaseDataCache1 = cls_Get_Case_BaseData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.case_id);

            // 89835    op_planned_action_id
            Dictionary<Guid, CAS_GCBDoT_0911> caseBaseDataCache = caseBaseDataCache1.ToDictionary(t => t.Key, t => t.First()); ;
            LogTime(stopWatch, "6");
#else
#endif

#if OLAF
            // return new FR_CAS_GR_1608();
#else
#endif
            // 79851
            Dictionary<Guid, CAS_GCTDoT_0932>
                caseTreatmentDataCache = cls_Get_Case_Treatment_Data_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.Single());
            LogTime(stopWatch, "7");

            // 49376
            Dictionary<Guid, CAS_GCDODoT_1131>
                caseDrugOrderDataCache = cls_Get_Case_DrugOrderData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.hec_order_position_id).ToDictionary(t => t.Key, t => t.Single());
            LogTime(stopWatch, "8");

            //39901
            Dictionary<Guid, bool>
                caseInvoiceToPracticeDataCache = cls_Get_Case_InvoiceToPracticeData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.Single().is_send_invoice_to_practice);
            LogTime(stopWatch, "9");


            // Durch Refactoring a. 170.000 Diagnose-Records weniger im Mnmory!!!
            Dictionary<Guid, List<CAS_GCADDoT_1332>> nonOctActionDiagnoseData, allOctActionDiagnoseData;

            GetDiagnoseData(Connection, Transaction, securityTicket, out nonOctActionDiagnoseData, out allOctActionDiagnoseData);

            LogTime(stopWatch, "0");

            // 67800
            Dictionary<Guid, IGrouping<Guid, CAS_GMFPVoT_1916>>
            managementFeeWaivedCache = cls_Get_Management_Fee_Property_Values_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t);
            LogTime(stopWatch, "1");

            // 10
            Dictionary<Guid, string>
                drugNameCache = cls_Get_Drug_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DrugID).ToDictionary(t => t.Key, t => t.Single().DrugName);
            LogTime(stopWatch, "12");

            // 77973 CAS_GCSFSSoT_1858

            Dictionary<Guid, IGrouping<Guid, MMDocConnectDBMethods.Case.Atomic.Retrieval.CAS_GCFSSoT_1858>>
                caseFSStatusCache = cls_Get_Case_FS_Statuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t);
            LogTime(stopWatch, "3");

            // 1
            Guid aftercarePlannedActionTypeID = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedAftercare.Value() }, securityTicket).Result;
            LogTime(stopWatch, "14");

            // 79752
            Dictionary<Guid, List<CAS_GRPAfATIDoT_1656>> aftercareCache = cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant.Invoke(Connection, Transaction, new P_CAS_GRPAfATIDoT_1656()
            {
                ActionTypeID = aftercarePlannedActionTypeID,
                IsPerformed = false
            }, securityTicket).Result.OrderBy(ra => ra.CreationTimestamp).GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.ToList());
            LogTime(stopWatch, "5");

            // 1
            Guid octPlannedActionTypeId = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
            LogTime(stopWatch, "16");

            // 6388
            Dictionary<Guid, List<CAS_GRPAfATIDoT_1656>> octCache = cls_Get_RelevantPlannedActions_for_ActionTypeID_on_Tenant.Invoke(Connection, Transaction, new P_CAS_GRPAfATIDoT_1656()
            {
                ActionTypeID = octPlannedActionTypeId,
                IsPerformed = Parameter.position_numbers != null && Parameter.position_numbers.Any()
            }, securityTicket).Result.OrderBy(ra => ra.CreationTimestamp).GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());
            LogTime(stopWatch, "17");

            //77819
            Dictionary<Guid, int>
                gposAssignmentsCountCache = cls_Get_Number_of_GposTypes_on_Case_for_CaseID_and_GposType.Invoke(Connection, Transaction, new P_CAS_GNoGPOSToCfCIDaGPOST_1023()
                {
                    GposType = EGposType.Operation.Value()
                }, securityTicket).Result.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.Single().NumberOfTreatmentGposes);
            LogTime(stopWatch, "18");


            // 245242 (ev. Spalte T aktueller Prozess-Status, wahrscheinlicher Spalte K "Typ" (e.g. "Nachsorge")
            // STatusCode und StatusType sind verschiedene Sachen...
            Dictionary<Guid, IGrouping<Guid, CAS_GTSoT_1718>>
                statuses = cls_Get_TransmitionStatuses_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.BillPositionID).ToDictionary(t => t.Key, t => t);
            LogTime(stopWatch, "19");

            // 1
            Guid fakeCaseUniversalPropertyID = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                GlobalPropertyMatchingID = "mm.doc.connect.case.treatment.year.fake"
            }).Single().HEC_CAS_Case_UniversalPropertyID;
            LogTime(stopWatch, "20");


            // 6452 Alle Behandlungen nach Patienten sortiert ( Spalte O)
            Dictionary<Guid, IGrouping<Guid, CAS_GTDuT_1931>>
                treatmentCountCache = cls_Get_Treatment_Data_using_Temporary.Invoke(Connection, Transaction, new P_CAS_GTDuT_1931()
                {
                    CaseUniversalPID = fakeCaseUniversalPropertyID
                }, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t);
            LogTime(stopWatch, "21");

            // 351  // Arztdaten mit Bankdaten
            var doctorDataCache = cls_Get_Doctor_Details_for_Report.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.DoctorBptID).ToDictionary(t => t.Key, t => t);
            LogTime(stopWatch, "22");

            // 201 Praxisdatenmit Bankdaten
            var practiceDataCache = cls_Get_Practice_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PracticeBptID).ToDictionary(t => t.Key, t => t);
            LogTime(stopWatch, "23");

            // 254201   // Fast nur Schlüssel
            List<ORM_HEC_ACT_PlannedAction>
                plannedActions = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
            LogTime(stopWatch, "24");

            //7171 (B, C, D, E, F)
            Dictionary<Guid, PA_GPDoT_0910>
                patientDataCache = cls_Get_Patient_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.Single());
            LogTime(stopWatch, "25");

            // 3
            Dictionary<Guid, List<ORM_CMN_CTR_Contract_Parameter>>
                contractParameterCache = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).GroupBy(t => t.Contract_RefID).ToDictionary(t => t.Key, t => t.ToList());
            LogTime(stopWatch, "26");

            // 6557 // Verbindungstabelle
            Dictionary<Guid, List<ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient>>
                patientConsentCache = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                {
                    Tenant_RefID = securityTicket.TenantID
                }).GroupBy(t => t.Patient_RefID).ToDictionary(t => t.Key, t => t.ToList());
            LogTime(stopWatch, "17");

            // 24
            Dictionary<Guid, Guid>
            contractGposComboCache = cls_Get_ContractID_GposID_Combinations_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.GposID).ToDictionary(t => t.Key, t => t.Single().ContractID);
            LogTime(stopWatch, "28");

            // 244014 Casetype e.g. "treatment"
            Dictionary<Guid, List<CAS_GNoNToT_1822>>
                numberOfNegativeTriesCache = cls_Get_Number_of_Negative_Tries_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.BillPositionID).ToDictionary(t => t.Key, t => t.ToList());
            LogTime(stopWatch, "29");

            // 271227 GPosType e.g. "operation", PositionType e.g. "treatment")
            List<CAS_GACBPoT_1820>
                allBillPositionsOnTenant = cls_Get_All_Case_BillPositions_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Where(x => !x.IsDeleted).ToList();
            LogTime(stopWatch, "30");

            // 79833 nach CaseId geordnet (IsDeleted, PositionType
            Dictionary<Guid, List<CAS_GACBPoT_1820>>
                nonOctBillPositions = allBillPositionsOnTenant.GroupBy(t => t.CaseID).ToDictionary(t => t.Key, t => t.ToList());
            LogTime(stopWatch, "31");

            // 6488 nach PatientId geordnet
            Dictionary<Guid, List<CAS_GACBPoT_1820>>
                octBillPositions = allBillPositionsOnTenant.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());
            LogTime(stopWatch, "32");

            // 7171 Patient-Krankenkasse (A 
            Dictionary<Guid, List<PA_GPIDoT_1002>>
                patientInsurancesCache = cls_Get_Patient_Insurance_Data_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());
            LogTime(stopWatch, "33");

            #endregion CACHE

            var case_to_test_hip = WebConfigurationManager.AppSettings["test-hip-for-case"];
            var caseModel = default(CaseForReportModel);
            for (var index = 0; index < caseBillPositionData.Count; index++)
            {
                CaseBillingData caseBillPosition = caseBillPositionData[index];

                if (!caseBaseDataCache.ContainsKey(caseBillPosition.case_id) || !caseTreatmentDataCache.ContainsKey(caseBillPosition.case_id)) //|| index > 1000)
                {
                    continue;
                }

                var caseBaseData = caseBaseDataCache[caseBillPosition.case_id];

                try
                {
                    var caseDrugOrderData = caseDrugOrderDataCache.ContainsKey(caseBaseData.drug_order_position_id) ? caseDrugOrderDataCache[caseBaseData.drug_order_position_id] : null;
                    var patientData = patientDataCache[caseBaseData.patient_id];


                    var diagnoseData = caseTreatmentDataCache[caseBaseData.case_id];
                    var is_ac_op_billed_together = false;
                    var diagnoseId = diagnoseData.diagnose_id;
                    var localizationCode = diagnoseData.localization;
                    var management_fee_value = "-";
                    var doctor_bpt_id = Guid.Empty;

                    if (caseBillPosition.gpos_type == EGposType.Aftercare.Value() && (!caseBaseData.is_op_performed || !aftercareCache.ContainsKey(caseBaseData.case_id)))
                    {
                        continue;
                    }

                    caseModel = new CaseForReportModel();
                    caseModel.TransmitionStatusID = caseBillPosition.fs_status_id;

                    #region Diagnose data

                    caseModel.Diagnose = diagnoseData.diagnose_name ?? "-";
                    caseModel.DiagnoseCode = diagnoseData.diagnose_code ?? "-";
                    caseModel.Localization = diagnoseData.localization;

                    #endregion Diagnose data

                    AddDrug(caseInvoiceToPracticeDataCache, drugNameCache, caseModel, caseBaseData, caseDrugOrderData);


                    is_ac_op_billed_together = AddBilling(managementFeeWaivedCache, caseFSStatusCache, gposAssignmentsCountCache, caseModel, caseBillPosition, caseBaseData, is_ac_op_billed_together, management_fee_value);


                    #region Patient

                    #region Base data

                    caseModel.PatientGender = patientData.Gender;
                    caseModel.PatientFirstName = patientData.FirstName;
                    caseModel.PatientLastName = patientData.LastName;
                    caseModel.PatientBirthday = patientData.BirthDate;

                    #endregion Base data


                    AddAnrede(caseModel, patientData);


                    #endregion Patient

                    #region Base data

                    caseModel.CaseNumber = Convert.ToInt32(caseBaseData.case_number);
                    caseModel.CaseType = !is_ac_op_billed_together ? gposes[caseBillPosition.gpos_id] : caseBillPosition.gpos_price == 60 ? "Nachsorge" : gposes[caseBillPosition.gpos_id];
                    caseModel.CaseID = caseBaseData.case_id;
                    caseModel.GposID = caseBillPosition.gpos_id;
                    caseModel.CodeForType = caseBillPosition.fs_status_key;

                    #endregion Base data

                    var dateToMatchInsuranceDate = DateTime.MinValue;

                    dateToMatchInsuranceDate = AddStatus(statuses, numberOfNegativeTriesCache, caseModel, caseBillPosition, dateToMatchInsuranceDate);

                    // var AOKvERSICHERT = patientInsurancesCache[caseBaseData.patient_id].OrderByDescending(t => t.InsuranceDate).First(t => t.HipName.ToLower().Contains("aok"));



                    dateToMatchInsuranceDate = AddHipdata(patientInsurancesCache, case_to_test_hip, caseModel, caseBillPosition, caseBaseData, dateToMatchInsuranceDate);

                    if (ShowOnlyAok != null)
                    {
                        bool getAllAok = (bool)ShowOnlyAok;
                        if (caseModel.HIP.ToLower().Contains("aok"))
                        {
                            if (!getAllAok)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (getAllAok)
                            {
                                continue;
                            }
                        }
                    }

                    #region Treatment

                    AddTreatment(nonOctActionDiagnoseData, allOctActionDiagnoseData, aftercareCache, octCache, plannedActions,
                        nonOctBillPositions, octBillPositions, caseModel, caseBillPosition, caseBaseData, is_ac_op_billed_together,
                        ref diagnoseId, ref localizationCode, ref doctor_bpt_id);

                    if (Parameter.updateCasesSubmittedBeforeDate.HasValue && caseModel.TreatmentDay > Parameter.updateCasesSubmittedBeforeDate)
                    {
                        continue;
                    }

                    caseModel.TreatmentCount = !treatmentCountCache.ContainsKey(caseBaseData.patient_id) ? 0 : treatmentCountCache[caseBaseData.patient_id]
                        .Count(t => t.TreatmentDate.Date <= caseBaseData.op_date.Date && t.DiagnoseID == diagnoseId && t.LocalizationCode == localizationCode);

                    #endregion Treatment

                    AddConsent(allPerformedOpDates, contractParameterCache, patientConsentCache, contractGposComboCache, caseModel, caseBillPosition, caseBaseData);
                    AddDoctor(doctorDataCache, practiceDataCache, caseModel, doctor_bpt_id);

                    cases.Add(caseModel);
                }
                catch (Exception ex)
                {
                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry("EXCEPTION STACK TRACE"));
                    LogUtils.Logger.LogInfo(new LogUtils.LogEntry(ex.StackTrace));

                    var mess = ex.InnerException != null ? ex.InnerException.Message + "; " : "";
                    throw new Exception(String.Format("{0} - {1}; case number: {2}", mess, ex.Message, caseBaseData.case_number));
                }

                if (index > 266698)
                {
                    var a = 1;
                }

                if (index % 1000 == 0)
                {
                    LogTime(stopWatch, "-- baue Result: " + index.ToString());
                }
            }

            LogTime(stopWatch, "-- Vor Return --");

            returnValue.Result = new CAS_GR_1608
            {
                cases = cases.OrderBy(t => t.CaseNumber).ThenBy(t => t.InvoiceNumberForTheHIP == 0).ThenBy(t => t.InvoiceNumberForTheHIP).ToArray()
            };

            return returnValue;

            #endregion UserCode
        }

        private static void LogTime(Stopwatch stopWatch, string step)
        {
            string elapsedTime = StopWatch(stopWatch);
            LogUtils.Logger.LogInfo(new LogUtils.LogEntry(" -- " + step + " -- " + elapsedTime));
            stopWatch.Restart();
        }

        private static string StopWatch(Stopwatch stopWatch)
        {
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return elapsedTime;
        }

        private static void GetDiagnoseData(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, out Dictionary<Guid, List<CAS_GCADDoT_1332>> nonOctActionDiagnoseData, out Dictionary<Guid, List<CAS_GCADDoT_1332>> allOctActionDiagnoseData)
        {
            // 162878
            CAS_GCADDoT_1332[]
                allActionDiagnoseData = cls_Get_Case_ActionDiagnoseData_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            // 79897    Diagnosedaten nach Case_Id sortiert
            nonOctActionDiagnoseData = allActionDiagnoseData.GroupBy(t => t.case_id).ToDictionary(t => t.Key, t => t.ToList());

            // 6390 Diagnosedaten (nur OCT)
            allOctActionDiagnoseData = allActionDiagnoseData.Where(t => t.type == EActionType.PlannedOct.Value()).GroupBy(t => t.patient_id).ToDictionary(t => t.Key, t => t.ToList());
        }

        private static bool AddBilling(Dictionary<Guid, IGrouping<Guid, CAS_GMFPVoT_1916>> managementFeeWaivedCache,
            Dictionary<Guid, IGrouping<Guid, CAS_GCFSSoT_1858>> caseFSStatusCache,
            Dictionary<Guid, int> gposAssignmentsCountCache,
            CaseForReportModel caseModel,
            CaseBillingData caseBillPosition,
            CAS_GCBDoT_0911 caseBaseData,
            bool is_ac_op_billed_together,
            string management_fee_value)
        {
            #region Billing

            caseModel.GPOS = caseBillPosition.gpos_code;

            #region Management fee

            if (managementFeeWaivedCache.ContainsKey(caseBaseData.case_id))
            {
                var managementFee = managementFeeWaivedCache[caseBaseData.case_id].FirstOrDefault(t => t.GposID == caseBillPosition.gpos_id);
                caseModel.ManagementFee = managementFee == null ? "-" : managementFee.PropertyValue == "waived" ? "-" : management_fee_value;
            }
            else
            {
                caseModel.ManagementFee = "-";
            }

            #endregion Management fee

            #region Is case billed the old way

            List<CAS_GCFSSoT_1858> multiple_submitted_aftercares = new List<CAS_GCFSSoT_1858>();

            if (caseFSStatusCache.ContainsKey(caseBaseData.case_id))
            {
                is_ac_op_billed_together = gposAssignmentsCountCache.ContainsKey(caseBillPosition.gpos_id) ? gposAssignmentsCountCache[caseBaseData.case_id] > 1 : false;

                // Olaf: raus
                //multiple_submitted_aftercares = caseFSStatusCache[caseBaseData.case_id].Where(fs => fs.fs_key == "aftercare" && fs.is_status_active).ToList();
            }

            #endregion Is case billed the old way
            return is_ac_op_billed_together;
            #endregion Billing
        }

        private static void AddDrug(Dictionary<Guid, bool> caseInvoiceToPracticeDataCache, Dictionary<Guid, string> drugNameCache, CaseForReportModel caseModel, CAS_GCBDoT_0911 caseBaseData, CAS_GCDODoT_1131 caseDrugOrderData)
        {
            #region Drug

            caseModel.Drug = !drugNameCache.ContainsKey(caseBaseData.drug_id) ? "-" : drugNameCache[caseBaseData.drug_id];
            caseModel.DrugOrdered = (caseBaseData.drug_order_position_id != Guid.Empty && caseDrugOrderData != null && caseDrugOrderData.order_status_code > 0 && caseDrugOrderData.order_status_code < 6) ? "Ja" : "Nein";
            caseModel.NoFee = caseDrugOrderData != null && caseDrugOrderData.is_patient_fee_waived ? "Ja" : "Nein";
            caseModel.InvoiceToPractice = caseInvoiceToPracticeDataCache.ContainsKey(caseBaseData.case_id) && caseInvoiceToPracticeDataCache[caseBaseData.case_id] ? "Ja" : "Nein";
            caseModel.OnlyLabelRequired = caseDrugOrderData != null && caseDrugOrderData.is_label_only ? "Ja" : "Nein";

            #endregion Drug
        }

        private static void AddAnrede(CaseForReportModel caseModel, PA_GPDoT_0910 patientData)
        {
            #region Salutation

            switch (patientData.Gender)
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
            #endregion Salutation
        }

        private static DateTime AddStatus(Dictionary<Guid, IGrouping<Guid, CAS_GTSoT_1718>> statuses, Dictionary<Guid, List<CAS_GNoNToT_1822>> numberOfNegativeTriesCache, CaseForReportModel caseModel, CaseBillingData caseBillPosition, DateTime dateToMatchInsuranceDate)
        {
            #region Case status

            var statusCurrent = "-";
            var statusCurrentDate = DateTime.MinValue;
            var statusPrevious = "-";
            var statusPreviousDate = DateTime.MinValue;

            caseModel.AmountForThisGPOS = caseBillPosition.gpos_price;
            caseModel.CurrentStatus = "-";
            caseModel.DateOfCurrentStatus = DateTime.MinValue;
            caseModel.PreCurrentStatus = "-";
            caseModel.DateOfPreCurrentStatus = DateTime.MinValue;
            caseModel.InvoiceNumberForTheHIP = 0;
            caseModel.DateOfTheSubmissionToTheHIP = DateTime.MinValue;
            caseModel.FeedBackOfTheHIP = DateTime.MinValue;
            caseModel.PaymentDate = DateTime.MinValue;

            if (statuses.ContainsKey(caseBillPosition.hec_bill_position_id))
            {
                var fs_statuses = statuses[caseBillPosition.hec_bill_position_id].OrderByDescending(t => t.StatusDate).ToList();

                var status = fs_statuses.FirstOrDefault(d => d.IsActive);
                if (status != null)
                {
                    caseModel.FsStatus = status.StatusCode;
                    statusCurrent = "FS" + status.StatusCode;
                    caseModel.CurrentFsStatusCode = status.StatusCode;
                    statusCurrentDate = status.StatusDate;
                    try
                    {
                        var previousStatuses = fs_statuses.Where(t => !t.IsActive).ToArray();
                        caseModel.PositionWasPaid = fs_statuses.Any(t => t.StatusCode == 7);

                        var prevStatusIndex = previousStatuses.First().StatusCode == 12 ? 2 : 0;
                        statusPrevious = "FS" + previousStatuses[prevStatusIndex].StatusCode.ToString();
                        statusPreviousDate = previousStatuses[prevStatusIndex].StatusDate;
                    }
                    catch (Exception ex)
                    {
                        statusPrevious = "-";
                    }

                    #region TRANSLATIONS

                    string statusCurrentSt = TranslateStatus(statusCurrent);
                    string statusPreviousSt = TranslateStatus(statusPrevious);

                    #endregion TRANSLATIONS

                    caseModel.CurrentStatus = statusCurrentSt;
                    caseModel.DateOfCurrentStatus = statusCurrentDate;

                    caseModel.PreCurrentStatus = statusPreviousSt;
                    caseModel.DateOfPreCurrentStatus = statusPreviousDate;
                    caseModel.InvoiceNumberForTheHIP = !String.IsNullOrEmpty(caseBillPosition.bill_position_number) ? Convert.ToInt32(caseBillPosition.bill_position_number) : 0;
                    caseModel.AmountForThisGPOS = caseBillPosition.gpos_price;

                    caseModel.NumberOfNegativeTry = "0";
                    if (numberOfNegativeTriesCache.ContainsKey(caseBillPosition.hec_bill_position_id))
                    {
                        var negativeTries = numberOfNegativeTriesCache[caseBillPosition.hec_bill_position_id];
                        caseModel.NumberOfNegativeTry = negativeTries.Count(t => t.TransmitionCode == 2 && negativeTries.Any(r => r.TransmitionCode == 5 && r.TransmittedOnDate >= t.TransmittedOnDate)).ToString();
                    }

                    var submissionToMMStatus = fs_statuses.FirstOrDefault(t => t.StatusCode == 1);
                    var submissionStatus = fs_statuses.FirstOrDefault(dt => dt.StatusCode == 2);
                    var feedbackStatus = fs_statuses.FirstOrDefault(dt => dt.StatusCode == 4);
                    var paymentStatus = fs_statuses.FirstOrDefault(dt => dt.StatusCode == 7);

                    caseModel.DateOfTheSubmissionToTheHIP = submissionStatus != null ? submissionStatus.StatusDate : DateTime.MinValue;
                    caseModel.FeedBackOfTheHIP = feedbackStatus != null ? feedbackStatus.StatusDate : DateTime.MinValue;
                    caseModel.PaymentDate = paymentStatus != null ? paymentStatus.TransmittedOnDate : DateTime.MinValue;

                    if (submissionToMMStatus != null)
                    {
                        dateToMatchInsuranceDate = submissionToMMStatus.StatusDate;
                    }
                }
            }

            #endregion Case status
            return dateToMatchInsuranceDate;
        }

        private static string TranslateStatus(string statusCurrent)
        {

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
            var FS13 = Properties.Resources.FS13;
            var FS21 = Properties.Resources.FS21;

            string statusCurrentSt;
            switch (statusCurrent)
            {
                case "FS1":
                    statusCurrentSt = FS1;
                    break;

                case "FS2":
                    statusCurrentSt = FS2;
                    break;

                case "FS3":
                    statusCurrentSt = FS3;
                    break;

                case "FS4":
                    statusCurrentSt = FS4;
                    break;

                case "FS5":
                    statusCurrentSt = FS5;
                    break;

                case "FS6":
                    statusCurrentSt = FS6;
                    break;

                case "FS7":
                    statusCurrentSt = FS7;
                    break;

                case "FS8":
                    statusCurrentSt = FS8;
                    break;

                case "FS9":
                    statusCurrentSt = FS9;
                    break;

                case "FS10":
                    statusCurrentSt = FS10;
                    break;

                case "FS11":
                    statusCurrentSt = FS11;
                    break;

                case "FS12":
                    statusCurrentSt = FS7;
                    break;

                case "FS13":
                    statusCurrentSt = FS13;
                    break;

                case "FS17":
                    statusCurrentSt = FS8;
                    break;

                case "FS18":
                    statusCurrentSt = FS10;
                    break;

                case "FS21":
                    statusCurrentSt = FS21;
                    break;

                default:
                    statusCurrentSt = "-";
                    break;
            }

            return statusCurrentSt;
        }

        private static DateTime AddHipdata(Dictionary<Guid, List<PA_GPIDoT_1002>> patientInsurancesCache, string case_to_test_hip, CaseForReportModel caseModel, CaseBillingData caseBillPosition, CAS_GCBDoT_0911 caseBaseData, DateTime dateToMatchInsuranceDate)
        {
            #region Hip data
            PA_GPIDoT_1002 hipData = null;

            if (Int32.Parse(caseBaseData.case_number) < 10000)
            {
                hipData = patientInsurancesCache[caseBaseData.patient_id].OrderByDescending(t => t.InsuranceDate).First(t => t.HipName.ToLower().Contains("aok"));
            }
            else
            {
                if (dateToMatchInsuranceDate == DateTime.MinValue)
                {
                    dateToMatchInsuranceDate = caseBillPosition.gpos_type == EGposType.Operation.Value() ? caseBaseData.creation_date : DateTime.Now;
                }

                var hips = patientInsurancesCache[caseBaseData.patient_id].Where(t => t.InsuranceDate <= dateToMatchInsuranceDate).OrderByDescending(t => t.InsuranceDate).ToList();

                if (hips.Any())
                {
                    if (hips.First().HipIkNumber != "000000000")
                    {
                        hipData = hips.First();
                    }
                    else
                    {
                        hipData = hips.Last();
                    }
                }
                #region log
                if (!String.IsNullOrEmpty(case_to_test_hip))
                {
                    if (Int32.Parse(caseBaseData.case_number) == Int32.Parse(case_to_test_hip))
                    {
                        var filepath = WebConfigurationManager.AppSettings["test-hip-for-case-file-path"];
                        var patient_hips = patientInsurancesCache[caseBaseData.patient_id];

                        File.AppendAllText(filepath, String.Format("GPOS: {0}\n\n", caseModel.CaseType));

                        File.AppendAllText(filepath, "All patient insurances: \n");
                        File.AppendAllText(filepath, "------------------------------------------------------\n");
                        foreach (var hip in patient_hips)
                        {
                            File.AppendAllText(filepath, String.Format("HIP: {0},   Date of creation: {1}\n", hip.HipName, hip.InsuranceDate.ToString("yyyy-MM-dd HH:mm:ss")));
                        }
                        File.AppendAllText(filepath, "------------------------------------------------------\n\n");
                        File.AppendAllText(filepath, String.Format("Date matched against insurance dates: {0}\n\n", dateToMatchInsuranceDate.ToString("yyyy-MM-dd HH:mm:ss")));
                        File.AppendAllText(filepath, "------------------------------------------------------\n\n");


                        File.AppendAllText(filepath, "Matching insurances: \n");
                        File.AppendAllText(filepath, "------------------------------------------------------\n");
                        foreach (var hip in hips)
                        {
                            File.AppendAllText(filepath, String.Format("HIP: {0},   Date of creation: {1}\n", hip.HipName, hip.InsuranceDate.ToString("yyyy-MM-dd HH:mm:ss")));
                        }
                        File.AppendAllText(filepath, "------------------------------------------------------\n\n");
                        if (hipData != null)
                        {
                            File.AppendAllText(filepath, String.Format("Best matching HIP: {0},   Date of creation: {1}\n\n", hipData.HipName, hipData.InsuranceDate.ToString("yyyy-MM-dd HH:mm:ss")));
                        }
                        else
                        {
                            File.AppendAllText(filepath, "No HIP matches. \n");
                        }

                        File.AppendAllText(filepath, "***********************************************************\n\n");
                    }
                }
                #endregion
            }

            if (hipData == null)
            {
                caseModel.HIP = "-";
                caseModel.HIP_IK = "-";
                caseModel.PatientInsuranceNumber = "-";
                caseModel.PatientStatusNumber = "-";
            }
            else
            {
                caseModel.HIP = hipData.HipName;
                caseModel.HIP_IK = hipData.HipIkNumber;
                caseModel.PatientInsuranceNumber = hipData.InsuranceIdNumber;
                caseModel.PatientStatusNumber = hipData.InsuranceStateCode;
            }

            #endregion Hip data
            return dateToMatchInsuranceDate;
        }


        private static void AddTreatment(
            Dictionary<Guid, List<CAS_GCADDoT_1332>> nonOctActionDiagnoseData,
            Dictionary<Guid, List<CAS_GCADDoT_1332>> allOctActionDiagnoseData,
            Dictionary<Guid, List<CAS_GRPAfATIDoT_1656>> aftercareCache,
            Dictionary<Guid, List<CAS_GRPAfATIDoT_1656>> octCache,
            List<ORM_HEC_ACT_PlannedAction> plannedActions,
            Dictionary<Guid, List<CAS_GACBPoT_1820>> nonOctBillPositions,
            Dictionary<Guid, List<CAS_GACBPoT_1820>> octBillPositions,
            CaseForReportModel caseModel, CaseBillingData caseBillPosition,
            CAS_GCBDoT_0911 caseBaseData,
            bool is_ac_op_billed_together,
            ref Guid diagnoseId,
            ref string localizationCode,
            ref Guid doctor_bpt_id)
        {
            #region TRANSLATIONS
            var AC4 = Properties.Resources.AC4;
            #endregion TRANSLATIONS

            caseModel.TreatmentDay = DateTime.MinValue;
            caseModel.SurgeryDateForThisCase = caseBaseData.op_date;

            var caseActionDiagnoseData = nonOctActionDiagnoseData.ContainsKey(caseBaseData.case_id) ? nonOctActionDiagnoseData[caseBaseData.case_id] : Enumerable.Empty<CAS_GCADDoT_1332>();
            if (caseBillPosition.gpos_type == EGposType.Operation.Value())
            {
                if (is_ac_op_billed_together)
                {
                    var acOpBilledTogetherDiagnoseData = caseActionDiagnoseData.SingleOrDefault(t => t.type == EActionType.PlannedAftercare.Value());

                    if (caseBillPosition.gpos_price == 60)
                    {
                        caseModel.TreatmentDay = acOpBilledTogetherDiagnoseData.performed_on_date;
                        doctor_bpt_id = acOpBilledTogetherDiagnoseData.performed_by_bpt_id;
                        caseModel.UniqueID = acOpBilledTogetherDiagnoseData.action_id;
                    }
                    else
                    {
                        caseModel.TreatmentDay = caseBaseData.op_date;
                        doctor_bpt_id = caseBaseData.op_doctor_bpt_id;
                        caseModel.UniqueID = caseBaseData.op_planned_action_id;
                    }
                }
                else
                {
                    caseModel.UniqueID = caseBaseData.op_planned_action_id;
                    if (caseModel.CurrentStatus != "-")
                    {
                        caseModel.TreatmentDay = caseBaseData.op_date;
                    }
                    doctor_bpt_id = caseBaseData.op_doctor_bpt_id;
                }
            }
            else if (caseBillPosition.gpos_type == EGposType.Aftercare.Value())
            {
                if (nonOctBillPositions.ContainsKey(caseBaseData.case_id))
                {
                    var positions = nonOctBillPositions[caseBaseData.case_id].Where(t =>
                    {
                        var gposTypeMatches = t.GposType == caseBillPosition.gpos_type;
                        return caseModel.CurrentStatus == "-" ? gposTypeMatches : gposTypeMatches && !String.IsNullOrEmpty(t.PositionType);
                    }).ToList();

                    for (var i = 0; i < positions.Count; i++)
                    {
                        if (positions[i].BillPositionID == caseBillPosition.hec_bill_position_id)
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(positions[i].PositionType))
                                {
                                    var acActionDiagnoseData = caseActionDiagnoseData.Where(t =>
                                    {
                                        var typeMatches = t.type == EActionType.PlannedAftercare.Value();
                                        return caseModel.CurrentStatus == "-" ? typeMatches : typeMatches && t.performed;
                                    }).ToList();

                                    var acDiagnoseData = acActionDiagnoseData[i];
                                    if (acDiagnoseData != null)
                                    {
                                        if (acDiagnoseData.diagnose_id != Guid.Empty)
                                        {
                                            diagnoseId = acDiagnoseData.diagnose_id;
                                            localizationCode = acDiagnoseData.localization;
                                        }

                                        caseModel.TreatmentDay = acDiagnoseData.performed_on_date;
                                        doctor_bpt_id = acDiagnoseData.performed_by_bpt_id;

                                        var action = plannedActions.Single(t => t.HEC_ACT_PlannedActionID == acDiagnoseData.action_id);
                                        if (caseModel.CurrentStatus == "-" && action.IsCancelled)
                                        {
                                            caseModel.CurrentStatus = AC4;
                                        }
                                        caseModel.UniqueID = acDiagnoseData.action_id;
                                    }
                                }
                                else
                                {
                                    var relevantActions = aftercareCache[caseBaseData.case_id].OrderBy(t => t.CreationTimestamp);
                                    var relevantAction = relevantActions.Last();
                                    var action = plannedActions.Single(t => t.HEC_ACT_PlannedActionID == relevantAction.PlannedActionID);
                                    if (action.IsCancelled)
                                    {
                                        caseModel.CurrentStatus = AC4;
                                    }
                                    doctor_bpt_id = action.ToBePerformedBy_BusinessParticipant_RefID;
                                    caseModel.UniqueID = action.HEC_ACT_PlannedActionID;
                                }
                            }
                            catch { }
                            break;
                        }
                    }
                }
            }
            else if (caseBillPosition.gpos_type == EGposType.Oct.Value())
            {
                if (allOctActionDiagnoseData.ContainsKey(caseBaseData.patient_id))
                {
                    if (octBillPositions.ContainsKey(caseBaseData.patient_id))
                    {
                        var octActionDiagnoseData = allOctActionDiagnoseData[caseBaseData.patient_id].Where(t => t.performed).ToList();
                        var positions = octBillPositions[caseBaseData.patient_id].Where(t =>
                        {
                            var gposTypeMatches = t.GposType == caseBillPosition.gpos_type;
                            return caseModel.CurrentStatus == "-" ? gposTypeMatches : gposTypeMatches && !String.IsNullOrEmpty(t.PositionType);
                        }).ToList();

                        for (var i = 0; i < positions.Count; i++)
                        {
                            if (positions[i].BillPositionID == caseBillPosition.hec_bill_position_id)
                            {
                                try
                                {
                                    if (!String.IsNullOrEmpty(positions[i].PositionType))
                                    {
                                        var octDiagnoseData = octActionDiagnoseData[i];
                                        if (octDiagnoseData != null)
                                        {
                                            if (octDiagnoseData.diagnose_id != Guid.Empty)
                                            {
                                                diagnoseId = octDiagnoseData.diagnose_id;
                                                localizationCode = octDiagnoseData.localization;
                                            }

                                            caseModel.TreatmentDay = octDiagnoseData.performed_on_date;
                                            doctor_bpt_id = octDiagnoseData.performed_by_bpt_id;

                                            var action = plannedActions.SingleOrDefault(t => t.HEC_ACT_PlannedActionID == octDiagnoseData.action_id);
                                            if (caseModel.CurrentStatus == "-" && action.IsCancelled)
                                            {
                                                caseModel.CurrentStatus = AC4;
                                            }
                                            caseModel.UniqueID = action.HEC_ACT_PlannedActionID;
                                        }
                                    }
                                    else
                                    {
                                        var relevantActions = octCache[caseBaseData.patient_id];
                                        var relevantAction = relevantActions[i];
                                        var action = plannedActions.Single(t => t.HEC_ACT_PlannedActionID == relevantAction.PlannedActionID);
                                        if (action.IsCancelled)
                                        {
                                            caseModel.CurrentStatus = AC4;
                                        }
                                        doctor_bpt_id = action.ToBePerformedBy_BusinessParticipant_RefID;
                                        caseModel.UniqueID = action.HEC_ACT_PlannedActionID;
                                    }
                                }
                                catch { }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void AddConsent(Dictionary<Guid, List<DateTime>> allPerformedOpDates,
            Dictionary<Guid, List<ORM_CMN_CTR_Contract_Parameter>> contractParameterCache,
            Dictionary<Guid, List<ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient>> patientConsentCache,
            Dictionary<Guid, Guid> contractGposComboCache,
            CaseForReportModel caseModel,
            CaseBillingData caseBillPosition,
            CAS_GCBDoT_0911 caseBaseData)
        {
            #region Consent

            try
            {
                var patientConsents = patientConsentCache[caseBaseData.patient_id].GroupBy(t => t.InsuranceToBrokerContract_RefID).ToDictionary(t => t.Key, t => t.Where(x => x.ValidFrom.Date <= caseBaseData.op_date.Date).OrderByDescending(x => x.ValidFrom));
                caseModel.ContractID = contractGposComboCache[caseBillPosition.gpos_id];
                if (contractParameterCache.ContainsKey(caseModel.ContractID))
                {
                    var contractParameters = contractParameterCache[contractGposComboCache[caseBillPosition.gpos_id]];
                    var isConsentRenewedByOp = contractParameters.Any(p => p.ParameterName == "OP renews patient consent");
                    var consentValidForMonthsParameter = contractParameters.SingleOrDefault(p => p.ParameterName == "Duration of participation consent – Month");
                    var consentValidForMonths = Convert.ToInt32(consentValidForMonthsParameter.IfNumericValue_Value);

                    if (!isConsentRenewedByOp)
                    {
                        var patientConsent = patientConsents.First(t => t.Value.Any()).Value.First(t => t.ValidFrom.Date <= caseBaseData.op_date.Date && t.ValidFrom.AddMonths(consentValidForMonths) >= caseBaseData.op_date.Date);
                        caseModel.PatientParticipationConsentValidUntil = patientConsent.ValidFrom.AddMonths(consentValidForMonths);
                    }
                    else
                    {
                        var treatmentDate = caseModel.TreatmentDay != DateTime.MinValue ? caseModel.TreatmentDay.Date : caseModel.SurgeryDateForThisCase.Date;
                        var opDates = allPerformedOpDates.ContainsKey(caseBaseData.patient_id) ? allPerformedOpDates[caseBaseData.patient_id] : new List<DateTime>();
                        var performedOpDate = opDates.FirstOrDefault(t => t.Date <= treatmentDate);
                        if (performedOpDate != DateTime.MinValue)
                        {
                            caseModel.PatientParticipationConsentValidUntil = performedOpDate.AddMonths(consentValidForMonths);
                        }
                        else
                        {
                            caseModel.PatientParticipationConsentValidUntil = patientConsents.First(x => x.Value.Any()).Value.Last(x => x.ValidFrom.Date <= treatmentDate).ValidFrom.AddMonths(consentValidForMonths);
                        }
                    }
                }
                else
                {
                    caseModel.PatientParticipationConsentValidUntil = DateTime.MaxValue;
                }
            }
            catch (Exception ex)
            {
                caseModel.PatientParticipationConsentValidUntil = DateTime.MinValue;
            }

            #endregion Consent
        }

        private static void AddDoctor(Dictionary<Guid, IGrouping<Guid, DO_GDDfR_2028>> doctorDataCache, Dictionary<Guid, IGrouping<Guid, DO_GPDoT_2040>> practiceDataCache, CaseForReportModel caseModel, Guid doctor_bpt_id)
        {
            caseModel.BSNR = "-";
            caseModel.PracticeName = "-";
            caseModel.DocName = "-";
            caseModel.LANR = "-";
            caseModel.BankAccountHolder = "-";
            caseModel.BankName = "-";
            caseModel.IBAN = "-";
            caseModel.BIC = "-";

            DO_GDDfR_2028 doctorData = null;
            if (doctorDataCache.ContainsKey(doctor_bpt_id))
                doctorData = doctorDataCache[doctor_bpt_id].SingleOrDefault();

            DO_GPDoT_2040 practiceData = null;
            if (practiceDataCache.ContainsKey(doctor_bpt_id))
                practiceData = practiceDataCache[doctor_bpt_id].FirstOrDefault();

            if (doctorData != null)
            {
                if (!String.IsNullOrEmpty(doctorData.PracticeBSNR))
                {
                    caseModel.BSNR = doctorData.PracticeBSNR;
                }

                caseModel.PracticeName = string.IsNullOrEmpty(doctorData.PracticeName) ? "-" : doctorData.PracticeName;
                caseModel.DocName = string.IsNullOrEmpty(doctorData.FirstName) ? doctorData.LastName : doctorData.FirstName + " " + doctorData.LastName;
                caseModel.LANR = string.IsNullOrEmpty(doctorData.DoctorLANR) ? "-" : doctorData.DoctorLANR;
                caseModel.BankAccountHolder = string.IsNullOrEmpty(doctorData.AccountHolder) ? "-" : doctorData.AccountHolder;
                caseModel.BankName = string.IsNullOrEmpty(doctorData.BankName) ? "-" : doctorData.BankName;
                caseModel.IBAN = string.IsNullOrEmpty(doctorData.IBAN) ? "-" : doctorData.IBAN;
                caseModel.BIC = string.IsNullOrEmpty(doctorData.BIC) ? "-" : doctorData.BIC;
                caseModel.DoctorID = doctorData.DoctorID;
                if (practiceDataCache.ContainsKey(doctorData.PracticeBPTID))
                {
                    var practice = practiceDataCache[doctorData.PracticeBPTID].First();
                    caseModel.Address = practice.StreetName + " " + practice.StreetNumber;
                    caseModel.City = practice.ZIP + " " + practice.City;
                    caseModel.DoctorTitle = doctorData.Title;
                    caseModel.DoctorFirstName = doctorData.FirstName;
                    caseModel.DoctorLastName = doctorData.LastName;
                    caseModel.DoctorEmail = doctorData.SignInEmail;
                }
            }
            else if (practiceData != null)
            {
                caseModel.BSNR = string.IsNullOrEmpty(practiceData.PracticeBSNR) ? "-" : practiceData.PracticeBSNR;
                caseModel.PracticeName = string.IsNullOrEmpty(practiceData.PracticeName) ? "-" : practiceData.PracticeName;
                caseModel.DocName = "-";
                caseModel.LANR = "-";
                caseModel.BankAccountHolder = string.IsNullOrEmpty(practiceData.AccountHolder) ? "-" : practiceData.AccountHolder;
                caseModel.BankName = string.IsNullOrEmpty(practiceData.BankName) ? "-" : practiceData.BankName;
                caseModel.IBAN = string.IsNullOrEmpty(practiceData.IBAN) ? "-" : practiceData.IBAN;
                caseModel.BIC = string.IsNullOrEmpty(practiceData.BIC) ? "-" : practiceData.BIC;
            }
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_GR_1608 Invoke(string ConnectionString, P_CAS_GR_1608 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null, bool? ShowOnlyAok = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_GR_1608 Invoke(DbConnection Connection, P_CAS_GR_1608 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_GR_1608 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_GR_1608 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null, bool? ShowOnlyAok = null)
        {
            // Generate Report
            return Invoke(Connection, Transaction, null, Parameter, securityTicket, ShowOnlyAok);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_GR_1608 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_GR_1608 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null, bool? ShowOnlyAok = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GR_1608 functionReturn = new FR_CAS_GR_1608();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket, ShowOnlyAok);

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

                throw new Exception("Exception occured in method cls_Generate_Report", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_GR_1608 : FR_Base
    {
        public CAS_GR_1608 Result { get; set; }

        public FR_CAS_GR_1608() : base() { }

        public FR_CAS_GR_1608(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_GR_1608 for attribute P_CAS_GR_1608
    [DataContract]
    public class P_CAS_GR_1608
    {
        //Standard type parameters
        [DataMember]
        public int[] statuses { get; set; }
        [DataMember]
        public double[] position_numbers { get; set; }
        [DataMember]
        public DateTime? updateCasesSubmittedBeforeDate { get; set; }

    }
    #endregion
    #region SClass CAS_GR_1608 for attribute CAS_GR_1608
    [DataContract]
    public class CAS_GR_1608
    {
        //Standard type parameters
        [DataMember]
        public MMDocConnectUtils.ExcelTemplates.CaseForReportModel[] cases { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GR_1608 cls_Generate_Report(,P_CAS_GR_1608 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GR_1608 invocationResult = cls_Generate_Report.Invoke(connectionString,P_CAS_GR_1608 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Manipulation.P_CAS_GR_1608();
parameter.statuses = ...;
parameter.position_numbers = ...;
parameter.updateCasesSubmittedBeforeDate = ...;

*/
