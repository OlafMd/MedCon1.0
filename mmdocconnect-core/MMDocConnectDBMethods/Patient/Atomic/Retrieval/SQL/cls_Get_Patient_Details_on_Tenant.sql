
    Select                        
      hec_patients.HEC_PatientID As PatientID,
      cmn_per_personinfo.FirstName,
      cmn_per_personinfo.LastName,
      cmn_per_personinfo.Gender,
      cmn_per_personinfo.BirthDate,
      hec_patient_healthinsurances.HealthInsurance_Number as InsuranceIdNumber,
      hec_patient_healthinsurances.InsuranceStateCode as InsuranceStatus,
      hec_his_healthinsurance_companies.HealthInsurance_IKNumber as HipIkNumber,
      cmn_bpt_businessparticipants1.DisplayName as HipName
    From
      hec_patients
      Inner Join cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
      cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
      cmn_bpt_businessparticipants.IsDeleted = 0
      Inner Join cmn_per_personinfo On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID And
      cmn_per_personinfo.Tenant_RefID = @TenantID And
      cmn_per_personinfo.IsDeleted = 0
      Inner Join hec_patient_healthinsurances On hec_patients.HEC_PatientID = hec_patient_healthinsurances.Patient_RefID And
      hec_patient_healthinsurances.Tenant_RefID = @TenantID And
      hec_patient_healthinsurances.IsDeleted = 0
      Inner Join hec_his_healthinsurance_companies On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
      hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
      hec_his_healthinsurance_companies.IsDeleted = 0
      Inner Join cmn_bpt_businessparticipants cmn_bpt_businessparticipants1 On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID And
        cmn_bpt_businessparticipants1.IsDeleted = 0
    Where
      hec_patients.Tenant_RefID = @TenantID And
      hec_patients.IsDeleted = 0 
  
  