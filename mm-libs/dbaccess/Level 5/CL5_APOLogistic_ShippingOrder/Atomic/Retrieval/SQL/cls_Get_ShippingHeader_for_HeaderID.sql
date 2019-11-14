
	Select
	  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
	  cmn_universalcontactdetails.CompanyName_Line1,
	  log_shp_shipment_headers.IsDeleted,
	  log_shp_shipment_headers.IsReadyForPicking,
	  ord_cuo_customerorder_headers.CustomerOrder_Number
	From
	  log_shp_shipment_headers Inner Join
	  log_shp_shipmentheader_2_customerorderheader
	    On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
	    log_shp_shipmentheader_2_customerorderheader.LOG_SHP_Shipment_Header_RefID
	    And log_shp_shipmentheader_2_customerorderheader.Tenant_RefID = @TenantID
	  Inner Join
	  ord_cuo_customerorder_headers
	    On ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
	    log_shp_shipmentheader_2_customerorderheader.ORD_CUO_CustomerOrder_Header_RefID And ord_cuo_customerorder_headers.Tenant_RefID = @TenantID Inner Join
	  cmn_bpt_businessparticipants
	    On ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID
	    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
	  cmn_com_companyinfo
	    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID And
	    cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
	  cmn_universalcontactdetails
	    On cmn_universalcontactdetails.CMN_UniversalContactDetailID =
	    cmn_com_companyinfo.Contact_UCD_RefID And
	    cmn_universalcontactdetails.Tenant_RefID = @TenantID
	Where
	  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = @HeaderID And
	  log_shp_shipment_headers.IsDeleted = 0 And
	  log_shp_shipment_headers.Tenant_RefID = @TenantID And
	  log_shp_shipment_headers.IsReadyForPicking = 1
  