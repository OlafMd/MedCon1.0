/* 
 * Generated on 2/21/2017 4:14:22 PM
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
using System.Runtime.Serialization;
using System.Globalization;
using CL1_HEC;
using CL1_USR;
using CL1_CMN;
using CL1_BIL;
using CL1_HEC_BIL;
using CL1_HEC_ACT;
using CL1_ORD_PRC;
using CL1_HEC_CAS;
using CL1_HEC_TRE;
using CL1_HEC_DIA;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectElasticSearchMethods.Doctor.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectUtils;
using System.Threading;
using System.Web.Configuration;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using System.Web;
using CL1_CMN_BPT_CTM;
using System.IO;
using Newtonsoft.Json;
using MMDocConnectDocApp;
using CL1_CMN_CTR;
using CL1_HEC_PRC;
using MMDocConnectElasticSearchMethods;
using MMDocConnectDBMethods.Order.Complex.Manipulation;
using MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Complex.Manipulation;


namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Case.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Case
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            #region DATA
            var new_case_id = Parameter.case_id;
            var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.treatment_doctor_id }, securityTicket).Result.SingleOrDefault();
            var oct_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.oct_doctor_id }, securityTicket).Result.SingleOrDefault();
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = Parameter.patient_id }, securityTicket).Result;
            var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1608() { DiagnoseID = Parameter.diagnose_id }, securityTicket).Result;
            var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = Parameter.drug_id }, securityTicket).Result;
            var previous_case_details = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = Parameter.case_id }, securityTicket).Result;
            var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.aftercare_doctor_practice_id }, securityTicket).Result.SingleOrDefault();
            var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = Parameter.aftercare_doctor_practice_id }, securityTicket).Result.FirstOrDefault();
            var aftercare_doctor_was_temprary = false;

            var all_languagesQ = new ORM_CMN_Language.Query();
            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
            all_languagesQ.IsDeleted = false;
            var ordersForSubmit = new List<Guid>();

            var all_languages = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();

            var trigger_accQ = new ORM_USR_Account.Query();
            trigger_accQ.Tenant_RefID = securityTicket.TenantID;
            trigger_accQ.USR_AccountID = securityTicket.AccountID;
            trigger_accQ.IsDeleted = false;

            var trigger_acc = ORM_USR_Account.Query.Search(Connection, Transaction, trigger_accQ).SingleOrDefault();

            var is_order_cancelled = false;
            var cancelled_order_id = Guid.Empty;
            var cancelled_order_drug_id = Guid.Empty;
            var is_drug_reordered = false;
            var initial_performed_action_id = Guid.Empty;
            var intraocular_procedure_id = Guid.Empty;
            var procurement_order_id = Guid.Empty;
            var drug_order_header_id = Guid.Empty;
            var previous_aftercare_id = Guid.Empty;
            var new_aftercare_id = Guid.Empty;
            var treatment_planned_action_id = Guid.Empty;

            var previous_status = "";
            var aftercare_sent_to_different_practice = false;
            var fs_statuses = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTCfCID_1427() { CaseID = Parameter.case_id }, securityTicket).Result;
            var is_case_submitted = Parameter.case_id == Guid.Empty ? false : fs_statuses.Any(t => t.gpos_type == EGposType.Operation.Value());
            var is_diagnose_changed = false;
            var is_localization_changed = false;
            var is_op_doctor_changed = false;
            var is_aftercare_submitted = false;
            var is_ac_doctor_changed = false;
            var is_treatment_date_changed = false;
            var delete_drug_order = false;
            var edit_drug_order = false;
            #endregion

            #region POTENTIAL PROCEDURE
            var intraocular_packageQ = new ORM_HEC_TRE_PotentialProcedure_Package.Query();
            intraocular_packageQ.Tenant_RefID = securityTicket.TenantID;
            intraocular_packageQ.IsDeleted = false;
            intraocular_packageQ.GlobalPropertyMatchingID = "mm.docconect.doc.app.intraocular.package";

            var intraocular_package = ORM_HEC_TRE_PotentialProcedure_Package.Query.Search(Connection, Transaction, intraocular_packageQ).FirstOrDefault();
            if (intraocular_package != null)
            {
                var procedure_2_packageQ = new ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query();
                procedure_2_packageQ.Tenant_RefID = securityTicket.TenantID;
                procedure_2_packageQ.IsDeleted = false;
                procedure_2_packageQ.HEC_TRE_PotentialProcedure_Package_RefID = intraocular_package.HEC_TRE_PotentialProcedure_PackageID;

                var procedure_2_package = ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query.Search(Connection, Transaction, procedure_2_packageQ).FirstOrDefault();
                if (procedure_2_package != null)
                {
                    intraocular_procedure_id = procedure_2_package.HEC_TRE_PotentialProcedure_RefID;
                }
                else
                {
                    intraocular_procedure_id = cls_Create_Potential_Procedure.Invoke(Connection, Transaction, securityTicket).Result;
                }
            }
            else
            {
                intraocular_procedure_id = cls_Create_Potential_Procedure.Invoke(Connection, Transaction, securityTicket).Result;
            }
            #endregion POTENTIAL PROCEDURE

            #region NEW
            if (Parameter.case_id == Guid.Empty)
            {
                #region NEW CASE
                var new_case = new ORM_HEC_CAS_Case();
                new_case.CreatedBy_BusinessParticipant_RefID = trigger_acc.BusinessParticipant_RefID;
                new_case.Patient_RefID = Parameter.patient_id;
                new_case.Patient_FirstName = patient_details.patient_first_name;
                new_case.Patient_LastName = patient_details.patient_last_name;
                new_case.Patient_Gender = patient_details.gender;
                new_case.Patient_BirthDate = patient_details.birthday;
                new_case.CaseNumber = cls_Get_Next_Case_Number.Invoke(Connection, Transaction, securityTicket).Result.case_number;
                new_case.Modification_Timestamp = DateTime.Now;

                var today = DateTime.Today;
                var age = today.Year - patient_details.birthday.Year;
                if (patient_details.birthday > today.AddYears(-age))
                    age--;

                new_case.Patient_Age = age;
                new_case.Tenant_RefID = securityTicket.TenantID;

                new_case.Save(Connection, Transaction);

                new_case_id = new_case.HEC_CAS_CaseID;
                #endregion NEW CASE

                #region INITIAL PERFORMED ACTION
                initial_performed_action_id = cls_Create_Initial_Performed_Action.Invoke(Connection, Transaction, new P_CAS_CIPA_1140()
                {
                    all_languagesL = all_languages,
                    case_id = new_case_id,
                    created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                    patient_id = Parameter.patient_id,
                    practice_id = Parameter.practice_id,
                    action_type_gpmid = EActionType.PerformedInitial.Value()
                }, securityTicket).Result;
                #endregion INITIAL PERFORMED ACTION

                #region DRUG ORDER
                if (Parameter.is_orders_drug)
                {
                    var drug_order_result = cls_Create_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1202()
                    {
                        all_languagesL = all_languages,
                        alternative_delivery_date_from = Parameter.alternative_delivery_date_from,
                        alternative_delivery_date_to = Parameter.alternative_delivery_date_to,
                        case_id = new_case_id,
                        created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                        delivery_date = Parameter.delivery_date,
                        drug_id = Parameter.drug_id,
                        is_alternative_delivery_date = Parameter.is_alternative_delivery_date,
                        is_label_only = Parameter.is_label_only,
                        is_patient_fee_waived = Parameter.is_patient_fee_waived,
                        is_send_invoice_to_practice = Parameter.is_send_invoice_to_practice,
                        patient_details = patient_details,
                        patient_id = Parameter.patient_id,
                        practice_id = Parameter.practice_id,
                        treatment_date = Parameter.treatment_date,
                        treatment_doctor_details = treatment_doctor_details,
                        treatment_doctor_id = Parameter.treatment_doctor_id,
                        order_comment = Parameter.order_comment
                    }, securityTicket).Result;

                    procurement_order_id = drug_order_result.procurement_order_position_id;
                    drug_order_header_id = drug_order_result.procurement_order_header_id;

                    if (Parameter.is_quick_order)
                    {
                        ordersForSubmit.Add(drug_order_result.procurement_order_header_id);
                    }

                }
                #endregion DRUG ORDER

                #region TREATMENT PLANNED ACTION
                treatment_planned_action_id = cls_Create_Treatment_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CTPA_1225()
                {
                    all_languagesL = all_languages,
                    case_id = new_case_id,
                    diagnose_id = Parameter.diagnose_id,
                    initial_performed_action_id = initial_performed_action_id,
                    drug_id = Parameter.drug_id,
                    intraocular_procedure_id = intraocular_procedure_id,
                    is_confirmed = Parameter.is_confirmed,
                    is_left_eye = Parameter.is_left_eye,
                    patient_id = Parameter.patient_id,
                    practice_id = Parameter.practice_id,
                    procurement_order_id = procurement_order_id,
                    treatment_date = Parameter.treatment_date,
                    treatment_doctor_id = Parameter.treatment_doctor_id
                }, securityTicket).Result;
                #endregion TREATMENT PLANNED ACTION

                #region AFTERCARE PLANNED ACTION
                if (Parameter.aftercare_doctor_practice_id != Guid.Empty)
                {
                    cls_Create_Aftercare_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CAPA_1237()
                    {
                        aftercare_doctor_practice_id = Parameter.aftercare_doctor_practice_id,
                        all_languagesL = all_languages,
                        case_id = new_case_id,
                        patient_id = Parameter.patient_id,
                        practice_id = Parameter.practice_id,
                        treatment_date = Parameter.treatment_date
                    }, securityTicket);
                }
                #endregion AFTERCARE PLANNED ACTION

                #region ADD GPOS TO THE CASE
                if (Parameter.diagnose_id != Guid.Empty)
                {
                    cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                    {
                        ac_doctor_id = Parameter.aftercare_doctor_practice_id,
                        all_languagesL = all_languages,
                        case_id = new_case_id,
                        diagnose_id = Parameter.diagnose_id,
                        drug_id = Parameter.drug_id,
                        patient_id = Parameter.patient_id,
                        treatment_doctor_id = Parameter.treatment_doctor_id,
                        localization = Parameter.is_left_eye ? "L" : "R",
                        treatment_date = Parameter.treatment_date
                    }, securityTicket);
                }
                #endregion
            }
            #endregion NEW

            #region EDIT
            else
            {
                var initial_performed_action = cls_Get_Initial_PerformedActionID_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GIPAIDfCID_1059() { CaseID = Parameter.case_id }, securityTicket).Result;
                initial_performed_action_id = initial_performed_action != null ? initial_performed_action.initial_performed_action_id : Guid.Empty;

                var case_to_editQ = new ORM_HEC_CAS_Case.Query();
                case_to_editQ.HEC_CAS_CaseID = Parameter.case_id;
                case_to_editQ.Tenant_RefID = securityTicket.TenantID;
                case_to_editQ.IsDeleted = false;

                var case_to_edit = ORM_HEC_CAS_Case.Query.Search(Connection, Transaction, case_to_editQ).SingleOrDefault();
                if (case_to_edit != null)
                {
                    if (!is_case_submitted)
                    {
                        #region DELETE CURRENT GPOS
                        var current_gpos_ids = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = Parameter.case_id }, securityTicket).Result.Where(t => t.gpos_type != EGposType.Oct.Value()).ToList();
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
                            ac_doctor_id = Parameter.aftercare_doctor_practice_id,
                            all_languagesL = all_languages,
                            case_id = Parameter.case_id,
                            diagnose_id = Parameter.diagnose_id,
                            drug_id = Parameter.drug_id,
                            patient_id = Parameter.patient_id,
                            treatment_doctor_id = Parameter.treatment_doctor_id,
                            localization = Parameter.is_left_eye ? "L" : "R",
                            treatment_date = Parameter.treatment_date
                        }, securityTicket);
                        #endregion
                    }

                    var patient_changed = false;
                    patient_changed = case_to_edit.Patient_RefID != Parameter.patient_id;

                    var today = DateTime.Today;
                    var age = today.Year - patient_details.birthday.Year;
                    if (patient_details.birthday > today.AddYears(-age))
                        age--;

                    case_to_edit.Patient_Age = age;
                    case_to_edit.Patient_BirthDate = patient_details.birthday;
                    case_to_edit.Patient_FirstName = patient_details.patient_first_name;
                    case_to_edit.Patient_Gender = patient_details.gender;
                    case_to_edit.Patient_LastName = patient_details.patient_last_name;
                    case_to_edit.Patient_RefID = Parameter.patient_id;
                    case_to_edit.Modification_Timestamp = DateTime.Now;

                    case_to_edit.Save(Connection, Transaction);

                    var treatment_planned_actioN = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = Parameter.case_id }, securityTicket).Result;
                    if (treatment_planned_actioN != null)
                    {
                        treatment_planned_action_id = treatment_planned_actioN.planned_action_id;

                        var treatment_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                        treatment_planned_actionQ.HEC_ACT_PlannedActionID = treatment_planned_actioN.planned_action_id;
                        treatment_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                        treatment_planned_actionQ.IsDeleted = false;

                        var treatment_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, treatment_planned_actionQ).SingleOrDefault();
                        if (!is_case_submitted)
                        {
                            #region EDIT DRUG ORDER
                            var drug_order_ids = cls_Get_DrugOrderIDs_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GDOIDsfPAID_1243() { PlannedActionID = treatment_planned_actioN.planned_action_id }, securityTicket).Result;
                            if (drug_order_ids != null && Parameter.delivery_date != DateTime.MinValue)
                            {
                                procurement_order_id = drug_order_ids.HEC_PRC_ProcurementOrder_PositionID;
                                ORM_ORD_PRC_ProcurementOrder_Header.Query ord_drug_order_headerQ = new ORM_ORD_PRC_ProcurementOrder_Header.Query();
                                ord_drug_order_headerQ.Tenant_RefID = securityTicket.TenantID;
                                ord_drug_order_headerQ.ORD_PRC_ProcurementOrder_HeaderID = drug_order_ids.ORD_PRC_ProcurementOrder_HeaderID;
                                ord_drug_order_headerQ.IsDeleted = false;

                                var ord_drug_order_header = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction, ord_drug_order_headerQ).SingleOrDefault();
                                if (ord_drug_order_header != null)
                                {
                                    drug_order_header_id = ord_drug_order_header.ORD_PRC_ProcurementOrder_HeaderID;

                                    ORM_ORD_PRC_ProcurementOrder_Status.Query drug_order_status_latestQ = new ORM_ORD_PRC_ProcurementOrder_Status.Query();
                                    drug_order_status_latestQ.ORD_PRC_ProcurementOrder_StatusID = ord_drug_order_header.Current_ProcurementOrderStatus_RefID;
                                    drug_order_status_latestQ.Tenant_RefID = securityTicket.TenantID;
                                    drug_order_status_latestQ.IsDeleted = false;

                                    var drug_order_status_latest = ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction, drug_order_status_latestQ).SingleOrDefault();
                                    if (drug_order_status_latest != null)
                                    {
                                        Guid status_id = Guid.Empty;

                                        #region CHANGE ORDER STATUS
                                        ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query potential_procedure_required_productQ = new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query();
                                        potential_procedure_required_productQ.HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID = drug_order_ids.HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID;
                                        potential_procedure_required_productQ.Tenant_RefID = securityTicket.TenantID;
                                        potential_procedure_required_productQ.IsDeleted = false;

                                        var potential_procedure_required_product = ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query.Search(Connection, Transaction, potential_procedure_required_productQ).SingleOrDefault();
                                        var drug_order_settings = cls_Get_Drug_Order_Settings.Invoke(Connection, Transaction, new P_CAS_GDOS_1108() { CaseID = Parameter.case_id }, securityTicket).Result;

                                        ORM_ORD_PRC_ProcurementOrder_Position.Query ord_procurement_order_positionQ = new ORM_ORD_PRC_ProcurementOrder_Position.Query();
                                        ord_procurement_order_positionQ.Tenant_RefID = securityTicket.TenantID;
                                        ord_procurement_order_positionQ.IsDeleted = false;
                                        ord_procurement_order_positionQ.ORD_PRC_ProcurementOrder_PositionID = drug_order_ids.Ext_ORD_PRC_ProcurementOrder_Position_RefID;

                                        var ord_procurement_order_position = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction, ord_procurement_order_positionQ).SingleOrDefault();

                                        previous_status = "MO" + drug_order_status_latest.Status_Code;

                                        var orderHeaderID = Guid.Empty;
                                        switch (drug_order_status_latest.Status_Code)
                                        {
                                            // MO0 status
                                            case 0:
                                                var existing_treatment_planned_action_required_product = ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query()
                                                {
                                                    HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID = drug_order_ids.HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID
                                                }).Single();

                                                if (!Parameter.is_orders_drug)
                                                {
                                                    delete_drug_order = true;
                                                    cls_Cancel_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1250()
                                                    {
                                                        all_languagesL = all_languages,
                                                        created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                        ord_drug_order_header = ord_drug_order_header,
                                                        procurement_order_position_id = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID,
                                                        case_id = Parameter.case_id
                                                    }, securityTicket);
                                                }
                                                else
                                                {
                                                    edit_drug_order = true;

                                                    existing_treatment_planned_action_required_product.HealthcareProduct_RefID = Parameter.drug_id;
                                                    existing_treatment_planned_action_required_product.Modification_Timestamp = DateTime.Now;

                                                    existing_treatment_planned_action_required_product.Save(Connection, Transaction);

                                                    ord_procurement_order_position.IsProFormaOrderPosition = Parameter.is_label_only;
                                                    ord_procurement_order_position.RequestedDateOfDelivery_TimeFrame_From = Parameter.is_alternative_delivery_date ? Parameter.alternative_delivery_date_from : Parameter.delivery_date.AddHours(8);
                                                    ord_procurement_order_position.RequestedDateOfDelivery_TimeFrame_To = Parameter.is_alternative_delivery_date ? Parameter.alternative_delivery_date_to : Parameter.delivery_date.AddHours(17).AddMinutes(59).AddSeconds(59);
                                                    ord_procurement_order_position.Position_RequestedDateOfDelivery = Parameter.delivery_date;

                                                    var edit_ord_drug_order_position_history_entry = new ORM_ORD_PRC_ProcurementOrder_Position_History();
                                                    edit_ord_drug_order_position_history_entry.Tenant_RefID = securityTicket.TenantID;
                                                    edit_ord_drug_order_position_history_entry.ProcurementOrder_Position_RefID = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID;
                                                    edit_ord_drug_order_position_history_entry.IsModified = true;
                                                    edit_ord_drug_order_position_history_entry.Modification_Timestamp = DateTime.Now;

                                                    edit_ord_drug_order_position_history_entry.Save(Connection, Transaction);

                                                    var hec_procurement_order_position = ORM_HEC_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction, new ORM_HEC_PRC_ProcurementOrder_Position.Query()
                                                    {
                                                        Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID,
                                                        Tenant_RefID = securityTicket.TenantID,
                                                        IsDeleted = false
                                                    }).Single();

                                                    hec_procurement_order_position.IfProFormaOrderPosition_PrintLabelOnly = Parameter.is_label_only;
                                                    hec_procurement_order_position.IsOrderForPatient_PatientFeeWaived = Parameter.is_patient_fee_waived;

                                                    if (Parameter.is_send_invoice_to_practice)
                                                    {
                                                        var id = Guid.Empty;
                                                        var practice_account = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.practice_id }, securityTicket).Result;
                                                        if (practice_account != null)
                                                        {
                                                            id = practice_account.accountID;
                                                        }

                                                        var invoice_practice_accountQ = new ORM_USR_Account.Query();
                                                        invoice_practice_accountQ.USR_AccountID = id;
                                                        invoice_practice_accountQ.Tenant_RefID = securityTicket.TenantID;
                                                        invoice_practice_accountQ.IsDeleted = false;

                                                        var invoice_practice_account = ORM_USR_Account.Query.Search(Connection, Transaction, invoice_practice_accountQ).SingleOrDefault();
                                                        if (invoice_practice_account != null)
                                                        {
                                                            ord_procurement_order_position.BillTo_BusinessParticipant_RefID = invoice_practice_account.BusinessParticipant_RefID;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ord_procurement_order_position.BillTo_BusinessParticipant_RefID = Guid.Empty;
                                                    }

                                                    ord_procurement_order_position.Position_Comment = Parameter.order_comment;

                                                    ord_procurement_order_position.Save(Connection, Transaction);

                                                    orderHeaderID = ord_drug_order_header.ORD_PRC_ProcurementOrder_HeaderID;
                                                }

                                                break;
                                            // MO1 status
                                            case 1:
                                            // MO2 status
                                            case 2:
                                                var treatment_date = treatment_planned_action.PlannedFor_Date.Date;
                                                if (!Parameter.is_orders_drug || (Parameter.treatment_date < DateTime.Now.Date && treatment_date != Parameter.treatment_date.Date))
                                                {
                                                    #region CANCEL DRUG ORDER
                                                    previous_status = cls_Cancel_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1250()
                                                    {
                                                        all_languagesL = all_languages,
                                                        created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                        ord_drug_order_header = ord_drug_order_header,
                                                        procurement_order_position_id = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID,
                                                        case_id = Parameter.case_id
                                                    }, securityTicket).Result.previous_status;
                                                    is_order_cancelled = true;
                                                    #endregion
                                                }
                                                else
                                                {
                                                    #region CANCEL PREVIOUS, CREATE NEW ORDER
                                                    if (drug_order_settings != null)
                                                    {
                                                        if (Parameter.is_patient_fee_waived != drug_order_settings.is_patient_fee_waived ||
                                                            Parameter.drug_id != drug_order_settings.drug_id ||
                                                            Parameter.is_send_invoice_to_practice != drug_order_settings.is_send_invoice_to_practice ||
                                                            Parameter.is_label_only != drug_order_settings.is_label_only ||
                                                            drug_order_settings.treatment_date.Date != Parameter.treatment_date.Date ||
                                                            patient_changed)
                                                        {
                                                            #region CANCEL PREVIOUS ORDER
                                                            previous_status = cls_Cancel_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1250()
                                                            {
                                                                all_languagesL = all_languages,
                                                                created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                                ord_drug_order_header = ord_drug_order_header,
                                                                procurement_order_position_id = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID,
                                                                case_id = Parameter.case_id
                                                            }, securityTicket).Result.previous_status;
                                                            is_order_cancelled = true;
                                                            #endregion

                                                            #region CREATE NEW ORDER

                                                            if (Parameter.is_orders_drug)
                                                            {
                                                                is_drug_reordered = true;
                                                                potential_procedure_required_product.IsDeleted = true;
                                                                potential_procedure_required_product.Save(Connection, Transaction);

                                                                cancelled_order_id = drug_order_ids.ORD_PRC_ProcurementOrder_HeaderID;
                                                                cancelled_order_drug_id = drug_order_settings.drug_id;

                                                                var drug_order_result = cls_Create_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1202()
                                                                {
                                                                    all_languagesL = all_languages,
                                                                    alternative_delivery_date_from = Parameter.alternative_delivery_date_from,
                                                                    alternative_delivery_date_to = Parameter.alternative_delivery_date_to,
                                                                    case_id = Parameter.case_id,
                                                                    created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                                    delivery_date = Parameter.delivery_date,
                                                                    drug_id = Parameter.drug_id,
                                                                    is_alternative_delivery_date = Parameter.is_alternative_delivery_date,
                                                                    is_label_only = Parameter.is_label_only,
                                                                    is_patient_fee_waived = Parameter.is_patient_fee_waived,
                                                                    is_send_invoice_to_practice = Parameter.is_send_invoice_to_practice,
                                                                    patient_details = patient_details,
                                                                    patient_id = Parameter.patient_id,
                                                                    practice_id = Parameter.practice_id,
                                                                    treatment_date = Parameter.treatment_date,
                                                                    treatment_doctor_details = treatment_doctor_details,
                                                                    treatment_doctor_id = Parameter.treatment_doctor_id,
                                                                    order_comment = Parameter.order_comment
                                                                }, securityTicket).Result;

                                                                orderHeaderID = drug_order_result.procurement_order_header_id;

                                                                procurement_order_id = drug_order_result.procurement_order_position_id;
                                                                drug_order_header_id = drug_order_result.procurement_order_header_id;

                                                                var treatment_planned_action_required_product = new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct();
                                                                treatment_planned_action_required_product.BoundTo_HealthcareProcurementOrderPosition_RefID = procurement_order_id;
                                                                treatment_planned_action_required_product.Modification_Timestamp = DateTime.Now;
                                                                treatment_planned_action_required_product.PlannedAction_PotentialProcedure_RefID = drug_order_ids.HEC_ACT_PlannedAction_PotentialProcedureID;
                                                                treatment_planned_action_required_product.Tenant_RefID = securityTicket.TenantID;
                                                                treatment_planned_action_required_product.HealthcareProduct_RefID = Parameter.drug_id;

                                                                treatment_planned_action_required_product.Save(Connection, Transaction);
                                                            }
                                                            #endregion
                                                        }
                                                        else
                                                        {
                                                            previous_status = "MO" + drug_order_status_latest.Status_Code;

                                                            #region EDIT EXISTING ORDER DELIVERY DATE
                                                            if (ord_procurement_order_position != null)
                                                            {
                                                                ord_procurement_order_position.IsProFormaOrderPosition = Parameter.is_label_only;

                                                                var edit_ord_drug_order_position_history_entry = new ORM_ORD_PRC_ProcurementOrder_Position_History();
                                                                edit_ord_drug_order_position_history_entry.Tenant_RefID = securityTicket.TenantID;
                                                                edit_ord_drug_order_position_history_entry.ProcurementOrder_Position_RefID = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID;
                                                                edit_ord_drug_order_position_history_entry.IsModified = true;
                                                                edit_ord_drug_order_position_history_entry.Modification_Timestamp = DateTime.Now;

                                                                edit_ord_drug_order_position_history_entry.Save(Connection, Transaction);

                                                                ord_procurement_order_position.Save(Connection, Transaction);
                                                            }
                                                            #endregion
                                                        }
                                                    }
                                                    #endregion
                                                }
                                                break;
                                            // MO3 status
                                            case 3:
                                                if (patient_changed)
                                                {
                                                    #region CANCEL PREVIOUS ORDER
                                                    previous_status = cls_Cancel_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1250()
                                                    {
                                                        all_languagesL = all_languages,
                                                        created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                        ord_drug_order_header = ord_drug_order_header,
                                                        procurement_order_position_id = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID,
                                                        case_id = Parameter.case_id
                                                    }, securityTicket).Result.previous_status;
                                                    is_order_cancelled = true;
                                                    #endregion

                                                    #region CREATE NEW ORDER
                                                    if (Parameter.is_orders_drug)
                                                    {
                                                        is_drug_reordered = true;
                                                        potential_procedure_required_product.IsDeleted = true;
                                                        potential_procedure_required_product.Save(Connection, Transaction);

                                                        cancelled_order_id = drug_order_ids.ORD_PRC_ProcurementOrder_HeaderID;
                                                        cancelled_order_drug_id = drug_order_settings.drug_id;

                                                        var drug_order_result = cls_Create_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1202()
                                                        {
                                                            all_languagesL = all_languages,
                                                            alternative_delivery_date_from = Parameter.alternative_delivery_date_from,
                                                            alternative_delivery_date_to = Parameter.alternative_delivery_date_to,
                                                            case_id = Parameter.case_id,
                                                            created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                            delivery_date = Parameter.delivery_date,
                                                            drug_id = Parameter.drug_id,
                                                            is_alternative_delivery_date = Parameter.is_alternative_delivery_date,
                                                            is_label_only = Parameter.is_label_only,
                                                            is_patient_fee_waived = Parameter.is_patient_fee_waived,
                                                            is_send_invoice_to_practice = Parameter.is_send_invoice_to_practice,
                                                            patient_details = patient_details,
                                                            patient_id = Parameter.patient_id,
                                                            practice_id = Parameter.practice_id,
                                                            treatment_date = Parameter.treatment_date,
                                                            treatment_doctor_details = treatment_doctor_details,
                                                            treatment_doctor_id = Parameter.treatment_doctor_id,
                                                            order_comment = Parameter.order_comment
                                                        }, securityTicket).Result;

                                                        orderHeaderID = drug_order_result.procurement_order_header_id;

                                                        procurement_order_id = drug_order_result.procurement_order_position_id;
                                                        drug_order_header_id = drug_order_result.procurement_order_header_id;

                                                        var treatment_planned_action_required_product = new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct();
                                                        treatment_planned_action_required_product.BoundTo_HealthcareProcurementOrderPosition_RefID = procurement_order_id;
                                                        treatment_planned_action_required_product.Modification_Timestamp = DateTime.Now;
                                                        treatment_planned_action_required_product.PlannedAction_PotentialProcedure_RefID = drug_order_ids.HEC_ACT_PlannedAction_PotentialProcedureID;
                                                        treatment_planned_action_required_product.Tenant_RefID = securityTicket.TenantID;
                                                        treatment_planned_action_required_product.HealthcareProduct_RefID = Parameter.drug_id;

                                                        treatment_planned_action_required_product.Save(Connection, Transaction);
                                                    }
                                                    #endregion
                                                }
                                                break;
                                            // MO4 status
                                            case 4:
                                                if (drug_order_settings != null)
                                                {
                                                    #region CANCEL PREVIOUS, CREATE NEW ORDER
                                                    if (Parameter.is_orders_drug)
                                                    {
                                                        #region CANCEL PREVIOUS ORDER
                                                        previous_status = cls_Cancel_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1250()
                                                        {
                                                            all_languagesL = all_languages,
                                                            created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                            ord_drug_order_header = ord_drug_order_header,
                                                            procurement_order_position_id = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID,
                                                            case_id = Parameter.case_id
                                                        }, securityTicket).Result.previous_status;
                                                        is_order_cancelled = true;
                                                        #endregion

                                                        is_drug_reordered = true;

                                                        potential_procedure_required_product.IsDeleted = true;
                                                        potential_procedure_required_product.Save(Connection, Transaction);

                                                        cancelled_order_id = drug_order_ids.ORD_PRC_ProcurementOrder_HeaderID;
                                                        cancelled_order_drug_id = drug_order_settings.drug_id;

                                                        var drug_order_result = cls_Create_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1202()
                                                        {
                                                            all_languagesL = all_languages,
                                                            alternative_delivery_date_from = Parameter.alternative_delivery_date_from,
                                                            alternative_delivery_date_to = Parameter.alternative_delivery_date_to,
                                                            case_id = Parameter.case_id,
                                                            created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                            delivery_date = Parameter.delivery_date,
                                                            drug_id = Parameter.drug_id,
                                                            is_alternative_delivery_date = Parameter.is_alternative_delivery_date,
                                                            is_label_only = Parameter.is_label_only,
                                                            is_patient_fee_waived = Parameter.is_patient_fee_waived,
                                                            is_send_invoice_to_practice = Parameter.is_send_invoice_to_practice,
                                                            patient_details = patient_details,
                                                            patient_id = Parameter.patient_id,
                                                            practice_id = Parameter.practice_id,
                                                            treatment_date = Parameter.treatment_date,
                                                            treatment_doctor_details = treatment_doctor_details,
                                                            treatment_doctor_id = Parameter.treatment_doctor_id,
                                                            order_comment = Parameter.order_comment
                                                        }, securityTicket).Result;

                                                        orderHeaderID = drug_order_result.procurement_order_header_id;

                                                        procurement_order_id = drug_order_result.procurement_order_position_id;
                                                        drug_order_header_id = drug_order_result.procurement_order_header_id;

                                                        ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct treatment_planned_action_required_product = new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct();
                                                        treatment_planned_action_required_product.BoundTo_HealthcareProcurementOrderPosition_RefID = procurement_order_id;
                                                        treatment_planned_action_required_product.Modification_Timestamp = DateTime.Now;
                                                        treatment_planned_action_required_product.PlannedAction_PotentialProcedure_RefID = drug_order_ids.HEC_ACT_PlannedAction_PotentialProcedureID;
                                                        treatment_planned_action_required_product.Tenant_RefID = securityTicket.TenantID;
                                                        treatment_planned_action_required_product.HealthcareProduct_RefID = Parameter.drug_id;

                                                        treatment_planned_action_required_product.Save(Connection, Transaction);
                                                    }
                                                    else
                                                    {
                                                        #region CANCEL PREVIOUS ORDER
                                                        previous_status = cls_Cancel_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1250()
                                                        {
                                                            all_languagesL = all_languages,
                                                            created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                            ord_drug_order_header = ord_drug_order_header,
                                                            procurement_order_position_id = ord_procurement_order_position.ORD_PRC_ProcurementOrder_PositionID,
                                                            case_id = Parameter.case_id
                                                        }, securityTicket).Result.previous_status;
                                                        is_order_cancelled = true;
                                                        #endregion
                                                    }

                                                    #endregion
                                                }

                                                break;
                                            // MO6 status
                                            case 6:
                                            case 7:
                                                #region ADD NEW ORDER
                                                if (Parameter.is_orders_drug)
                                                {
                                                    if (potential_procedure_required_product != null)
                                                    {
                                                        potential_procedure_required_product.IsDeleted = true;
                                                        potential_procedure_required_product.Save(Connection, Transaction);
                                                    }

                                                    cancelled_order_id = drug_order_ids.ORD_PRC_ProcurementOrder_HeaderID;
                                                    cancelled_order_drug_id = drug_order_settings.drug_id;

                                                    var drug_order_result = cls_Create_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1202()
                                                    {
                                                        all_languagesL = all_languages,
                                                        alternative_delivery_date_from = Parameter.alternative_delivery_date_from,
                                                        alternative_delivery_date_to = Parameter.alternative_delivery_date_to,
                                                        case_id = Parameter.case_id,
                                                        created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                                        delivery_date = Parameter.delivery_date,
                                                        drug_id = Parameter.drug_id,
                                                        is_alternative_delivery_date = Parameter.is_alternative_delivery_date,
                                                        is_label_only = Parameter.is_label_only,
                                                        is_patient_fee_waived = Parameter.is_patient_fee_waived,
                                                        is_send_invoice_to_practice = Parameter.is_send_invoice_to_practice,
                                                        patient_details = patient_details,
                                                        patient_id = Parameter.patient_id,
                                                        practice_id = Parameter.practice_id,
                                                        treatment_date = Parameter.treatment_date,
                                                        treatment_doctor_details = treatment_doctor_details,
                                                        treatment_doctor_id = Parameter.treatment_doctor_id,
                                                        order_comment = Parameter.order_comment
                                                    }, securityTicket).Result;

                                                    orderHeaderID = drug_order_result.procurement_order_header_id;

                                                    procurement_order_id = drug_order_result.procurement_order_position_id;
                                                    drug_order_header_id = drug_order_result.procurement_order_header_id;

                                                    ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct treatment_planned_action_required_product = new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct();
                                                    treatment_planned_action_required_product.BoundTo_HealthcareProcurementOrderPosition_RefID = procurement_order_id;
                                                    treatment_planned_action_required_product.Modification_Timestamp = DateTime.Now;
                                                    treatment_planned_action_required_product.PlannedAction_PotentialProcedure_RefID = drug_order_ids.HEC_ACT_PlannedAction_PotentialProcedureID;
                                                    treatment_planned_action_required_product.Tenant_RefID = securityTicket.TenantID;
                                                    treatment_planned_action_required_product.HealthcareProduct_RefID = Parameter.drug_id;

                                                    treatment_planned_action_required_product.Save(Connection, Transaction);
                                                }
                                                #endregion
                                                break;
                                        }
                                        if (Parameter.is_quick_order && orderHeaderID != Guid.Empty)
                                        {
                                            ordersForSubmit.Add(orderHeaderID);
                                            orderHeaderID = Guid.Empty;
                                        }
                                        #endregion
                                    }
                                }
                            }
                            else
                            {
                                if (Parameter.is_orders_drug)
                                {
                                    #region CREATE NEW ORDER
                                    var drug_order_result = cls_Create_Drug_Order.Invoke(Connection, Transaction, new P_CAS_CDO_1202()
                                    {
                                        all_languagesL = all_languages,
                                        alternative_delivery_date_from = Parameter.alternative_delivery_date_from,
                                        alternative_delivery_date_to = Parameter.alternative_delivery_date_to,
                                        case_id = Parameter.case_id,
                                        created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                                        delivery_date = Parameter.delivery_date,
                                        drug_id = Parameter.drug_id,
                                        is_alternative_delivery_date = Parameter.is_alternative_delivery_date,
                                        is_label_only = Parameter.is_label_only,
                                        is_patient_fee_waived = Parameter.is_patient_fee_waived,
                                        is_send_invoice_to_practice = Parameter.is_send_invoice_to_practice,
                                        patient_details = patient_details,
                                        patient_id = Parameter.patient_id,
                                        practice_id = Parameter.practice_id,
                                        treatment_date = Parameter.treatment_date,
                                        treatment_doctor_details = treatment_doctor_details,
                                        treatment_doctor_id = Parameter.treatment_doctor_id,
                                        order_comment = Parameter.order_comment
                                    }, securityTicket).Result;

                                    procurement_order_id = drug_order_result.procurement_order_position_id;
                                    drug_order_header_id = drug_order_result.procurement_order_header_id;

                                    var treatment_planned_action_potential_procedure = cls_Get_Treatment_Planned_Action_PotentialProcedureID_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAPPIDfCID_1247() { CaseID = Parameter.case_id }, securityTicket).Result;
                                    if (treatment_planned_action_potential_procedure != null)
                                    {
                                        var existing_planned_action_potential_procedure_required_product = ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query()
                                        {
                                            IsDeleted = false,
                                            Tenant_RefID = securityTicket.TenantID,
                                            PlannedAction_PotentialProcedure_RefID = treatment_planned_action_potential_procedure.potential_procedure_id
                                        }).SingleOrDefault();

                                        if (existing_planned_action_potential_procedure_required_product != null)
                                        {
                                            existing_planned_action_potential_procedure_required_product.IsDeleted = true;
                                            existing_planned_action_potential_procedure_required_product.Modification_Timestamp = DateTime.Now;

                                            existing_planned_action_potential_procedure_required_product.Save(Connection, Transaction);
                                        }

                                        ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct new_treatment_planned_action_potential_procedure_required_product = new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct();
                                        new_treatment_planned_action_potential_procedure_required_product.BoundTo_HealthcareProcurementOrderPosition_RefID = procurement_order_id;
                                        new_treatment_planned_action_potential_procedure_required_product.HealthcareProduct_RefID = Parameter.drug_id;
                                        new_treatment_planned_action_potential_procedure_required_product.Modification_Timestamp = DateTime.Now;
                                        new_treatment_planned_action_potential_procedure_required_product.PlannedAction_PotentialProcedure_RefID = treatment_planned_action_potential_procedure.potential_procedure_id;
                                        new_treatment_planned_action_potential_procedure_required_product.Tenant_RefID = securityTicket.TenantID;

                                        new_treatment_planned_action_potential_procedure_required_product.Save(Connection, Transaction);

                                        if (Parameter.is_quick_order)
                                        {
                                            ordersForSubmit.Add(drug_order_result.procurement_order_header_id);
                                        }
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }

                        if (treatment_planned_action != null)
                        {
                            is_treatment_date_changed = treatment_planned_action.PlannedFor_Date != Parameter.treatment_date;

                            #region EDIT TREATMENT
                            if (Parameter.treatment_doctor_id != Guid.Empty)
                            {
                                var doctor_account_id = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.treatment_doctor_id }, securityTicket).Result.accountID;

                                ORM_USR_Account.Query doctor_accountQ = new ORM_USR_Account.Query();
                                doctor_accountQ.USR_AccountID = doctor_account_id;
                                doctor_accountQ.Tenant_RefID = securityTicket.TenantID;
                                doctor_accountQ.IsDeleted = false;

                                var doctor_account = ORM_USR_Account.Query.Search(Connection, Transaction, doctor_accountQ).SingleOrDefault();
                                if (doctor_account != null)
                                {
                                    is_op_doctor_changed = treatment_planned_action.ToBePerformedBy_BusinessParticipant_RefID != doctor_account.BusinessParticipant_RefID;
                                    treatment_planned_action.ToBePerformedBy_BusinessParticipant_RefID = doctor_account.BusinessParticipant_RefID;
                                }
                            }
                            else
                            {
                                treatment_planned_action.ToBePerformedBy_BusinessParticipant_RefID = Guid.Empty;
                            }

                            treatment_planned_action.PlannedFor_Date = Parameter.treatment_date;
                            treatment_planned_action.Patient_RefID = Parameter.patient_id;
                            treatment_planned_action.Modification_Timestamp = DateTime.Now;

                            treatment_planned_action.Save(Connection, Transaction);



                            var diagnosis_ids = cls_Get_Planned_Action_DiagnosisIDs_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GPADIDsfPAID_1041() { PlannedActionID = treatment_planned_action.HEC_ACT_PlannedActionID }, securityTicket).Result;
                            if (diagnosis_ids != null)
                            {
                                #region UPDATE CURRENT DIAGNOSE
                                var patient_diagnosis = new ORM_HEC_Patient_Diagnosis();
                                patient_diagnosis.R_PotentialDiagnosis_RefID = Parameter.diagnose_id;
                                patient_diagnosis.Patient_RefID = Parameter.patient_id;
                                patient_diagnosis.R_IsConfirmed = Parameter.is_confirmed;
                                patient_diagnosis.Modification_Timestamp = DateTime.Now;

                                patient_diagnosis.Save(Connection, Transaction);

                                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query performed_action_diagnosis_updateQ = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query();
                                performed_action_diagnosis_updateQ.HEC_ACT_PerformedAction_DiagnosisUpdateID = diagnosis_ids.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                                performed_action_diagnosis_updateQ.Tenant_RefID = securityTicket.TenantID;
                                performed_action_diagnosis_updateQ.IsDeleted = false;

                                var performed_action_diagnosis_update = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query.Search(Connection, Transaction, performed_action_diagnosis_updateQ).SingleOrDefault();
                                if (performed_action_diagnosis_update != null)
                                {
                                    is_diagnose_changed = performed_action_diagnosis_update.PotentialDiagnosis_RefID != Parameter.diagnose_id;

                                    if (Parameter.diagnose_id == Guid.Empty)
                                    {
                                        performed_action_diagnosis_update.IsDeleted = true;
                                        performed_action_diagnosis_update.Modification_Timestamp = DateTime.Now;
                                    }
                                    else
                                    {
                                        performed_action_diagnosis_update.PotentialDiagnosis_RefID = Parameter.diagnose_id;
                                        performed_action_diagnosis_update.IsDiagnosisConfirmed = Parameter.is_confirmed;
                                        performed_action_diagnosis_update.HEC_Patient_Diagnosis_RefID = patient_diagnosis.HEC_Patient_DiagnosisID;
                                        performed_action_diagnosis_update.IM_PotentialDiagnosis_Code = diagnose_details.diagnose_icd_10;
                                        performed_action_diagnosis_update.IM_PotentialDiagnosis_Name = diagnose_details.diagnose_name;
                                        performed_action_diagnosis_update.IM_PotentialDiagnosisCatalog_Name = diagnose_details.catalog_display_name;
                                    }
                                    performed_action_diagnosis_update.Save(Connection, Transaction);
                                }

                                ORM_HEC_DIA_Diagnosis_Localization.Query diagnosis_localizationQ = new ORM_HEC_DIA_Diagnosis_Localization.Query();
                                diagnosis_localizationQ.Tenant_RefID = securityTicket.TenantID;
                                diagnosis_localizationQ.IsDeleted = false;
                                diagnosis_localizationQ.HEC_DIA_Diagnosis_LocalizationID = diagnosis_ids.HEC_DIA_Diagnosis_Localization_RefID;

                                var diagnosis_localization = ORM_HEC_DIA_Diagnosis_Localization.Query.Search(Connection, Transaction, diagnosis_localizationQ).SingleOrDefault();
                                if (diagnosis_localization != null)
                                {
                                    is_localization_changed = diagnosis_localization.LocalizationCode.Equals("L") != Parameter.is_left_eye;

                                    if (Parameter.diagnose_id == Guid.Empty)
                                    {
                                        diagnosis_localization.IsDeleted = true;
                                        diagnosis_localization.Modification_Timestamp = DateTime.Now;
                                    }
                                    else
                                    {
                                        diagnosis_localization.Diagnosis_RefID = Parameter.diagnose_id;
                                        diagnosis_localization.LocalizationCode = Parameter.is_left_eye ? "L" : "R";
                                        diagnosis_localization.Modification_Timestamp = DateTime.Now;
                                    }
                                    diagnosis_localization.Save(Connection, Transaction);
                                }

                                ORM_HEC_Patient_Diagnosis_Localization patient_diagnosis_localization = new ORM_HEC_Patient_Diagnosis_Localization();
                                patient_diagnosis_localization.DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                                patient_diagnosis_localization.Patient_Diagnosis_RefID = patient_diagnosis.HEC_Patient_DiagnosisID;
                                patient_diagnosis_localization.Tenant_RefID = securityTicket.TenantID;
                                patient_diagnosis_localization.IsDeleted = Parameter.diagnose_id == Guid.Empty;
                                patient_diagnosis_localization.Modification_Timestamp = DateTime.Now;

                                patient_diagnosis_localization.Save(Connection, Transaction);

                                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query performed_action_diagnosis_update_localizationQ = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query();
                                performed_action_diagnosis_update_localizationQ.Tenant_RefID = securityTicket.TenantID;
                                performed_action_diagnosis_update_localizationQ.IsDeleted = false;
                                performed_action_diagnosis_update_localizationQ.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = diagnosis_ids.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID;

                                var performed_action_diagnosis_update_localization = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query.Search(Connection, Transaction, performed_action_diagnosis_update_localizationQ).SingleOrDefault();
                                if (performed_action_diagnosis_update_localization != null)
                                {
                                    if (Parameter.diagnose_id == Guid.Empty)
                                    {
                                        performed_action_diagnosis_update_localization.IsDeleted = true;
                                        performed_action_diagnosis_update_localization.Modification_Timestamp = DateTime.Now;
                                    }
                                    else
                                    {
                                        performed_action_diagnosis_update_localization.IM_PotentialDiagnosisLocalization_Code = Parameter.is_left_eye ? "L" : "R";
                                        performed_action_diagnosis_update_localization.IM_PotentialDiagnosisLocalization_Name = Parameter.is_left_eye ? "Left eye" : "Right eye";
                                    }
                                    performed_action_diagnosis_update_localization.Save(Connection, Transaction);
                                }
                                #endregion UPDATE CURRENT DIAGNOSE
                            }
                            else
                            {
                                #region NEW TREATMENT PLANNED ACTION
                                cls_Create_Treatment_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CTPA_1225()
                                {
                                    all_languagesL = all_languages,
                                    case_id = Parameter.case_id,
                                    diagnose_id = Parameter.diagnose_id,
                                    initial_performed_action_id = initial_performed_action_id,
                                    drug_id = Parameter.drug_id,
                                    intraocular_procedure_id = intraocular_procedure_id,
                                    is_confirmed = Parameter.is_confirmed,
                                    is_left_eye = Parameter.is_left_eye,
                                    patient_id = Parameter.patient_id,
                                    practice_id = Parameter.practice_id,
                                    procurement_order_id = procurement_order_id,
                                    treatment_date = Parameter.treatment_date,
                                    treatment_doctor_id = Parameter.treatment_doctor_id,
                                    treatment_planned_action_id = treatment_planned_action.HEC_ACT_PlannedActionID
                                }, securityTicket);
                                #endregion TREATMENT PLANNED ACTION
                            }

                            if (treatment_planned_action.IsPerformed)
                            {
                                //orm_hec_act
                                var treatment_performed_action = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction.Query()
                                {
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false,
                                    HEC_ACT_PerformedActionID = treatment_planned_action.IfPerformed_PerformedAction_RefID
                                }).SingleOrDefault();

                                if (treatment_performed_action != null)
                                {
                                    treatment_performed_action.Modification_Timestamp = DateTime.Now;
                                    treatment_performed_action.IfPerfomed_DateOfAction = Parameter.treatment_date;
                                    treatment_performed_action.IfPerformed_DateOfAction_Day = Parameter.treatment_date.Day;
                                    treatment_performed_action.IfPerformed_DateOfAction_Month = Parameter.treatment_date.Month;
                                    treatment_performed_action.IfPerformed_DateOfAction_Year = Parameter.treatment_date.Year;

                                    treatment_performed_action.Save(Connection, Transaction);
                                }
                            }

                            #endregion EDIT TREATMENT
                        }
                        else
                        {
                            if (Parameter.diagnose_id != Guid.Empty)
                            {
                                #region NEW TREATMENT PLANNED ACTION
                                cls_Create_Treatment_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CTPA_1225()
                                {
                                    all_languagesL = all_languages,
                                    case_id = Parameter.case_id,
                                    diagnose_id = Parameter.diagnose_id,
                                    initial_performed_action_id = initial_performed_action_id,
                                    drug_id = Parameter.drug_id,
                                    intraocular_procedure_id = intraocular_procedure_id,
                                    is_confirmed = Parameter.is_confirmed,
                                    is_left_eye = Parameter.is_left_eye,
                                    patient_id = Parameter.patient_id,
                                    practice_id = Parameter.practice_id,
                                    procurement_order_id = procurement_order_id,
                                    treatment_date = Parameter.treatment_date,
                                    treatment_doctor_id = Parameter.treatment_doctor_id
                                }, securityTicket);
                                #endregion TREATMENT PLANNED ACTION
                            }
                        }

                        var aftercare_planned_action_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959()
                        {
                            CaseID = Parameter.case_id,
                            IsPerformed = true
                        }, securityTicket).Result;
                        if (aftercare_planned_action_id != null)
                        {
                            var case_aftercare_planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                            case_aftercare_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                            case_aftercare_planned_actionQ.HEC_ACT_PlannedActionID = aftercare_planned_action_id.planned_action_id;
                            case_aftercare_planned_actionQ.IsDeleted = false;

                            var case_aftercare_planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, case_aftercare_planned_actionQ).SingleOrDefault();
                            if (case_aftercare_planned_action != null)
                            {
                                is_aftercare_submitted = case_aftercare_planned_action.IsPerformed;
                                previous_aftercare_id = case_aftercare_planned_action.HEC_ACT_PlannedActionID;

                                if (Parameter.diagnose_id == Guid.Empty)
                                {
                                    case_aftercare_planned_action.IsCancelled = true;
                                    case_aftercare_planned_action.Save(Connection, Transaction);
                                }
                                else
                                {
                                    Guid id = Guid.Empty;

                                    var aftercare_doctor_account = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.aftercare_doctor_practice_id }, securityTicket).Result;
                                    if (aftercare_doctor_account != null)
                                    {
                                        id = aftercare_doctor_account.accountID;
                                    }
                                    else
                                    {
                                        var aftercare_practice_account = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.aftercare_doctor_practice_id }, securityTicket).Result;
                                        if (aftercare_practice_account != null)
                                        {
                                            id = aftercare_practice_account.accountID;
                                        }
                                    }

                                    var aftercare_accountQ = new ORM_USR_Account.Query();
                                    aftercare_accountQ.USR_AccountID = id;
                                    aftercare_accountQ.Tenant_RefID = securityTicket.TenantID;
                                    aftercare_accountQ.IsDeleted = false;

                                    var aftercare_account = ORM_USR_Account.Query.Search(Connection, Transaction, aftercare_accountQ).SingleOrDefault();
                                    if (aftercare_account != null)
                                    {
                                        if (aftercare_account.BusinessParticipant_RefID != case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID)
                                        {
                                            is_ac_doctor_changed = true;
                                            var is_current_aftercare_practice = false;
                                            var current_aftercare_practice = default(CAS_GPIDfPBPTID_1336);
                                            var current_aftercare_doctor = cls_Get_PracticeID_for_Doctor_BusinessParticipantID.Invoke(
                                                Connection,
                                                Transaction,
                                                new P_CAS_GPIDfDBPTID_1205()
                                                {
                                                    BusinessParticipantID = case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID
                                                },
                                                securityTicket).Result;

                                            if (current_aftercare_doctor == null)
                                            {
                                                current_aftercare_practice = cls_Get_PracticeID_for_Practice_BusinessParticipantID.Invoke(Connection, Transaction, new P_CAS_GPIDfPBPTID_1336() { BusinessParticipantID = case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID }, securityTicket).Result;
                                                is_current_aftercare_practice = true;
                                            }

                                            var new_aftercare_practice_id = aftercare_doctor_details != null ? aftercare_doctor_details.practice_id : aftercare_practice_details.practiceID;
                                            var current_aftercare_practice_id = !is_current_aftercare_practice ? current_aftercare_doctor.practice_id : current_aftercare_practice != null ? current_aftercare_practice.practice_id : Guid.Empty;


                                            if (is_aftercare_submitted)
                                            {
                                                var filtered_fs_statuses = fs_statuses.Where(fs => fs.gpos_type == EGposType.Aftercare.Value());

                                                if (filtered_fs_statuses.Any() && !filtered_fs_statuses.Any(fs => fs.fs_status != 8 && fs.fs_status != 11 && fs.fs_status != 17))
                                                {
                                                    aftercare_sent_to_different_practice = true;

                                                    #region AFTERCARE PLANNED ACTION
                                                    if (Parameter.aftercare_doctor_practice_id != Guid.Empty)
                                                    {
                                                        #region DELETE CURRENT PLANNED ACTION TO CASE
                                                        var current_aftercare_action_2_caseQ = new ORM_HEC_CAS_Case_RelevantPlannedAction.Query();
                                                        current_aftercare_action_2_caseQ.Case_RefID = Parameter.case_id;
                                                        current_aftercare_action_2_caseQ.PlannedAction_RefID = aftercare_planned_action_id.planned_action_id;
                                                        current_aftercare_action_2_caseQ.Tenant_RefID = securityTicket.TenantID;
                                                        current_aftercare_action_2_caseQ.IsDeleted = false;

                                                        var current_aftercare_action_2_case = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, current_aftercare_action_2_caseQ).SingleOrDefault();
                                                        if (current_aftercare_action_2_case != null)
                                                        {
                                                            current_aftercare_action_2_case.IsDeleted = true;
                                                            current_aftercare_action_2_case.Save(Connection, Transaction);
                                                        }
                                                        #endregion

                                                        new_aftercare_id = cls_Create_Aftercare_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CAPA_1237()
                                                        {
                                                            aftercare_doctor_practice_id = Parameter.aftercare_doctor_practice_id,
                                                            all_languagesL = all_languages,
                                                            case_id = Parameter.case_id,
                                                            patient_id = Parameter.patient_id,
                                                            practice_id = Parameter.practice_id,
                                                            treatment_date = Parameter.treatment_date
                                                        }, securityTicket).Result;

                                                        #region ADD NEW BILL POSITION
                                                        cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                                                        {
                                                            ac_doctor_id = Parameter.aftercare_doctor_practice_id,
                                                            all_languagesL = all_languages,
                                                            case_id = Parameter.case_id,
                                                            diagnose_id = Parameter.diagnose_id,
                                                            drug_id = Parameter.drug_id,
                                                            patient_id = Parameter.patient_id,
                                                            treatment_doctor_id = Guid.Empty,
                                                            localization = Parameter.is_left_eye ? "L" : "R",
                                                            treatment_date = treatment_planned_action.PlannedFor_Date
                                                        }, securityTicket);
                                                        #endregion
                                                    }
                                                    #endregion
                                                }
                                            }
                                            else
                                            {
                                                if (new_aftercare_practice_id != current_aftercare_practice_id && current_aftercare_practice_id != Guid.Empty)
                                                {
                                                    aftercare_sent_to_different_practice = true;
                                                    case_aftercare_planned_action.IsCancelled = true;
                                                    case_aftercare_planned_action.Save(Connection, Transaction);

                                                    #region AFTERCARE PLANNED ACTION
                                                    if (Parameter.aftercare_doctor_practice_id != Guid.Empty)
                                                    {
                                                        #region DELETE CURRENT PLANNED ACTION TO CASE
                                                        ORM_HEC_CAS_Case_RelevantPlannedAction.Query current_aftercare_action_2_caseQ = new ORM_HEC_CAS_Case_RelevantPlannedAction.Query();
                                                        current_aftercare_action_2_caseQ.Case_RefID = Parameter.case_id;
                                                        current_aftercare_action_2_caseQ.PlannedAction_RefID = aftercare_planned_action_id.planned_action_id;
                                                        current_aftercare_action_2_caseQ.Tenant_RefID = securityTicket.TenantID;
                                                        current_aftercare_action_2_caseQ.IsDeleted = false;

                                                        var current_aftercare_action_2_case = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, current_aftercare_action_2_caseQ).SingleOrDefault();
                                                        if (current_aftercare_action_2_case != null)
                                                        {
                                                            current_aftercare_action_2_case.IsDeleted = true;
                                                            current_aftercare_action_2_case.Save(Connection, Transaction);
                                                        }
                                                        #endregion

                                                        new_aftercare_id = cls_Create_Aftercare_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CAPA_1237()
                                                        {
                                                            aftercare_doctor_practice_id = Parameter.aftercare_doctor_practice_id,
                                                            all_languagesL = all_languages,
                                                            case_id = Parameter.case_id,
                                                            patient_id = Parameter.patient_id,
                                                            practice_id = Parameter.practice_id,
                                                            treatment_date = Parameter.treatment_date
                                                        }, securityTicket).Result;
                                                    }
                                                    #endregion AFTERCARE PLANNED ACTION
                                                }
                                                else
                                                {
                                                    aftercare_doctor_was_temprary = current_aftercare_practice_id == Guid.Empty;
                                                    case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID = aftercare_account.BusinessParticipant_RefID;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var current_aftercare_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query()
                                        {
                                            IsDeleted = false,
                                            Tenant_RefID = securityTicket.TenantID,
                                            BusinessParticipant_RefID = case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID
                                        }).SingleOrDefault();

                                        if (current_aftercare_doctor != null)
                                        {
                                            if (current_aftercare_doctor.Account_RefID != Guid.Empty)
                                                aftercare_sent_to_different_practice = true;
                                        }
                                        else
                                        {
                                            var practice_customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
                                            {
                                                IsDeleted = false,
                                                Ext_BusinessParticipant_RefID = case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID,
                                                Tenant_RefID = securityTicket.TenantID
                                            }).SingleOrDefault();

                                            aftercare_sent_to_different_practice = practice_customer != null;
                                        }

                                        var temporary_aftercare_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query()
                                        {
                                            HEC_DoctorID = Parameter.aftercare_doctor_practice_id,
                                            Tenant_RefID = securityTicket.TenantID,
                                            IsDeleted = false
                                        }).FirstOrDefault();

                                        if (temporary_aftercare_doctor != null)
                                        {
                                            case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID = temporary_aftercare_doctor.BusinessParticipant_RefID;
                                        }
                                        else
                                        {
                                            case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID = Guid.Empty;
                                        }
                                    }

                                    if (aftercare_account != null && !is_aftercare_submitted && !aftercare_sent_to_different_practice)
                                        case_aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID = aftercare_account.BusinessParticipant_RefID;

                                    case_aftercare_planned_action.Modification_Timestamp = DateTime.Now;
                                    case_aftercare_planned_action.Patient_RefID = Parameter.patient_id;
                                    case_aftercare_planned_action.PlannedFor_Date = is_case_submitted ? Parameter.aftercare_performed_date : Parameter.treatment_date;

                                    case_aftercare_planned_action.Save(Connection, Transaction);

                                    ORM_HEC_ACT_PerformedAction.Query aftercare_performed_actionQ = new ORM_HEC_ACT_PerformedAction.Query();
                                    aftercare_performed_actionQ.HEC_ACT_PerformedActionID = case_aftercare_planned_action.IfPerformed_PerformedAction_RefID;
                                    aftercare_performed_actionQ.IsDeleted = false;
                                    aftercare_performed_actionQ.Tenant_RefID = securityTicket.TenantID;

                                    var aftercare_performed_action = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, aftercare_performed_actionQ).SingleOrDefault();
                                    if (aftercare_performed_action != null && Parameter.aftercare_performed_date != DateTime.MinValue)
                                    {
                                        aftercare_performed_action.IfPerfomed_DateOfAction = Parameter.aftercare_performed_date;
                                        aftercare_performed_action.IfPerformed_DateOfAction_Day = Parameter.aftercare_performed_date.Day;
                                        aftercare_performed_action.IfPerformed_DateOfAction_Month = Parameter.aftercare_performed_date.Month;
                                        aftercare_performed_action.IfPerformed_DateOfAction_Year = Parameter.aftercare_performed_date.Year;
                                        aftercare_performed_action.Modification_Timestamp = DateTime.Now;

                                        aftercare_performed_action.Save(Connection, Transaction);
                                    }
                                }
                            }
                        }
                        else
                        {
                            #region AFTERCARE PLANNED ACTION
                            if (Parameter.aftercare_doctor_practice_id != Guid.Empty)
                            {
                                cls_Create_Aftercare_Planned_Action.Invoke(Connection, Transaction, new P_CAS_CAPA_1237()
                                {
                                    aftercare_doctor_practice_id = Parameter.aftercare_doctor_practice_id,
                                    all_languagesL = all_languages,
                                    case_id = Parameter.case_id,
                                    patient_id = Parameter.patient_id,
                                    practice_id = Parameter.practice_id,
                                    treatment_date = Parameter.treatment_date,
                                }, securityTicket);
                            }
                            #endregion AFTERCARE PLANNED ACTION
                        }

                        #region CHANGE GPOS POSITIONS
                        if ((is_diagnose_changed || is_localization_changed) && is_case_submitted)
                        {
                            cls_Calculate_Case_GPOS.Invoke(Connection, Transaction, new P_CAS_CCGPOS_1000()
                            {
                                should_update = true,
                                case_id = Parameter.case_id,
                                all_languagesL = all_languages,
                                diagnose_id = Parameter.diagnose_id,
                                drug_id = Parameter.drug_id,
                                localization = Parameter.is_left_eye ? "L" : "R",
                                patient_id = Parameter.patient_id,
                                treatment_date = Parameter.treatment_date
                            }, securityTicket);
                        }
                        #endregion
                    }
                }
            }
            #endregion

            #region OCT
            cls_Handle_OCT.Invoke(Connection, Transaction, new P_CAS_HOCT_1013()
            {
                case_id = new_case_id,
                diagnose_id = Parameter.diagnose_id,
                diagnose_name = diagnose_details == null ? "-" : String.Format("{0} ({1}: {2})", diagnose_details.diagnose_name, diagnose_details.catalog_display_name, diagnose_details.diagnose_icd_10),
                drug_id = Parameter.drug_id,
                localization = Parameter.is_left_eye ? "L" : "R",
                oct_doctor_id = Parameter.oct_doctor_id,
                oct_doctor_name = oct_doctor_details != null ? GenericUtils.GetDoctorName(oct_doctor_details) : "-",
                oct_doctor_practice_id = oct_doctor_details != null ? oct_doctor_details.practice_id : Guid.Empty,
                patient_birthdate = patient_details.birthday,
                patient_id = Parameter.patient_id,
                patient_name = String.Format("{0}, {1}", patient_details.patient_last_name, patient_details.patient_first_name),
                treatment_date = Parameter.treatment_date,
                treatment_doctor_id = Parameter.treatment_doctor_id,
                treatment_doctor_name = treatment_doctor_details != null ? GenericUtils.GetDoctorName(treatment_doctor_details) : "-",
                treatment_doctor_practice_id = treatment_doctor_details != null ? treatment_doctor_details.practice_id : Guid.Empty,
                treatment_doctor_practice_name = treatment_doctor_details != null ? treatment_doctor_details.practice : "-",
                withdraw_oct = Parameter.withdraw_oct,
                submit_oct_until_date = Parameter.submit_oct_until_date,
                patient_hip = patient_details.health_insurance_provider,
                localization_changed = is_localization_changed,
                is_documentation = Parameter.is_documentation_only
            }, securityTicket);
            #endregion

            #region DOCUMENTATION ONLY
            var caseProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
            {
                GlobalPropertyMatchingID = ECaseProperty.DocumentationOnly.Value(),
                Tenant_RefID = securityTicket.TenantID,
                IsValue_Boolean = true,
                IsDeleted = false,
                PropertyName = "Is For Documentation Only"
            }).SingleOrDefault();

            if (caseProperty == null)
            {
                caseProperty = new ORM_HEC_CAS_Case_UniversalProperty();
                caseProperty.GlobalPropertyMatchingID = ECaseProperty.DocumentationOnly.Value();
                caseProperty.IsValue_Boolean = true;
                caseProperty.Modification_Timestamp = DateTime.Now;
                caseProperty.PropertyName = "Is For Documentation Only";
                caseProperty.Tenant_RefID = securityTicket.TenantID;

                caseProperty.Save(Connection, Transaction);
            }

            var casePropertyValue = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
            {
                HEC_CAS_Case_RefID = new_case_id,
                HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (casePropertyValue == null)
            {
                casePropertyValue = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                casePropertyValue.HEC_CAS_Case_RefID = new_case_id;
                casePropertyValue.HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID;
                casePropertyValue.Tenant_RefID = securityTicket.TenantID;
            }

            casePropertyValue.Modification_Timestamp = DateTime.Now;
            casePropertyValue.Value_Boolean = Parameter.is_documentation_only;

            casePropertyValue.Save(Connection, Transaction);

            #endregion

            #region SUBMIT ORDERS
            var userInfo = cls_Get_Account_Information_with_PracticeID.Invoke(Connection, Transaction, securityTicket).Result;

            if (ordersForSubmit.Any())
            {
                var practice_address = cls_Get_Practice_Address_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAfPID_0845()
                {
                    PracticeID = Parameter.practice_id
                }, securityTicket).Result;

                var default_pharmacy = cls_Get_Default_Pharmacy_for_Practice.Invoke(Connection, Transaction, new P_PH_GDPfP_1421
                {
                    PracticeID = Parameter.practice_id
                }, securityTicket).Result;

                var deliveryDateFrom = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
                {
                    PracticeID = Parameter.practice_id,
                    PropertyName = "Delivery date from"
                }, securityTicket).Result;

                var deliveryDateTo = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
                {
                    PracticeID = Parameter.practice_id,
                    PropertyName = "Delivery date to"
                }, securityTicket).Result;

                cls_Submit_Order_to_MM.Invoke(Connection, Transaction, new P_OR_SOtMM_1311
                {
                    Order = new Order.Complex.Model.OrderSubmitParameter
                    {
                        city = practice_address.city,
                        comment = String.Empty,
                        default_pharmacy = Guid.Parse(default_pharmacy.DefaultPharmacy),
                        delivery_date = Parameter.delivery_date.ToString("dd.MM.yyyy"),
                        delivery_date_from = deliveryDateFrom == null ? "08:00" : deliveryDateFrom.TextValue,
                        delivery_date_to = deliveryDateTo == null ? "18:00" : deliveryDateTo.TextValue,
                        doctor_id = Parameter.submited_by_doctor_id,
                        number = practice_address.number,
                        order_ids = ordersForSubmit.ToArray(),
                        receiver = practice_address.name,
                        street = practice_address.street,
                        zip = practice_address.zip
                    }
                }, securityTicket);
            }
            #endregion

            #region SUBMIT TREATMENT
            if (Parameter.submit_created_case && Parameter.diagnose_id != Guid.Empty &&
                Parameter.aftercare_doctor_practice_id != Guid.Empty && Parameter.treatment_doctor_id != Guid.Empty)
            {
                var parameter = new P_CAS_SC_1425()
                {
                    case_ids = new Guid[] { new_case_id },
                    is_treatment = true,
                    practice_id = Parameter.practice_id,
                    authorizing_doctor_id = Parameter.submited_by_doctor_id
                };

                cls_Submit_Case.Invoke(Connection, Transaction, parameter, securityTicket);
            }
            #endregion

            #region HANDLE GRACE PERIOD
            if (Parameter.is_quick_order)
            {
                cls_Save_Grace_Period.Invoke(Connection, Transaction, new P_DO_SGP_1655
                {
                    IsDoctor = userInfo.AccountInformation.role == Properties.Settings.Default.OPDocAccountDocApp || userInfo.AccountInformation.role == Properties.Settings.Default.ACDocAccountDocApp
                }, securityTicket);
            }
            #endregion

            #region Last used doctors
            if (Parameter.aftercare_doctor_practice_id != Guid.Empty)
            {
                var aftercare_name = "";
                var ac_practice_id = Guid.Empty;

                if (aftercare_doctor_details != null)
                {
                    ac_practice_id = aftercare_doctor_details.practice_id;
                    aftercare_name = GenericUtils.GetDoctorName(aftercare_doctor_details) + " (" + aftercare_doctor_details.lanr + ")";
                }
                else
                {
                    aftercare_name = aftercare_practice_details.practice_name + " (" + aftercare_practice_details.practice_BSNR + ")";
                    ac_practice_id = aftercare_practice_details.practiceID;
                }

                var last_used_practices_doctors = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket);
                if (last_used_practices_doctors.Count != 0)
                {
                    last_used_practices_doctors = last_used_practices_doctors.OrderBy(l => l.date_of_use).ToList();
                    var last_used = last_used_practices_doctors.SingleOrDefault(l => l.id.ToLower().Equals(Parameter.aftercare_doctor_practice_id.ToString().ToLower()));
                    if (last_used != null)
                    {
                        last_used.date_of_use = DateTime.Now;
                    }
                    else
                    {
                        var practice_last_used_model = new Practice_Doctor_Last_Used_Model();
                        practice_last_used_model.id = Parameter.aftercare_doctor_practice_id.ToString();
                        practice_last_used_model.display_name = aftercare_name;
                        practice_last_used_model.date_of_use = DateTime.Now;
                        practice_last_used_model.practice_id = ac_practice_id.ToString();

                        last_used_practices_doctors.Add(practice_last_used_model);
                    }
                }
                else
                {
                    var practice_last_used_model = new Practice_Doctor_Last_Used_Model();
                    practice_last_used_model.id = Parameter.aftercare_doctor_practice_id.ToString();
                    practice_last_used_model.display_name = aftercare_name;
                    practice_last_used_model.date_of_use = DateTime.Now;
                    practice_last_used_model.practice_id = ac_practice_id.ToString();

                    last_used_practices_doctors.Add(practice_last_used_model);
                }

                Add_New_Practice_Last_Used.Import_Practice_Last_Used_Data_to_ElasticDB(last_used_practices_doctors, securityTicket.TenantID.ToString(), securityTicket.AccountID.ToString());

                last_used_practices_doctors = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket);

                if (last_used_practices_doctors.Count > 3)
                {
                    var id_to_delete = last_used_practices_doctors.OrderBy(pd => pd.date_of_use).First().id;
                    Add_New_Practice_Last_Used.Delete_Practice_Last_Used(securityTicket.TenantID.ToString(), "user_" + securityTicket.AccountID.ToString(), id_to_delete);
                }
            }


            if (Parameter.oct_doctor_id != Guid.Empty)
            {
                var elastic_type = "user_oct_";
                var last_used_practices_doctors_oct = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket, elastic_type);
                if (last_used_practices_doctors_oct.Count != 0)
                {
                    last_used_practices_doctors_oct = last_used_practices_doctors_oct.OrderBy(l => l.date_of_use).ToList();
                    var last_used = last_used_practices_doctors_oct.SingleOrDefault(l => l.id.ToLower() == Parameter.oct_doctor_id.ToString().ToLower());
                    if (last_used != null)
                    {
                        last_used.date_of_use = DateTime.Now;
                    }
                    else
                    {
                        var practice_last_used_model = new Practice_Doctor_Last_Used_Model();
                        practice_last_used_model.id = Parameter.oct_doctor_id.ToString();
                        practice_last_used_model.display_name = GenericUtils.GetDoctorName(oct_doctor_details);
                        practice_last_used_model.date_of_use = DateTime.Now;
                        practice_last_used_model.practice_id = oct_doctor_details.practice_id.ToString();

                        last_used_practices_doctors_oct.Add(practice_last_used_model);
                    }
                }
                else
                {
                    var practice_last_used_model = new Practice_Doctor_Last_Used_Model();
                    practice_last_used_model.id = Parameter.oct_doctor_id.ToString();
                    practice_last_used_model.display_name = GenericUtils.GetDoctorName(oct_doctor_details);
                    practice_last_used_model.date_of_use = DateTime.Now;
                    practice_last_used_model.practice_id = oct_doctor_details.practice_id.ToString();

                    last_used_practices_doctors_oct.Add(practice_last_used_model);
                }

                Add_New_Practice_Last_Used.Import_Practice_Last_Used_Data_to_ElasticDB(last_used_practices_doctors_oct, securityTicket.TenantID.ToString(), securityTicket.AccountID.ToString(), elastic_type);

                last_used_practices_doctors_oct = Get_Practices_and_Doctors.Get_Last_Used_Doctors_Practices(Guid.Empty, securityTicket, elastic_type);

                if (last_used_practices_doctors_oct.Count > 3)
                {
                    var id_to_delete = last_used_practices_doctors_oct.OrderBy(pd => pd.date_of_use).First().id;
                    Add_New_Practice_Last_Used.Delete_Practice_Last_Used(securityTicket.TenantID.ToString(), elastic_type + securityTicket.AccountID.ToString(), id_to_delete);
                }
            }
            #endregion

            returnValue.Result = new_case_id;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SC_1711 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Case", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_SC_1711 for attribute P_CAS_SC_1711
    [DataContract]
    public class P_CAS_SC_1711
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public DateTime treatment_date { get; set; }
        [DataMember]
        public Boolean is_alternative_delivery_date { get; set; }
        [DataMember]
        public DateTime delivery_date { get; set; }
        [DataMember]
        public DateTime alternative_delivery_date_from { get; set; }
        [DataMember]
        public DateTime alternative_delivery_date_to { get; set; }
        [DataMember]
        public Guid drug_id { get; set; }
        [DataMember]
        public Boolean is_orders_drug { get; set; }
        [DataMember]
        public Boolean is_patient_fee_waived { get; set; }
        [DataMember]
        public Boolean is_send_invoice_to_practice { get; set; }
        [DataMember]
        public Boolean is_label_only { get; set; }
        [DataMember]
        public Guid diagnose_id { get; set; }
        [DataMember]
        public Boolean is_left_eye { get; set; }
        [DataMember]
        public Boolean is_confirmed { get; set; }
        [DataMember]
        public Guid treatment_doctor_id { get; set; }
        [DataMember]
        public Guid aftercare_doctor_practice_id { get; set; }
        [DataMember]
        public DateTime min_delivery_date { get; set; }
        [DataMember]
        public DateTime aftercare_performed_date { get; set; }
        [DataMember]
        public Guid planned_action_id { get; set; }
        [DataMember]
        public String order_comment { get; set; }
        [DataMember]
        public Guid oct_doctor_id { get; set; }
        [DataMember]
        public Boolean is_documentation_only { get; set; }
        [DataMember]
        public Boolean withdraw_oct { get; set; }
        [DataMember]
        public DateTime submit_oct_until_date { get; set; }
        [DataMember]
        public Boolean is_quick_order { get; set; }
        [DataMember]
        public Boolean submit_created_case { get; set; }
        [DataMember]
        public Guid submited_by_doctor_id { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Case(,P_CAS_SC_1711 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Case.Invoke(connectionString,P_CAS_SC_1711 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_SC_1711();
parameter.case_id = ...;
parameter.patient_id = ...;
parameter.practice_id = ...;
parameter.treatment_date = ...;
parameter.is_alternative_delivery_date = ...;
parameter.delivery_date = ...;
parameter.alternative_delivery_date_from = ...;
parameter.alternative_delivery_date_to = ...;
parameter.drug_id = ...;
parameter.is_orders_drug = ...;
parameter.is_patient_fee_waived = ...;
parameter.is_send_invoice_to_practice = ...;
parameter.is_label_only = ...;
parameter.diagnose_id = ...;
parameter.is_left_eye = ...;
parameter.is_confirmed = ...;
parameter.treatment_doctor_id = ...;
parameter.aftercare_doctor_practice_id = ...;
parameter.min_delivery_date = ...;
parameter.aftercare_performed_date = ...;
parameter.planned_action_id = ...;
parameter.order_comment = ...;
parameter.oct_doctor_id = ...;
parameter.is_documentation_only = ...;
parameter.withdraw_oct = ...;
parameter.submit_oct_until_date = ...;
parameter.is_quick_order = ...;
parameter.submit_created_case = ...;
parameter.submited_by_doctor_id = ...;

*/
