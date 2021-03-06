
	SELECT ORD_PRC_ExpectedDelivery_Headers.ORD_PRC_ExpectedDelivery_HeaderID
		,ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.ORD_PRC_ProcurementOrder_Position_RefID
    ,ORD_PRC_ExpectedDelivery_Headers.ExpectedDeliveryDate
	FROM ORD_PRC_ExpectedDelivery_Headers
	INNER JOIN ORD_PRC_ExpectedDelivery_Positions ON ORD_PRC_ExpectedDelivery_Headers.ORD_PRC_ExpectedDelivery_HeaderID = ORD_PRC_ExpectedDelivery_Positions.ORD_PRC_ExpectedDelivery_RefID
		AND ORD_PRC_ExpectedDelivery_Positions.IsDeleted = 0
		AND ORD_PRC_ExpectedDelivery_Positions.Tenant_RefID = @TenantID
	INNER JOIN ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition ON ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.ORD_PRC_ExpectedDelivery_Position_RefID = ORD_PRC_ExpectedDelivery_Positions.ORD_PRC_ExpectedDelivery_PositionID
		AND ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.ORD_PRC_ProcurementOrder_Position_RefID = @ProcurementOrderPositions
		AND ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.IsDeleted = 0
		AND ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.Tenant_RefID = @TenantID
	WHERE ORD_PRC_ExpectedDelivery_Headers.IsDeleted = 0
		AND ORD_PRC_ExpectedDelivery_Headers.Tenant_RefID = @TenantID
  