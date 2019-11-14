
    SELECT
      bil_billpositions.BIL_BillPositionID,
      log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
      log_shp_shipment_headers.ShipmentHeader_Number,
      ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID,
      ord_cuo_customerorderreturn_headers.CustomerOrderReturnNumber
    FROM bil_billpositions
    LEFT JOIN bil_billposition_2_shipmentposition
      ON bil_billposition_2_shipmentposition.BIL_BillPosition_RefID = bil_billpositions.BIL_BillPositionID
      AND bil_billposition_2_shipmentposition.Tenant_RefID = bil_billpositions.Tenant_RefID
      AND bil_billposition_2_shipmentposition.IsDeleted = bil_billpositions.IsDeleted
    LEFT JOIN log_shp_shipment_positions
      ON log_shp_shipment_positions.LOG_SHP_Shipment_PositionID = bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID
      AND log_shp_shipment_positions.Tenant_RefID = bil_billpositions.Tenant_RefID
      AND log_shp_shipment_positions.IsDeleted = bil_billpositions.IsDeleted
    LEFT JOIN log_shp_shipment_headers
      ON log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID
      AND log_shp_shipment_headers.Tenant_RefID = bil_billpositions.Tenant_RefID
      AND log_shp_shipment_headers.IsDeleted = bil_billpositions.IsDeleted
    LEFT JOIN bil_billposition_2_customerorderreturnposition
      ON bil_billposition_2_customerorderreturnposition.BIL_BillPosition_RefID = bil_billpositions.BIL_BillPositionID
      AND bil_billposition_2_customerorderreturnposition.Tenant_RefID = bil_billpositions.Tenant_RefID
      AND bil_billposition_2_customerorderreturnposition.IsDeleted = bil_billpositions.IsDeleted
    LEFT JOIN ord_cuo_customerorderreturn_positions
      ON ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID = bil_billposition_2_customerorderreturnposition.ORD_CUO_CustomerOrderReturn_Position_RefID
      AND ord_cuo_customerorderreturn_positions.Tenant_RefID = bil_billpositions.Tenant_RefID
      AND ord_cuo_customerorderreturn_positions.IsDeleted = bil_billpositions.IsDeleted 
    LEFT JOIN ord_cuo_customerorderreturn_headers
      ON ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID = ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID
      AND ord_cuo_customerorderreturn_headers.Tenant_RefID = bil_billpositions.Tenant_RefID
      AND ord_cuo_customerorderreturn_headers.IsDeleted = bil_billpositions.IsDeleted 
    WHERE 
      bil_billpositions.BIL_BillPositionID = @BillPositionIDs
      AND bil_billpositions.Tenant_RefID = @TenantID
      AND bil_billpositions.IsDeleted = 0;
  