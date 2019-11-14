
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_patient_healthinsurances.HealthInsurance_Number,
  hec_patients.HEC_PatientID,
  cmn_per_personinfo.Salutation_General,
  hec_patients.IsPatientParticipationPolicyValidated,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  usr_accounts.USR_AccountID
From
  cmn_per_personinfo Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_patients On hec_patients.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  hec_stu_study_participatingpatients On hec_patients.HEC_PatientID =
    hec_stu_study_participatingpatients.Patient_RefID Left Join
  hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Where
  (hec_patients.IsPatientParticipationPolicyValidated = 1 Or
    hec_patients.IsPatientParticipationPolicyValidated =
    @IncludeOnlyConfirmedPolicy) And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  hec_patients.IsDeleted = 0 And
  hec_stu_study_participatingpatients.IsDeleted = 0 And
  hec_patient_healthinsurances.IsDeleted = 0 And
  hec_patients.Tenant_RefID = @TenantID And
  hec_patient_healthinsurances.IsPrimary = 1 And
  usr_accounts.IsDeleted = 0
  