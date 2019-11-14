
Select
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber As ik_number,
  cmn_bpt_businessparticipants.DisplayName AS hip_name
From
  hec_patient_healthinsurances Inner Join
  hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID =
    hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
    hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
    hec_his_healthinsurance_companies.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.IsDeleted = 0
Where
  hec_patient_healthinsurances.Tenant_RefID = @TenantID And
  hec_patient_healthinsurances.IsDeleted = 0 And
  hec_patient_healthinsurances.Patient_RefID = @PatientID
	