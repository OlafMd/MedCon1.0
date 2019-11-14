
	SELECT
        log_shp_returnshipment_positions.LOG_SHP_ReturnShipment_PositionID,
        log_shp_returnshipment_positions.ReturnPolicy_RefID,
        log_ret_returnpolicies.ReturnPolicy_Reason_DictID,
        log_shp_shipment_positions.CMN_PRO_Product_RefID,
        log_shp_shipment_positions.QuantityToShip,
        log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax AS TotalValue,
        cmn_bpt_businessparticipants.DisplayName AS Supplier,
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID AS SupplierID,
        log_shp_returnshipment_positions.ReturnShipment_Header_RefID,
        log_shp_returnshipment_positions.ReturnProductOriginatedFromReceiptPosition_RefID AS ReceiptPositionID,
        log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
        log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
        log_shp_shipment_headers.ShipmentHeader_Currency_RefID,
        log_shp_shipment_headers.ShipmentHeader_ValueWithoutTax AS HeaderTotalValue,
        log_shp_shipment_headers.ShipmentHeader_Number
	FROM log_shp_returnshipment_positions
    INNER JOIN log_shp_shipment_positions
	    ON log_shp_shipment_positions.LOG_SHP_Shipment_PositionID = log_shp_returnshipment_positions.Ext_Shipment_Position_RefID
	    AND log_shp_shipment_positions.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
	    AND log_shp_shipment_positions.IsDeleted = log_shp_returnshipment_positions.IsDeleted
    INNER JOIN log_shp_shipment_headers
	    ON log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID
	    AND log_shp_shipment_headers.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
	    AND log_shp_shipment_headers.IsDeleted = log_shp_returnshipment_positions.IsDeleted  
    INNER JOIN log_rcp_receipt_positions
      ON log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID = log_shp_returnshipment_positions.ReturnProductOriginatedFromReceiptPosition_RefID
      AND log_rcp_receipt_positions.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_rcp_receipt_positions.IsDeleted = log_shp_returnshipment_positions.IsDeleted
    INNER JOIN log_rcp_receipt_headers
      ON log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = log_rcp_receipt_positions.Receipt_Header_RefID
      AND log_rcp_receipt_headers.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_rcp_receipt_headers.IsDeleted = log_shp_returnshipment_positions.IsDeleted
      AND log_rcp_receipt_headers.IsCustomerReturnReceipt = 0
    INNER JOIN cmn_bpt_suppliers
      ON cmn_bpt_suppliers.CMN_BPT_SupplierID = log_rcp_receipt_headers.ProvidingSupplier_RefID
      AND cmn_bpt_suppliers.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND cmn_bpt_suppliers.IsDeleted = log_shp_returnshipment_positions.IsDeleted
    INNER JOIN cmn_bpt_businessparticipants
      ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_bpt_suppliers.Ext_BusinessParticipant_RefID
      AND cmn_bpt_businessparticipants.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND cmn_bpt_businessparticipants.IsDeleted = log_shp_returnshipment_positions.IsDeleted     
    LEFT JOIN log_ret_returnpolicies
      ON log_ret_returnpolicies.LOG_RET_ReturnPolicyID = log_shp_returnshipment_positions.ReturnPolicy_RefID
      AND log_ret_returnpolicies.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_ret_returnpolicies.IsDeleted = log_shp_returnshipment_positions.IsDeleted    
	WHERE
	  log_shp_returnshipment_positions.Tenant_RefID = @TenantID
	  AND log_shp_returnshipment_positions.IsDeleted = 0
	  AND log_shp_returnshipment_positions.Ext_Shipment_Position_RefID = @ShipmentPositionIDs
	  AND log_shp_shipment_headers.IsCustomerReturnShipment = 0;
  