
Select
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  log_shp_shipment_headers.ShipmentHeader_Number,
  ord_cuo_customerorder_headers.CustomerOrder_Number,
  ord_cuo_customerorder_headers.CustomerOrder_Date,
  log_shp_shipment_headers.Creation_Timestamp As ShipmentOrderDate,
  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
  Count(log_shp_shipment_positions.LOG_SHP_Shipment_PositionID) As
  ShipmentPositionsCount,
  Count(bil_billposition_2_shipmentposition.BIL_BillPosition_RefID) As
  BillPositionsCount,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitNumber,
  cmn_bpt_ctm_organizationalunits.ExternalOrganizationalUnitNumber,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_SimpleName,
  log_shp_shipment_statuses.GlobalPropertyMatchingID,
    
  log_shp_shipment_statushistory.Creation_Timestamp As StatusDate
From
  log_shp_shipmentheader_2_customerorderheader Inner Join
  log_shp_shipment_headers On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
    = log_shp_shipmentheader_2_customerorderheader.LOG_SHP_Shipment_Header_RefID
  Inner Join
  ord_cuo_customerorder_headers
    On ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
    log_shp_shipmentheader_2_customerorderheader.ORD_CUO_CustomerOrder_Header_RefID Left Join
  log_shp_shipment_positions
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID Left Join
  bil_billposition_2_shipmentposition
    On bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID =
    log_shp_shipment_positions.LOG_SHP_Shipment_PositionID Left Join
  log_shp_shipment_statushistory
    On log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID Left Join
  log_shp_shipment_statuses
    On log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID =
    log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID Left Join
  ord_cuo_customerorder_position_2_shipmentposition
    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID Left Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID =
    ord_cuo_customerorder_position_2_shipmentposition.CMN_BPT_CTM_OrganizationalUnit_RefID
Where
  log_shp_shipmentheader_2_customerorderheader.ORD_CUO_CustomerOrder_Header_RefID = @CustomerOrderHeaderID And
  log_shp_shipmentheader_2_customerorderheader.IsDeleted = 0
Group By
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitNumber,
  cmn_bpt_ctm_organizationalunits.ExternalOrganizationalUnitNumber,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_SimpleName,
  log_shp_shipmentheader_2_customerorderheader.ORD_CUO_CustomerOrder_Header_RefID, log_shp_shipment_statuses.GlobalPropertyMatchingID

  