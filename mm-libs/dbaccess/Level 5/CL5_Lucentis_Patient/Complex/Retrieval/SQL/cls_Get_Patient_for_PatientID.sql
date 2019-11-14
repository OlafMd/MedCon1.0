
Select
  hec_patients.HEC_PatientID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_patient_medicalpractices.HEC_MedicalPractices_RefID,
  hec_patient_healthinsurances.HealthInsurance_Number,
  hec_patient_healthinsurances.HealthInsurance_State_RefID,
  cmn_per_personinfo.BirthDate,
  hec_patient_healthinsurances.InsuranceStateCode,
  cmn_per_personinfo.Gender,
  hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID,
  cmn_bpt_businessparticipants1.DisplayName As CompanyName
From
  hec_patients Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_patient_medicalpractices On hec_patients.HEC_PatientID =
    hec_patient_medicalpractices.HEC_Patient_RefID Inner Join
  hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID =
    hec_patients.HEC_PatientID Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID
Where
  hec_patients.HEC_PatientID = @PatientID And
  hec_patients.Tenant_RefID = @TenantID And
  hec_patients.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  hec_patient_medicalpractices.IsDeleted = 0 And
  hec_patient_healthinsurances.IsDeleted = 0 And
  hec_his_healthinsurance_companies.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsCompany = 1 And
  cmn_bpt_businessparticipants1.IsDeleted = 0
  