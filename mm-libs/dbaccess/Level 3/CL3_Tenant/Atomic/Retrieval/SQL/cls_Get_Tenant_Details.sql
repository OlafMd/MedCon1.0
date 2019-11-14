
	SELECT
	  cmn_tenants.CMN_TenantID,
	  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
	  cmn_bpt_businessparticipants.DisplayName AS BusinessParticipantDisplayName,
	  TenantUCD.CMN_UniversalContactDetailID AS TenantUniversalContactDetailID,
	  TenantUCD.CompanyName_Line1 AS TenantUniversalContactDetailCompanyName,
	  TenantUCD.Contact_Email AS TenantUniversalContactDetailContactEmail,
	  cmn_com_companyinfo.CMN_COM_CompanyInfoID,
	  CompanyInfoUCD.CMN_UniversalContactDetailID AS CompanyInfoUniversalContactDetailID,
	  CompanyInfoUCD.CompanyName_Line1 AS CompanyInfoUniversalContactDetailCompanyName,
	  CompanyInfoUCD.Contact_Email AS CompanyInfoUniversalContactDetailContactEmail,
	  cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
	  cmn_bpt_suppliers.CMN_BPT_SupplierID,
	  cmn_bpt_suppliers.SupplierType_RefID
	FROM cmn_tenants
	LEFT JOIN cmn_bpt_businessparticipants
	  ON cmn_bpt_businessparticipants.IfTenant_Tenant_RefID = cmn_tenants.CMN_TenantID
	  AND cmn_bpt_businessparticipants.Tenant_RefID = cmn_tenants.Tenant_RefID
	  AND cmn_bpt_businessparticipants.IsDeleted = 0
	LEFT JOIN cmn_universalcontactdetails AS TenantUCD
	  ON TenantUCD.CMN_UniversalContactDetailID = cmn_tenants.UniversalContactDetail_RefID
	  AND TenantUCD.Tenant_RefID = cmn_tenants.Tenant_RefID
	  AND TenantUCD.IsDeleted = 0
	LEFT JOIN cmn_com_companyinfo
	  ON cmn_com_companyinfo.CMN_COM_CompanyInfoID = cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID
	  AND cmn_com_companyinfo.Tenant_RefID = cmn_tenants.Tenant_RefID
	  AND cmn_com_companyinfo.IsDeleted = 0
	LEFT JOIN cmn_universalcontactdetails AS CompanyInfoUCD
	  ON CompanyInfoUCD.CMN_UniversalContactDetailID = cmn_com_companyinfo.Contact_UCD_RefID
	  AND CompanyInfoUCD.Tenant_RefID = cmn_tenants.Tenant_RefID
	  AND CompanyInfoUCD.IsDeleted = 0
	LEFT JOIN cmn_bpt_ctm_customers
	  ON cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	  AND cmn_bpt_ctm_customers.Tenant_RefID = cmn_tenants.Tenant_RefID
	  AND cmn_bpt_ctm_customers.IsDeleted = 0
	LEFT JOIN cmn_bpt_suppliers
	  ON cmn_bpt_suppliers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	  AND cmn_bpt_suppliers.Tenant_RefID = cmn_tenants.Tenant_RefID
	  AND cmn_bpt_suppliers.IsDeleted = 0
	WHERE
	  cmn_tenants.CMN_TenantID = @TenantID
	  AND cmn_tenants.IsDeleted = 0;
  