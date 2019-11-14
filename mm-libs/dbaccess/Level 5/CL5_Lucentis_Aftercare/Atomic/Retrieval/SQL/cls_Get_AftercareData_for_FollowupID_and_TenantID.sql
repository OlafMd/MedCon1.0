
Select
  followup.HEC_Patient_TreatmentID As FollowupID,
  followup.IfTreatmentFollowup_FromTreatment_RefID As TreatmentID,
  cmn_per_personinfo.FirstName As PatientFirstName,
  cmn_per_personinfo.LastName As PatientLastName,
   Case 
    WHEN (hec_patient_treatment.IsTreatmentPerformed=0 AND hec_patient_treatment.IsTreatmentBilled =0 AND hec_patient_treatment.IsScheduled=1 ) THEN hec_patient_treatment.IfSheduled_Date 
    WHEN (hec_patient_treatment.IsTreatmentPerformed=1 AND hec_patient_treatment.IsTreatmentBilled =0 ) THEN hec_patient_treatment.IfTreatmentPerformed_Date
    WHEN ( hec_patient_treatment.IsTreatmentBilled =1 ) THEN hec_patient_treatment.IfTreatmentBilled_Date
  END as TreatmentDate,
  cmn_bpt_businessparticipants1.DisplayName As HealthInsurance
From
  hec_patient_treatment followup Inner Join
  hec_patient_treatment On followup.IfTreatmentFollowup_FromTreatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    hec_patient_treatment.IsTreatmentFollowup = 0 And
    hec_patient_treatment.IsDeleted = 0 And hec_patient_treatment.Tenant_RefID =
    @TenantID Inner Join
  hec_patient_2_patienttreatment
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID And
    hec_patient_2_patienttreatment.IsDeleted = 0 And
    hec_patient_2_patienttreatment.Tenant_RefID = @TenantID Inner Join
  hec_patients On hec_patient_2_patienttreatment.HEC_Patient_RefID =
    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
  hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID And hec_patient_healthinsurances.IsDeleted = 0
    And hec_patient_healthinsurances.Tenant_RefID = @TenantID Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
    hec_his_healthinsurance_companies.IsDeleted = 0 And
    hec_his_healthinsurance_companies.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
  cmn_bpt_businessparticipants1.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants1.IsNaturalPerson = 0 And
  cmn_bpt_businessparticipants1.IsCompany = 1
Where
  followup.HEC_Patient_TreatmentID = @FollowupID And
  followup.IfTreatmentFollowup_FromTreatment_RefID = @TreatmentID And
  followup.IsDeleted = 0 And
  followup.Tenant_RefID = @TenantID And
  followup.IsTreatmentFollowup = 1 
  
  