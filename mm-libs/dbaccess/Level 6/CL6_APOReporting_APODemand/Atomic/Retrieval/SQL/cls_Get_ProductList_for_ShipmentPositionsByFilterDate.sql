
Select
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.CMN_PRO_ProductID,
  log_shp_shipment_headers.IsShipped,
  log_shp_shipment_statuses.GlobalPropertyMatchingID,
  log_shp_shipment_statushistory.Creation_Timestamp,
  log_shp_shipment_headers.RecipientBusinessParticipant_RefID,
  log_shp_shipment_positions.QuantityToShip,
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  cmn_pro_products.Tenant_RefID,
  cmn_pro_products.IsDeleted,
  cmn_pro_products.Product_Number
From
  cmn_pro_products Inner Join
  log_shp_shipment_positions On cmn_pro_products.CMN_PRO_ProductID =
    log_shp_shipment_positions.CMN_PRO_Product_RefID Inner Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID Inner Join
  log_shp_shipment_statushistory
    On log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID Inner Join
  log_shp_shipment_statuses
    On log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID =
    log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID
Where
  log_shp_shipment_headers.IsShipped = 1 And
  log_shp_shipment_statuses.GlobalPropertyMatchingID = 'shipment-statuses.shipped' And
  log_shp_shipment_statushistory.Creation_Timestamp Between @DateFrom And
  @DateTo And
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_products.IsDeleted = 0
Group By
  cmn_pro_products.Product_Name_DictID, cmn_pro_products.CMN_PRO_ProductID,
  log_shp_shipment_headers.IsShipped,
  log_shp_shipment_statuses.GlobalPropertyMatchingID,
  log_shp_shipment_statushistory.Creation_Timestamp,
  log_shp_shipment_headers.RecipientBusinessParticipant_RefID,
  log_shp_shipment_positions.QuantityToShip,
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  cmn_pro_products.Tenant_RefID, cmn_pro_products.IsDeleted,
  cmn_pro_products.Product_Number
Having
  log_shp_shipment_headers.RecipientBusinessParticipant_RefID = @CustomerID
  