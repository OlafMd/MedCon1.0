
     SELECT
		log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID
	FROM log_shp_shipment_statuses
	WHERE 
 		log_shp_shipment_statuses.GlobalPropertyMatchingID = @GlobalPropertyMatchingID
		AND log_shp_shipment_statuses.IsDeleted = 0
		AND log_shp_shipment_statuses.Tenant_RefID = @TenantID
  