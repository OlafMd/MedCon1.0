
    Select
      hec_patient_healthinsurances.Patient_RefID As PatientID
    From
      hec_patient_medicalpractices
      Inner Join hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID = hec_patient_medicalpractices.HEC_Patient_RefID And
        hec_patient_healthinsurances.Tenant_RefID = @TenantID And hec_patient_healthinsurances.IsDeleted = 0 And
        hec_patient_healthinsurances.HealthInsurance_Number = @InsuranceID
      Inner Join cmn_bpt_ctm_organizationalunits
        On hec_patient_medicalpractices.HEC_MedicalPractices_RefID = cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID And
        cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And cmn_bpt_ctm_organizationalunits.IsDeleted = 0
      Inner Join cmn_bpt_ctm_customers On cmn_bpt_ctm_organizationalunits.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And cmn_bpt_ctm_customers.Tenant_RefID =
        @TenantID And cmn_bpt_ctm_customers.IsDeleted = 0
      Inner Join cmn_bpt_businessparticipants On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0
      Inner Join cmn_com_companyinfo On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted =
        0 And cmn_com_companyinfo.Tenant_RefID = @TenantID And
        cmn_com_companyinfo.CompanyInfo_EstablishmentNumber = @BSNR
    Where
      hec_patient_medicalpractices.Tenant_RefID = @TenantID And
      hec_patient_medicalpractices.IsDeleted = 0  
  