
	Select
	  cmn_universalcontactdetails.Street_Name,
	  cmn_universalcontactdetails.Street_Number,
	  cmn_universalcontactdetails.ZIP,
	  cmn_universalcontactdetails.Town,
	  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
	From
	  log_shp_shipment_headers Inner Join
	  cmn_universalcontactdetails
	    On log_shp_shipment_headers.Shippipng_AddressUCD_RefID =
	    cmn_universalcontactdetails.CMN_UniversalContactDetailID
	Where
	  log_shp_shipment_headers.IsDeleted = 0 And
	  log_shp_shipment_headers.Tenant_RefID = @TenantID And
	  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = @ShipmentHeaderID
  