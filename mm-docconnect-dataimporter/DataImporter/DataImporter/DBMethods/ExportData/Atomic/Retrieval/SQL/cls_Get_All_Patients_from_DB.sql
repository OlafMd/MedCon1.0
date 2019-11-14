

Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.BirthDate,
  cmn_per_personinfo.Gender,
  hec_patient_medicalpractices.HEC_MedicalPractices_RefID As PracticeID,
  hec_patient_healthinsurances.HealthInsurance_Number As HipNumber,
  hec_patient_healthinsurances.Patient_RefID,
  hec_patients.HEC_PatientID As Id,
  hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID As HIPID,
  hec_patient_healthinsurances.InsuranceStateCode As InsuranceStatus,
  hec_crt_insurancetobrokercontract_participatingpatients.ValidThrough,
  hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom,
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber
From
  hec_patients Left Join
  cmn_bpt_businessparticipants
    On hec_patients.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
  hec_patient_medicalpractices
    On hec_patients.HEC_PatientID =
    hec_patient_medicalpractices.HEC_Patient_RefID And
    hec_patient_medicalpractices.IsDeleted = 0 And
    hec_patient_medicalpractices.Tenant_RefID = @TenantID Inner Join
  hec_patient_healthinsurances
    On hec_patient_healthinsurances.Patient_RefID = hec_patients.HEC_PatientID
    And hec_patient_healthinsurances.IsDeleted = 0 And
    hec_patient_healthinsurances.Tenant_RefID = @TenantID Left Join
  hec_crt_insurancetobrokercontract_participatingpatients
    On hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID =
    hec_patients.HEC_PatientID Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
    hec_his_healthinsurance_companies.IsDeleted = 0 And 
    hec_his_healthinsurance_companies.Tenant_RefID = @TenantID
Where
  hec_his_healthinsurance_companies.IsDeleted = 0 And
  hec_his_healthinsurance_companies.Tenant_RefID = @TenantID
Group By
 Id
  