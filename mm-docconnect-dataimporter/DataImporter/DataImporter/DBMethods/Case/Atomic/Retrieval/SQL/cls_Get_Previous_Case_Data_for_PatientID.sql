
  Select Straight_Join
            hec_doctors.HEC_DoctorID As treatment_doctor_id,
            hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As
            diagnose_id,
            hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
            hec_doctors1.HEC_DoctorID As aftercare_doctor_id,
            cmn_bpt_businessparticipants.IsNaturalPerson As is_aftercare_doctor,
            Concat(cmn_per_personinfo.Title, ' ', cmn_per_personinfo.FirstName, ' ',
            cmn_per_personinfo.LastName) As aftercare_doctor_display_name,
            cmn_universalcontactdetails.CompanyName_Line1 As
            aftercare_practice_display_name,
            cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As
            aftercare_practice_id,
            hec_act_performedaction_diagnosisupdates.IsDiagnosisConfirmed As
            is_diagnosis_confirmed
      From
        hec_cas_cases Left Join
        hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID =
          hec_cas_case_relevantperformedactions.Case_RefID And
          hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
          hec_cas_case_relevantperformedactions.IsDeleted = 0
           Left Join
        hec_cas_case_relevantplannedactions On hec_cas_cases.HEC_CAS_CaseID =
          hec_cas_case_relevantplannedactions.Case_RefID And
          hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
          hec_cas_case_relevantplannedactions.IsDeleted = 0
           Left Join
        hec_act_plannedactions
          On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
          hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
          hec_act_plannedactions.Tenant_RefID = @TenantID And
          hec_act_plannedactions.IsDeleted = 0
           Left Join
        hec_doctors
          On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
          hec_doctors.BusinessParticipant_RefID And
          hec_doctors.Tenant_RefID = @TenantID And
          hec_doctors.IsDeleted = 0
           Inner Join
        hec_act_performedaction_diagnosisupdates
          On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID =
          hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
          hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
          hec_act_performedaction_diagnosisupdates.IsDeleted = 0    
        Left Join
        hec_act_performedaction_diagnosisupdate_localizations
          On
          hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID = hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And 
          hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
          hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
          Left Join
        hec_dia_diagnosis_localizations
          On
          hec_act_performedaction_diagnosisupdate_localizations.HEC_DIA_Diagnosis_Localization_RefID = hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID And
          hec_dia_diagnosis_localizations.Tenant_RefID = @TenantID And
          hec_dia_diagnosis_localizations.IsDeleted = 0 Left Join
        hec_act_plannedactions hec_act_plannedactions1
          On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
          hec_act_plannedactions1.HEC_ACT_PlannedActionID And
          hec_act_plannedactions1.Tenant_RefID = @TenantID And
          hec_act_plannedactions1.IsDeleted = 0 Left Join
        cmn_bpt_businessparticipants
          On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID =
          cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
          cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
          cmn_bpt_businessparticipants.IsDeleted = 0
          Left Join
        hec_doctors hec_doctors1
          On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
          hec_doctors1.BusinessParticipant_RefID And
          hec_doctors1.Tenant_RefID = @TenantID And
          hec_doctors1.IsDeleted = 0
          Left Join
        cmn_per_personinfo
          On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
          cmn_per_personinfo.CMN_PER_PersonInfoID And
          cmn_per_personinfo.Tenant_RefID = @TenantID And
          cmn_per_personinfo.IsDeleted = 0
           Left Join
        cmn_bpt_ctm_customers
          On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
          cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID And
          cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
          cmn_bpt_ctm_customers.IsDeleted = 0
           Left Join
        cmn_bpt_ctm_organizationalunits
          On cmn_bpt_ctm_organizationalunits.Customer_RefID =
          cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
          cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
          cmn_bpt_ctm_organizationalunits.IsDeleted = 0
           Left Join
        cmn_com_companyinfo
          On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
          cmn_com_companyinfo.CMN_COM_CompanyInfoID And
          cmn_com_companyinfo.Tenant_RefID = @TenantID And
          cmn_com_companyinfo.IsDeleted = 0
           Left Join
        cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
          cmn_universalcontactdetails.CMN_UniversalContactDetailID And
          cmn_universalcontactdetails.Tenant_RefID = @TenantID And
          cmn_universalcontactdetails.IsDeleted = 0
    
      Where
        hec_cas_cases.Patient_RefID = @PatientID And
        hec_cas_cases.Tenant_RefID = @TenantID 
      Order By
        hec_cas_cases.Creation_Timestamp Desc
      Limit 1
	