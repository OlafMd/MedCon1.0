
	SELECT CMN_STR_CostCenters.CMN_STR_CostCenterID
		,CMN_STR_CostCenters.InternalID
		,CMN_STR_CostCenters.Name_DictID
		,CMN_STR_CostCenters.Description_DictID
	FROM CMN_STR_CostCenters
	WHERE Tenant_RefID = @TenantID
		AND CMN_STR_CostCenterID = @CostCenterID
		AND IsDeleted = 0
  