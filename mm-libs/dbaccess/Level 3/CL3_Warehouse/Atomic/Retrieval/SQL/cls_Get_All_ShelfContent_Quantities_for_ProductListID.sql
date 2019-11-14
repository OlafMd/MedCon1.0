
	SELECT
		log_wrh_shelf_contents.Product_RefID,
		SUM(log_wrh_shelf_contents.Quantity_Current) AS Sum_Quantity_Current,
		SUM(log_wrh_shelf_contents.R_ReservedQuantity) AS Sum_R_ReservedQuantity,
		SUM(log_wrh_shelf_contents.R_FreeQuantity) AS Sum_R_FreeQuantity
	FROM 
		log_wrh_shelf_contents
	WHERE
		log_wrh_shelf_contents.IsDeleted = 0
		AND log_wrh_shelf_contents.Tenant_RefID  = @TenantID
		AND log_wrh_shelf_contents.Product_RefID = @ProductIDList
	GROUP BY
		log_wrh_shelf_contents.Product_RefID
  