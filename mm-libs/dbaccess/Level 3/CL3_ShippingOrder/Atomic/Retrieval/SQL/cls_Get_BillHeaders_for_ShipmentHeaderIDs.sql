
        SELECT
          log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
          bil_billheaders.BIL_BillHeaderID,
          bil_billheaders.BillNumber
        FROM log_shp_shipment_headers
          INNER JOIN log_shp_shipment_positions
            ON log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
            AND log_shp_shipment_positions.Tenant_RefID = log_shp_shipment_headers.Tenant_RefID
            AND log_shp_shipment_positions.IsDeleted = log_shp_shipment_headers.IsDeleted
          INNER JOIN bil_billposition_2_shipmentposition
            ON bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
            AND bil_billposition_2_shipmentposition.Tenant_RefID = log_shp_shipment_headers.Tenant_RefID
            AND bil_billposition_2_shipmentposition.IsDeleted = log_shp_shipment_headers.IsDeleted
          INNER JOIN bil_billpositions
            ON bil_billpositions.BIL_BillPositionID = bil_billposition_2_shipmentposition.BIL_BillPosition_RefID
            AND bil_billpositions.Tenant_RefID = log_shp_shipment_headers.Tenant_RefID
            AND bil_billpositions.IsDeleted = log_shp_shipment_headers.IsDeleted
          INNER JOIN bil_billheaders
            ON bil_billheaders.BIL_BillHeaderID = bil_billpositions.BIL_BilHeader_RefID
            AND bil_billheaders.Tenant_RefID = log_shp_shipment_headers.Tenant_RefID
            AND bil_billheaders.IsDeleted = log_shp_shipment_headers.IsDeleted
        WHERE
          log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = @ShipmentHeaderIDs
          AND log_shp_shipment_headers.Tenant_RefID = @TenantID
          AND log_shp_shipment_headers.IsDeleted = 0
        GROUP BY
          bil_billheaders.BIL_BillHeaderID
        ORDER BY
          bil_billheaders.BillNumber;
  