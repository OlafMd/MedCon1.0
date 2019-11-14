
Select
  hec_shippingposition_barcodelabels.HEC_ShippingPosition_BarcodeLabelID,
  hec_shippingposition_barcodelabels.ShippingPosition_BarcodeLabel,
  hec_shippingposition_barcodelabels.R_IsSubmission_Complete,
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  hec_shippingposition_barcodelabels.Creation_Timestamp,
  log_shp_shipment_headers.Creation_Timestamp As Header_Creation_Timestamp
From
  hec_shippingposition_barcodelabels Inner Join
  log_shp_shipment_positions
    On hec_shippingposition_barcodelabels.LOG_SHP_Shipment_Position_RefID =
    log_shp_shipment_positions.LOG_SHP_Shipment_PositionID Inner Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
Where
  hec_shippingposition_barcodelabels.IsDeleted = 0 And
  log_shp_shipment_positions.IsDeleted = 0 And
  log_shp_shipment_headers.IsDeleted = 0 And
  hec_shippingposition_barcodelabels.Tenant_RefID = @TenantID And
  log_shp_shipment_headers.IsShipped = 0 And
  hec_shippingposition_barcodelabels.Doctor_RefID = @HEC_DoctorID And
  hec_shippingposition_barcodelabels.Creation_Timestamp >= @FormDate And
  hec_shippingposition_barcodelabels.Creation_Timestamp <= @ToDate 
  