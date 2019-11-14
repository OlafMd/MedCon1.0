
Select
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
  log_shp_shipment_headers.ShipmentHeader_Number,
  ord_cuo_customerorder_headers.CustomerOrder_Number,
  ord_cuo_customerorder_headers.Creation_Timestamp As CustomerOrderCreationDate,
  log_shp_shipment_headers.Creation_Timestamp As ShippingCreationDate,
  log_shp_shipment_headers.IsPartiallyReadyForPicking,
  log_shp_shipment_headers.IsReadyForPicking,
  log_shp_shipment_headers.HasPickingStarted,
  log_shp_shipment_headers.HasPickingFinished,
  cmn_universalcontactdetails.CompanyName_Line1,
  log_shp_shipment_headers.IsManuallyCleared_ForPicking,
  log_shp_shipment_headers.IsBilled,
  log_shp_shipment_headers.IsShipped,
  log_shp_shipment_headers.Shippipng_AddressUCD_RefID
From
  log_shp_shipment_headers Inner Join
  log_shp_shipmentheader_2_customerorderheader
    On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
    log_shp_shipmentheader_2_customerorderheader.LOG_SHP_Shipment_Header_RefID
    And log_shp_shipment_headers.Tenant_RefID = @TenantID And
    log_shp_shipment_headers.IsDeleted = 0 Inner Join
  ord_cuo_customerorder_headers
    On
    log_shp_shipmentheader_2_customerorderheader.ORD_CUO_CustomerOrder_Header_RefID = ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID And log_shp_shipmentheader_2_customerorderheader.Tenant_RefID = @TenantID And log_shp_shipmentheader_2_customerorderheader.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And
    cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_com_companyinfo.Tenant_RefID = @TenantID
Where
  log_shp_shipment_headers.IsPartiallyReadyForPicking =
  IfNull(@IsPartiallyReadyForPicking,
  log_shp_shipment_headers.IsPartiallyReadyForPicking) And
  log_shp_shipment_headers.IsReadyForPicking = IfNull(@IsReadyForPicking,
  log_shp_shipment_headers.IsReadyForPicking) And
  log_shp_shipment_headers.HasPickingStarted = IfNull(@HasPickingStarted,
  log_shp_shipment_headers.HasPickingStarted) And
  log_shp_shipment_headers.HasPickingFinished = IfNull(@HasPickingFinished,
  log_shp_shipment_headers.HasPickingFinished) And
  log_shp_shipment_headers.IsManuallyCleared_ForPicking =
  IfNull(@IsManuallyCleared_ForPicking,
  log_shp_shipment_headers.IsManuallyCleared_ForPicking) And
  log_shp_shipment_headers.IsBilled = IfNull(@IsBilled,
  log_shp_shipment_headers.IsBilled) And
  log_shp_shipment_headers.IsShipped = IfNull(@IsShipped,
  log_shp_shipment_headers.IsShipped) And
  log_shp_shipment_headers.Tenant_RefID = @TenantID And
  log_shp_shipment_headers.IsDeleted = 0
Group By
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
  log_shp_shipment_headers.ShipmentHeader_Number,
  ord_cuo_customerorder_headers.CustomerOrder_Number,
  ord_cuo_customerorder_headers.Creation_Timestamp,
  log_shp_shipment_headers.Creation_Timestamp,
  log_shp_shipment_headers.IsPartiallyReadyForPicking,
  log_shp_shipment_headers.IsReadyForPicking,
  log_shp_shipment_headers.HasPickingStarted,
  log_shp_shipment_headers.HasPickingFinished,
  cmn_universalcontactdetails.CompanyName_Line1,
  log_shp_shipment_headers.IsManuallyCleared_ForPicking,
  log_shp_shipment_headers.IsBilled, log_shp_shipment_headers.IsShipped,
  log_shp_shipment_headers.Shippipng_AddressUCD_RefID
  