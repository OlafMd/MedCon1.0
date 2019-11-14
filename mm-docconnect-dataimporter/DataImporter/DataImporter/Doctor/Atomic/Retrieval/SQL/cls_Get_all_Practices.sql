
Select
  cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID,
  cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_ctm_organizationalunits.Customer_RefID,
  cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
  hec_medicalpractises.HEC_MedicalPractiseID,
  cmn_bpt_ctm_organizationalunits.IsMedicalPractice,
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID,
  cmn_bpt_businessparticipants.DisplayName 
From
  cmn_bpt_businessparticipants Inner Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunits.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID Inner Join
  hec_medicalpractises
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID
Where
  cmn_bpt_ctm_organizationalunits.IsMedicalPractice = 1 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_ctm_customers.IsDeleted = 0 And
  cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And  
  cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And 
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And 
  cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And 
  hec_medicalpractises.Tenant_RefID = @TenantID 
  
  