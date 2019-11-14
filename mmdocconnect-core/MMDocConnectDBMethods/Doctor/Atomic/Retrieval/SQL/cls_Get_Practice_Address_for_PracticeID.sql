
    Select
      cmn_universalcontactdetails.Town as city,
      cmn_universalcontactdetails.ZIP as zip,
      cmn_universalcontactdetails.Street_Name as street,
      cmn_universalcontactdetails.Street_Number as number,
      cmn_bpt_businessparticipants.DisplayName as name
    From
      cmn_bpt_ctm_organizationalunits Inner Join
      cmn_bpt_ctm_customers
        On cmn_bpt_ctm_organizationalunits.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
        cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
        cmn_bpt_ctm_customers.IsDeleted = 0 Inner Join
      cmn_bpt_businessparticipants
        On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
        cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
      cmn_com_companyinfo_addresses
        On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo_addresses.CompanyInfo_RefID And    
  	    cmn_com_companyinfo_addresses.Address_Description = 'Standard address for billing, shipping' And
  	    cmn_com_companyinfo_addresses.Tenant_RefID = @TenantID And
  	    cmn_com_companyinfo_addresses.IsDeleted = 0 Inner Join
      cmn_universalcontactdetails
        On cmn_com_companyinfo_addresses.Address_UCD_RefID = cmn_universalcontactdetails.CMN_UniversalContactDetailID And
        cmn_universalcontactdetails.Tenant_RefID = @TenantID And
        cmn_universalcontactdetails.IsDeleted = 0
    Where	
	    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID = @PracticeID And
	    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
	    cmn_bpt_ctm_organizationalunits.IsDeleted = 0
	