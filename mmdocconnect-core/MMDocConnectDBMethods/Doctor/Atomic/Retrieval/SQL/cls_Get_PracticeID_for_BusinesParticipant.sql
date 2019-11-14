
    
Select
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID as PracticeID,
  cmn_bpt_ctm_customers.Tenant_RefID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsCompany = 1 Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID =
    cmn_bpt_ctm_organizationalunits.Customer_RefID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID
Where
  cmn_bpt_ctm_customers.Tenant_RefID = @TenantID  and
  cmn_bpt_ctm_customers.IsDeleted = 0 and
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = @PracticeBusinessParticipant
	
  