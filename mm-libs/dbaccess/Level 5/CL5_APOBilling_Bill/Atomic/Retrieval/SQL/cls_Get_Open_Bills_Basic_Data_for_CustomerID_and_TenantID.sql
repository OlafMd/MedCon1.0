
SELECT bil_billheader_2_billstatus.Creation_Timestamp AS BillStatusCreationTime
	,bil_billheaders.BIL_BillHeaderID
	,bil_billheaders.BillNumber
	,bil_billheaders.DateOnBill
	,cmn_bpt_businessparticipants_billrecipient.DisplayName AS BillRecipientName
FROM bil_billheaders
INNER JOIN bil_billheader_2_billstatus ON bil_billheader_2_billstatus.BIL_BillHeader_RefID = bil_billheaders.BIL_BillHeaderID
	AND bil_billheader_2_billstatus.IsCurrentStatus = 1
	AND bil_billheader_2_billstatus.IsDeleted = 0
	AND bil_billheader_2_billstatus.Tenant_RefID = @TenantID
	AND bil_billheader_2_billstatus.BIL_BillStatus_RefID = @BillStatusID
INNER JOIN BIL_BillPositions ON BIL_BillPositions.BIL_BilHeader_RefID = bil_billheaders.BIL_BillHeaderID
	AND BIL_BillPositions.IsDeleted = 0
	AND BIL_BillPositions.Tenant_RefID = @TenantID
INNER JOIN cmn_bpt_ctm_customers AS cust ON cust.CMN_BPT_CTM_CustomerID = @CustomerID
	AND cust.IsDeleted = 0
	AND cust.Tenant_RefID = @TenantID
LEFT JOIN BIL_BillPosition_2_ShipmentPosition ON bil_billpositions.BIL_BillPositionID = bil_billposition_2_shipmentposition.BIL_BillPosition_RefID
	AND BIL_BillPosition_2_ShipmentPosition.IsDeleted = 0
	AND BIL_BillPosition_2_ShipmentPosition.Tenant_RefID = @TenantID
LEFT JOIN Log_Shp_Shipment_Positions ON bil_billposition_2_shipmentposition.Log_Shp_Shipment_Position_RefID = Log_Shp_Shipment_Positions.Log_Shp_Shipment_PositionID
	AND Log_Shp_Shipment_Positions.IsDeleted = 0
	AND Log_Shp_Shipment_Positions.Tenant_RefID = @TenantID
JOIN log_shp_Shipment_Headers ON log_shp_Shipment_Headers.Log_Shp_Shipment_HeaderID = Log_Shp_Shipment_Positions.LOG_SHP_Shipment_Header_RefID
	AND log_shp_Shipment_Headers.IsDeleted = 0
	AND log_shp_shipment_headers.RecipientBusinessParticipant_RefID = cust.Ext_BusinessParticipant_RefID
	AND log_shp_Shipment_Headers.Tenant_RefID = @TenantID
LEFT JOIN BIL_BillPosition_2_CustomerOrderReturnPosition ON BIL_BillPosition_2_CustomerOrderReturnPosition.Bil_BillPosition_RefID = BIL_BillPositions.BIL_BillPositionID
	AND BIL_BillPosition_2_CustomerOrderReturnPosition.IsDeleted = 0
	AND BIL_BillPosition_2_CustomerOrderReturnPosition.Tenant_RefID = @TenantID
LEFT JOIN ORD_CUO_CustomerOrderReturn_Positions ON ORD_CUO_CustomerOrderReturn_Positions.ord_cuo_CustomerOrderReturn_PositionID = BIL_BillPosition_2_CustomerOrderReturnPosition.ORD_CUO_CustomerOrderReturn_Position_RefID
	AND ORD_CUO_CustomerOrderReturn_Positions.IsDeleted = 0
	AND ORD_CUO_CustomerOrderReturn_Positions.Tenant_RefID = @TenantID
LEFT JOIN ord_cuo_CustomerOrderReturn_Headers ON ord_cuo_CustomerOrderReturn_Headers.ord_cuo_CustomerOrderReturn_HeaderID = ORD_CUO_CustomerOrderReturn_Positions.CustomerOrderReturnHeader_RefID
	AND ord_cuo_CustomerOrderReturn_Headers.IsDeleted = 0
	AND ord_cuo_CustomerOrderReturn_Headers.Customer_RefID = cust.CMN_BPT_CTM_CustomerID
	AND ord_cuo_CustomerOrderReturn_Headers.Tenant_RefID = @TenantID
INNER JOIN cmn_bpt_businessparticipants AS cmn_bpt_businessparticipants_billrecipient ON cmn_bpt_businessparticipants_billrecipient.CMN_BPT_BusinessParticipantID = bil_billheaders.BillRecipient_BuisnessParticipant_RefID -- cust.Ext_BusinessParticipant_RefID 
	AND cmn_bpt_businessparticipants_billrecipient.IsDeleted = 0
 AND cmn_bpt_businessparticipants_billrecipient.Tenant_RefID = @TenantID 
WHERE (
		bil_billheaders.IsDeleted = 0
		AND bil_billheaders.Tenant_RefID = @TenantID
		)
    AND (
      (@Date IS NULL)
      OR
      (
        Year(bil_billheaders.DateOnBill) = Year(@Date) 
        AND Month(bil_billheaders.DateOnBill) = Month(@Date)
      )
  )
	AND (
		@BillNumber IS NULL
		OR (
			@BillNumber IS NOT NULL
			AND bil_billheaders.BillNumber LIKE CONCAT (
				'%'
				,@BillNumber
				,'%'
				)
			)
		)
GROUP BY bil_billheaders.BIL_BillHeaderID
  