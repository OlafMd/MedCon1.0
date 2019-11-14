
    Select
      cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As bsnr,
      cmn_bpt_businessparticipants.DisplayName As name
    From
      cmn_bpt_ctm_organizationalunits Inner Join
      cmn_bpt_ctm_customers
        On cmn_bpt_ctm_organizationalunits.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
        cmn_bpt_ctm_customers.IsDeleted = 0 Inner Join
      cmn_bpt_businessparticipants
        On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
      cmn_com_companyinfo
        On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.Tenant_RefID =
        @TenantID And cmn_com_companyinfo.IsDeleted = 0
    Where
      cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID = @PracticeID And
      cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
      cmn_bpt_ctm_organizationalunits.IsDeleted = 0
	