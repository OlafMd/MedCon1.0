
    Select
      cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID As practice_bpt_id,
      cmn_bpt_businessparticipants.DisplayName As practice_name,
      cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As practice_id,
      cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As bsnr,
      usr_accounts.USR_AccountID as account_id
    From
      cmn_bpt_ctm_customers Inner Join
      cmn_bpt_ctm_organizationalunits
        On cmn_bpt_ctm_organizationalunits.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And cmn_bpt_ctm_organizationalunits.Tenant_RefID =
        @TenantID And cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Inner Join
      cmn_bpt_businessparticipants
        On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
      cmn_com_companyinfo
        On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.Tenant_RefID =
        @TenantID And cmn_com_companyinfo.IsDeleted = 0 Inner Join
      usr_accounts
        On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = usr_accounts.BusinessParticipant_RefID And usr_accounts.Tenant_RefID = @TenantID And
        usr_accounts.IsDeleted = 0
    Where
      cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = @PracticeBptIDs And
      cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
      cmn_bpt_ctm_customers.IsDeleted = 0
	