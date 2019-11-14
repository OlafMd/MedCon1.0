
Select
  usr_accounts.USR_AccountID As accountID,
  usr_accounts.AccountSignInEmailAddress As accountMail,
  cmn_bpt_businessparticipants.DisplayName
From
  hec_medicalpractises Inner Join
  cmn_bpt_ctm_organizationalunits
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_organizationalunits.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
    cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_customers.IsDeleted = 0 Inner Join
  usr_accounts On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    usr_accounts.BusinessParticipant_RefID And usr_accounts.Tenant_RefID =
    @TenantID And usr_accounts.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    usr_accounts.BusinessParticipant_RefID  And  cmn_bpt_businessparticipants.Tenant_RefID =
        @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0 
Where
  hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID And
  hec_medicalpractises.Tenant_RefID = @TenantID And
  hec_medicalpractises.IsDeleted = 0
  