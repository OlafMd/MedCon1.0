
	SELECT 
		log_rcp_receipt_position_qualitycontrolitems.LOG_RCP_Receipt_Position_QualityControlItem
		,log_rcp_receipt_position_qualitycontrolitems.Quantity
		,log_rcp_receipt_position_qualitycontrolitems.BatchNumber
		,log_rcp_receipt_position_qualitycontrolitems.ExpiryDate
		,cmn_pro_products.IsStorage_BatchNumberMandatory
		,cmn_pro_products.IsStorage_ExpiryDateMandatory
	FROM log_rcp_receipt_position_qualitycontrolitems
	INNER JOIN log_rcp_receipt_positions 
		ON log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID = log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID
		AND log_rcp_receipt_positions.IsDeleted = 0
	INNER JOIN cmn_pro_products 
		ON cmn_pro_products.CMN_PRO_ProductID = log_rcp_receipt_positions.ReceiptPosition_Product_RefID
		AND cmn_pro_products.IsDeleted = 0
	WHERE log_rcp_receipt_position_qualitycontrolitems.IsDeleted = 0
		AND log_rcp_receipt_position_qualitycontrolitems.Tenant_RefID = @TenantID
		AND log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID = @ReceiptPositionID

  