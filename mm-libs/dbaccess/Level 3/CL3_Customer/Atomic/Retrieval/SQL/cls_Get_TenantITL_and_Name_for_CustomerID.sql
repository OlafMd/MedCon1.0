
	SELECT cmn_tenants.TenantITL
		,cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID
		,cmn_bpt_businessparticipants.DisplayName
	FROM cmn_bpt_ctm_customers
	INNER JOIN cmn_bpt_businessparticipants ON cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
		AND cmn_bpt_businessparticipants.IsDeleted = 0
	INNER JOIN cmn_tenants ON cmn_bpt_businessparticipants.IfTenant_Tenant_RefID = cmn_tenants.CMN_TenantID
		AND cmn_tenants.IsDeleted = 0
	WHERE cmn_bpt_ctm_customers.IsDeleted = 0
		AND cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID = @CustomerID;
  