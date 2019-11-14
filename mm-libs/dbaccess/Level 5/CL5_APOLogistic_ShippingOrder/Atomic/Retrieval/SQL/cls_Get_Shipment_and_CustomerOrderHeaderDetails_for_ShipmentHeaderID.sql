
Select
  x.*,
  Count(log_shp_shipment_notes.LOG_SHP_Shipment_NoteID) As NotesCount
From
  (Select
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
    ord_cuo_customerorder_headers.CustomerOrder_Number,
    ord_cuo_customerorder_headers.CustomerOrder_Date,
    log_shp_shipment_headers.ShipmentHeader_Number,
    log_shp_shipment_headers.Creation_Timestamp As ShippingDate,
    log_shp_shipment_types.LOG_SHP_Shipment_TypeID,
    log_shp_shipment_types.ShipmentType_Name_DictID,
    ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID,
    ord_cuo_customerorder_position_2_shipmentposition.CMN_BPT_CTM_OrganizationalUnit_RefID,
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID
  From
    log_shp_shipment_headers Left Join
    log_shp_shipment_positions
      On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
      log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
      log_shp_shipment_positions.Tenant_RefID = @TenantID And
      log_shp_shipment_positions.IsDeleted = 0 Inner Join
    log_shp_shipmentheader_2_customerorderheader
      On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
      log_shp_shipmentheader_2_customerorderheader.LOG_SHP_Shipment_Header_RefID
      And log_shp_shipmentheader_2_customerorderheader.Tenant_RefID = @TenantID
    Inner Join
    ord_cuo_customerorder_headers
      On ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
      log_shp_shipmentheader_2_customerorderheader.ORD_CUO_CustomerOrder_Header_RefID And ord_cuo_customerorder_headers.Tenant_RefID = @TenantID Left Join
    log_shp_shipment_types On log_shp_shipment_headers.ShipmentType_RefID =
      log_shp_shipment_types.LOG_SHP_Shipment_TypeID And
      log_shp_shipment_headers.IsDeleted = 0 And
      log_shp_shipment_headers.Tenant_RefID = @TenantID Left Join
    ord_cuo_customerorder_position_2_shipmentposition
      On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
      ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID And ord_cuo_customerorder_position_2_shipmentposition.Tenant_RefID = @TenantID And ord_cuo_customerorder_position_2_shipmentposition.IsDeleted = 0 Inner Join
    cmn_bpt_businessparticipants
      On log_shp_shipment_headers.RecipientBusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
    cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID
      = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = @ShippingHeaderID And
    log_shp_shipment_headers.IsDeleted = 0 And
    log_shp_shipment_headers.Tenant_RefID = @TenantID
  Group By
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID) x Left Join
  log_shp_shipment_notes On log_shp_shipment_notes.Shipment_Header_RefID =
    x.LOG_SHP_Shipment_HeaderID And log_shp_shipment_notes.Tenant_RefID =
    @TenantID And log_shp_shipment_notes.IsDeleted = 0
  