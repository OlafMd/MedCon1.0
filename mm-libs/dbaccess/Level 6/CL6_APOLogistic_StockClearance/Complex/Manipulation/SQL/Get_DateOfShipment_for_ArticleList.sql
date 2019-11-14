
	SELECT
	  log_shp_shipment_statushistory.Creation_Timestamp,
	  log_shp_shipment_positions.CMN_PRO_Product_RefID,
      log_shp_shipment_statuses.GlobalPropertyMatchingID
	FROM log_shp_shipment_positions 
    INNER JOIN log_shp_shipment_statushistory
	  ON log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID 
    INNER JOIN log_shp_shipment_statuses
	  ON log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID = log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID
	WHERE
        log_shp_shipment_positions.CMN_PRO_Product_RefID = @ProductID_List 
        AND log_shp_shipment_positions.Tenant_RefID = @TenantId 
        AND (@shipmentStatus IS NULL OR log_shp_shipment_statuses.GlobalPropertyMatchingID = @shipmentStatus)
        AND (@DateFrom Is null or log_shp_shipment_statushistory.Creation_Timestamp >= @DateFrom)
  