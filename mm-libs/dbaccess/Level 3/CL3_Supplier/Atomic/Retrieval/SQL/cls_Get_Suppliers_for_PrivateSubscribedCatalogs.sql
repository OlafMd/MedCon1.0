
	    SELECT cmn_pro_subscribedcatalogs.CMN_PRO_SubscribedCatalogID,
	           cmn_pro_subscribedcatalogs.CatalogCodeITL,
	           cmn_bpt_suppliers.CMN_BPT_SupplierID,
	           cmn_bpt_suppliers.ExternalSupplierProvidedIdentifier,
	           cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
	           cmn_tenants.CMN_TenantID,
	           cmn_tenants.TenantITL
	      FROM cmn_bpt_suppliers
	           INNER JOIN cmn_pro_subscribedcatalogs
	              ON cmn_pro_subscribedcatalogs.PublishingSupplier_RefID =
	                    cmn_bpt_suppliers.CMN_BPT_SupplierID
	           INNER JOIN cmn_bpt_businessparticipants
	              ON cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
	                    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	           LEFT JOIN cmn_tenants
	              ON cmn_bpt_businessparticipants.IfTenant_Tenant_RefID =
	                    cmn_tenants.CMN_TenantID
	                    AND cmn_tenants.IsDeleted = 0
	     WHERE cmn_pro_subscribedcatalogs.IsCatalogPublic = 0
	           AND cmn_bpt_suppliers.IsDeleted = 0
	           AND cmn_bpt_businessparticipants.IsDeleted = 0
	           AND cmn_pro_subscribedcatalogs.IsDeleted = 0
	           AND cmn_pro_subscribedcatalogs.Tenant_RefID = @TenantID

  