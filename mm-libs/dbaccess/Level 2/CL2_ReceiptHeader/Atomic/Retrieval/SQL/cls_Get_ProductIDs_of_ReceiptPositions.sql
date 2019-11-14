
	SELECT LOG_RCP_Receipt_Positions.ReceiptPosition_Product_RefID
  , LOG_RCP_Receipt_Positions.LOG_RCP_Receipt_PositionID
	FROM LOG_RCP_Receipt_Positions
	WHERE LOG_RCP_Receipt_Positions.IsDeleted = 0
		AND LOG_RCP_Receipt_Positions.Tenant_RefID = @TenantID
		AND LOG_RCP_Receipt_Positions.LOG_RCP_Receipt_PositionID = @ReceiptPositionIDs
  