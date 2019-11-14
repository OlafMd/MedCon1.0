
Select Distinct
  cmn_bpt_ctm_organizationalunit_addresses.IsPrimary,
  cmn_bpt_ctm_organizationalunit_addresses.AddressType,
  cmn_universalcontactdetails.IsCompany,
  cmn_universalcontactdetails.PostalAddress_Number,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.CompanyName_Line1,
  cmn_universalcontactdetails.CompanyName_Line2,
  cmn_universalcontactdetails.PostalAddress_Formatted,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.CMN_UniversalContactDetailID,
  cmn_universalcontactdetails.ZIP
From
  log_shp_shipment_headers Inner Join
  log_shp_shipment_positions
    On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
    log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID Left Join
  ord_cuo_customerorder_position_2_shipmentposition
    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID And ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID Is Not Null Left Join
  cmn_bpt_ctm_organizationalunit_addresses
    On
    ord_cuo_customerorder_position_2_shipmentposition.CMN_BPT_CTM_OrganizationalUnit_RefID = cmn_bpt_ctm_organizationalunit_addresses.OrganizationalUnit_RefID And cmn_bpt_ctm_organizationalunit_addresses.AddressType = 1 Left Join
  cmn_universalcontactdetails
    On cmn_universalcontactdetails.CMN_UniversalContactDetailID =
    cmn_bpt_ctm_organizationalunit_addresses.UniversalContactDetail_Address_RefID
Where
  log_shp_shipment_headers.Tenant_RefID = @TenantID And
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = @ShipmentHeaderID
  