
Select
  If(Count(hec_patient_healthinsurances.HealthInsurance_Number) > 0, 'false',
  'true') As isHINumberUnique,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName
From
  hec_patient_healthinsurances Inner Join
  hec_patients On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID Inner Join
  hec_patient_medicalpractices On hec_patient_medicalpractices.HEC_Patient_RefID
    = hec_patients.HEC_PatientID And hec_patient_medicalpractices.IsDeleted = 0
    And hec_patient_medicalpractices.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID
Where
  hec_patients.HEC_PatientID != @PatientID And
  hec_patient_healthinsurances.HealthInsurance_Number = @InsuranceNumber And
  hec_patient_healthinsurances.IsDeleted = 0 And
  hec_patient_healthinsurances.Tenant_RefID = @TenantID And
  hec_patient_medicalpractices.HEC_MedicalPractices_RefID = @MedicalPracticeID

  
	