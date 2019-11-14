
 Select
  hec_cas_case_relevantperformedactions.Case_RefID As case_id,
  hec_act_plannedactions.PlannedFor_Date As date,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As drug_id,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As diagnose_id,
  hec_doctors.HEC_DoctorID As op_doctor_id
From
  hec_act_plannedactions Inner Join
  hec_cas_case_relevantperformedactions
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID = hec_cas_case_relevantperformedactions.PerformedAction_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations
    On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
    hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @Localization And
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
  Inner Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_potentialprocedures.PlannedAction_RefID Inner Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID =
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID Inner Join
  hec_cas_case_billcodes
    On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.Tenant_RefID = @TenantID And
    hec_cas_case_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Inner Join
  bil_billposition_transmitionstatuses
    On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.TransmitionStatusKey = 'treatment' And bil_billposition_transmitionstatuses.TransmitionCode Not In (8, 11, 17) And
    bil_billposition_transmitionstatuses.IsActive = 1 And bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 Inner Join
  hec_doctors
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID = @TenantID And
    hec_doctors.IsDeleted = 0 Left Join
  hec_cas_case_universalpropertyvalue
    On hec_cas_case_relevantperformedactions.Case_RefID = hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID And
    hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = @CasePropertyID And
    hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
    hec_cas_case_universalpropertyvalue.IsDeleted = 0 
Where
  hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalPropertyValueID Is Null And
  hec_act_plannedactions.Patient_RefID = @PatientID And
  hec_act_plannedactions.IsPerformed = 1 And
  hec_act_plannedactions.IsCancelled = 0 And
  hec_act_plannedactions.Tenant_RefID = @TenantID And
  hec_act_plannedactions.IsDeleted = 0
Order By
  date Desc
Limit 1
	