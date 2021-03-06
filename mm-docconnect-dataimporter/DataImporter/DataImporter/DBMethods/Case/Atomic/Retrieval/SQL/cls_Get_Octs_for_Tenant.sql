
   Select
  hec_act_plannedactions.PlannedFor_Date As TreatmentDate,
  Concat_Ws(' ', cmn_per_personinfo1.Title, cmn_per_personinfo1.FirstName,
  cmn_per_personinfo1.LastName) As OctDoctorName,
  Concat_Ws(' ', cmn_per_personinfo.Title, cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName) As OpDoctorName,
  Concat_Ws(', ', hec_cas_cases.Patient_LastName,
  hec_cas_cases.Patient_FirstName) As PatientName,
  hec_cas_cases.Patient_RefID As PatientID,
  hec_cas_cases.HEC_CAS_CaseID As CaseID,
  hec_act_plannedactions1.HEC_ACT_PlannedActionID As ID,
  hec_act_plannedactions1.IsCancelled,
  hec_act_plannedactions1.IsPerformed,
  hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As Localization,
  hec_dia_potentialdiagnosis_catalogcodes.Code As DiagnoseCode,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As DiagnoseID,
  hec_doctors.HEC_DoctorID As OpDoctorID,
  hec_doctors1.HEC_DoctorID As OctDoctorID,
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As OpPracticeID,
  cmn_bpt_ctm_organizationalunits1.IfMedicalPractise_HEC_MedicalPractice_RefID As OctPracticeID,
  cmn_bpt_businessparticipants2.DisplayName As OpPracticeName,
  hec_cas_cases.Patient_BirthDate As PatientBirthDate,
  hec_act_plannedactions.IsPerformed As IsOpPerformed,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As DrugID
From
  hec_cas_cases Inner Join
  hec_cas_case_relevantperformedactions
    On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_relevantperformedactions.Case_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID
    = @TenantID And cmn_per_personinfo.IsDeleted = 0 Inner Join
  hec_cas_case_relevantplannedactions
    On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_relevantplannedactions.Case_RefID And
    hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantplannedactions.IsDeleted = 0 Inner Join
  hec_act_plannedactions hec_act_plannedactions1
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions1.HEC_ACT_PlannedActionID And
    hec_act_plannedactions1.Tenant_RefID = @TenantID And
    hec_act_plannedactions1.IsDeleted = 0 Inner Join
  hec_act_plannedaction_2_actiontype
    On hec_act_plannedactions1.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
    hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join
  hec_act_actiontype
    On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    hec_act_actiontype.HEC_ACT_ActionTypeID And
    hec_act_actiontype.GlobalPropertyMatchingID =
    'mm.docconect.doc.app.planned.action.oct' And
    hec_act_actiontype.Tenant_RefID = @TenantID And
    hec_act_actiontype.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants1.IsDeleted = 0 Inner Join
  cmn_per_personinfo cmn_per_personinfo1
    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo1.CMN_PER_PersonInfoID And
    cmn_per_personinfo1.Tenant_RefID = @TenantID And
    cmn_per_personinfo1.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID =
    hec_cas_case_relevantperformedactions.PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
  hec_act_performedaction_diagnosisupdate_localizations On
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And 
    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And 
    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
  hec_dia_potentialdiagnoses
    On hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnoses.IsDeleted = 0 Inner Join
  hec_dia_potentialdiagnosis_catalogcodes
    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
    hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID And
    hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 Inner Join
  hec_doctors
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID =
    @TenantID And hec_doctors.IsDeleted = 0 Inner Join
  hec_doctors hec_doctors1
    On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID =
    hec_doctors1.BusinessParticipant_RefID And hec_doctors1.Tenant_RefID =
    @TenantID And hec_doctors1.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunit_staff
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID And
    cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID =
    cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunit_staff cmn_bpt_ctm_organizationalunit_staff1
    On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID =
    cmn_bpt_ctm_organizationalunit_staff1.BusinessParticipant_RefID And
    cmn_bpt_ctm_organizationalunit_staff1.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunit_staff1.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunits cmn_bpt_ctm_organizationalunits1
    On cmn_bpt_ctm_organizationalunit_staff1.OrganizationalUnit_RefID =
    cmn_bpt_ctm_organizationalunits1.CMN_BPT_CTM_OrganizationalUnitID And
    cmn_bpt_ctm_organizationalunits1.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits1.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_customers
    On cmn_bpt_ctm_organizationalunits.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
    cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_customers.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants2
    On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants2.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants2.IsDeleted = 0 Inner Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
    hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID
    And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID = hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And 
    hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And 
    hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0
Where
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_cas_cases.IsDeleted = 0
Order By
  TreatmentDate
	