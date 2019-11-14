
Select
  bil_billpositions.BIL_BillPositionID,
  bil_billpositions.Quantity,
  bil_billpositions.PositionValue_BeforeTax,
  bil_billpositions.PositionValue_IncludingTax,
  ord_cuo_customerorderreturn_positions.CMN_PRO_Product_RefID,
  ord_cuo_customerorderreturn_positions.Position_ValuePerUnit,
  ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID,
  ord_cuo_customerorderreturn_headers.CustomerOrderReturnNumber,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_currencies.Symbol As CurrencySymbol,
  cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_SimpleName,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Description_DictID,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitNumber,
  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitSimpleName,
  cmn_bpt_ctm_organizationalunits.ExternalOrganizationalUnitNumber,
  ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID,
  ord_cuo_customerorderreturn_headers.Creation_Timestamp,
  ord_cuo_customerorderreturn_headers.DateOfCustomerReturn,
  bil_billpositions.PositionPricePerUnitValue_BeforeTax,
  bil_billpositions.PositionPricePerUnitValue_IncludingTax
From
  bil_billheaders Inner Join
  bil_billpositions On bil_billpositions.BIL_BilHeader_RefID =
    bil_billheaders.BIL_BillHeaderID And bil_billpositions.IsDeleted = 0 And
    bil_billpositions.Tenant_RefID = @TenantID Inner Join
  bil_billposition_2_customerorderreturnposition
    On bil_billposition_2_customerorderreturnposition.BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And
    bil_billposition_2_customerorderreturnposition.IsDeleted = 0 And
    bil_billposition_2_customerorderreturnposition.Tenant_RefID = @TenantID
  Inner Join
  ord_cuo_customerorderreturn_positions
    On
    bil_billposition_2_customerorderreturnposition.ORD_CUO_CustomerOrderReturn_Position_RefID = ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID And ord_cuo_customerorderreturn_positions.IsDeleted = 0 And ord_cuo_customerorderreturn_positions.Tenant_RefID = @TenantID Inner Join
  ord_cuo_customerorderreturn_headers
    On ord_cuo_customerorderreturn_positions.CustomerOrderReturnHeader_RefID =
    ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID And
    ord_cuo_customerorderreturn_headers.IsDeleted = 0 And
    ord_cuo_customerorderreturn_headers.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_ctm_customers On ord_cuo_customerorderreturn_headers.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
    cmn_bpt_ctm_customers.IsDeleted = 0 And cmn_bpt_ctm_customers.Tenant_RefID =
    @TenantID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Left Join
  cmn_currencies On bil_billheaders.Currency_RefID =
    cmn_currencies.CMN_CurrencyID And cmn_currencies.IsDeleted = 0 Left Join
  bil_billposition_2_shipmentposition On bil_billpositions.BIL_BillPositionID =
    bil_billposition_2_shipmentposition.BIL_BillPosition_RefID And
    bil_billposition_2_shipmentposition.Tenant_RefID = @TenantID Left Join
  log_shp_shipment_positions
    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
    bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID And
    log_shp_shipment_positions.IsDeleted = 0 And
    log_shp_shipment_positions.Tenant_RefID = @TenantID Left Join
  ord_cuo_position_customerorganizationalunitdistribution
    On
    ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID
    =
    ord_cuo_position_customerorganizationalunitdistribution.ORD_CUO_CustomerOrder_Position_RefID Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID =
    ord_cuo_position_customerorganizationalunitdistribution.CMN_BPT_CTM_OrganizationalUnit_RefID
Where
  bil_billheaders.BIL_BillHeaderID = @BillHeaderID And
  bil_billheaders.IsDeleted = 0 And
  bil_billheaders.Tenant_RefID = @TenantID
  