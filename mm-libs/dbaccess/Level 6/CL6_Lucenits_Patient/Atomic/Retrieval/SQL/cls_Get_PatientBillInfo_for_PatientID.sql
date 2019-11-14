
Select
  hec_patients.HEC_PatientID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_patient_healthinsurances.HealthInsurance_Number,
  hec_patient_healthinsurances.HealthInsurance_State_RefID,
  cmn_per_personinfo.BirthDate,
  hec_patient_healthinsurances.InsuranceStateCode,
  cmn_per_personinfo.Gender
From
  hec_patients Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID
Where
  hec_patients.HEC_PatientID = @PatientID And
  hec_patients.Tenant_RefID = @TenantID And
  hec_patients.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  hec_patient_healthinsurances.IsDeleted = 0
  