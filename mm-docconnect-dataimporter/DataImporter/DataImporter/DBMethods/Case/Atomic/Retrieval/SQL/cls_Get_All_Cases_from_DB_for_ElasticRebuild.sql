-- SET @TenantId = '3CC9B86BF340704696977DDB940A51E1';
Select Straight_Join
  hec_act_plannedactions.PlannedFor_Date As treatment_date,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As hec_drug_id,
  cmn_pro_products_de.Content As drug_name,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code,
  Concat(Substring(hec_dia_potentialdiagnoses_de.Content,1,12), ' (',
  hec_dia_potentialdiagnosis_catalogs.Catalog_DisplayName, ': ',
  hec_dia_potentialdiagnosis_catalogcodes.Code, ')') As diagnose_name,
  hec_doctors.DoctorIDNumber As treatment_doctor_lanr,
  Trim(Concat_Ws(' ', Coalesce(cmn_per_personinfo.Title, ''),
  cmn_per_personinfo.FirstName, cmn_per_personinfo.LastName)) As
  treatment_doctor_name,
  hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID As
  aftercare_bpt,
  hec_act_plannedactions.IsCancelled As is_treatment_cancelled,
  hec_act_plannedactions.IsPerformed As is_treatment_performed,
  ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID As
  order_header_id,
  hec_doctors.HEC_DoctorID As treatment_doctor_id,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As
  diagnose_id,
  hec_cas_cases.HEC_CAS_CaseID As case_id,
  hec_cas_cases.Patient_RefID As patient_id,
  ord_prc_procurementorder_positions.Position_RequestedDateOfDelivery As
  order_delivery_date,
  ord_prc_procurementorder_positions.RequestedDateOfDelivery_TimeFrame_From As
  order_delivery_time_from,
  ord_prc_procurementorder_positions.RequestedDateOfDelivery_TimeFrame_To As
  order_delivery_time_to,
  hec_prc_procurementorder_positions.Modification_Timestamp As
  order_modification_timestamp,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
  hec_act_plannedactions.MedicalPractice_RefID As practice_id,
  hec_act_plannedactions1.HEC_ACT_PlannedActionID As
  aftercare_planned_action_id,
  hec_act_plannedactions.HEC_ACT_PlannedActionID As treatment_planned_action_id,
  ord_prc_procurementorder_statuses.Status_Code As order_status,
  hec_cas_cases.CaseNumber As case_number,
  hec_act_plannedactions1.IsCancelled As is_aftercare_cancelled,
  ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID As pharmacy_supplier_id
From
  hec_cas_cases Left Join
  hec_cas_case_relevantperformedactions
    On hec_cas_case_relevantperformedactions.Case_RefID =
    hec_cas_cases.HEC_CAS_CaseID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Left Join
  hec_act_plannedactions
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
    hec_cas_case_relevantperformedactions.PerformedAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Left Join
  hec_act_performedaction_diagnosisupdates
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID Left Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
    hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID
    And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Left Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On
    hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID = hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0 Left Join
  hec_products
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID = hec_products.HEC_ProductID And hec_products.Tenant_RefID = @TenantID And hec_products.IsDeleted = 0 Left Join
  cmn_pro_products
    On hec_products.Ext_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID
    And cmn_pro_products.Tenant_RefID = @TenantID And
    cmn_pro_products.IsDeleted = 0 Left Join
  cmn_pro_products_de
    On cmn_pro_products.Product_Name_DictID = cmn_pro_products_de.DictID And
    cmn_pro_products_de.IsDeleted = 0 Left Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID And hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Left Join
  hec_dia_potentialdiagnoses
    On hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnoses.IsDeleted = 0 Left Join
  hec_dia_potentialdiagnosis_catalogcodes
    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
    hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID And
    hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 Left Join
  hec_dia_potentialdiagnoses_de
    On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID =
    hec_dia_potentialdiagnoses_de.DictID And
    hec_dia_potentialdiagnoses_de.IsDeleted = 0 Left Join
  hec_dia_potentialdiagnosis_catalogs
    On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_Catalog_RefID
    = hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
    And hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID
    = @TenantID And cmn_per_personinfo.IsDeleted = 0 Left Join
  hec_cas_case_relevantplannedactions
    On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_relevantplannedactions.Case_RefID And
    hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantplannedactions.IsDeleted = 0 Left Join
  hec_act_plannedactions hec_act_plannedactions1
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions1.HEC_ACT_PlannedActionID And
    hec_act_plannedactions1.Tenant_RefID = @TenantID Left Join
  hec_prc_procurementorder_positions
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID = hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And hec_prc_procurementorder_positions.IsDeleted = 0 Left Join
  ord_prc_procurementorder_positions
    On
    hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And ord_prc_procurementorder_positions.IsDeleted = 0 Left Join
  hec_doctors
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID =
    @TenantID And hec_doctors.IsDeleted = 0 Left Join
  hec_cas_case_billcodes
    On hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID
  Left Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 Left Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Left Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID =
    ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID And
    ord_prc_procurementorder_headers.IsDeleted = 0 And
    ord_prc_procurementorder_headers.Tenant_RefID = @TenantID Left Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
    ord_prc_procurementorder_statuses.IsDeleted = 0 And
    ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID
Where
  hec_cas_cases.Tenant_RefID = @TenantID
Group By
  hec_cas_cases.HEC_CAS_CaseID
	