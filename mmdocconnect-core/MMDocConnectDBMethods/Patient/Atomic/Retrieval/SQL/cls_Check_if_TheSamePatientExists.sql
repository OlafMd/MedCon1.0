
Select
  If(Count(cmn_per_personinfo.CMN_PER_PersonInfoID) > 0, 'false',
  'true') As isPatientUnique
From
  cmn_per_personinfo Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  hec_patients On hec_patients.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    hec_patients.IsDeleted = 0 And hec_patients.Tenant_RefID = @TenantID
  Inner Join
  hec_patient_medicalpractices On hec_patients.HEC_PatientID =
    hec_patient_medicalpractices.HEC_Patient_RefID And
    hec_patient_medicalpractices.HEC_MedicalPractices_RefID = @MedicalPracticeID
    And hec_patient_medicalpractices.IsDeleted = 0 And
    hec_patient_medicalpractices.Tenant_RefID = @TenantID
Where
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_per_personinfo.Tenant_RefID = @TenantID And
  Lower(cmn_per_personinfo.FirstName) = @FirstName And
  Lower(cmn_per_personinfo.LastName) = @LastName And
  Date(cmn_per_personinfo.BirthDate) = @Birthday And
  hec_patients.HEC_PatientID != @PatientID
  
	