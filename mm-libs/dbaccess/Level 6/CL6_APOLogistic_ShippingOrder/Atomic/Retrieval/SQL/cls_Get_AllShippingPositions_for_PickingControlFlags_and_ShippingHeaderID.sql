
Select
  cmn_pro_products.Product_Number,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_units.ISOCode,
  cmn_pro_pac_packageinfo.PackageContent_Amount,
  hec_product_dosageforms.GlobalPropertyMatchingID,
  hec_product_dosageforms.DosageForm_Name_DictID,
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
  log_shp_shipment_positions.QuantityToShip,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.DisplayName As ProducerName,
  ord_cuo_customerorder_position_2_shipmentposition.IsDeleted,
  cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_SimpleName,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID
From
  log_shp_shipment_headers Inner Join
  log_shp_shipment_positions
    On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
    log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID And
    log_shp_shipment_positions.IsDeleted = 0 Inner Join
  cmn_pro_products On log_shp_shipment_positions.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID Inner Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID Inner Join
  hec_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_pro_products.ProducingBusinessParticipant_RefID Inner Join
  ord_cuo_customerorder_position_2_shipmentposition
    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID =
    ord_cuo_customerorder_position_2_shipmentposition.CMN_BPT_CTM_OrganizationalUnit_RefID
Where
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = @ShippmentHeaderID And
  ord_cuo_customerorder_position_2_shipmentposition.IsDeleted = 0 And
  log_shp_shipment_headers.Tenant_RefID = @TenantID And
  log_shp_shipment_headers.IsDeleted = 0 And
  log_shp_shipment_headers.HasPickingStarted = 1 And
  log_shp_shipment_headers.HasPickingFinished = 0
  