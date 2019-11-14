
	Select
        cmn_sls_pointofsales.CMN_SLS_PointOfSaleID,
        cmn_sls_pointofsales.CMN_STR_Office_RefID,
        cmn_sls_pointofsales.PointOfSale_DisplayName,
        cmn_sls_pointofsales.IsDeleted,
        cmn_sls_pointofsales.Tenant_RefID
    From
        cmn_sls_pointofsales
	Where cmn_sls_pointofsales.Tenant_RefID = @TenantID And cmn_sls_pointofsales.IsDeleted = 0
		  And cmn_sls_pointofsales.CMN_SLS_PointOfSaleID = @PointOfSaleID		 
  