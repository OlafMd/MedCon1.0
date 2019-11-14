
    Select
      cmn_bpt_businessparticipants.DisplayName as hip_name,
      hec_his_healthinsurance_companies.HealthInsurance_IKNumber as hip_ik_number
    From
      hec_his_healthinsurance_companies Inner Join
      cmn_bpt_businessparticipants
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
 	     cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
      hec_patient_healthinsurances
        On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
        hec_patient_healthinsurances.Tenant_RefID = @TenantID And
        hec_patient_healthinsurances.IsDeleted = 0 Inner Join
      hec_patient_medicalpractices
        On hec_patient_healthinsurances.Patient_RefID = hec_patient_medicalpractices.HEC_Patient_RefID And
 	     hec_patient_medicalpractices.HEC_MedicalPractices_RefID = @PracticeID And
        hec_patient_medicalpractices.Tenant_RefID = @TenantID And
        hec_patient_medicalpractices.IsDeleted = 0
    Where
      hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
      hec_his_healthinsurance_companies.IsDeleted = 0
    Group By
      hip_name
	