
Select
  RecepientBP.DisplayName RecepientBP,
  log_shp_shipment_positions.QuantityToShip,
  log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax,
  log_shp_shipment_statushistory.Creation_Timestamp,
  IsShipedStatusCreator.DisplayName ShippedStatusCreator,
  ord_cuo_customerorder_headers.CustomerOrder_Number,
  log_shp_shipment_headers.ShipmentHeader_Number,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitSimpleName
From
  log_shp_shipment_positions Inner Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
    log_shp_shipment_headers.IsDeleted = 0 And
    log_shp_shipment_headers.IsShipped = 1 Inner Join
  cmn_bpt_businessparticipants RecepientBP
    On log_shp_shipment_headers.RecipientBusinessParticipant_RefID =
    RecepientBP.CMN_BPT_BusinessParticipantID And RecepientBP.IsDeleted = 0
  Inner Join
  log_shp_shipment_statushistory
    On log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
    log_shp_shipment_statushistory.IsDeleted = 0 Inner Join
  log_shp_shipment_statuses
    On log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID =
    log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID And
    log_shp_shipment_statuses.IsDeleted = 0 And
    log_shp_shipment_statuses.GlobalPropertyMatchingID = @Status Inner Join
  cmn_bpt_businessparticipants IsShipedStatusCreator
    On log_shp_shipment_statushistory.PerformedBy_BusinessParticipant_RefID =
    IsShipedStatusCreator.CMN_BPT_BusinessParticipantID Inner Join
  log_shp_shipmentheader_2_customerorderheader
    On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
    log_shp_shipmentheader_2_customerorderheader.LOG_SHP_Shipment_Header_RefID
  Inner Join
  ord_cuo_customerorder_headers
    On ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
    log_shp_shipmentheader_2_customerorderheader.ORD_CUO_CustomerOrder_Header_RefID Inner Join
  ord_cuo_customerorder_position_2_shipmentposition
    On
    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID Inner Join
  cmn_bpt_ctm_organizationalunits
    On
    ord_cuo_customerorder_position_2_shipmentposition.CMN_BPT_CTM_OrganizationalUnit_RefID = cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID
Where
  log_shp_shipment_positions.CMN_PRO_Product_RefID = @ArticleID And
  log_shp_shipment_positions.Tenant_RefID = @TenantID And
  log_shp_shipment_positions.IsDeleted = 0
  