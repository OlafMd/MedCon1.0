
	SELECT ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID
	FROM ord_cuo_customerorderreturn_positions
	LEFT JOIN bil_billposition_2_customerorderreturnposition ON bil_billposition_2_customerorderreturnposition.ORD_CUO_CustomerOrderReturn_Position_RefID = ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID
		AND bil_billposition_2_customerorderreturnposition.IsDeleted = 0
		AND bil_billposition_2_customerorderreturnposition.Tenant_RefID = @TenantID
	WHERE ord_cuo_customerorderreturn_positions.Tenant_RefID = @TenantID
		AND ord_cuo_customerorderreturn_positions.IsDeleted = 0
		AND bil_billposition_2_customerorderreturnposition.AssignmentID IS NULL
		AND ord_cuo_customerorderreturn_positions.CustomerOrderReturnHeader_RefID = @ReturnPositionHeaderIDs
  