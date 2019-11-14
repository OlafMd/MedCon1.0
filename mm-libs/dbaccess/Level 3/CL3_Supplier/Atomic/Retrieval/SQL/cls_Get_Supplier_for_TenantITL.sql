
  SELECT cmn_bpt_suppliers.CMN_BPT_SupplierID
	FROM cmn_bpt_businessparticipants
	INNER JOIN cmn_bpt_suppliers ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_bpt_suppliers.Ext_BusinessParticipant_RefID
		AND cmn_bpt_suppliers.IsDeleted = 0 AND cmn_bpt_suppliers.Tenant_RefID = @TenantID
	INNER JOIN cmn_tenants ON cmn_tenants.CMN_TenantID = cmn_bpt_businessparticipants.IfTenant_Tenant_RefID
		AND cmn_tenants.IsDeleted = 0 AND cmn_tenants.Tenant_RefID = @TenantID
	WHERE cmn_bpt_businessparticipants.IsDeleted = 0
		AND cmn_tenants.TenantITL = @TenantITL
    AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID;
  