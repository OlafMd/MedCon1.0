
Select
  log_shp_shipment_positions.CMN_PRO_Product_RefID,
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
  log_shp_shipment_headers.ShipmentHeader_Number,
  log_shp_shipment_headers.RecipientBusinessParticipant_RefID,
  cmn_bpt_businessparticipants_customer.DisplayName As CustomerName,
  log_shp_shipment_positions.QuantityToShip As Position_Quantity,
  log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax As
  Position_ValueTotal,
  log_shp_shipment_statushistory.Creation_Timestamp As StatusDeliveryDate,
  cmn_currencies.Symbol As CurrencySymbol,
  cmn_currencies.ISO4127 As CurrencyISO,
  log_shp_shipment_positions.ShipmentPosition_PricePerUnitValueWithoutTax As Position_ValuePerUnit
From
  log_shp_shipment_positions Inner Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
    log_shp_shipment_headers.Tenant_RefID = @TenantID And
    log_shp_shipment_headers.IsDeleted = 0 And
    log_shp_shipment_headers.IsShipped = 1 And log_shp_shipment_headers.IsBilled
    = 0 Inner Join
  log_shp_shipment_statushistory
    On log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
    log_shp_shipment_statushistory.IsDeleted = 0 And
    log_shp_shipment_statushistory.Tenant_RefID = @TenantID And
    log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID =
    @ShipmentStatusID Inner Join
  cmn_bpt_businessparticipants As cmn_bpt_businessparticipants_customer
    On log_shp_shipment_headers.RecipientBusinessParticipant_RefID =
    cmn_bpt_businessparticipants_customer.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants_customer.IsCompany = 1 And
    cmn_bpt_businessparticipants_customer.IsTenant = 1 And
    cmn_bpt_businessparticipants_customer.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants_customer.IsDeleted = 0 Left Outer Join
  bil_billposition_2_shipmentposition
    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
    bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID And
    bil_billposition_2_shipmentposition.IsDeleted = 0 And
    bil_billposition_2_shipmentposition.Tenant_RefID = @TenantID Inner Join
  cmn_currencies On log_shp_shipment_headers.ShipmentHeader_Currency_RefID =
    cmn_currencies.CMN_CurrencyID And cmn_currencies.IsDeleted = 0 And
    cmn_currencies.Tenant_RefID = @TenantID
Where
  log_shp_shipment_positions.Tenant_RefID = @TenantID And
  log_shp_shipment_positions.IsDeleted = 0 And
  bil_billposition_2_shipmentposition.AssignmentID Is Null
  