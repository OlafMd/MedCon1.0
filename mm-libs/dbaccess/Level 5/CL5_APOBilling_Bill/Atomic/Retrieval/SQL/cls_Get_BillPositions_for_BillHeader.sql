
Select
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
  log_shp_shipment_headers.ShipmentHeader_Number,
  log_shp_shipment_headers.RecipientBusinessParticipant_RefID,
  cmn_bpt_businessparticipants_customer.DisplayName As CustomerName,
  log_shp_shipment_positions.CMN_PRO_Product_RefID,
  bil_billpositions.BIL_BillPositionID,
  bil_billpositions.Quantity,
  bil_billpositions.PositionValue_BeforeTax,
  bil_billpositions.PositionValue_IncludingTax,
  log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax,
  cmn_currencies.Symbol As CurrencySymbol,
  log_shp_shipment_statushistory.Creation_Timestamp As StatusDeliveryDate,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_SimpleName,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID,
  cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID,
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  log_shp_shipment_headers.Creation_Timestamp As
  LOG_SHP_ShipmentHeader_Creation_Timestamp,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Description_DictID,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitNumber,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitSimpleName,
  cmn_bpt_ctm_organizationalunits.ExternalOrganizationalUnitNumber,
  bil_billpositions.PositionPricePerUnitValue_BeforeTax,
  bil_billpositions.PositionPricePerUnitValue_IncludingTax
From
  bil_billpositions Inner Join
  bil_billheaders On bil_billpositions.BIL_BilHeader_RefID =
    bil_billheaders.BIL_BillHeaderID And bil_billheaders.IsDeleted = 0
    And bil_billheaders.Tenant_RefID = @TenantID Inner Join
  bil_billposition_2_shipmentposition On bil_billpositions.BIL_BillPositionID =
    bil_billposition_2_shipmentposition.BIL_BillPosition_RefID And
    bil_billposition_2_shipmentposition.IsDeleted = 0 And
    bil_billposition_2_shipmentposition.Tenant_RefID = @TenantID Inner Join
  log_shp_shipment_positions
    On bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID =
    log_shp_shipment_positions.LOG_SHP_Shipment_PositionID And
    log_shp_shipment_positions.IsDeleted = 0 And
    log_shp_shipment_positions.Tenant_RefID = @TenantID Inner Join
  log_shp_shipment_headers On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
    = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID And
    log_shp_shipment_headers.IsDeleted = 0 And
    log_shp_shipment_headers.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants As cmn_bpt_businessparticipants_customer
    On log_shp_shipment_headers.RecipientBusinessParticipant_RefID =
    cmn_bpt_businessparticipants_customer.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants_customer.IsDeleted = 0 And
    cmn_bpt_businessparticipants_customer.Tenant_RefID = @TenantID Inner Join
  log_shp_shipment_statushistory
    On log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
    log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID =
    @ShipmentStatusID And log_shp_shipment_statushistory.IsDeleted = 0
    And log_shp_shipment_statushistory.Tenant_RefID = @TenantID Left Join
  cmn_currencies On bil_billheaders.Currency_RefID =
    cmn_currencies.CMN_CurrencyID And cmn_currencies.IsDeleted = 0 Left Join
  ord_cuo_customerorder_position_2_shipmentposition
    On
    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID Left Join
  cmn_bpt_ctm_organizationalunits
    On
    ord_cuo_customerorder_position_2_shipmentposition.CMN_BPT_CTM_OrganizationalUnit_RefID = cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID
Where
  bil_billpositions.Tenant_RefID = @TenantID And
  bil_billpositions.IsDeleted = 0 And
  bil_billheaders.BIL_BillHeaderID = @BillHeaderID
  