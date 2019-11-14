
Select
  Concat_Ws(' ', cmn_per_personinfo.FirstName, cmn_per_personinfo.LastName) As name,
  cmn_per_personinfo.FirstName As patient_first_name,
  cmn_per_personinfo.LastName As patient_last_name,
  cmn_per_personinfo.BirthDate As birthday,
  hec_patient_healthinsurances.HealthInsurance_Number As insurance_id,
  hec_patient_healthinsurances.InsuranceStateCode As insurance_status,
  cmn_bpt_businessparticipants1.DisplayName As health_insurance_provider,
  hec_patients.HEC_PatientID As id,
  cmn_per_personinfo.Gender As gender,
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber
From
  cmn_per_personinfo
  Inner Join cmn_bpt_businessparticipants On cmn_per_personinfo.CMN_PER_PersonInfoID = cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And cmn_bpt_businessparticipants.IsCompany = 0 And cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  Inner Join hec_patients On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = hec_patients.CMN_BPT_BusinessParticipant_RefID And hec_patients.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID
  Inner Join hec_patient_healthinsurances On hec_patients.HEC_PatientID = hec_patient_healthinsurances.Patient_RefID And hec_patient_healthinsurances.IsDeleted = 0 And
    hec_patient_healthinsurances.Tenant_RefID = @TenantID
  Inner Join hec_his_healthinsurance_companies On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID
    And hec_his_healthinsurance_companies.IsDeleted = 0 And hec_his_healthinsurance_companies.Tenant_RefID = @TenantID
  Inner Join cmn_bpt_businessparticipants cmn_bpt_businessparticipants1 On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipants1.IsCompany = 1 And cmn_bpt_businessparticipants1.IsNaturalPerson = 0 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID
Where
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_per_personinfo.Tenant_RefID = @TenantID
  