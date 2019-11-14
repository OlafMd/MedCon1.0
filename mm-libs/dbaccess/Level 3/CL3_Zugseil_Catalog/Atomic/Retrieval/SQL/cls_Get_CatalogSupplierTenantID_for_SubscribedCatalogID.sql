
	SELECT
	  CMN_BPT_BusinessParticipants.IfTenant_Tenant_RefID
	FROM
	  CMN_PRO_SubscribedCatalogs
	  INNER JOIN CMN_BPT_Suppliers
	    ON CMN_BPT_Suppliers.CMN_BPT_SupplierID =
	         CMN_PRO_SubscribedCatalogs.PublishingSupplier_RefID AND
	       CMN_BPT_Suppliers.IsDeleted = 0 AND
	       CMN_BPT_Suppliers.Tenant_RefID = @TenantID
	  INNER JOIN CMN_BPT_BusinessParticipants
	    ON CMN_BPT_BusinessParticipants.CMN_BPT_BusinessParticipantID =
	         CMN_BPT_Suppliers.Ext_BusinessParticipant_RefID AND
	       CMN_BPT_BusinessParticipants.IsDeleted = 0 AND
	       CMN_BPT_BusinessParticipants.Tenant_RefID = @TenantID
	WHERE
	  CMN_PRO_SubscribedCatalogs.CMN_PRO_SubscribedCatalogID = @SubscribedCatalogID AND
	  CMN_PRO_SubscribedCatalogs.IsDeleted = 0 AND
	  CMN_PRO_SubscribedCatalogs.Tenant_RefID = @TenantID
  