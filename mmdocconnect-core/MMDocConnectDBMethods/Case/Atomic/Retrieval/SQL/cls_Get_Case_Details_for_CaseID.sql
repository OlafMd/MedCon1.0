
    Select Straight_Join
  hec_cas_cases.Patient_RefID As patient_id,
  hec_cas_cases.HEC_CAS_CaseID As case_id,
  Concat(hec_cas_cases.Patient_FirstName, ' ', hec_cas_cases.Patient_LastName,
  ' (', Date_Format(hec_cas_cases.Patient_BirthDate, '%d.%m.%Y'), ')')
  As patient_display_name,
  hec_act_plannedactions.PlannedFor_Date As treatment_date,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As drug_id,
  hec_prc_procurementorder_positions.IsOrderForPatient_PatientFeeWaived As
  is_patient_fee_waived,
  hec_prc_procurementorder_positions.IfProFormaOrderPosition_PrintLabelOnly As
  is_label_only,
  hec_cas_case_universalpropertyvalue.Value_Boolean As
  is_send_invoice_to_practice,
  hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID As
  order_id,
  ord_prc_procurementorder_positions.RequestedDateOfDelivery_TimeFrame_From As
  alternative_delivery_date_from,
  ord_prc_procurementorder_positions.RequestedDateOfDelivery_TimeFrame_To As
  alternative_delivery_date_to,
  ord_prc_procurementorder_positions.Position_RequestedDateOfDelivery As
  delivery_date,
  hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As
  diagnose_id,
  hec_dia_diagnosis_localizations.LocalizationCode As localization,
  hec_act_performedaction_diagnosisupdates.IsDiagnosisConfirmed As is_confirmed,
  hec_doctors.HEC_DoctorID As op_doctor_id,
  hec_doctors1.HEC_DoctorID As ac_doctor_id,
  cmn_bpt_businessparticipants.IsNaturalPerson As is_aftercare_doctor,
  cmn_bpt_businessparticipants.IsCompany As is_aftercare_practice,
  Concat_Ws(' ', cmn_per_personinfo.Title, cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName) As aftercare_doctor_display_name,
  cmn_universalcontactdetails.CompanyName_Line1 As
  aftercare_practice_display_name,
  ord_prc_procurementorder_statuses.Status_Code As order_status_code,
  cmn_universalcontactdetails.CompanyName_Line1 As
  aftercare_practice_display_name,
  hec_cas_cases.Patient_FirstName,
  hec_cas_cases.Patient_LastName,
  hec_cas_cases.Patient_Gender,
  hec_cas_cases.Patient_Age,
  hec_cas_cases.Patient_BirthDate,
  hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID As
  treatment_doctor_id,
  hec_act_plannedactions.MedicalPractice_RefID As practice_id,
  hec_prc_procurementorder_positions.Modification_Timestamp As
  order_modification_timestamp,
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As
  ac_practice_id,
  hec_act_plannedactions1.HEC_ACT_PlannedActionID As
  aftercare_planned_action_id,
  bil_billposition_transmitionstatuses.TransmitionCode As case_status,
  hec_act_plannedactions.HEC_ACT_PlannedActionID As treatment_planned_action_id,
  cmn_bpt_ctm_organizationalunits1.IfMedicalPractise_HEC_MedicalPractice_RefID
  As aftercare_doctors_practice_id,
  hec_act_performedactions.IfPerfomed_DateOfAction As aftercare_performed_date,
  ord_prc_procurementorder_positions.Position_Comment as order_comment
From
  hec_cas_cases Left Join
  hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_relevantperformedactions.Case_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Left Join
  hec_act_performedaction_2_actiontype
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID
    And hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID And
    hec_act_performedaction_2_actiontype.IsDeleted = 0 Left Join
  hec_act_actiontype
    On hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    hec_act_actiontype.HEC_ACT_ActionTypeID And hec_act_actiontype.Tenant_RefID
    = @TenantID And hec_act_actiontype.IsDeleted = 0 And
    hec_act_actiontype.GlobalPropertyMatchingID =
    'mm.docconect.doc.app.performed.action.initial' Left Join
  hec_act_plannedactions
    On hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 And hec_act_plannedactions.IsCancelled
    = 0 Left Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedaction_potentialprocedures.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID
    And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Left Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID = hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0 Left Join
  hec_prc_procurementorder_positions
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID = hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And hec_prc_procurementorder_positions.IsDeleted = 0 Left Join
  hec_cas_case_universalpropertyvalue On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID And
    hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
    hec_cas_case_universalpropertyvalue.IsDeleted = 0 Left Join
  hec_cas_case_universalproperties
    On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID
    = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
    hec_cas_case_universalproperties.IsValue_Boolean = 1 And
    hec_cas_case_universalproperties.IsDeleted = 0 And
    hec_cas_case_universalproperties.Tenant_RefID = @TenantID Left Join
  ord_prc_procurementorder_positions
    On
    hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And ord_prc_procurementorder_positions.IsDeleted = 0 Left Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
    hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Left Join
  hec_doctors
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID =
    @TenantID And hec_doctors.IsDeleted = 0 Left Join
  hec_cas_case_relevantplannedactions On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_relevantplannedactions.Case_RefID And
    hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantplannedactions.IsDeleted = 0 Left Join
  hec_act_plannedaction_2_actiontype
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
    hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
    hec_act_plannedaction_2_actiontype.IsDeleted = 0 Left Join
  hec_act_actiontype hec_act_actiontype1
    On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    hec_act_actiontype1.HEC_ACT_ActionTypeID And
    hec_act_actiontype1.GlobalPropertyMatchingID =
    'mm.docconect.doc.app.planned.action.aftercare' And
    hec_act_actiontype1.Tenant_RefID = @TenantID And
    hec_act_actiontype1.IsDeleted = 0 Left Join
  hec_act_plannedactions hec_act_plannedactions1
    On hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID =
    hec_act_plannedactions1.HEC_ACT_PlannedActionID And
    hec_act_plannedactions1.Tenant_RefID = @TenantID And
    hec_act_plannedactions1.IsDeleted = 0 And
    hec_act_plannedactions1.IsCancelled = 0 Left Join
  hec_doctors hec_doctors1
    On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID =
    hec_doctors1.BusinessParticipant_RefID And hec_doctors1.Tenant_RefID =
    @TenantID And hec_doctors1.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants
    On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID
    = @TenantID And cmn_per_personinfo.IsDeleted = 0 Left Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And
    cmn_com_companyinfo.Tenant_RefID = @TenantID And
    cmn_com_companyinfo.IsDeleted = 0 Left Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.Tenant_RefID = @TenantID And
    cmn_universalcontactdetails.IsDeleted = 0 Left Join
  hec_act_performedaction_diagnosisupdate_localizations
    On
    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 And hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID Left Join
  hec_dia_diagnosis_localizations
    On
    hec_act_performedaction_diagnosisupdate_localizations.HEC_DIA_Diagnosis_Localization_RefID = hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID And hec_dia_diagnosis_localizations.Tenant_RefID = @TenantID And hec_dia_diagnosis_localizations.IsDeleted = 0 Left Join
  ord_prc_procurementorder_positions ord_prc_procurementorder_positions1
    On
    hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions1.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions1.Tenant_RefID = @TenantID And ord_prc_procurementorder_positions1.IsDeleted = 0 Left Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions1.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    And ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_headers.IsDeleted = 0 Left Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
    ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_statuses.IsDeleted = 0 Left Join
  hec_cas_case_billcodes On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_billcodes.HEC_CAS_Case_RefID Left Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 Left Join
  hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0 Left Join
  bil_billpositions On hec_bil_billpositions.Ext_BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And bil_billpositions.Tenant_RefID =
    @TenantID And bil_billpositions.IsDeleted = 0 Left Join
  cmn_bpt_ctm_customers
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID And
    cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_customers.IsDeleted = 0 Left Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID =
    cmn_bpt_ctm_organizationalunits.Customer_RefID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Left Join
  bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 Left Join
  cmn_bpt_ctm_organizationalunit_staff On hec_doctors1.BusinessParticipant_RefID
    = cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID And
    cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Left Join
  cmn_bpt_ctm_organizationalunits cmn_bpt_ctm_organizationalunits1
    On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID =
    cmn_bpt_ctm_organizationalunits1.CMN_BPT_CTM_OrganizationalUnitID And
    cmn_bpt_ctm_organizationalunits1.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits1.IsDeleted = 0 Left Join
  hec_act_performedactions
    On hec_act_plannedactions1.IfPerformed_PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID And
    hec_act_performedactions.Tenant_RefID = @TenantID And
    hec_act_performedactions.IsDeleted = 0
Where
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_cas_cases.IsDeleted = 0 And
  hec_cas_cases.HEC_CAS_CaseID = @CaseID
Group By
  hec_cas_cases.HEC_CAS_CaseID

	