Select
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  log_shp_shipment_headers.IsShipped,
  log_shp_shipment_headers.ShipmentHeader_Number,
  log_shp_shipment_headers.IsPartiallyReadyForPicking,
  log_shp_shipment_headers.IsReadyForPicking,
  log_shp_shipment_headers.HasPickingStarted,
  log_shp_shipment_headers.HasPickingFinished,
  log_shp_shipment_headers.IsBilled,
  log_shp_shipment_headers.DemandDate,
  log_shp_shipment_headers.IsPartialShippingAllowed,
  log_shp_shipment_headers.IsManuallyCleared_ForPicking,
  log_shp_shipment_headers.Shippipng_AddressUCD_RefID,
  log_shp_shipment_headers.Creation_Timestamp
From
  log_shp_shipment_headers
Where
  log_shp_shipment_headers.IsShipped = IfNull(@IsShipped,
  log_shp_shipment_headers.IsShipped) And
  log_shp_shipment_headers.IsPartiallyReadyForPicking =
  IfNull(@IsPartiallyReadyForPicking,
  log_shp_shipment_headers.IsPartiallyReadyForPicking) And
  log_shp_shipment_headers.IsReadyForPicking = IfNull(@IsReadyForPicking,
  log_shp_shipment_headers.IsReadyForPicking) And
  log_shp_shipment_headers.HasPickingStarted = IfNull(@HasPickingStarted,
  log_shp_shipment_headers.HasPickingStarted) And
  log_shp_shipment_headers.HasPickingFinished = IfNull(@HasPickingFinished,
  log_shp_shipment_headers.HasPickingFinished) And
  log_shp_shipment_headers.IsBilled = IfNull(@IsBilled,
  log_shp_shipment_headers.IsBilled) And
  log_shp_shipment_headers.IsManuallyCleared_ForPicking =
  IfNull(@IsManuallyCleared_ForPicking,
  log_shp_shipment_headers.IsManuallyCleared_ForPicking) And
  log_shp_shipment_headers.Creation_Timestamp Between
  Coalesce(@ShipmentCreationDateFrom,
  log_shp_shipment_headers.Creation_Timestamp) And
  Coalesce(@ShipmentCreationDateTo, log_shp_shipment_headers.Creation_Timestamp) And
  (@ShipmentNumber Is Null Or
    Upper(log_shp_shipment_headers.ShipmentHeader_Number) Like Concat('%',
    Upper(@ShipmentNumber), '%')) And
  log_shp_shipment_headers.IsDeleted = 0 And
  log_shp_shipment_headers.Tenant_RefID = @TenantID