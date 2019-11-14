
    
Select
  bil_billpositions.BIL_BillPositionID,
  bil_billpositions.PositionValue_BeforeTax as BillPosition_Value_BeforeTax,
  bil_billpositions.PositionValue_IncludingTax as BillPosition_Value_AfterTax,
  acc_tax_taxes.ACC_TAX_TaxeID,
  acc_tax_taxes.TaxRate,
  acc_tax_taxes.TaxName_DictID,
  cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_SimpleName,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Description_DictID,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitNumber,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitSimpleName,
  cmn_bpt_ctm_organizationalunits.ExternalOrganizationalUnitNumber,
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  log_shp_shipment_headers.ShipmentHeader_Number,
  log_shp_shipment_headers.Creation_Timestamp as ShipmentHeader_Creation_Timestamp
From
  bil_billpositions Left Join
  acc_tax_taxes On bil_billpositions.ApplicableSalesTax_RefID =
    acc_tax_taxes.ACC_TAX_TaxeID And acc_tax_taxes.IsDeleted = 0 And
    acc_tax_taxes.Tenant_RefID = @TenantID Left Join
  bil_billposition_2_shipmentposition On bil_billpositions.BIL_BillPositionID =
    bil_billposition_2_shipmentposition.BIL_BillPosition_RefID And
    bil_billposition_2_shipmentposition.IsDeleted = 0 And
    bil_billposition_2_shipmentposition.Tenant_RefID = @TenantID Left Join
  ord_cuo_customerorder_position_2_shipmentposition
    On bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID =
    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID And ord_cuo_customerorder_position_2_shipmentposition.IsDeleted = 0 And ord_cuo_customerorder_position_2_shipmentposition.Tenant_RefID = @TenantID Left Join
  cmn_bpt_ctm_organizationalunits
    On
    ord_cuo_customerorder_position_2_shipmentposition.CMN_BPT_CTM_OrganizationalUnit_RefID = cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID Left Join
  log_shp_shipment_positions
    On bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID =
    log_shp_shipment_positions.LOG_SHP_Shipment_PositionID And
    log_shp_shipment_positions.IsDeleted = 0 And
    log_shp_shipment_positions.Tenant_RefID = @TenantID Inner Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
    log_shp_shipment_headers.IsDeleted = 0 And
    log_shp_shipment_headers.Tenant_RefID = @TenantID and 
  bil_billpositions.BIL_BilHeader_RefID = @BillHeaderID
    
  