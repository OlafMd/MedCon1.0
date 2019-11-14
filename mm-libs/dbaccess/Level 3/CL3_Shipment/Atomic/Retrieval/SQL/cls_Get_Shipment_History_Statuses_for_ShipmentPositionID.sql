
 
Select
  log_shp_shipment_statushistory.LOG_SHP_Shipment_StatusHistoryID,
  log_shp_shipment_statushistory.Creation_Timestamp As StatusCreationTime,
  log_shp_shipment_statushistory.Comment,
  log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID,
  log_shp_shipment_statuses.GlobalPropertyMatchingID As Status
From
  log_shp_shipment_statuses Inner Join
  log_shp_shipment_statushistory
    On log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID =
    log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID
Where
  log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID =
  @ShipmentHeaderID And
  log_shp_shipment_statushistory.IsDeleted = 0 And
  log_shp_shipment_statushistory.Tenant_RefID = @TenantID And
  log_shp_shipment_statuses.IsDeleted = 0 And
  log_shp_shipment_statuses.Tenant_RefID = @TenantID
Order By
  StatusCreationTime

