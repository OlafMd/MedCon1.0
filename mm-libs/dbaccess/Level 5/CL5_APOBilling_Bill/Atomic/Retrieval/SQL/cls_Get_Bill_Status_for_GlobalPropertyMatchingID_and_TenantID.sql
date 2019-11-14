
		SELECT
			bil_billstatuses.BIL_BillStatusID
		FROM bil_billstatuses
		WHERE 
			bil_billstatuses.GlobalPropertyMatchingID = @GlobalPropertyMatchingID
			AND bil_billstatuses.IsDeleted = 0
			AND bil_billstatuses.Tenant_RefID = @TenantID
  