/* 
 * Generated on 08/17/15 14:57:26
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
using CL1_BIL;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using CL1_HEC_CAS;
using CL1_HEC_ACT;
using MMDocConnectDBMethods.Case.Complex.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectDocApp;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectUtils;
using CL1_HEC_BIL;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Change_PerformedAction_Status_for_PlannedActionID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guids Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CPASfPAID_1654 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guids();
            var patient_ids = new List<Guid>();
            //Put your code here

            var aftercare_gpos = cls_Get_All_GPOS_Billing_Codes_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, new P_CAS_GAGPOSBCfGPMID_1516() { GlobalPropertyMatchingID = EGposType.Aftercare.Value() }, securityTicket).Result.Select(gpos => gpos.BillingCode).ToList();

            var cases_to_submit = new List<Submitted_Case_Model>();
            var settlements = new List<Settlement_Model>();
            var patientDetailList = new List<PatientDetailViewModel>();
            var octs = new List<Oct_Model>();

            foreach (var planned_action_id in Parameter.planned_action_ids)
            {
                var action_gpmid = cls_Get_PlannedActionType_GlobalPropertyMatchingID_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GPAGPMIDfPAID_1652() { PlannedActionID = planned_action_id }, securityTicket).Result.GlobalPropertyMatchingID;

                var case_id = Guid.Empty;
                if (action_gpmid == EActionType.PlannedOperation.Value())
                {
                    var planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                    planned_actionQ.HEC_ACT_PlannedActionID = planned_action_id;
                    planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                    planned_actionQ.IsDeleted = false;
                    var planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, planned_actionQ).SingleOrDefault();
                    if (planned_action != null)
                    {
                        ORM_HEC_CAS_Case_RelevantPerformedAction.Query relevant_performed_actionQ = new ORM_HEC_CAS_Case_RelevantPerformedAction.Query();
                        relevant_performed_actionQ.PerformedAction_RefID = planned_action.IfPlannedFollowup_PreviousAction_RefID;
                        relevant_performed_actionQ.Tenant_RefID = securityTicket.TenantID;
                        relevant_performed_actionQ.IsDeleted = false;

                        var relevant_performed_action = ORM_HEC_CAS_Case_RelevantPerformedAction.Query.Search(Connection, Transaction, relevant_performed_actionQ).SingleOrDefault();
                        if (relevant_performed_action != null)
                        {
                            case_id = relevant_performed_action.Case_RefID;
                        }
                    }
                }
                else
                {
                    var relevant_planned_actionQ = new ORM_HEC_CAS_Case_RelevantPlannedAction.Query();
                    relevant_planned_actionQ.PlannedAction_RefID = planned_action_id;
                    relevant_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                    var relevant_planned_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, relevant_planned_actionQ).SingleOrDefault();
                    if (relevant_planned_action != null)
                    {
                        case_id = relevant_planned_action.Case_RefID;
                    }
                }


                var case_to_submit = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;
                patient_ids.Add(case_to_submit.patient_id);

                if (case_to_submit != null)
                {
                    int current_transmition_code = 1;
                    var gpos_type = EGposType.Aftercare.Value();
                    if (action_gpmid == EActionType.PlannedOperation.Value())
                        gpos_type = EGposType.Operation.Value();
                    else if (action_gpmid == EActionType.PlannedOct.Value())
                        gpos_type = EGposType.Oct.Value();

                    CAS_GCTCfCID_1427 current_transmition = null;
                    if (action_gpmid == EActionType.PlannedOperation.Value() || action_gpmid == EActionType.PlannedOct.Value())
                    {
                        current_transmition = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTCfCID_1427() { CaseID = case_id }, securityTicket).Result.FirstOrDefault(st => st.gpos_type == gpos_type);
                    }
                    else
                    {
                        var current_statuses = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTCfCID_1427() { CaseID = case_id }, securityTicket).Result.Where(st => st.gpos_type == gpos_type).ToArray();
                        if (current_statuses.Length > 1)
                        {
                            current_transmition = current_statuses.SingleOrDefault(st => st.fs_status != 8 && st.fs_status != 11 && st.fs_status != 17);
                        }
                        else
                        {
                            current_transmition = current_statuses.SingleOrDefault();
                        }
                    }

                    if (current_transmition != null)
                    {
                        current_transmition_code = current_transmition.fs_status;
                    }

                    var current_status = "FS" + current_transmition_code;
                    var previous_status = cls_Get_Previous_Status_for_Case_That_Was_on_Hold.Invoke(Connection, Transaction, new P_CAS_GPSfCTWoH_1237() { CaseID = case_id, GPOSType = gpos_type }, securityTicket).Result;
                    var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1608() { DiagnoseID = case_to_submit.diagnose_id }, securityTicket).Result;
                    var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = case_to_submit.drug_id }, securityTicket).Result;
                    var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.op_doctor_id }, securityTicket).Result.SingleOrDefault();
                    var oct_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.oct_doctor_id }, securityTicket).Result.SingleOrDefault();
                    var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = case_to_submit.patient_id }, securityTicket).Result;
                    var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result.SingleOrDefault();
                    var treatment_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.practice_id }, securityTicket).Result.FirstOrDefault();
                    var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.aftercare_doctors_practice_id }, securityTicket).Result.FirstOrDefault();
                    var all_bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result;

                    if (Parameter.change_status)
                    {
                        if (action_gpmid == EActionType.PlannedOperation.Value())
                        {
                            #region CHANGE TREATMENT STATUS
                            var bill_positions = all_bill_positions.Where(t => t.gpos_type == EGposType.Operation.Value()).ToList();
                            foreach (var bill_position in bill_positions)
                            {
                                var transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                                transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                                transmition_statusQ.TransmitionStatusKey = "treatment";
                                transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                                transmition_statusQ.IsDeleted = false;
                                transmition_statusQ.IsActive = true;

                                var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();
                                if (transmition_status != null && transmition_status.TransmitionCode != Parameter.new_status)
                                {
                                    transmition_status.IsActive = false;
                                    transmition_status.Modification_Timestamp = DateTime.Now;
                                    transmition_status.Save(Connection, Transaction);

                                    var position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                    position_status.BillPosition_RefID = bill_position.bill_position_id;
                                    position_status.IsActive = true;
                                    position_status.PrimaryComment = Parameter.new_status_ground;
                                    position_status.Modification_Timestamp = DateTime.Now;
                                    position_status.TransmitionCode = Parameter.new_status != 0 ? Parameter.new_status : previous_status != null ? previous_status.previous_status : current_transmition_code;
                                    position_status.TransmittedOnDate = DateTime.Now;
                                    position_status.Tenant_RefID = securityTicket.TenantID;
                                    position_status.TransmitionStatusKey = "treatment";
                                    position_status.IsTransmitionStatusManuallySet = true;

                                    #region CREATE SNAPSHOT
                                    var today = DateTime.Today;
                                    int age = today.Year - patient_details.birthday.Year;
                                    if (patient_details.birthday > today.AddYears(-age))
                                        age--;

                                    var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                                    {
                                        DiagnosisCatalogCode = diagnose_details == null ? "-" : diagnose_details.diagnose_icd_10,
                                        DiagnosisCatalogName = diagnose_details == null ? "-" : diagnose_details.catalog_display_name,
                                        DiagnosisName = diagnose_details == null ? "-" : diagnose_details.diagnose_name,
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

                                    current_status = "FS" + transmition_status.TransmitionCode;
                                }
                            }
                            #endregion
                        }
                        else if (action_gpmid == EActionType.PlannedOct.Value())
                        {
                            var oct_bill_positions = cls_Get_BillPositionIDs_for_PatientID_and_GposType.Invoke(Connection, Transaction, new P_CAS_GBPIDsfPIDaGposT_1709()
                            {
                                GposType = EGposType.Oct.Value(),
                                PatientID = case_to_submit.patient_id
                            }, securityTicket).Result.Where(t => t.status_id != Guid.Empty).ToList();

                            #region CHANGE OCT STATUS
                            var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;
                            var relevant_octs = cls_Get_PlannedActionIDs_for_PatientID_and_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GPAIDsfPIDaATID_1705()
                            {
                                PatientID = case_to_submit.patient_id,
                                ActionTypeID = oct_planned_action_type_id
                            }, securityTicket).Result.Where(t => t.performed).ToList();

                            var index = -1;
                            for (int i = 0; i < relevant_octs.Count; i++)
                            {
                                if (relevant_octs[i].action_id == planned_action_id)
                                {
                                    index = i;
                                    break;
                                }
                            }

                            var bill_position = index < oct_bill_positions.Count ? oct_bill_positions[index] : oct_bill_positions.First();

                            var transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                            transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                            transmition_statusQ.TransmitionStatusKey = "oct";
                            transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                            transmition_statusQ.IsDeleted = false;
                            transmition_statusQ.IsActive = true;

                            var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();
                            if (transmition_status != null && transmition_status.TransmitionCode != Parameter.new_status)
                            {
                                transmition_status.IsActive = false;
                                transmition_status.Modification_Timestamp = DateTime.Now;
                                transmition_status.Save(Connection, Transaction);

                                var position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                position_status.BillPosition_RefID = bill_position.bill_position_id;
                                position_status.IsActive = true;
                                position_status.PrimaryComment = Parameter.new_status_ground;
                                position_status.Modification_Timestamp = DateTime.Now;
                                position_status.TransmitionCode = Parameter.new_status != 0 ? Parameter.new_status : previous_status != null ? previous_status.previous_status : current_transmition_code;
                                position_status.TransmittedOnDate = DateTime.Now;
                                position_status.Tenant_RefID = securityTicket.TenantID;
                                position_status.TransmitionStatusKey = "oct";
                                position_status.IsTransmitionStatusManuallySet = true;

                                #region CREATE SNAPSHOT
                                var today = DateTime.Today;
                                int age = today.Year - patient_details.birthday.Year;
                                if (patient_details.birthday > today.AddYears(-age))
                                    age--;

                                var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                                {
                                    DiagnosisCatalogCode = diagnose_details == null ? "-" : diagnose_details.diagnose_icd_10,
                                    DiagnosisCatalogName = diagnose_details == null ? "-" : diagnose_details.catalog_display_name,
                                    DiagnosisName = diagnose_details == null ? "-" : diagnose_details.diagnose_name,
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

                                current_status = "FS" + transmition_status.TransmitionCode;

                                if (Parameter.new_status == 8)
                                {
                                    var performed_oct_data = cls_Get_PerformedActionDate_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GPADfPAID_1613() { ActionID = planned_action_id }, securityTicket).Result;
                                    var old_treatment_year_start_date = cls_Get_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GTY_1125()
                                    {
                                        Date = performed_oct_data.performed_on_date,
                                        LocalizationCode = performed_oct_data.localization,
                                        PatientID = case_to_submit.patient_id
                                    }, securityTicket).Result;

                                    var oct = Retrieve_Octs.GetOctsWhereFieldsHaveValues(new List<FieldValueParameter>() { 
                                            new FieldValueParameter() { FieldName = "localization", FieldValue = case_to_submit.localization },
                                            new FieldValueParameter() { FieldName = "patient_id", FieldValue = case_to_submit.patient_id.ToString() },
                                    }, null, securityTicket.TenantID.ToString(),
                                    new FieldValueParameter() { FieldName = "treatment_year_date", RangeConfig = "gte", FieldValue = old_treatment_year_start_date.ToString("yyyy-MM-ddTHH:mm:ss") }).SingleOrDefault();

                                    if (oct != null)
                                    {
                                        oct.treatment_year_octs--;
                                        if (oct.status == "OCT6")
                                        {
                                            oct.status = "OCT1";

                                            var patient_details_entry = new PatientDetailViewModel();
                                            patient_details_entry.id = oct.id;
                                            patient_details_entry.case_id = oct.case_id.ToString();
                                            patient_details_entry.practice_id = oct.practice_id.ToString();
                                            patient_details_entry.drug_id = case_to_submit.drug_id.ToString();
                                            patient_details_entry.date = oct.treatment_date;
                                            patient_details_entry.date_string = oct.treatment_date.ToString("dd.MM.");
                                            patient_details_entry.detail_type = "oct";
                                            patient_details_entry.diagnose_or_medication = oct.diagnose;
                                            patient_details_entry.doctor = oct.oct_doctor_name;
                                            patient_details_entry.localisation = oct.localization;
                                            patient_details_entry.patient_id = oct.patient_id.ToString();
                                            patient_details_entry.treatment_doctor_id = oct.oct_doctor_id.ToString();
                                            patient_details_entry.diagnose_id = oct.diagnose_id.ToString();
                                            patient_details_entry.status = "OCT1";
                                            patient_details_entry.hip_ik = patient_details.HealthInsurance_IKNumber;

                                            patientDetailList.Add(patient_details_entry);
                                        }

                                        octs.Add(oct);
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            #region CHANGE AFTERCARE STATUS
                            var aftercare_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedAftercare.Value() }, securityTicket).Result;
                            var relevant_aftercares = cls_Get_RelevanActionIDs_for_CaseID_and_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GRAIDsfCIDaATID_1547()
                            {
                                CaseID = case_id,
                                ActionTypeID = aftercare_planned_action_type_id
                            }, securityTicket).Result;

                            var index = -1;
                            for (int i = 0; i < relevant_aftercares.Length; i++)
                            {
                                if (relevant_aftercares[i].action_id == planned_action_id)
                                {
                                    index = i;
                                    break;
                                }
                            }

                            var bill_positions = all_bill_positions.Where(t => t.gpos_type == EGposType.Aftercare.Value()).ToList();
                            if (!bill_positions.Any())
                            {
                                throw new Exception(String.Format("No aftercare bill positions found. Aftercare id: {0}", planned_action_id));
                            }
                            var bill_position = bill_positions.Count > 1 ? bill_positions[index] : bill_positions.First();

                            var transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                            transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                            transmition_statusQ.TransmitionStatusKey = "aftercare";
                            transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                            transmition_statusQ.IsDeleted = false;
                            transmition_statusQ.IsActive = true;

                            ORM_BIL_BillPosition_TransmitionStatus transmition_status = null;

                            var fs_statuses = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).ToArray();
                            if (fs_statuses.Length < 2)
                                transmition_status = fs_statuses.SingleOrDefault();
                            else
                            {
                                if (fs_statuses.Any(fs => fs.TransmitionCode != 8 && fs.TransmitionCode != 11 && fs.TransmitionCode != 17))
                                {
                                    transmition_status = fs_statuses.Single(fs => fs.TransmitionCode != 8 && fs.TransmitionCode != 11 && fs.TransmitionCode != 17);
                                }
                                else
                                {
                                    transmition_status = fs_statuses.OrderByDescending(fs => fs.Creation_Timestamp).FirstOrDefault();
                                }
                            }

                            if (transmition_status != null && transmition_status.TransmitionCode != Parameter.new_status)
                            {
                                transmition_status.IsActive = false;
                                transmition_status.Modification_Timestamp = DateTime.Now;

                                transmition_status.Save(Connection, Transaction);

                                var position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                position_status.BillPosition_RefID = bill_position.bill_position_id;
                                position_status.IsActive = true;
                                position_status.PrimaryComment = Parameter.new_status_ground;
                                position_status.Modification_Timestamp = DateTime.Now;
                                position_status.TransmitionCode = Parameter.new_status != 0 ? Parameter.new_status : previous_status != null ? previous_status.previous_status : current_transmition_code;
                                position_status.TransmittedOnDate = DateTime.Now;
                                position_status.Tenant_RefID = securityTicket.TenantID;
                                position_status.TransmitionStatusKey = "aftercare";
                                position_status.IsTransmitionStatusManuallySet = true;

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

                            foreach (var other_bill_position in bill_positions.Where(t => t.bill_position_id != bill_position.bill_position_id))
                            {
                                var update_bill_position_status = false;

                                var any_covered_diagnoses = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                                {
                                    HEC_BIL_PotentialCode_RefID = other_bill_position.gpos_id,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                }).Any();

                                if (any_covered_diagnoses)
                                {
                                    update_bill_position_status = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                                    {
                                        HEC_BIL_PotentialCode_RefID = other_bill_position.gpos_id,
                                        Tenant_RefID = securityTicket.TenantID,
                                        IsDeleted = false
                                    }).Any();
                                }
                                else
                                {
                                    update_bill_position_status = true;
                                }

                                if (update_bill_position_status)
                                {
                                    var other_fs_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                                    {
                                        BillPosition_RefID = other_bill_position.bill_position_id,
                                        TransmitionStatusKey = "aftercare",
                                        Tenant_RefID = securityTicket.TenantID,
                                        IsDeleted = false,
                                        IsActive = true
                                    }).SingleOrDefault();

                                    if (transmition_status != null && transmition_status.TransmitionCode != Parameter.new_status)
                                    {
                                        transmition_status.IsActive = false;
                                        transmition_status.Modification_Timestamp = DateTime.Now;

                                        transmition_status.Save(Connection, Transaction);

                                        var position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                        position_status.BillPosition_RefID = other_bill_position.bill_position_id;
                                        position_status.IsActive = true;
                                        position_status.PrimaryComment = Parameter.new_status_ground;
                                        position_status.Modification_Timestamp = DateTime.Now;
                                        position_status.TransmitionCode = Parameter.new_status != 0 ? Parameter.new_status : previous_status != null ? previous_status.previous_status : current_transmition_code;
                                        position_status.TransmittedOnDate = DateTime.Now;
                                        position_status.Tenant_RefID = securityTicket.TenantID;
                                        position_status.TransmitionStatusKey = "aftercare";
                                        position_status.IsTransmitionStatusManuallySet = true;

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
                            }
                            #endregion
                        }
                    }

                    var is_treatment = action_gpmid == EActionType.PlannedOperation.Value();
                    var is_oct = action_gpmid == EActionType.PlannedOct.Value();

                    Submitted_Case_Model submitted_case_model_elastic = Get_Submitted_Cases.GetSubmittedCaseforSubmittedCaseID(planned_action_id.ToString(), securityTicket);

                    var prev_status = previous_status != null ? previous_status.previous_status : current_transmition_code;
                    submitted_case_model_elastic.status = !Parameter.change_status ? current_status : Parameter.new_status != 0 ? "FS" + Parameter.new_status : submitted_case_model_elastic.status != "FS3" ? submitted_case_model_elastic.status : "FS" + prev_status;
                    submitted_case_model_elastic.status_date = DateTime.Now;
                    submitted_case_model_elastic.status_date_string = DateTime.Now.ToString("dd.MM.yyyy");
                    if (submitted_case_model_elastic.status == "FS5" || submitted_case_model_elastic.status == "FS6")
                    {
                        submitted_case_model_elastic.patient_birthdate = patient_details.birthday;
                        submitted_case_model_elastic.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
                        submitted_case_model_elastic.patient_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
                        submitted_case_model_elastic.hip_name = patient_details.health_insurance_provider;
                        submitted_case_model_elastic.patient_insurance_number = patient_details.insurance_id;

                        if (!is_oct)
                        {
                            submitted_case_model_elastic.doctor_lanr = is_treatment ? treatment_doctor_details.lanr : aftercare_doctor_details.lanr;
                            submitted_case_model_elastic.doctor_name = is_treatment ? GenericUtils.GetDoctorName(treatment_doctor_details) : GenericUtils.GetDoctorName(aftercare_doctor_details);

                            submitted_case_model_elastic.practice_bsnr = is_treatment ? treatment_practice_details.practice_BSNR : aftercare_practice_details.practice_BSNR;
                            submitted_case_model_elastic.practice_name = is_treatment ? treatment_practice_details.practice_name : aftercare_practice_details.practice_name;
                        }
                        else
                        {
                            submitted_case_model_elastic.doctor_lanr = oct_doctor_details.lanr;
                            submitted_case_model_elastic.doctor_name = GenericUtils.GetDoctorName(oct_doctor_details);

                            submitted_case_model_elastic.practice_bsnr = oct_doctor_details.BSNR;
                            submitted_case_model_elastic.practice_name = oct_doctor_details.practice;
                        }
                    }

                    cases_to_submit.Add(submitted_case_model_elastic);

                    if (Parameter.new_status != 3 && Parameter.new_status != 5 && Parameter.new_status != 10)
                    {
                        var settlement = Get_Settlement.GetSettlementForID(planned_action_id.ToString(), securityTicket);
                        settlement.status = !Parameter.change_status ? current_status : Parameter.new_status != 0 ? "FS" + Parameter.new_status : settlement.status != "FS3" ? settlement.status : "FS" + prev_status;
                        if (settlement.status == "FS6")
                        {
                            settlement.patient_full_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
                            settlement.patient_insurance_number = patient_details.insurance_id;
                            settlement.birthday = patient_details.birthday.ToString("dd.MM.yyyy");
                            settlement.hip = patient_details.health_insurance_provider;

                            if (!is_oct)
                            {
                                settlement.doctor = is_treatment ? GenericUtils.GetDoctorName(treatment_doctor_details) : GenericUtils.GetDoctorName(aftercare_doctor_details);
                                settlement.lanr = is_treatment ? treatment_doctor_details.lanr : aftercare_doctor_details.lanr;
                            }
                            else
                            {
                                settlement.doctor = GenericUtils.GetDoctorName(oct_doctor_details);
                                settlement.lanr = oct_doctor_details.lanr;
                            }
                        }

                        settlements.Add(settlement);

                        PatientDetailViewModel patient_detail = Retrieve_Patients.Get_PatientDetaiForID(planned_action_id.ToString(), securityTicket);

                        if (patient_detail != null)
                        {
                            patient_detail.status = !Parameter.change_status ? current_status : Parameter.new_status != 0 ? "FS" + Parameter.new_status : patient_detail.status != "FS3" ? patient_detail.status : "FS" + prev_status;
                            patientDetailList.Add(patient_detail);
                        }
                    }
                }
            }

            if (cases_to_submit.Count != 0)
            {
                Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(cases_to_submit, securityTicket.TenantID.ToString());
            }

            if (settlements.Count != 0)
            {
                Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements, securityTicket.TenantID.ToString());
            }

            if (patientDetailList.Count != 0)
            {
                Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());
            }

            if (octs.Any())
            {
                Add_New_Oct.Import_Oct_Data_to_ElasticDB(octs, securityTicket.TenantID.ToString());
            }

            returnValue.Result = patient_ids.ToArray();
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guids Invoke(string ConnectionString, P_CAS_CPASfPAID_1654 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, P_CAS_CPASfPAID_1654 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CPASfPAID_1654 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CPASfPAID_1654 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guids functionReturn = new FR_Guids();
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

                throw new Exception("Exception occured in method cls_Change_PerformedAction_Status_for_PlannedActionID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_CPASfPAID_1654 for attribute P_CAS_CPASfPAID_1654
    [DataContract]
    public class P_CAS_CPASfPAID_1654
    {
        //Standard type parameters
        [DataMember]
        public Guid[] planned_action_ids { get; set; }
        [DataMember]
        public Boolean all_selected { get; set; }
        [DataMember]
        public Boolean change_status { get; set; }
        [DataMember]
        public int new_status { get; set; }
        [DataMember]
        public String new_status_ground { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Change_PerformedAction_Status_for_PlannedActionID(,P_CAS_CPASfPAID_1654 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(connectionString,P_CAS_CPASfPAID_1654 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CPASfPAID_1654();
parameter.planned_action_ids = ...;
parameter.all_selected = ...;
parameter.change_status = ...;
parameter.new_status = ...;
parameter.new_status_ground = ...;

*/
