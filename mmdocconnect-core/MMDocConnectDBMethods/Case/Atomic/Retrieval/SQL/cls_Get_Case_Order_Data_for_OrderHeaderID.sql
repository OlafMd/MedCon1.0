
Select
  hec_act_plannedactions.PlannedFor_Date As treatment_date,
  cmn_per_personinfo.FirstName As patient_first_name,
  cmn_per_personinfo.LastName As patient_last_name,
  cmn_per_personinfo.BirthDate As patient_birthdate,
  hec_prc_procurementorder_positions.IsOrderForPatient_PatientFeeWaived As
  patient_fee_waived,
  hec_prc_procurementorder_positions.IfProFormaOrderPosition_PrintLabelOnly As
  label_only,
  ord_prc_procurementorder_positions.Position_Comment As order_comment,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As drug_id,
  hec_cas_case_relevantperformedactions.Case_RefID As case_id,
  hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID Is Not Null As treatment_exist
From
  ord_prc_procurementorder_positions Inner Join
  hec_prc_procurementorder_positions
    On ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID =
    hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And hec_prc_procurementorder_positions.IsDeleted = 0 Inner Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID =
    hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0 Inner Join
  hec_act_plannedaction_potentialprocedures
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID = hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_act_plannedaction_potentialprocedures.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Inner Join
  hec_patients
    On hec_act_plannedactions.Patient_RefID = hec_patients.HEC_PatientID And
    hec_patients.Tenant_RefID = @TenantID And hec_patients.IsDeleted = 0
  Inner Join
  cmn_bpt_businessparticipants
    On hec_patients.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID
    = @TenantID And cmn_per_personinfo.IsDeleted = 0 Inner Join
  hec_cas_case_relevantperformedactions
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
    hec_cas_case_relevantperformedactions.PerformedAction_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Left Join
  hec_act_performedaction_diagnosisupdates
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID
Where
  ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
  @OrderHeaderID And
  ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
  ord_prc_procurementorder_positions.IsDeleted = 0
	