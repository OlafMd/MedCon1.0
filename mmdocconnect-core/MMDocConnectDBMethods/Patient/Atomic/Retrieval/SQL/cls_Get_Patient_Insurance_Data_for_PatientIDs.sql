
    Select
      cmn_bpt_businessparticipants.DisplayName As HipName,
      hec_patient_healthinsurances.Patient_RefID As PatientID,
      hec_his_healthinsurance_companies.HealthInsurance_IKNumber As HipIkNumber,
      hec_patient_healthinsurances.Creation_Timestamp As InsuranceDate,
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As HipBptID,
      hec_patient_healthinsurances.HealthInsurance_Number as InsuranceIdNumber,
      hec_patient_healthinsurances.InsuranceStateCode
    From
      hec_patient_healthinsurances
      Inner Join hec_his_healthinsurance_companies On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID
        And hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And hec_his_healthinsurance_companies.IsDeleted = 0
      Inner Join cmn_bpt_businessparticipants On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0
    Where
      hec_patient_healthinsurances.Tenant_RefID = @TenantID  And
      hec_patient_healthinsurances.Patient_RefID = @PatientIDs
    order by
    hec_patient_healthinsurances.Creation_Timestamp  desc
	