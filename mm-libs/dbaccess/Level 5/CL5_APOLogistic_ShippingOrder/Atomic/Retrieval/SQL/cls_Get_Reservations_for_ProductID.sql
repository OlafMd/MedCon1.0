
	Select
	  log_shp_shipment_headers.ShipmentHeader_Number,
	  cmn_universalcontactdetails.CompanyName_Line1,
	  log_rsv_reservations.ReservedQuantity,
	  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
	  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
	  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	From
	  log_rsv_reservations Inner Join
	  log_shp_shipment_positions
	    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
	    log_rsv_reservations.LOG_SHP_Shipment_Position_RefID Inner Join
	  log_shp_shipment_headers
	    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
	    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID Inner Join
	  log_shp_shipmentheader_2_customerorderheader
	    On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
	    log_shp_shipmentheader_2_customerorderheader.LOG_SHP_Shipment_Header_RefID
	  Inner Join
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
	  log_rsv_reservations.IsDeleted = 0 And
	  log_rsv_reservations.IsReservationExecuted = 0 And
	  log_shp_shipment_positions.CMN_PRO_Product_RefID = @ProductID And
	  log_shp_shipment_positions.IsDeleted = 0 And
	  log_shp_shipment_positions.Tenant_RefID = @TenantID
  