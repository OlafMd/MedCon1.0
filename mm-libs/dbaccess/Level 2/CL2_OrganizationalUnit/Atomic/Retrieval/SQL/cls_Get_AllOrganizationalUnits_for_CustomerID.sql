
	SELECT 
	  cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID, 
	  cmn_bpt_ctm_organizationalunits.CustomerTenant_OfficeITL, 
	  cmn_bpt_ctm_organizationalunits.Parent_OrganizationalUnit_RefID, 
	  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_SimpleName, 
	  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID, 
	  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Description_DictID, 
	  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitNumber, 
	  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitSimpleName, 
	  cmn_bpt_ctm_organizationalunits.ExternalOrganizationalUnitNumber, 
	  cmn_bpt_ctm_organizationalunits.Default_PhoneNumber, 
	  cmn_bpt_ctm_organizationalunits.Default_FaxNumber 
	FROM 
	  cmn_bpt_ctm_organizationalunits
	WHERE
	  cmn_bpt_ctm_organizationalunits.Customer_RefID = @CustomerID
	  AND cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID
	  AND cmn_bpt_ctm_organizationalunits.IsDeleted = 0;
  