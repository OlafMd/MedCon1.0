
	SELECT
		log_wrh_shelf_contents.Product_RefID,
		SUM(log_wrh_shelf_contents.Quantity_Current) AS Quantity
	FROM
		log_wrh_shelf_contents
	WHERE
		log_wrh_shelf_contents.IsDeleted = 0
		AND log_wrh_shelf_contents.Tenant_RefID = @TenantID
		AND log_wrh_shelf_contents.Product_RefID = @ProductID_List
	GROUP BY Product_RefID
  