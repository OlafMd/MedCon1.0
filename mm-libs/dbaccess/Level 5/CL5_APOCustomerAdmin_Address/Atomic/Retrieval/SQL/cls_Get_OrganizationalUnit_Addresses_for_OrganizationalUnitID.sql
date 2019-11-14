
	SELECT CMN_BPT_CTM_OrganizationalUnit_addresses.CMN_BPT_CTM_OrganizationalUnit_AddressID
		,CMN_BPT_CTM_OrganizationalUnit_addresses.IsPrimary
		,CMN_BPT_CTM_OrganizationalUnit_addresses.AddressType
		,cmn_universalcontactdetails.Street_Name
		,cmn_universalcontactdetails.Street_Number
		,cmn_universalcontactdetails.ZIP
		,cmn_universalcontactdetails.Town
		,cmn_universalcontactdetails.Country_639_1_ISOCode
		,cmn_universalcontactdetails.CMN_UniversalContactDetailID
		,cmn_universalcontactdetails.Country_Name
    ,cmn_universalcontactdetails.IsReadOnly
	FROM CMN_BPT_CTM_OrganizationalUnit_addresses
	INNER JOIN CMN_UniversalContactDetails ON CMN_UniversalContactDetails.cmn_UniversalContactDetailID = cmn_bpt_ctm_organizationalunit_addresses.UniversalContactDetail_Address_RefID
		AND CMN_UniversalContactDetails.IsDeleted = 0
		AND CMN_UniversalContactDetails.Tenant_RefID = @TenantID
	WHERE CMN_BPT_CTM_OrganizationalUnit_addresses.IsDeleted = 0
		AND CMN_BPT_CTM_OrganizationalUnit_addresses.Tenant_RefID = @TenantID
		AND CMN_BPT_CTM_OrganizationalUnit_addresses.OrganizationalUnit_RefID = @OrganizationalUnitID
  