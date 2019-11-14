
    SELECT
      log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
    FROM log_shp_shipment_positions
    LEFT JOIN bil_billposition_2_shipmentposition
      ON log_shp_shipment_positions.LOG_SHP_Shipment_PositionID = bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID
      AND bil_billposition_2_shipmentposition.IsDeleted = 0
      AND bil_billposition_2_shipmentposition.Tenant_RefID = @TenantID
    WHERE 
      log_shp_shipment_positions.Tenant_RefID = @TenantID
      AND log_shp_shipment_positions.IsDeleted = 0
      AND bil_billposition_2_shipmentposition.AssignmentID IS NULL
      AND log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = @ShipmentHeaderIDs

  