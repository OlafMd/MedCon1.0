/* 
 * Generated on 07/21/15 13:49:54
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
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using CL1_USR;
using CL1_CMN;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using CL1_HEC_CAS;
using CL1_BIL;
using CL1_HEC_BIL;
using DataImporter.DBMethods.Case.Complex.Retrieval;
using DataImporter.DBMethods.Case.Complex.Manipulation;
using CL1_HEC_ACT;
using CL1_HEC;
using CL1_HEC_DIA;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using DataImporter.Models;

namespace DataImporter.DBMethods.Case.Atomic.Manipulation
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
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var practice_default_settings = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDSfPID_0909() { PracticeID = Parameter.practice_id }, securityTicket).Result;
            bool is_management_fee_waived = practice_default_settings.WaiveServiceFee;

            String[] treatment_gpos = cls_Get_All_GPOS_Billing_Codes_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, new P_CAS_GAGPOSBCfGPMID_1516() { GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.operation" }, securityTicket).Result.Select(gpos => gpos.BillingCode).ToArray();
            String[] aftercare_gpos = cls_Get_All_GPOS_Billing_Codes_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, new P_CAS_GAGPOSBCfGPMID_1516() { GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.nachsorge" }, securityTicket).Result.Select(gpos => gpos.BillingCode).ToArray();

            #region TRIGGER ACCOUNT
            ORM_USR_Account.Query trigger_accQ = new ORM_USR_Account.Query();
            trigger_accQ.Tenant_RefID = securityTicket.TenantID;
            trigger_accQ.USR_AccountID = securityTicket.AccountID;
            trigger_accQ.IsDeleted = false;

            var trigger_acc = ORM_USR_Account.Query.Search(Connection, Transaction, trigger_accQ).SingleOrDefault();
            #endregion

            #region ALL LANGUAGES
            ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
            all_languagesQ.IsDeleted = false;

            var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();
            #endregion

            var case_to_submit = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = Parameter.case_id }, securityTicket).Result;
            if (case_to_submit != null)
            {
                var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = case_to_submit.diagnose_id }, securityTicket).Result;
                var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = case_to_submit.drug_id }, securityTicket).Result;
                var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.op_doctor_id }, securityTicket).Result.SingleOrDefault();
                var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_PA_GPDfPID_1729() { PatientID = case_to_submit.patient_id }, securityTicket).Result;
                var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result.SingleOrDefault();
                var treatment_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.practice_id }, securityTicket).Result.FirstOrDefault();
                var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.aftercare_doctors_practice_id }, securityTicket).Result.FirstOrDefault();

                var gpos_where_management_fee_is_waived = cls_Get_GPOS_where_Management_Fee_is_Waived_for_PatientID.Invoke(Connection, Transaction, new P_CAS_GGPOSwMFiWfPID_1512() { PatientID = case_to_submit.patient_id }, securityTicket).Result;

                #region ADD GPOS HEADER TO CASE BILL POSITIONS AND SET STATUS TO FS1
                Guid bill_to_bpt_id = Guid.Empty;

                if (case_to_submit.is_send_invoice_to_practice)
                {
                    Guid id = Guid.Empty;
                    var practice_account = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1522() { PracticeID = case_to_submit.practice_id }, securityTicket).Result;
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

                ORM_BIL_BillHeader gpos_header = new ORM_BIL_BillHeader();
                gpos_header.BIL_BillHeaderID = Guid.NewGuid();
                gpos_header.BillRecipient_BuisnessParticipant_RefID = bill_to_bpt_id;
                gpos_header.CreatedBy_BusinessParticipant_RefID = trigger_acc.BusinessParticipant_RefID;
                gpos_header.Creation_Timestamp = Parameter.date_of_submission;
                gpos_header.Modification_Timestamp = Parameter.date_of_submission;
                gpos_header.Tenant_RefID = securityTicket.TenantID;

                ORM_BIL_BillHeader_History bill_header_history_entry = new ORM_BIL_BillHeader_History();
                bill_header_history_entry.BIL_BillHeader_HistoryID = Guid.NewGuid();
                bill_header_history_entry.BillHeader_RefID = gpos_header.BIL_BillHeaderID;
                bill_header_history_entry.Comment = "Doctor";
                bill_header_history_entry.Creation_Timestamp = Parameter.date_of_submission;
                bill_header_history_entry.IsCreated = true;
                bill_header_history_entry.Modification_Timestamp = Parameter.date_of_submission;
                bill_header_history_entry.Tenant_RefID = securityTicket.TenantID;
                bill_header_history_entry.TriggeredBy_BusinessParticipant_RefID = trigger_acc.BusinessParticipant_RefID;

                bill_header_history_entry.Save(Connection, Transaction);

                ORM_HEC_BIL_BillHeader hec_gpos_header = new ORM_HEC_BIL_BillHeader();
                hec_gpos_header.Creation_Timestamp = Parameter.date_of_submission;
                hec_gpos_header.Ext_BIL_BillHeader_RefID = gpos_header.BIL_BillHeaderID;
                hec_gpos_header.HEC_BIL_BillHeaderID = Guid.NewGuid();
                hec_gpos_header.Modification_Timestamp = Parameter.date_of_submission;
                hec_gpos_header.Patient_RefID = case_to_submit.patient_id;
                hec_gpos_header.Tenant_RefID = securityTicket.TenantID;

                hec_gpos_header.Save(Connection, Transaction);

                decimal sum_total = 0;

                var bill_position_ids = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = Parameter.case_id }, securityTicket).Result;
                if (bill_position_ids.FirstOrDefault() != null)
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
                            switch (id.gpos_type)
                            {
                                case "mm.docconnect.gpos.catalog.wartezeitenmanagement":
                                    if (Parameter.is_treatment)
                                        bill_position.PositionNumber = Parameter.management_fee_bill_number;
                                    break;
                                case "mm.docconnect.gpos.catalog.operation":
                                    if (Parameter.is_treatment)
                                        bill_position.PositionNumber = Parameter.treatment_bill_number;
                                    break;
                                case "mm.docconnect.gpos.catalog.nachsorge":
                                    if (!Parameter.is_treatment)
                                        bill_position.PositionNumber = Parameter.aftercare_bill_number;
                                    break;
                                case "mm.docconnect.gpos.catalog.zusatzposition.bevacizumab":
                                    if (Parameter.is_treatment)
                                        bill_position.PositionNumber = Parameter.bevacizumab_bill_number;
                                    break;
                            }

                            bill_position.BIL_BilHeader_RefID = gpos_header.BIL_BillHeaderID;

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
                                if (!aftercare_gpos.Contains(billing_code.BillingCode))
                                {
                                    ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                    position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                    position_status.BillPosition_RefID = id.bill_position_id;
                                    position_status.Creation_Timestamp = Parameter.date_of_performed_action;
                                    position_status.IsActive = true;
                                    position_status.Modification_Timestamp = Parameter.date_of_performed_action;
                                    position_status.TransmitionCode = 1;
                                    position_status.TransmittedOnDate = Parameter.date_of_performed_action;
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
                                        IFPerformedResponsibleBPFullName = treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name,
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
                                if (aftercare_gpos.Contains(billing_code.BillingCode))
                                {
                                    ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                    position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                    position_status.BillPosition_RefID = id.bill_position_id;
                                    position_status.Creation_Timestamp = Parameter.date_of_performed_action;
                                    position_status.IsActive = true;
                                    position_status.Modification_Timestamp = Parameter.date_of_performed_action;
                                    position_status.TransmitionCode = 1;
                                    position_status.TransmittedOnDate = Parameter.date_of_performed_action;
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
                                        IFPerformedResponsibleBPFullName = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name,
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

                        if (!is_management_fee_waived)
                        {
                            if (billing_code != null)
                            {
                                if (Parameter.is_treatment)
                                {
                                    if (treatment_gpos.Contains(billing_code.BillingCode))
                                    {
                                        is_management_fee_waived = gpos_where_management_fee_is_waived.Any(gpos => gpos.BillingCode.Equals(billing_code.BillingCode));
                                    }
                                }
                                else
                                {
                                    if (aftercare_gpos.Contains(billing_code.BillingCode))
                                    {
                                        is_management_fee_waived = gpos_where_management_fee_is_waived.Any(gpos => gpos.BillingCode.Equals(billing_code.BillingCode));
                                    }
                                }
                            }
                        }
                    }
                }

                    gpos_header.TotalValue_IncludingTax = sum_total;

                gpos_header.Save(Connection, Transaction);

                ORM_BIL_BillHeader_PropertyValue gpos_header_management_fee_property_value = new ORM_BIL_BillHeader_PropertyValue();
                gpos_header_management_fee_property_value.BIL_BillHeader_PropertyValueID = Guid.NewGuid();
                gpos_header_management_fee_property_value.BIL_BillHeader_RefID = gpos_header.BIL_BillHeaderID;
                gpos_header_management_fee_property_value.Creation_Timestamp = Parameter.date_of_submission;
                gpos_header_management_fee_property_value.Modification_Timestamp = Parameter.date_of_submission;
                gpos_header_management_fee_property_value.PropertyKey = "mm.doc.connect.management.fee";
                gpos_header_management_fee_property_value.PropertyValue = is_management_fee_waived ? "waived" : "deducted";
                gpos_header_management_fee_property_value.Tenant_RefID = securityTicket.TenantID;

                gpos_header_management_fee_property_value.Save(Connection, Transaction);
                #endregion GPOS

                #region SET ACTION TO PERFORMED
                if (Parameter.is_treatment)
                {
                    #region TREATMENT
                    returnValue.Result = Parameter.case_id;
                    var treatment_planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_to_submit.case_id }, securityTicket).Result;
                    if (treatment_planned_action_id != null)
                    {
                        ORM_HEC_ACT_PlannedAction.Query treatment_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                        treatment_planned_actionQ.HEC_ACT_PlannedActionID = treatment_planned_action_id.planned_action_id;
                        treatment_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                        treatment_planned_actionQ.IsDeleted = false;
                        treatment_planned_actionQ.IsPerformed = false;

                        var treatment_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, treatment_planned_actionQ).SingleOrDefault();
                        if (treatment_planned_action != null)
                        {
                            ORM_HEC_ACT_PerformedAction treatment_performed_action = new ORM_HEC_ACT_PerformedAction();
                            treatment_performed_action.Creation_Timestamp = Parameter.date_of_performed_action;
                            treatment_performed_action.HEC_ACT_PerformedActionID = Guid.NewGuid();
                            treatment_performed_action.IfPerfomed_DateOfAction = Parameter.date_of_performed_action;
                            treatment_performed_action.IfPerformed_DateOfAction_Day = Parameter.date_of_performed_action.Day;
                            treatment_performed_action.IfPerformed_DateOfAction_Month = Parameter.date_of_performed_action.Month;
                            treatment_performed_action.IfPerformed_DateOfAction_Year = Parameter.date_of_performed_action.Year;
                            treatment_performed_action.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = case_to_submit.treatment_doctor_id;
                            treatment_performed_action.IsPerformed_MedicalPractice_RefID = case_to_submit.practice_id;
                            treatment_performed_action.Modification_Timestamp = Parameter.date_of_performed_action;
                            treatment_performed_action.Patient_RefID = case_to_submit.patient_id;
                            treatment_performed_action.Tenant_RefID = securityTicket.TenantID;
                            treatment_performed_action.IM_IfPerformed_ResponsibleBP_FullName = treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name;
                            treatment_performed_action.IM_IfPerformed_MedicalPractice_Name = treatment_practice_details.practice_name;
                            treatment_performed_action.Save(Connection, Transaction);

                            Guid treatment_performed_action_type_id = Guid.Empty;

                            ORM_HEC_ACT_ActionType.Query treatment_performed_action_typeQ = new ORM_HEC_ACT_ActionType.Query();
                            treatment_performed_action_typeQ.GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.treatment";
                            treatment_performed_action_typeQ.Tenant_RefID = securityTicket.TenantID;
                            treatment_performed_action_typeQ.IsDeleted = false;

                            var treatment_performed_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, treatment_performed_action_typeQ).SingleOrDefault();
                            if (treatment_performed_action_type == null)
                            {
                                treatment_performed_action_type = new ORM_HEC_ACT_ActionType();
                                treatment_performed_action_type.GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.treatment";
                                treatment_performed_action_type.Creation_Timestamp = Parameter.date_of_performed_action;
                                treatment_performed_action_type.Modification_Timestamp = Parameter.date_of_performed_action;
                                treatment_performed_action_type.Tenant_RefID = securityTicket.TenantID;

                                treatment_performed_action_type.Save(Connection, Transaction);

                                treatment_performed_action_type_id = treatment_performed_action_type.HEC_ACT_ActionTypeID;
                            }
                            else
                            {
                                treatment_performed_action_type_id = treatment_performed_action_type.HEC_ACT_ActionTypeID;
                            }

                            ORM_HEC_ACT_PerformedAction_2_ActionType treatment_performed_action_2_type = new ORM_HEC_ACT_PerformedAction_2_ActionType();
                            treatment_performed_action_2_type.AssignmentID = Guid.NewGuid();
                            treatment_performed_action_2_type.Creation_Timestamp = Parameter.date_of_performed_action;
                            treatment_performed_action_2_type.HEC_ACT_ActionType_RefID = treatment_performed_action_type_id;
                            treatment_performed_action_2_type.HEC_ACT_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                            treatment_performed_action_2_type.IM_ActionType_Name = "Treatment";
                            treatment_performed_action_2_type.Tenant_RefID = securityTicket.TenantID;
                            treatment_performed_action_2_type.Modification_Timestamp = Parameter.date_of_performed_action;

                            treatment_performed_action_2_type.Save(Connection, Transaction);

                            treatment_planned_action.IsPerformed = true;
                            treatment_planned_action.IfPerformed_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                            treatment_planned_action.Modification_Timestamp = Parameter.date_of_performed_action;

                            treatment_planned_action.Save(Connection, Transaction);

                            var patient_diagnosis = new ORM_HEC_Patient_Diagnosis();
                            patient_diagnosis.Creation_Timestamp = Parameter.date_of_performed_action;
                            patient_diagnosis.HEC_Patient_DiagnosisID = Guid.NewGuid();
                            patient_diagnosis.Modification_Timestamp = Parameter.date_of_performed_action;
                            patient_diagnosis.Patient_RefID = case_to_submit.patient_id;
                            patient_diagnosis.R_IsConfirmed = case_to_submit.is_confirmed;
                            patient_diagnosis.R_PotentialDiagnosis_RefID = case_to_submit.diagnose_id;
                            patient_diagnosis.Tenant_RefID = securityTicket.TenantID;

                            patient_diagnosis.Save(Connection, Transaction);

                            ORM_HEC_ACT_PerformedAction_DiagnosisUpdate treatment_diagnosis_update = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                            treatment_diagnosis_update.Creation_Timestamp = Parameter.date_of_performed_action;
                            treatment_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
                            treatment_diagnosis_update.HEC_ACT_PerformedAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                            treatment_diagnosis_update.PotentialDiagnosis_RefID = case_to_submit.diagnose_id;
                            treatment_diagnosis_update.IM_PotentialDiagnosis_Code = diagnose_details.diagnose_icd_10;
                            treatment_diagnosis_update.IM_PotentialDiagnosis_Name = diagnose_details.diagnose_name;
                            treatment_diagnosis_update.IM_PotentialDiagnosisCatalog_Name = diagnose_details.catalog_display_name;
                            treatment_diagnosis_update.IsDiagnosisConfirmed = true;
                            treatment_diagnosis_update.Modification_Timestamp = Parameter.date_of_performed_action;
                            treatment_diagnosis_update.Tenant_RefID = securityTicket.TenantID;
                            treatment_diagnosis_update.HEC_Patient_Diagnosis_RefID = patient_diagnosis != null ? patient_diagnosis.HEC_Patient_DiagnosisID : Guid.Empty;

                            treatment_diagnosis_update.Save(Connection, Transaction);

                            ORM_HEC_DIA_Diagnosis_Localization diagnosis_localization = new ORM_HEC_DIA_Diagnosis_Localization();
                            diagnosis_localization.Creation_Timestamp = Parameter.date_of_performed_action;
                            diagnosis_localization.Diagnosis_RefID = case_to_submit.diagnose_id;
                            diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID = Guid.NewGuid();
                            diagnosis_localization.Modification_Timestamp = Parameter.date_of_performed_action;
                            diagnosis_localization.Tenant_RefID = securityTicket.TenantID;
                            diagnosis_localization.LocalizationCode = case_to_submit.localization;

                            diagnosis_localization.Save(Connection, Transaction);

                            ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization treatment_diagnosis_update_localization = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization();
                            treatment_diagnosis_update_localization.Creation_Timestamp = Parameter.date_of_performed_action;
                            treatment_diagnosis_update_localization.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = Guid.NewGuid();
                            treatment_diagnosis_update_localization.HEX_EXC_Action_DiagnosisUpdate_RefID = treatment_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                            treatment_diagnosis_update_localization.HEC_DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                            treatment_diagnosis_update_localization.IM_PotentialDiagnosisLocalization_Code = case_to_submit.localization;
                            treatment_diagnosis_update_localization.Tenant_RefID = securityTicket.TenantID;
                            treatment_diagnosis_update_localization.Modification_Timestamp = Parameter.date_of_performed_action;

                            treatment_diagnosis_update_localization.Save(Connection, Transaction);

                            var aftercare_planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = Parameter.case_id }, securityTicket).Result;
                            if (aftercare_planned_action_id != null)
                            {
                                ORM_HEC_ACT_PlannedAction.Query aftercare_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                                aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                                aftercare_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                                aftercare_planned_actionQ.IsDeleted = false;
                                aftercare_planned_actionQ.IsPerformed = false;
                                aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                                var aftercare_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, aftercare_planned_actionQ).SingleOrDefault();
                                if (aftercare_planned_action != null)
                                {
                                    aftercare_planned_action.IfPlannedFollowup_PreviousAction_RefID = treatment_performed_action.HEC_ACT_PerformedActionID;
                                    aftercare_planned_action.Modification_Timestamp = Parameter.date_of_performed_action;

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
                    var aftercare_planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_to_submit.case_id }, securityTicket).Result;
                    if (aftercare_planned_action_id != null)
                    {
                        returnValue.Result = aftercare_planned_action_id.planned_action_id;

                        ORM_HEC_ACT_PlannedAction.Query aftercare_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                        aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                        aftercare_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                        aftercare_planned_actionQ.IsDeleted = false;
                        aftercare_planned_actionQ.IsPerformed = false;

                        var aftercare_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, aftercare_planned_actionQ).SingleOrDefault();
                        if (aftercare_planned_action != null)
                        {
                            ORM_HEC_ACT_PerformedAction aftercare_performed_action = new ORM_HEC_ACT_PerformedAction();
                            aftercare_performed_action.Creation_Timestamp = Parameter.date_of_performed_action;
                            aftercare_performed_action.HEC_ACT_PerformedActionID = Guid.NewGuid();
                            aftercare_performed_action.IfPerfomed_DateOfAction = Parameter.date_of_performed_action;
                            aftercare_performed_action.IfPerformed_DateOfAction_Day = Parameter.date_of_performed_action.Day;
                            aftercare_performed_action.IfPerformed_DateOfAction_Month = Parameter.date_of_performed_action.Month;
                            aftercare_performed_action.IfPerformed_DateOfAction_Year = Parameter.date_of_performed_action.Year;
                            aftercare_performed_action.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = case_to_submit.treatment_doctor_id;
                            aftercare_performed_action.IsPerformed_MedicalPractice_RefID = case_to_submit.practice_id;
                            aftercare_performed_action.Modification_Timestamp = Parameter.date_of_performed_action;
                            aftercare_performed_action.Patient_RefID = case_to_submit.patient_id;
                            aftercare_performed_action.Tenant_RefID = securityTicket.TenantID;
                            aftercare_performed_action.IM_IfPerformed_MedicalPractice_Name = aftercare_practice_details.practice_name;
                            aftercare_performed_action.IM_IfPerformed_ResponsibleBP_FullName = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name;

                            aftercare_performed_action.Save(Connection, Transaction);

                            Guid aftercare_performed_action_type_id = Guid.Empty;

                            ORM_HEC_ACT_ActionType.Query aftercare_performed_action_typeQ = new ORM_HEC_ACT_ActionType.Query();
                            aftercare_performed_action_typeQ.GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.aftercare";
                            aftercare_performed_action_typeQ.Tenant_RefID = securityTicket.TenantID;
                            aftercare_performed_action_typeQ.IsDeleted = false;

                            var aftercare_performed_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, aftercare_performed_action_typeQ).SingleOrDefault();
                            if (aftercare_performed_action_type == null)
                            {
                                aftercare_performed_action_type = new ORM_HEC_ACT_ActionType();
                                aftercare_performed_action_type.GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.aftercare";
                                aftercare_performed_action_type.Creation_Timestamp = Parameter.date_of_performed_action;
                                aftercare_performed_action_type.Modification_Timestamp = Parameter.date_of_performed_action;
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
                            aftercare_performed_action_2_type.Creation_Timestamp = Parameter.date_of_performed_action;
                            aftercare_performed_action_2_type.HEC_ACT_ActionType_RefID = aftercare_performed_action_type_id;
                            aftercare_performed_action_2_type.HEC_ACT_PerformedAction_RefID = aftercare_performed_action.HEC_ACT_PerformedActionID;
                            aftercare_performed_action_2_type.IM_ActionType_Name = "Treatment";
                            aftercare_performed_action_2_type.Tenant_RefID = securityTicket.TenantID;
                            aftercare_performed_action_2_type.Modification_Timestamp = Parameter.date_of_performed_action;

                            aftercare_performed_action_2_type.Save(Connection, Transaction);

                            aftercare_planned_action.IsPerformed = true;
                            aftercare_planned_action.IfPerformed_PerformedAction_RefID = aftercare_performed_action.HEC_ACT_PerformedActionID;
                            aftercare_planned_action.Modification_Timestamp = Parameter.date_of_performed_action;

                            aftercare_planned_action.Save(Connection, Transaction);

                            var patient_diagnosis = new ORM_HEC_Patient_Diagnosis();
                            patient_diagnosis.Creation_Timestamp = Parameter.date_of_performed_action;
                            patient_diagnosis.HEC_Patient_DiagnosisID = Guid.NewGuid();
                            patient_diagnosis.Modification_Timestamp = Parameter.date_of_performed_action;
                            patient_diagnosis.Patient_RefID = case_to_submit.patient_id;
                            patient_diagnosis.R_IsConfirmed = case_to_submit.is_confirmed;
                            patient_diagnosis.R_PotentialDiagnosis_RefID = case_to_submit.diagnose_id;
                            patient_diagnosis.Tenant_RefID = securityTicket.TenantID;

                            patient_diagnosis.Save(Connection, Transaction);

                            var treatment_performed_diagnose_details = cls_Get_Treatment_Performed_Action_Diagnose_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPADDfCID_1304() { CaseID = Parameter.case_id }, securityTicket).Result;
                            if (treatment_performed_diagnose_details != null)
                            {
                                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate aftercare_diagnosis_update = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                                aftercare_diagnosis_update.Creation_Timestamp = Parameter.date_of_performed_action;
                                aftercare_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
                                aftercare_diagnosis_update.HEC_ACT_PerformedAction_RefID = aftercare_performed_action.HEC_ACT_PerformedActionID;
                                aftercare_diagnosis_update.PotentialDiagnosis_RefID = treatment_performed_diagnose_details.diagnose_id;
                                aftercare_diagnosis_update.IM_PotentialDiagnosis_Code = diagnose_details.diagnose_icd_10;
                                aftercare_diagnosis_update.IM_PotentialDiagnosis_Name = diagnose_details.diagnose_name;
                                aftercare_diagnosis_update.IM_PotentialDiagnosisCatalog_Name = diagnose_details.catalog_display_name;
                                aftercare_diagnosis_update.IsDiagnosisConfirmed = true;
                                aftercare_diagnosis_update.Modification_Timestamp = Parameter.date_of_performed_action;
                                aftercare_diagnosis_update.Tenant_RefID = securityTicket.TenantID;
                                aftercare_diagnosis_update.HEC_Patient_Diagnosis_RefID = patient_diagnosis != null ? patient_diagnosis.HEC_Patient_DiagnosisID : Guid.Empty;

                                aftercare_diagnosis_update.Save(Connection, Transaction);

                                ORM_HEC_DIA_Diagnosis_Localization diagnosis_localization = new ORM_HEC_DIA_Diagnosis_Localization();
                                diagnosis_localization.Creation_Timestamp = Parameter.date_of_performed_action;
                                diagnosis_localization.Diagnosis_RefID = treatment_performed_diagnose_details.diagnose_id;
                                diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID = Guid.NewGuid();
                                diagnosis_localization.Modification_Timestamp = Parameter.date_of_performed_action;
                                diagnosis_localization.Tenant_RefID = securityTicket.TenantID;
                                diagnosis_localization.LocalizationCode = treatment_performed_diagnose_details.localization;

                                diagnosis_localization.Save(Connection, Transaction);

                                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization treatment_diagnosis_update_localization = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization();
                                treatment_diagnosis_update_localization.Creation_Timestamp = Parameter.date_of_performed_action;
                                treatment_diagnosis_update_localization.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = Guid.NewGuid();
                                treatment_diagnosis_update_localization.HEX_EXC_Action_DiagnosisUpdate_RefID = aftercare_diagnosis_update.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                                treatment_diagnosis_update_localization.HEC_DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                                treatment_diagnosis_update_localization.IM_PotentialDiagnosisLocalization_Code = treatment_performed_diagnose_details.localization;
                                treatment_diagnosis_update_localization.Tenant_RefID = securityTicket.TenantID;
                                treatment_diagnosis_update_localization.Modification_Timestamp = Parameter.date_of_performed_action;

                                treatment_diagnosis_update_localization.Save(Connection, Transaction);
                            }
                        }
                    }
                    #endregion AFTERCARE
                }
                #endregion

                #region IMPORT TO ELASTIC

                if (Parameter.is_treatment)
                {
                    Add_New_Case.Delete_Case_After_Submitting(securityTicket.TenantID.ToString(), "case", case_to_submit.case_id.ToString());
                }
                else
                {
                    Add_New_Aftercare.Delete_Aftercare_Submitting(securityTicket.TenantID.ToString(), "aftercare", returnValue.Result.ToString());
                }

                #region IMPORT SUBMITTED CASE TO ELASTIC
                Submitted_Case_Model submitted_case_model_elastic = new Submitted_Case_Model();
                submitted_case_model_elastic.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
                submitted_case_model_elastic.id = Parameter.is_treatment ? case_to_submit.treatment_planned_action_id.ToString() : case_to_submit.aftercare_planned_action_id.ToString();
                submitted_case_model_elastic.case_id = Parameter.case_id.ToString();
                submitted_case_model_elastic.localization = case_to_submit.localization;
                submitted_case_model_elastic.management_pauschale = is_management_fee_waived ? "waived" : "deducted";
                submitted_case_model_elastic.patient_birthdate = case_to_submit.Patient_BirthDate;
                submitted_case_model_elastic.patient_birthdate_string = case_to_submit.Patient_BirthDate.ToString("dd.MM.yyyy");
                submitted_case_model_elastic.patient_name = patient_details != null ? patient_details.patient_last_name + ", " + patient_details.patient_first_name : "";
                submitted_case_model_elastic.status = "FS1";
                submitted_case_model_elastic.status_date = Parameter.date_of_submission;
                submitted_case_model_elastic.status_date_string = Parameter.date_of_submission.ToString("dd.MM.yyyy");
                submitted_case_model_elastic.treatment_date = case_to_submit.treatment_date;
                submitted_case_model_elastic.treatment_date_day_month = case_to_submit.treatment_date.ToString("dd.MM.");
                submitted_case_model_elastic.treatment_date_month_year = case_to_submit.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                submitted_case_model_elastic.drug = drug_details != null ? drug_details.drug_name : "";
                submitted_case_model_elastic.type = Parameter.is_treatment ? "op" : "ac";
                submitted_case_model_elastic.treatment_date_string = case_to_submit.treatment_date.ToString("dd.MM.yyyy");
                submitted_case_model_elastic.patient_insurance_number = patient_details.insurance_id;
                
                if (Parameter.is_treatment)
                {
                    submitted_case_model_elastic.doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name : "-";
                    submitted_case_model_elastic.practice_name = treatment_doctor_details.practice;
                    submitted_case_model_elastic.doctor_lanr = treatment_doctor_details.lanr;
                    submitted_case_model_elastic.practice_bsnr = treatment_practice_details.practice_BSNR;
                }
                else
                {
                    submitted_case_model_elastic.doctor_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name;
                    submitted_case_model_elastic.practice_name = aftercare_doctor_details.practice;
                    submitted_case_model_elastic.doctor_lanr = aftercare_doctor_details.lanr;
                    submitted_case_model_elastic.practice_bsnr = aftercare_practice_details.practice_BSNR;
                }

                submitted_case_model_elastic.hip_name = patient_details != null ? patient_details.health_insurance_provider : "-";

                List<Submitted_Case_Model> cases_to_submit = new List<Submitted_Case_Model>();
                cases_to_submit.Add(submitted_case_model_elastic);

                Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(cases_to_submit, securityTicket.TenantID.ToString());
                #endregion

                if (Parameter.is_treatment)
                {
                    #region IMPORT AFTERCARE TO ELASTIC
                    Aftercare_Model aftercare = new Aftercare_Model();
                    aftercare.aftercare_doctor_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.first_name + " " + aftercare_doctor_details.last_name;
                    aftercare.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
                    aftercare.id = case_to_submit.aftercare_planned_action_id.ToString();
                    aftercare.localization = case_to_submit.localization;
                    aftercare.patient_birthdate = case_to_submit.Patient_BirthDate;
                    aftercare.patient_birthdate_string = case_to_submit.Patient_BirthDate.ToString("dd.MM.yyyy");
                    aftercare.patient_name = patient_details != null ? patient_details.patient_last_name + ", " + patient_details.patient_first_name : "";
                    aftercare.practice_id = cls_Get_PracticeID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GPIDfDID_1353() { DoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result.SingleOrDefault().HEC_MedicalPractiseID.ToString();
                    aftercare.status = "AC1";
                    aftercare.treatment_date = case_to_submit.treatment_date;
                    aftercare.treatment_date_day_month = case_to_submit.treatment_date.ToString("dd.MM.");
                    aftercare.treatment_date_month_year = case_to_submit.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                    aftercare.treatment_doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.first_name + " " + treatment_doctor_details.last_name : "-";
                    aftercare.treatment_doctor_practice_name = treatment_doctor_details.practice;
                    aftercare.case_id = Parameter.case_id.ToString();
                    var aftercare_doctor_account_id = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result.accountID;
                    aftercare.aftercare_doctor_account_id = aftercare_doctor_account_id.ToString();

                    List<Aftercare_Model> aftercares = new List<Aftercare_Model>() { aftercare };
                    Add_New_Aftercare.Import_Aftercare_Data_to_ElasticDB(aftercares, securityTicket.TenantID.ToString());
                    #endregion
                }
                #endregion IMPORT TO ELASTIC

            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SC_1425 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Submit_Case", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_SC_1425 for attribute P_CAS_SC_1425
    [DataContract]
    public class P_CAS_SC_1425
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public Boolean is_treatment { get; set; }
        [DataMember]
        public DateTime date_of_performed_action { get; set; }
        [DataMember]
        public DateTime date_of_submission { get; set; }
        [DataMember]
        public String treatment_gpos { get; set; }
        [DataMember]
        public String aftercare_gpos { get; set; }
        [DataMember]
        public String bevacizumab_gpos { get; set; }
        [DataMember]
        public String management_fee_gpos { get; set; }
        [DataMember]
        public String treatment_bill_number { get; set; }
        [DataMember]
        public String management_fee_bill_number { get; set; }
        [DataMember]
        public String aftercare_bill_number { get; set; }
        [DataMember]
        public String bevacizumab_bill_number { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Submit_Case(,P_CAS_SC_1425 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Submit_Case.Invoke(connectionString,P_CAS_SC_1425 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Manipulation.P_CAS_SC_1425();
parameter.case_id = ...;
parameter.practice_id = ...;
parameter.is_treatment = ...;
parameter.date_of_performed_action = ...;
parameter.date_of_submission = ...;
parameter.treatment_gpos = ...;
parameter.aftercare_gpos = ...;
parameter.bevacizumab_gpos = ...;
parameter.management_fee_gpos = ...;
parameter.treatment_bill_number = ...;
parameter.management_fee_bill_number = ...;
parameter.aftercare_bill_number = ...;
parameter.bevacizumab_bill_number = ...;

*/
