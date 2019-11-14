
	SELECT ORD_PRC_ProcurementOrder_Position_Discounts.DiscountValue
	FROM ord_prc_procurementorder_positions
	INNER JOIN ORD_PRC_ProcurementOrder_Position_Discounts ON ORD_PRC_ProcurementOrder_Position_Discounts.ord_prc_procurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID
		AND ORD_PRC_ProcurementOrder_Position_Discounts.Tenant_RefID = @TenantID
		AND ORD_PRC_ProcurementOrder_Position_Discounts.IsDeleted = 0
	INNER JOIN ORD_PRC_DiscountTypes ON ORD_PRC_ProcurementOrder_Position_Discounts.ORD_PRC_DiscountType_RefID = ORD_PRC_DiscountTypes.ORD_PRC_DiscountTypeID
		AND ORD_PRC_DiscountTypes.Tenant_RefID = @TenantID
		AND ORD_PRC_DiscountTypes.IsDeleted = 0
		AND ORD_PRC_DiscountTypes.GlobalPropertyMatchingID = @DiscountType
	WHERE ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = @HeaderID
		AND ord_prc_procurementorder_positions.IsDeleted = 0
		AND ord_prc_procurementorder_positions.Tenant_RefID = @TenantID
  