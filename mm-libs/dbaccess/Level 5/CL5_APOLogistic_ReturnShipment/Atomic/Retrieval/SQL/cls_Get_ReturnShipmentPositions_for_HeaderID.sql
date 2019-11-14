
    SELECT 
      log_shp_returnshipment_positions.LOG_SHP_ReturnShipment_PositionID,
      log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
      log_shp_shipment_positions.CMN_PRO_Product_RefID AS ProductId,
      log_shp_shipment_positions.QuantityToShip AS ReturnedQuantity,
      log_rcp_receipt_positions.TotalQuantityTakenIntoStock AS ReceiptQuantity,
      log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax,
      cmn_bpt_businessparticipants.DisplayName AS Supplier,
      log_shp_shipment_headers.ShipmentHeader_ValueWithoutTax,
      log_ret_returnpolicies.LOG_RET_ReturnPolicyID
    FROM log_shp_returnshipment_positions
    
    INNER JOIN log_shp_shipment_positions
      ON log_shp_shipment_positions.LOG_SHP_Shipment_PositionID = log_shp_returnshipment_positions.Ext_Shipment_Position_RefID
      AND log_shp_shipment_positions.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_shp_shipment_positions.IsDeleted = log_shp_returnshipment_positions.IsDeleted
      
    INNER JOIN log_rcp_receipt_positions
      ON log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID = log_shp_returnshipment_positions.ReturnProductOriginatedFromReceiptPosition_RefID
      AND log_rcp_receipt_positions.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_rcp_receipt_positions.IsDeleted = log_shp_returnshipment_positions.IsDeleted
    INNER JOIN log_rcp_receipt_headers
      ON log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = log_rcp_receipt_positions.Receipt_Header_RefID
      AND log_rcp_receipt_headers.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_rcp_receipt_headers.IsDeleted = log_shp_returnshipment_positions.IsDeleted
      AND log_rcp_receipt_headers.IsCustomerReturnReceipt = 0
    LEFT JOIN cmn_bpt_suppliers
      ON cmn_bpt_suppliers.CMN_BPT_SupplierID = log_rcp_receipt_headers.ProvidingSupplier_RefID
      AND cmn_bpt_suppliers.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND cmn_bpt_suppliers.IsDeleted = log_shp_shipment_positions.IsDeleted
    LEFT JOIN cmn_bpt_businessparticipants
      ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_bpt_suppliers.Ext_BusinessParticipant_RefID
      AND cmn_bpt_businessparticipants.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND cmn_bpt_businessparticipants.IsDeleted = log_shp_returnshipment_positions.IsDeleted
      
    INNER JOIN log_shp_returnshipment_headers
      ON log_shp_returnshipment_headers.LOG_SHP_ReturnShipment_HeaderID = log_shp_returnshipment_positions.ReturnShipment_Header_RefID
      AND log_shp_returnshipment_headers.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_shp_returnshipment_headers.IsDeleted = log_shp_returnshipment_positions.IsDeleted
    LEFT JOIN log_shp_shipment_headers
      ON log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = log_shp_returnshipment_headers.Ext_Shipment_Header_RefID
      AND log_shp_shipment_headers.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_shp_shipment_headers.IsDeleted = log_shp_returnshipment_positions.IsDeleted
      AND log_shp_shipment_headers.IsCustomerReturnShipment = 0
      
    LEFT JOIN log_ret_returnpolicies
      ON log_ret_returnpolicies.LOG_RET_ReturnPolicyID = log_shp_returnshipment_positions.ReturnPolicy_RefID
      AND log_ret_returnpolicies.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND log_ret_returnpolicies.IsDeleted = log_shp_returnshipment_positions.IsDeleted
      
    WHERE
      log_shp_returnshipment_positions.Tenant_RefID = @TenantID
      AND log_shp_returnshipment_positions.IsDeleted = 0
      AND (@ReturnShipmentHeaderID IS NULL OR log_shp_returnshipment_positions.ReturnShipment_Header_RefID = @ReturnShipmentHeaderID);
  