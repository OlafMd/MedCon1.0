/* 
 * Generated on 3/20/2017 12:57:26 PM
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
using CL1_CMN;
using CL1_BIL;
using CL1_USR;
using CL1_HEC;
using CL1_HEC_CAS;
using CL1_CMN_PRO;
using CL1_HEC_BIL;
using CL1_HEC_ACT;
using CL1_ORD_PRC;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_HEC_DIA;
using System.IO;
using System.Web;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectDocApp;
using System.Globalization;
using System.Threading;
using System.Web.Configuration;
using System.Threading.Tasks;
using MMDocConnectUtils;
using CL1_CMN_CTR;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Submit_Case.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Submit_Case
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_SC_1425 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_SC_1425();
            returnValue.Result = new CAS_SC_1425();
            //Put your code here
            #region DATA
            var is_management_fee_waived = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = Parameter.practice_id, PropertyName = "Waive Service Fee" }, securityTicket).Result.BooleanValue;
            var shouldDownloadReportProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = Parameter.practice_id, PropertyName = "Download Report Upon Submission" }, securityTicket).Result;
            var elastic_index = securityTicket.TenantID.ToString();
            var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514()
            {
                action_type_gpmid = "mm.docconect.doc.app.planned.action.oct"
            }, securityTicket).Result;
            var gpos_type = Parameter.is_treatment ? "mm.docconnect.gpos.catalog.operation" : "mm.docconnect.gpos.catalog.nachsorge";
            var doctorsCache = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
            var diagnose_data_cache = new Dictionary<Guid, CAS_GDDfDID_1608>();
            var drug_data_cache = new Dictionary<Guid, CAS_GDDfDID_1614>();
            var treatment_doctor_data_cache = new Dictionary<Guid, DO_GDDfDID_0823>();
            var patient_data_cache = new Dictionary<Guid, P_PA_GPDfPID_1124>();
            var aftercare_doctor_data_cache = new Dictionary<Guid, DO_GDDfDID_0823>();
            var aftercare_practice_data_cache = new Dictionary<Guid, DO_GPDfPID_1432>();
            var treatment_practice_data_cache = new Dictionary<Guid, DO_GPDfPID_1432>();
            var aftercare_doctors_practice_data_cache = new Dictionary<Guid, DO_GPDfPID_1432>();
            var gpos_where_management_fee_is_waived_data_cache = new Dictionary<Guid, CAS_GGPOSwMFiWfPID_1512[]>();
            var aftercare_ids = new List<string>();
            var treatment_ids = new List<string>();
            var authorizing_doctor_account_id = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.authorizing_doctor_id }, securityTicket).Result.accountID;

            var documentationOnlyProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
            {
                GlobalPropertyMatchingID = "mm.doc.connect.case.is.for.documentation.only",
                Tenant_RefID = securityTicket.TenantID,
                IsValue_Boolean = true,
                IsDeleted = false,
                PropertyName = "Is For Documentation Only"
            }).SingleOrDefault();

            if (documentationOnlyProperty == null)
            {
                documentationOnlyProperty = new ORM_HEC_CAS_Case_UniversalProperty();
                documentationOnlyProperty.GlobalPropertyMatchingID = "mm.doc.connect.case.is.for.documentation.only";
                documentationOnlyProperty.IsValue_Boolean = true;
                documentationOnlyProperty.Modification_Timestamp = DateTime.Now;
                documentationOnlyProperty.PropertyName = "Is For Documentation Only";
                documentationOnlyProperty.Tenant_RefID = securityTicket.TenantID;

                documentationOnlyProperty.Save(Connection, Transaction);
            }

            var documentationOnlyPropertyValuesCache = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
            {
                HEC_CAS_Case_UniversalProperty_RefID = documentationOnlyProperty.HEC_CAS_Case_UniversalPropertyID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).GroupBy(t => t.HEC_CAS_Case_RefID).ToDictionary(t => t.Key, t => t.SingleOrDefault());

            ORM_USR_Account.Query trigger_accQ = new ORM_USR_Account.Query();
            trigger_accQ.Tenant_RefID = securityTicket.TenantID;
            trigger_accQ.USR_AccountID = authorizing_doctor_account_id;
            trigger_accQ.IsDeleted = false;

            var trigger_acc = ORM_USR_Account.Query.Search(Connection, Transaction, trigger_accQ).SingleOrDefault();
            #endregion

            #region ALL LANGUAGES
            ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
            all_languagesQ.IsDeleted = false;

            var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();
            #endregion

            var patient_ids = new List<Guid>();

            var cancelled_fs_status_codes = new int[] { 8, 11, 17 };
            foreach (var case_id in Parameter.case_ids)
            {
                var case_to_submit = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;
                patient_ids.Add(case_to_submit.patient_id);

                var is_case_for_documentation_only = documentationOnlyPropertyValuesCache.ContainsKey(case_id) && documentationOnlyPropertyValuesCache[case_id].Value_Boolean;

                var fs_status_prefix = "FS";
                var fs_status_code = is_case_for_documentation_only ? 13 : 1;
                var fs_status = String.Format("{0}{1}", fs_status_prefix, fs_status_code);

                if (case_to_submit != null)
                {
                    #region OCT DOCTOR
                    DO_GDDfDID_0823 oct_doctor = null;

                    var this_case_oct_planned_action = cls_Get_Latest_PlannedActionID_for_CaseID_and_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GLPAIDfCIDaATID_1635()
                    {
                        ActionTypeID = oct_planned_action_type_id,
                        CaseID = case_id
                    }, securityTicket).Result;

                    if (this_case_oct_planned_action != null)
                    {
                        var oct_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query() { HEC_ACT_PlannedActionID = this_case_oct_planned_action.PlannedActionID }).Single();
                        var doc = doctorsCache.SingleOrDefault(t => t.BusinessParticipant_RefID == oct_planned_action.ToBePerformedBy_BusinessParticipant_RefID);
                        if (doc != null)
                        {
                            if (!treatment_doctor_data_cache.ContainsKey(doc.HEC_DoctorID))
                            {
                                treatment_doctor_data_cache.Add(doc.HEC_DoctorID, cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = doc.HEC_DoctorID }, securityTicket).Result.SingleOrDefault());
                            }

                            oct_doctor = treatment_doctor_data_cache[doc.HEC_DoctorID];
                        }
                    }
                    #endregion

                    var is_aftercare_temporary = false;

                    var ac_doctor_account_id = cls_Get_AccountRefID_from_HEC_Doctors_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GARIDfHDfDID_1109() { AftercareDoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result;
                    if (ac_doctor_account_id != null)
                        is_aftercare_temporary = ac_doctor_account_id.Account_RefID == Guid.Empty;

                    var case_fs_statuses = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTCfCID_1427() { CaseID = case_id }, securityTicket).Result;
                    var active_fs = case_fs_statuses.FirstOrDefault(t => t.gpos_type == gpos_type && !cancelled_fs_status_codes.Any(x => x == t.fs_status));

                    var is_resubmit = active_fs == null ? false : active_fs.fs_status == 6;

                    #region CACHE
                    if (!diagnose_data_cache.ContainsKey(case_to_submit.diagnose_id))
                    {
                        diagnose_data_cache.Add(case_to_submit.diagnose_id, cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1608() { DiagnoseID = case_to_submit.diagnose_id }, securityTicket).Result);
                    }
                    var diagnose_details = diagnose_data_cache[case_to_submit.diagnose_id];

                    if (!drug_data_cache.ContainsKey(case_to_submit.drug_id))
                    {
                        drug_data_cache.Add(case_to_submit.drug_id, cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = case_to_submit.drug_id }, securityTicket).Result);
                    }
                    var drug_details = drug_data_cache[case_to_submit.drug_id];

                    if (!treatment_doctor_data_cache.ContainsKey(case_to_submit.op_doctor_id))
                    {
                        treatment_doctor_data_cache.Add(case_to_submit.op_doctor_id, cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.op_doctor_id }, securityTicket).Result.SingleOrDefault());
                    }
                    var treatment_doctor_details = treatment_doctor_data_cache[case_to_submit.op_doctor_id];

                    if (!patient_data_cache.ContainsKey(case_to_submit.patient_id))
                    {
                        patient_data_cache.Add(case_to_submit.patient_id, cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = case_to_submit.patient_id }, securityTicket).Result);
                    }
                    var patient_details = patient_data_cache[case_to_submit.patient_id];

                    if (!aftercare_doctor_data_cache.ContainsKey(case_to_submit.ac_doctor_id))
                    {
                        aftercare_doctor_data_cache.Add(case_to_submit.ac_doctor_id, cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result.SingleOrDefault());
                    }
                    var aftercare_doctor_details = aftercare_doctor_data_cache[case_to_submit.ac_doctor_id];

                    if (!treatment_practice_data_cache.ContainsKey(case_to_submit.practice_id))
                    {
                        treatment_practice_data_cache.Add(case_to_submit.practice_id, cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.practice_id }, securityTicket).Result.FirstOrDefault());
                    }
                    var treatment_practice_details = treatment_practice_data_cache[case_to_submit.practice_id];

                    DO_GPDfPID_1432 aftercare_practice_details = null;
                    if (case_to_submit.is_aftercare_doctor)
                    {
                        if (!aftercare_doctors_practice_data_cache.ContainsKey(case_to_submit.aftercare_doctors_practice_id))
                        {
                            aftercare_doctors_practice_data_cache.Add(case_to_submit.aftercare_doctors_practice_id, cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.aftercare_doctors_practice_id }, securityTicket).Result.FirstOrDefault());
                        }

                        aftercare_practice_details = aftercare_doctors_practice_data_cache[case_to_submit.aftercare_doctors_practice_id];
                    }
                    else
                    {
                        if (!aftercare_practice_data_cache.ContainsKey(case_to_submit.ac_practice_id))
                        {
                            aftercare_practice_data_cache.Add(case_to_submit.ac_practice_id, cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.ac_practice_id }, securityTicket).Result.FirstOrDefault());
                        }

                        aftercare_practice_details = aftercare_practice_data_cache[case_to_submit.ac_practice_id];
                    }

                    if (!gpos_where_management_fee_is_waived_data_cache.ContainsKey(case_to_submit.patient_id))
                    {
                        gpos_where_management_fee_is_waived_data_cache.Add(case_to_submit.patient_id, cls_Get_GPOS_where_Management_Fee_is_Waived_for_PatientID.Invoke(Connection, Transaction, new P_CAS_GGPOSwMFiWfPID_1512() { PatientID = case_to_submit.patient_id }, securityTicket).Result);
                    }

                    var gpos_where_management_fee_is_waived = gpos_where_management_fee_is_waived_data_cache[case_to_submit.patient_id];
                    #endregion

                    #region RECALCULATE GPOS
                    if (Parameter.is_treatment && !Parameter.is_settlement)
                    {
                        if (!Parameter.is_settlement)
                        {
                            #region DELETE CURRENT GPOS
                            var current_gpos_ids = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result.Where(t => t.gpos_type != EGposType.Oct.Value()).ToList();
                            if (current_gpos_ids.Any())
                            {
                                ORM_HEC_CAS_Case_BillCode.Query current_case_gposQ = new ORM_HEC_CAS_Case_BillCode.Query();
                                current_case_gposQ.Tenant_RefID = securityTicket.TenantID;
                                current_case_gposQ.IsDeleted = false;

                                foreach (var id in current_gpos_ids)
                                {
                                    current_case_gposQ.HEC_CAS_Case_BillCodeID = id.hec_case_bill_code_id;
                                    var current_case_gpos = ORM_HEC_CAS_Case_BillCode.Query.Search(Connection, Transaction, current_case_gposQ).SingleOrDefault();
                                    if (current_case_gpos != null)
                                    {
                                        current_case_gpos.IsDeleted = true;
                                        current_case_gpos.Save(Connection, Transaction);
                                    }
                                    ORM_BIL_BillPosition.Query bill_positionQ = new ORM_BIL_BillPosition.Query();
                                    bill_positionQ.BIL_BillPositionID = id.bill_position_id;
                                    bill_positionQ.Tenant_RefID = securityTicket.TenantID;
                                    bill_positionQ.IsDeleted = false;

                                    var bill_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, bill_positionQ).SingleOrDefault();
                                    if (bill_position != null)
                                    {
                                        bill_position.IsDeleted = true;
                                        bill_position.Save(Connection, Transaction);

                                        ORM_HEC_BIL_BillPosition.Query hec_bill_positionQ = new ORM_HEC_BIL_BillPosition.Query();
                                        hec_bill_positionQ.Ext_BIL_BillPosition_RefID = id.bill_position_id;
                                        hec_bill_positionQ.Tenant_RefID = securityTicket.TenantID;
                                        hec_bill_positionQ.IsDeleted = false;

                                        var hec_bill_position = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, hec_bill_positionQ).SingleOrDefault();
                                        if (hec_bill_position != null)
                                        {
                                            hec_bill_position.IsDeleted = true;
                                            hec_bill_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition_BillCode.Query bill_position_bill_codeQ = new ORM_HEC_BIL_BillPosition_BillCode.Query();
                                            bill_position_bill_codeQ.Tenant_RefID = securityTicket.TenantID;
                                            bill_position_bill_codeQ.IsDeleted = false;
                                            bill_position_bill_codeQ.BillPosition_RefID = hec_bill_position.HEC_BIL_BillPositionID;

                                            var bill_position_bill_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, bill_position_bill_codeQ).SingleOrDefault();
                                            if (bill_position_bill_code != null)
                                            {
                                                bill_position_bill_code.IsDeleted = true;
                                                bill_position_bill_code.Save(Connection, Transaction);
                                            }
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region ADD GPOS TO THE CASE
                            cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                            {
                                ac_doctor_id = case_to_submit.ac_doctor_id,
                                all_languagesL = all_languagesL,
                                case_id = case_id,
                                diagnose_id = case_to_submit.diagnose_id,
                                drug_id = case_to_submit.drug_id,
                                patient_id = case_to_submit.patient_id,
                                treatment_doctor_id = case_to_submit.op_doctor_id,
                                localization = case_to_submit.localization,
                                treatment_date = case_to_submit.treatment_date
                            }, securityTicket);
                            #endregion
                        }
                        else
                        {
                            #region UPDATE GPOS POSITIONS
                            cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                            {
                                should_update = true,
                                case_id = case_id,
                                all_languagesL = all_languagesL,
                                diagnose_id = case_to_submit.diagnose_id,
                                drug_id = case_to_submit.drug_id,
                                localization = case_to_submit.localization,
                                patient_id = case_to_submit.patient_id,
                                treatment_date = case_to_submit.treatment_date
                            }, securityTicket);
                            #endregion
                        }
                    }
                    #endregion

                    #region ADD GPOS HEADER TO CASE BILL POSITIONS AND SET STATUS TO FS1
                    Guid bill_to_bpt_id = Guid.Empty;

                    if (case_to_submit.is_send_invoice_to_practice)
                    {
                        Guid id = Guid.Empty;
                        var practice_account = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = case_to_submit.practice_id }, securityTicket).Result;
                        if (practice_account != null)
                        {
                            id = practice_account.accountID;
                        }

                        ORM_USR_Account.Query invoice_practice_accountQ = new ORM_USR_Account.Query();
                        invoice_practice_accountQ.USR_AccountID = id;
                        invoice_practice_accountQ.Tenant_RefID = securityTicket.TenantID;
                        invoice_practice_accountQ.IsDeleted = false;

                        var invoice_practice_account = ORM_USR_Account.Query.Search(Connection, Transaction, invoice_practice_accountQ).SingleOrDefault();
                        if (invoice_practice_account != null)
                        {
                            bill_to_bpt_id = invoice_practice_account.BusinessParticipant_RefID;
                        }
                    }

                    if (!Parameter.is_settlement)
                    {
                        #region ADD HEADER
                        var gpos_header = new ORM_BIL_BillHeader();
                        gpos_header.BillRecipient_BuisnessParticipant_RefID = bill_to_bpt_id;
                        gpos_header.CreatedBy_BusinessParticipant_RefID = trigger_acc.BusinessParticipant_RefID;
                        gpos_header.Modification_Timestamp = DateTime.Now;
                        gpos_header.Tenant_RefID = securityTicket.TenantID;

                        var bill_header_history_entry = new ORM_BIL_BillHeader_History();
                        bill_header_history_entry.BillHeader_RefID = gpos_header.BIL_BillHeaderID;
                        bill_header_history_entry.Comment = "Doctor";
                        bill_header_history_entry.IsCreated = true;
                        bill_header_history_entry.Modification_Timestamp = DateTime.Now;
                        bill_header_history_entry.Tenant_RefID = securityTicket.TenantID;
                        bill_header_history_entry.TriggeredBy_BusinessParticipant_RefID = trigger_acc.BusinessParticipant_RefID;

                        bill_header_history_entry.Save(Connection, Transaction);

                        var hec_gpos_header = new ORM_HEC_BIL_BillHeader();
                        hec_gpos_header.Ext_BIL_BillHeader_RefID = gpos_header.BIL_BillHeaderID;
                        hec_gpos_header.Modification_Timestamp = DateTime.Now;
                        hec_gpos_header.Patient_RefID = case_to_submit.patient_id;
                        hec_gpos_header.Tenant_RefID = securityTicket.TenantID;

                        hec_gpos_header.Save(Connection, Transaction);
                        #endregion

                        decimal sum_total = 0;

                        var bill_position_ids = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result;
                        if (bill_position_ids.Length != 0)
                        {
                            ORM_BIL_BillPosition.Query bill_positionQ = new ORM_BIL_BillPosition.Query();
                            bill_positionQ.IsDeleted = false;
                            bill_positionQ.Tenant_RefID = securityTicket.TenantID;

                            var latest = 0;
                            var latestBill = cls_Get_Latest_Bill_Position_Number.Invoke(Connection, Transaction, securityTicket).Result;
                            if (latestBill != null && !string.IsNullOrEmpty(latestBill.latest_bill_position_number))
                            {
                                latest = Convert.ToInt32(latestBill.latest_bill_position_number);
                            }

                            foreach (var id in bill_position_ids)
                            {
                                bill_positionQ.BIL_BillPositionID = id.bill_position_id;
                                var bill_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, bill_positionQ).SingleOrDefault();
                                if (bill_position != null)
                                {
                                    bill_position.BIL_BilHeader_RefID = gpos_header.BIL_BillHeaderID;
                                    if (string.IsNullOrEmpty(bill_position.PositionNumber))
                                    {
                                        bill_position.PositionNumber = SynchronizedSequentialNumberGenerator.Instance.Generate(latest).ToString();
                                    }

                                    bill_position.Save(Connection, Transaction);

                                    sum_total += bill_position.PositionValue_IncludingTax;
                                }

                                #region SET CASE STATUS TO FS1
                                var billing_code = cls_Get_BillingCode_for_CaseBillCodeID.Invoke(Connection, Transaction, new P_CAS_GBCfCBCID_1334() { CaseBillCodeID = id.hec_case_bill_code_id }, securityTicket).Result;
                                if (billing_code != null)
                                {
                                    #region SET TREATMENT STATUS TO FS1
                                    if (Parameter.is_treatment)
                                    {
                                        if (id.gpos_type == gpos_type)
                                        {

                                            ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                            position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                            position_status.BillPosition_RefID = id.bill_position_id;
                                            position_status.Creation_Timestamp = DateTime.Now;
                                            position_status.IsActive = true;
                                            position_status.Modification_Timestamp = DateTime.Now;
                                            position_status.TransmitionCode = fs_status_code;
                                            position_status.TransmittedOnDate = DateTime.Now;
                                            position_status.Tenant_RefID = securityTicket.TenantID;
                                            position_status.TransmitionStatusKey = "treatment";

                                            #region CREATE SNAPSHOT
                                            DateTime today = DateTime.Today;
                                            int age = today.Year - patient_details.birthday.Year;
                                            if (patient_details.birthday > today.AddYears(-age))
                                                age--;

                                            var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                                            {
                                                DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                                DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                                DiagnosisName = diagnose_details.diagnose_name,
                                                IFPerformedMedicalPracticeName = treatment_practice_details.practice_name,
                                                IFPerformedResponsibleBPFullName = GenericUtils.GetDoctorName(treatment_doctor_details),
                                                Localization = case_to_submit.localization,
                                                PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                                PatientFirstName = patient_details.patient_first_name,
                                                PatientGender = patient_details.gender.ToString(),
                                                PatientLastName = patient_details.patient_last_name,
                                                PatientAge = age.ToString()
                                            }, securityTicket).Result;

                                            if (snapshot != null)
                                            {
                                                position_status.TransmissionDataXML = snapshot.XmlFileString;
                                            }

                                            #endregion

                                            position_status.Save(Connection, Transaction);
                                        }
                                    }
                                    #endregion

                                    #region SET AFTERCARE STATUS TO FS1
                                    else
                                    {
                                        if (id.gpos_type == gpos_type)
                                        {
                                            var current_bill_position_status = case_fs_statuses.SingleOrDefault(fs => fs.bill_position_id == id.bill_position_id);

                                            if (current_bill_position_status == null || current_bill_position_status.fs_status == 6)
                                            {
                                                ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                                position_status.BillPosition_RefID = id.bill_position_id;
                                                position_status.Creation_Timestamp = DateTime.Now;
                                                position_status.IsActive = true;
                                                position_status.Modification_Timestamp = DateTime.Now;
                                                position_status.TransmitionCode = 1;
                                                position_status.TransmittedOnDate = DateTime.Now;
                                                position_status.Tenant_RefID = securityTicket.TenantID;
                                                position_status.TransmitionStatusKey = "aftercare";

                                                #region CREATE SNAPSHOT
                                                DateTime today = DateTime.Today;
                                                int age = today.Year - patient_details.birthday.Year;
                                                if (patient_details.birthday > today.AddYears(-age))
                                                    age--;

                                                var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                                                {
                                                    DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                                    DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                                    DiagnosisName = diagnose_details.diagnose_name,
                                                    IFPerformedMedicalPracticeName = aftercare_practice_details.practice_name,
                                                    IFPerformedResponsibleBPFullName = MMDocConnectDocApp.GenericUtils.GetDoctorName(aftercare_doctor_details),
                                                    Localization = case_to_submit.localization,
                                                    PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                                    PatientFirstName = patient_details.patient_first_name,
                                                    PatientGender = patient_details.gender.ToString(),
                                                    PatientLastName = patient_details.patient_last_name,
                                                    PatientAge = age.ToString()
                                                }, securityTicket).Result;

                                                if (snapshot != null)
                                                {
                                                    position_status.TransmissionDataXML = snapshot.XmlFileString;
                                                }
                                                #endregion

                                                position_status.Save(Connection, Transaction);
                                            }
                                        }
                                    }

                                    #endregion
                                }
                                #endregion

                                if (!is_management_fee_waived)
                                {
                                    if (billing_code != null)
                                    {
                                        if (Parameter.is_treatment)
                                        {
                                            if (id.gpos_type == gpos_type)
                                            {
                                                if (case_to_submit.order_id != Guid.Empty && (case_to_submit.order_status_code == 1 || case_to_submit.order_status_code == 2 || case_to_submit.order_status_code == 3))
                                                    is_management_fee_waived = gpos_where_management_fee_is_waived.Any(gpos => gpos.BillingCode == billing_code.BillingCode) && case_to_submit.order_id != Guid.Empty;
                                            }
                                        }
                                        else
                                        {
                                            if (id.gpos_type == gpos_type)
                                            {
                                                is_management_fee_waived = gpos_where_management_fee_is_waived.Any(gpos => gpos.BillingCode == billing_code.BillingCode);
                                            }
                                        }
                                    }
                                }

                                if (gpos_type == id.gpos_type)
                                {
                                    ORM_BIL_BillPosition_PropertyValue gpos_management_fee_property_value = new ORM_BIL_BillPosition_PropertyValue();
                                    gpos_management_fee_property_value.BIL_BillPosition_RefID = id.bill_position_id;
                                    gpos_management_fee_property_value.BIL_BillPosition_PropertyValueID = Guid.NewGuid();
                                    gpos_management_fee_property_value.Creation_Timestamp = DateTime.Now;
                                    gpos_management_fee_property_value.Modification_Timestamp = DateTime.Now;
                                    gpos_management_fee_property_value.PropertyKey = "mm.doc.connect.management.fee";
                                    gpos_management_fee_property_value.PropertyValue = is_management_fee_waived ? "waived" : "deducted";
                                    gpos_management_fee_property_value.Tenant_RefID = securityTicket.TenantID;

                                    gpos_management_fee_property_value.Save(Connection, Transaction);
                                }
                            }
                        }

                        gpos_header.TotalValue_IncludingTax = sum_total;
                        gpos_header.Save(Connection, Transaction);

                        #region SET ACTION TO PERFORMED
                        if (Parameter.is_treatment)
                        {
                            #region TREATMENT
                            var treatment_planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_to_submit.case_id }, securityTicket).Result;
                            if (treatment_planned_action_id != null)
                            {
                                treatment_ids.Add(treatment_planned_action_id.planned_action_id.ToString());

                                var treatment_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                                treatment_planned_actionQ.HEC_ACT_PlannedActionID = treatment_planned_action_id.planned_action_id;
                                treatment_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                                treatment_planned_actionQ.IsDeleted = false;
                                treatment_planned_actionQ.IsPerformed = false;

                                var treatment_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, treatment_planned_actionQ).SingleOrDefault();
                                if (treatment_planned_action != null)
                                {
                                    var treatment_performed_action = new ORM_HEC_ACT_PerformedAction();
                                    treatment_performed_action.Creation_Timestamp = DateTime.Now;
                                    treatment_performed_action.HEC_ACT_PerformedActionID = Guid.NewGuid();
                                    treatment_performed_action.IfPerfomed_DateOfAction = treatment_planned_action.PlannedFor_Date;
                                    treatment_performed_action.IfPerformed_DateOfAction_Day = treatment_planned_action.PlannedFor_Date.Day;
                                    treatment_performed_action.IfPerformed_DateOfAction_Month = treatment_planned_action.PlannedFor_Date.Month;
                                    treatment_performed_action.IfPerformed_DateOfAction_Year = treatment_planned_action.PlannedFor_Date.Year;
                                    treatment_performed_action.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = case_to_submit.treatment_doctor_id;
                                    treatment_performed_action.IsPerformed_MedicalPractice_RefID = case_to_submit.practice_id;
                                    treatment_performed_action.Modification_Timestamp = DateTime.Now;
                                    treatment_performed_action.Patient_RefID = case_to_submit.patient_id;
                                    treatment_performed_action.Tenant_RefID = securityTicket.TenantID;
                                    treatment_performed_action.IM_IfPerformed_ResponsibleBP_FullName = MMDocConnectDocApp.GenericUtils.GetDoctorName(treatment_doctor_details);
                                    treatment_performed_action.IM_IfPerformed_MedicalPractice_Name = treatment_practice_details.practice_name;
                                    treatment_performed_action.Save(Connection, Transaction);

                                    var treatment_performed_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PerformedOperation.Value() }, securityTicket).Result;

                                    var treatment_performed_action_2_type = new ORM_HEC_ACT_PerformedAction_2_ActionType();
                                    treatment_performed_action_2_type.AssignmentID = Guid.NewGuid();
                                    treatment_performed_action_2_type.Creation_Timestamp = DateTime.Now;
                                    treatment_performed_action_2_type.HEC_ACT_ActionType_RefID = treatment_performed_action_type_id;
                                    treatment_performed_action_2_type.HEC_ACT_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                    treatment_performed_action_2_type.IM_ActionType_Name = "Treatment";
                                    treatment_performed_action_2_type.Tenant_RefID = securityTicket.TenantID;
                                    treatment_performed_action_2_type.Modification_Timestamp = DateTime.Now;

                                    treatment_performed_action_2_type.Save(Connection, Transaction);

                                    treatment_planned_action.IsPerformed = true;
                                    treatment_planned_action.IfPerformed_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                    treatment_planned_action.Modification_Timestamp = DateTime.Now;

                                    treatment_planned_action.Save(Connection, Transaction);

                                    var patient_diagnosis = new ORM_HEC_Patient_Diagnosis();
                                    patient_diagnosis.Creation_Timestamp = DateTime.Now;
                                    patient_diagnosis.HEC_Patient_DiagnosisID = Guid.NewGuid();
                                    patient_diagnosis.Modification_Timestamp = DateTime.Now;
                                    patient_diagnosis.Patient_RefID = case_to_submit.patient_id;
                                    patient_diagnosis.R_IsConfirmed = case_to_submit.is_confirmed;
                                    patient_diagnosis.R_PotentialDiagnosis_RefID = case_to_submit.diagnose_id;
                                    patient_diagnosis.Tenant_RefID = securityTicket.TenantID;

                                    patient_diagnosis.Save(Connection, Transaction);

                                    var treatment_diagnosis_update = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                                    treatment_diagnosis_update.Creation_Timestamp = DateTime.Now;
                                    treatment_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
                                    treatment_diagnosis_update.HEC_ACT_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                    treatment_diagnosis_update.PotentialDiagnosis_RefID = case_to_submit.diagnose_id;
                                    treatment_diagnosis_update.IM_PotentialDiagnosis_Code = diagnose_details.diagnose_icd_10;
                                    treatment_diagnosis_update.IM_PotentialDiagnosis_Name = diagnose_details.diagnose_name;
                                    treatment_diagnosis_update.IM_PotentialDiagnosisCatalog_Name = diagnose_details.catalog_display_name;
                                    treatment_diagnosis_update.IsDiagnosisConfirmed = true;
                                    treatment_diagnosis_update.Modification_Timestamp = DateTime.Now;
                                    treatment_diagnosis_update.Tenant_RefID = securityTicket.TenantID;
                                    treatment_diagnosis_update.HEC_Patient_Diagnosis_RefID = patient_diagnosis != null ? patient_diagnosis.HEC_Patient_DiagnosisID : Guid.Empty;

                                    treatment_diagnosis_update.Save(Connection, Transaction);

                                    var diagnosis_localization = new ORM_HEC_DIA_Diagnosis_Localization();
                                    diagnosis_localization.Creation_Timestamp = DateTime.Now;
                                    diagnosis_localization.Diagnosis_RefID = case_to_submit.diagnose_id;
                                    diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID = Guid.NewGuid();
                                    diagnosis_localization.Modification_Timestamp = DateTime.Now;
                                    diagnosis_localization.Tenant_RefID = securityTicket.TenantID;
                                    diagnosis_localization.LocalizationCode = case_to_submit.localization;

                                    diagnosis_localization.Save(Connection, Transaction);

                                    var treatment_diagnosis_update_localization = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization();
                                    treatment_diagnosis_update_localization.Creation_Timestamp = DateTime.Now;
                                    treatment_diagnosis_update_localization.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = Guid.NewGuid();
                                    treatment_diagnosis_update_localization.HEX_EXC_Action_DiagnosisUpdate_RefID = treatment_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                                    treatment_diagnosis_update_localization.HEC_DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                                    treatment_diagnosis_update_localization.IM_PotentialDiagnosisLocalization_Code = case_to_submit.localization;
                                    treatment_diagnosis_update_localization.Tenant_RefID = securityTicket.TenantID;
                                    treatment_diagnosis_update_localization.Modification_Timestamp = DateTime.Now;

                                    treatment_diagnosis_update_localization.Save(Connection, Transaction);

                                    var aftercare_planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result;
                                    if (aftercare_planned_action_id != null)
                                    {
                                        var aftercare_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                                        aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                                        aftercare_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                                        aftercare_planned_actionQ.IsDeleted = false;
                                        aftercare_planned_actionQ.IsPerformed = false;
                                        aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                                        var aftercare_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, aftercare_planned_actionQ).SingleOrDefault();
                                        if (aftercare_planned_action != null)
                                        {
                                            aftercare_planned_action.IfPlannedFollowup_PreviousAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                            aftercare_planned_action.Modification_Timestamp = DateTime.Now;

                                            aftercare_planned_action.Save(Connection, Transaction);
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region AFTERCARE
                            var aftercare_planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_to_submit.case_id, IsPerformed = true }, securityTicket).Result;
                            if (aftercare_planned_action_id != null)
                            {
                                aftercare_ids.Add(aftercare_planned_action_id.planned_action_id.ToString());

                                ORM_HEC_ACT_PlannedAction.Query aftercare_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                                aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                                aftercare_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                                aftercare_planned_actionQ.IsDeleted = false;
                                aftercare_planned_actionQ.IsPerformed = false;

                                var aftercare_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, aftercare_planned_actionQ).SingleOrDefault();
                                if (aftercare_planned_action != null && !aftercare_planned_action.IsPerformed)
                                {
                                    ORM_HEC_ACT_PerformedAction aftercare_performed_action = new ORM_HEC_ACT_PerformedAction();
                                    aftercare_performed_action.Creation_Timestamp = DateTime.Now;
                                    aftercare_performed_action.HEC_ACT_PerformedActionID = Guid.NewGuid();
                                    aftercare_performed_action.IfPerfomed_DateOfAction = Parameter.date_of_performed_action;
                                    aftercare_performed_action.IfPerformed_DateOfAction_Day = Parameter.date_of_performed_action.Day;
                                    aftercare_performed_action.IfPerformed_DateOfAction_Month = Parameter.date_of_performed_action.Month;
                                    aftercare_performed_action.IfPerformed_DateOfAction_Year = Parameter.date_of_performed_action.Year;
                                    aftercare_performed_action.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = trigger_acc.BusinessParticipant_RefID;
                                    aftercare_performed_action.IsPerformed_MedicalPractice_RefID = case_to_submit.aftercare_doctors_practice_id;
                                    aftercare_performed_action.Modification_Timestamp = DateTime.Now;
                                    aftercare_performed_action.Patient_RefID = case_to_submit.patient_id;
                                    aftercare_performed_action.Tenant_RefID = securityTicket.TenantID;
                                    aftercare_performed_action.IM_IfPerformed_MedicalPractice_Name = aftercare_practice_details.practice_name;
                                    aftercare_performed_action.IM_IfPerformed_ResponsibleBP_FullName = MMDocConnectDocApp.GenericUtils.GetDoctorName(aftercare_doctor_details);

                                    aftercare_performed_action.Save(Connection, Transaction);

                                    Guid aftercare_performed_action_type_id = Guid.Empty;

                                    ORM_HEC_ACT_ActionType.Query aftercare_performed_action_typeQ = new ORM_HEC_ACT_ActionType.Query();
                                    aftercare_performed_action_typeQ.GlobalPropertyMatchingID = EActionType.PerformedAftercare.Value();
                                    aftercare_performed_action_typeQ.Tenant_RefID = securityTicket.TenantID;
                                    aftercare_performed_action_typeQ.IsDeleted = false;

                                    var aftercare_performed_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, aftercare_performed_action_typeQ).SingleOrDefault();
                                    if (aftercare_performed_action_type == null)
                                    {
                                        aftercare_performed_action_type = new ORM_HEC_ACT_ActionType();
                                        aftercare_performed_action_type.GlobalPropertyMatchingID = EActionType.PerformedAftercare.Value();
                                        aftercare_performed_action_type.Creation_Timestamp = DateTime.Now;
                                        aftercare_performed_action_type.Modification_Timestamp = DateTime.Now;
                                        aftercare_performed_action_type.Tenant_RefID = securityTicket.TenantID;

                                        aftercare_performed_action_type.Save(Connection, Transaction);

                                        aftercare_performed_action_type_id = aftercare_performed_action_type.HEC_ACT_ActionTypeID;
                                    }
                                    else
                                    {
                                        aftercare_performed_action_type_id = aftercare_performed_action_type.HEC_ACT_ActionTypeID;
                                    }

                                    ORM_HEC_ACT_PerformedAction_2_ActionType aftercare_performed_action_2_type = new ORM_HEC_ACT_PerformedAction_2_ActionType();
                                    aftercare_performed_action_2_type.AssignmentID = Guid.NewGuid();
                                    aftercare_performed_action_2_type.Creation_Timestamp = DateTime.Now;
                                    aftercare_performed_action_2_type.HEC_ACT_ActionType_RefID = aftercare_performed_action_type_id;
                                    aftercare_performed_action_2_type.HEC_ACT_PerformedAction_RefID = aftercare_performed_action.HEC_ACT_PerformedActionID;
                                    aftercare_performed_action_2_type.IM_ActionType_Name = "Aftercare";
                                    aftercare_performed_action_2_type.Tenant_RefID = securityTicket.TenantID;
                                    aftercare_performed_action_2_type.Modification_Timestamp = DateTime.Now;

                                    aftercare_performed_action_2_type.Save(Connection, Transaction);

                                    aftercare_planned_action.IsPerformed = true;
                                    aftercare_planned_action.IfPerformed_PerformedAction_RefID = aftercare_performed_action.HEC_ACT_PerformedActionID;
                                    aftercare_planned_action.Modification_Timestamp = DateTime.Now;

                                    aftercare_planned_action.Save(Connection, Transaction);

                                    var patient_diagnosis = new ORM_HEC_Patient_Diagnosis();
                                    patient_diagnosis.Creation_Timestamp = DateTime.Now;
                                    patient_diagnosis.HEC_Patient_DiagnosisID = Guid.NewGuid();
                                    patient_diagnosis.Modification_Timestamp = DateTime.Now;
                                    patient_diagnosis.Patient_RefID = case_to_submit.patient_id;
                                    patient_diagnosis.R_IsConfirmed = case_to_submit.is_confirmed;
                                    patient_diagnosis.R_PotentialDiagnosis_RefID = case_to_submit.diagnose_id;
                                    patient_diagnosis.Tenant_RefID = securityTicket.TenantID;

                                    patient_diagnosis.Save(Connection, Transaction);

                                    var treatment_performed_diagnose_details = cls_Get_Treatment_Performed_Action_Diagnose_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPADDfCID_1304() { CaseID = case_id }, securityTicket).Result;
                                    if (treatment_performed_diagnose_details != null)
                                    {
                                        ORM_HEC_ACT_PerformedAction_DiagnosisUpdate aftercare_diagnosis_update = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                                        aftercare_diagnosis_update.Creation_Timestamp = DateTime.Now;
                                        aftercare_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
                                        aftercare_diagnosis_update.HEC_ACT_PerformedAction_RefID = aftercare_performed_action.HEC_ACT_PerformedActionID;
                                        aftercare_diagnosis_update.PotentialDiagnosis_RefID = treatment_performed_diagnose_details.diagnose_id;
                                        aftercare_diagnosis_update.IM_PotentialDiagnosis_Code = diagnose_details.diagnose_icd_10;
                                        aftercare_diagnosis_update.IM_PotentialDiagnosis_Name = diagnose_details.diagnose_name;
                                        aftercare_diagnosis_update.IM_PotentialDiagnosisCatalog_Name = diagnose_details.catalog_display_name;
                                        aftercare_diagnosis_update.IsDiagnosisConfirmed = true;
                                        aftercare_diagnosis_update.Modification_Timestamp = DateTime.Now;
                                        aftercare_diagnosis_update.Tenant_RefID = securityTicket.TenantID;
                                        aftercare_diagnosis_update.HEC_Patient_Diagnosis_RefID = patient_diagnosis != null ? patient_diagnosis.HEC_Patient_DiagnosisID : Guid.Empty;

                                        aftercare_diagnosis_update.Save(Connection, Transaction);

                                        ORM_HEC_DIA_Diagnosis_Localization diagnosis_localization = new ORM_HEC_DIA_Diagnosis_Localization();
                                        diagnosis_localization.Creation_Timestamp = DateTime.Now;
                                        diagnosis_localization.Diagnosis_RefID = treatment_performed_diagnose_details.diagnose_id;
                                        diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID = Guid.NewGuid();
                                        diagnosis_localization.Modification_Timestamp = DateTime.Now;
                                        diagnosis_localization.Tenant_RefID = securityTicket.TenantID;
                                        diagnosis_localization.LocalizationCode = treatment_performed_diagnose_details.localization;

                                        diagnosis_localization.Save(Connection, Transaction);

                                        ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization treatment_diagnosis_update_localization = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization();
                                        treatment_diagnosis_update_localization.Creation_Timestamp = DateTime.Now;
                                        treatment_diagnosis_update_localization.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = Guid.NewGuid();
                                        treatment_diagnosis_update_localization.HEX_EXC_Action_DiagnosisUpdate_RefID = aftercare_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                                        treatment_diagnosis_update_localization.HEC_DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                                        treatment_diagnosis_update_localization.IM_PotentialDiagnosisLocalization_Code = treatment_performed_diagnose_details.localization;
                                        treatment_diagnosis_update_localization.Tenant_RefID = securityTicket.TenantID;
                                        treatment_diagnosis_update_localization.Modification_Timestamp = DateTime.Now;

                                        treatment_diagnosis_update_localization.Save(Connection, Transaction);
                                    }
                                }
                            }
                            #endregion AFTERCARE
                        }
                        #endregion
                    }
                    else
                    {
                        var bill_position_ids = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result;
                        if (bill_position_ids.Any())
                        {
                            ORM_BIL_BillPosition.Query bill_positionQ = new ORM_BIL_BillPosition.Query();
                            bill_positionQ.IsDeleted = false;
                            bill_positionQ.Tenant_RefID = securityTicket.TenantID;

                            foreach (var id in bill_position_ids)
                            {
                                bill_positionQ.BIL_BillPositionID = id.bill_position_id;

                                var bill_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, bill_positionQ).SingleOrDefault();
                                if (bill_position != null)
                                {
                                    ORM_BIL_BillPosition_TransmitionStatus.Query transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                                    transmition_statusQ.BillPosition_RefID = bill_position.BIL_BillPositionID;
                                    transmition_statusQ.TransmitionStatusKey = Parameter.is_treatment ? "treatment" : "aftercare";
                                    transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                                    transmition_statusQ.IsDeleted = false;
                                    transmition_statusQ.IsActive = true;

                                    var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();

                                    #region SET CASE STATUS TO FS1
                                    var billing_code = cls_Get_BillingCode_for_CaseBillCodeID.Invoke(Connection, Transaction, new P_CAS_GBCfCBCID_1334() { CaseBillCodeID = id.hec_case_bill_code_id }, securityTicket).Result;
                                    if (billing_code != null)
                                    {
                                        if (transmition_status != null && (transmition_status.TransmitionCode == 6 || transmition_status.TransmitionCode == 5))
                                        {
                                            transmition_status.IsActive = false;
                                            transmition_status.Modification_Timestamp = DateTime.Now;
                                            transmition_status.Save(Connection, Transaction);

                                            #region SET TREATMENT STATUS TO FS1
                                            if (Parameter.is_treatment)
                                            {
                                                ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                                position_status.BillPosition_RefID = id.bill_position_id;
                                                position_status.Creation_Timestamp = DateTime.Now;
                                                position_status.IsActive = true;
                                                position_status.Modification_Timestamp = DateTime.Now;
                                                position_status.TransmitionCode = 1;
                                                position_status.TransmittedOnDate = DateTime.Now;
                                                position_status.Tenant_RefID = securityTicket.TenantID;
                                                position_status.TransmitionStatusKey = "treatment";

                                                #region CREATE SNAPSHOT
                                                DateTime today = DateTime.Today;
                                                int age = today.Year - patient_details.birthday.Year;
                                                if (patient_details.birthday > today.AddYears(-age))
                                                    age--;

                                                var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                                                {
                                                    DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                                    DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                                    DiagnosisName = diagnose_details.diagnose_name,
                                                    IFPerformedMedicalPracticeName = treatment_practice_details.practice_name,
                                                    IFPerformedResponsibleBPFullName = MMDocConnectDocApp.GenericUtils.GetDoctorName(treatment_doctor_details),
                                                    Localization = case_to_submit.localization,
                                                    PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                                    PatientFirstName = patient_details.patient_first_name,
                                                    PatientGender = patient_details.gender.ToString(),
                                                    PatientLastName = patient_details.patient_last_name,
                                                    PatientAge = age.ToString()
                                                }, securityTicket).Result;

                                                if (snapshot != null)
                                                {
                                                    position_status.TransmissionDataXML = snapshot.XmlFileString;
                                                }

                                                #endregion

                                                position_status.Save(Connection, Transaction);
                                            }

                                            #endregion

                                            #region SET AFTERCARE STATUS TO FS1
                                            else
                                            {
                                                if (id.gpos_type == gpos_type)
                                                {
                                                    ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                                    position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                                    position_status.BillPosition_RefID = id.bill_position_id;
                                                    position_status.Creation_Timestamp = DateTime.Now;
                                                    position_status.IsActive = true;
                                                    position_status.Modification_Timestamp = DateTime.Now;
                                                    position_status.TransmitionCode = 1;
                                                    position_status.TransmittedOnDate = DateTime.Now;
                                                    position_status.Tenant_RefID = securityTicket.TenantID;
                                                    position_status.TransmitionStatusKey = "aftercare";

                                                    #region CREATE SNAPSHOT
                                                    DateTime today = DateTime.Today;
                                                    int age = today.Year - patient_details.birthday.Year;
                                                    if (patient_details.birthday > today.AddYears(-age))
                                                        age--;

                                                    var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                                                    {
                                                        DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                                        DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                                        DiagnosisName = diagnose_details.diagnose_name,
                                                        IFPerformedMedicalPracticeName = aftercare_practice_details.practice_name,
                                                        IFPerformedResponsibleBPFullName = MMDocConnectDocApp.GenericUtils.GetDoctorName(aftercare_doctor_details),
                                                        Localization = case_to_submit.localization,
                                                        PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                                        PatientFirstName = patient_details.patient_first_name,
                                                        PatientGender = patient_details.gender.ToString(),
                                                        PatientLastName = patient_details.patient_last_name,
                                                        PatientAge = age.ToString()
                                                    }, securityTicket).Result;

                                                    if (snapshot != null)
                                                    {
                                                        position_status.TransmissionDataXML = snapshot.XmlFileString;
                                                    }
                                                    #endregion

                                                    position_status.Save(Connection, Transaction);
                                                }
                                            }

                                            #endregion
                                        }
                                    #endregion
                                    }
                                }
                            }
                        }
                    }

                    #endregion GPOS

                    #region UPDATE IMMUTABLE CASE FIELDS
                    var hec_case = ORM_HEC_CAS_Case.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case.Query() { HEC_CAS_CaseID = case_id, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                    if (hec_case != null)
                    {
                        hec_case.Patient_FirstName = patient_details.patient_first_name;
                        hec_case.Patient_LastName = patient_details.patient_last_name;
                        hec_case.Patient_BirthDate = patient_details.birthday;
                        hec_case.Patient_Gender = patient_details.gender;
                        hec_case.Modification_Timestamp = DateTime.Now;

                        hec_case.Save(Connection, Transaction);
                    }
                    #endregion

                    #region UPDATE CASE REPORT DOWNLOADED PROPERTY
                    if (Parameter.is_settlement && (shouldDownloadReportProperty == null || !shouldDownloadReportProperty.BooleanValue))
                    {
                        var caseProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                        {
                            GlobalPropertyMatchingID = ECaseProperty.ReportDownloaded.Value(),
                            Tenant_RefID = securityTicket.TenantID,
                            IsValue_String = true,
                            IsDeleted = false,
                            PropertyName = "Case Report Downloaded"
                        }).SingleOrDefault();

                        if (caseProperty == null)
                        {
                            caseProperty = new ORM_HEC_CAS_Case_UniversalProperty();
                            caseProperty.GlobalPropertyMatchingID = ECaseProperty.ReportDownloaded.Value();
                            caseProperty.IsValue_String = true;
                            caseProperty.Modification_Timestamp = DateTime.Now;
                            caseProperty.PropertyName = "Case Report Downloaded";
                            caseProperty.Tenant_RefID = securityTicket.TenantID;

                            caseProperty.Save(Connection, Transaction);
                        }

                        var casePropertyValue = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                        {
                            HEC_CAS_Case_RefID = case_id,
                            HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).SingleOrDefault();

                        if (casePropertyValue == null)
                        {
                            casePropertyValue = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                            casePropertyValue.HEC_CAS_Case_RefID = case_id;
                            casePropertyValue.HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID;
                            casePropertyValue.Tenant_RefID = securityTicket.TenantID;
                        }

                        casePropertyValue.Modification_Timestamp = DateTime.Now;
                        casePropertyValue.Value_String = "";
                        if (!casePropertyValue.Value_String.Contains(Parameter.planned_action_id.ToString()))
                        {
                            casePropertyValue.Value_String.Replace(Parameter.planned_action_id.ToString(), "");
                        }

                        casePropertyValue.Save(Connection, Transaction);
                    }
                    #endregion

                    #region OCT
                    if (Parameter.is_treatment && !is_resubmit && oct_doctor != null)
                    {
                        cls_Handle_OCT.Invoke(Connection, Transaction, new P_CAS_HOCT_1013()
                        {
                            is_submit = true,
                            case_id = case_id,
                            diagnose_id = case_to_submit.diagnose_id,
                            diagnose_name = String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10),
                            drug_id = case_to_submit.drug_id,
                            localization = case_to_submit.localization,
                            oct_doctor_id = oct_doctor.id,
                            oct_doctor_name = oct_doctor != null ? GenericUtils.GetDoctorName(oct_doctor) : "-",
                            oct_doctor_practice_id = oct_doctor != null ? oct_doctor.practice_id : Guid.Empty,
                            patient_birthdate = patient_details.birthday,
                            patient_id = case_to_submit.patient_id,
                            patient_name = String.Format("{0}, {1}", patient_details.patient_last_name, patient_details.patient_first_name),
                            treatment_date = case_to_submit.treatment_date,
                            treatment_doctor_id = case_to_submit.op_doctor_id,
                            treatment_doctor_name = treatment_doctor_details != null ? GenericUtils.GetDoctorName(treatment_doctor_details) : "-",
                            treatment_doctor_practice_id = treatment_doctor_details != null ? treatment_doctor_details.practice_id : Guid.Empty,
                            treatment_doctor_practice_name = treatment_doctor_details != null ? treatment_doctor_details.practice : "-",
                            treatment_doctor_lanr = treatment_doctor_details != null ? treatment_doctor_details.lanr : "",
                            treatment_doctor_practice_bsnr = treatment_doctor_details != null ? treatment_doctor_details.BSNR : "",
                            oct_doctor_lanr = oct_doctor != null ? oct_doctor.lanr : "",
                            patient_hip = patient_details.health_insurance_provider,
                            patient_insurance_number = patient_details.insurance_id
                        }, securityTicket);
                    }
                    #endregion
                }
            }

            #region PDF REPORT
            if (HttpContext.Current != null)
            {
                var host = HttpContext.Current.Request.UserHostAddress;
                var logoUrl = HttpContext.Current.Server.MapPath("~/Content/images/medioslogo.jpg");
                var reportContentPath = HttpContext.Current.Server.MapPath("~/ReportContent/SubmissionReportContent.xml");
                var docOnlyReportContentPath = HttpContext.Current.Server.MapPath("~/ReportContent/DocumentationOnlySubmissionReportContent.xml");

                var case_data = new List<P_CAS_CPRfSC_1813a>();
                var action_ids = new List<Guid>();
                for (var i = 0; i < Parameter.case_ids.Length; i++)
                {
                    var action_id = Guid.Empty;
                    var cid = Parameter.case_ids[i];
                    if (aftercare_ids.Any())
                    {
                        action_id = Guid.Parse(aftercare_ids[i]);
                    }
                    else if (treatment_ids.Any())
                    {
                        action_id = Guid.Parse(treatment_ids[i]);
                    }
                    else
                    {
                        action_id = Parameter.planned_action_id;
                    }

                    case_data.Add(new P_CAS_CPRfSC_1813a()
                    {
                        CaseID = cid,
                        CaseType = Parameter.is_treatment ? "op" : "ac",
                        ActionID = action_id
                    });
                }

                if (shouldDownloadReportProperty != null && shouldDownloadReportProperty.BooleanValue)
                {
                    returnValue.Result.pdf_report_url = cls_Create_Pdf_Report_for_Submitted_Case.Invoke(Connection, Transaction, new P_CAS_CPRfSC_1813()
                    {
                        IsResubmit = Parameter.is_settlement,
                        CaseData = case_data.ToArray(),
                        UploadedFrom = host,
                        LogoImageUrl = logoUrl,
                        ReportContentPath = reportContentPath,
                        DocumentationOnlyReportContentPath = docOnlyReportContentPath
                    }, securityTicket).Result.PdfUploaded;
                }
                else
                {
                    var connectionString = WebConfigurationManager.ConnectionStrings[WebConfigurationManager.AppSettings["activeConnection"]].ConnectionString;
                    var asyncDelay = 5000;
                    try
                    {
                        asyncDelay = Int32.Parse(WebConfigurationManager.AppSettings["pdfReceiptAsyncDelay"]);
                    }
                    catch { }

                    Task.Run(async delegate
                    {
                        await Task.Delay(asyncDelay);
                        try
                        {
                            cls_Create_Pdf_Report_for_Submitted_Case.Invoke(connectionString, new P_CAS_CPRfSC_1813()
                            {
                                IsResubmit = Parameter.is_settlement,
                                CaseData = case_data.ToArray(),
                                UploadedFrom = host,
                                LogoImageUrl = logoUrl,
                                IsBackgroundTask = true,
                                ReportContentPath = reportContentPath
                            }, securityTicket);
                        }
                        catch { }
                    });
                }
            }
            #endregion

            returnValue.Result.patient_ids = patient_ids.Distinct().ToArray();
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_SC_1425 Invoke(string ConnectionString, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_SC_1425 Invoke(DbConnection Connection, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_SC_1425 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_SC_1425 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_SC_1425 functionReturn = new FR_CAS_SC_1425();
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

                throw new Exception("Exception occured in method cls_Submit_Case", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_SC_1425 : FR_Base
    {
        public CAS_SC_1425 Result { get; set; }

        public FR_CAS_SC_1425() : base() { }

        public FR_CAS_SC_1425(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_SC_1425 for attribute P_CAS_SC_1425
    [DataContract]
    public class P_CAS_SC_1425
    {
        //Standard type parameters
        [DataMember]
        public Guid[] case_ids { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public Boolean is_treatment { get; set; }
        [DataMember]
        public Boolean is_settlement { get; set; }
        [DataMember]
        public DateTime date_of_performed_action { get; set; }
        [DataMember]
        public Guid planned_action_id { get; set; }
        [DataMember]
        public Guid authorizing_doctor_id { get; set; }

    }
    #endregion
    #region SClass CAS_SC_1425 for attribute CAS_SC_1425
    [DataContract]
    public class CAS_SC_1425
    {
        //Standard type parameters
        [DataMember]
        public String pdf_report_url { get; set; }
        [DataMember]
        public Guid[] patient_ids { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_SC_1425 cls_Submit_Case(,P_CAS_SC_1425 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_SC_1425 invocationResult = cls_Submit_Case.Invoke(connectionString,P_CAS_SC_1425 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_SC_1425();
parameter.case_ids = ...;
parameter.practice_id = ...;
parameter.is_treatment = ...;
parameter.is_settlement = ...;
parameter.date_of_performed_action = ...;
parameter.planned_action_id = ...;
parameter.authorizing_doctor_id = ...;

*/
