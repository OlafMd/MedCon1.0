
	Select
	  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
	  log_shp_shipment_headers.ShipmentHeader_Number,
	  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
	  cmn_pro_products.CMN_PRO_ProductID,
	  cmn_pro_products.Product_Name_DictID,
	  cmn_pro_products.Product_Number,
	  cmn_pro_product_variants.CMN_PRO_Product_VariantID,
	  cmn_pro_product_variants.VariantName_DictID,
	  cmn_str_office_addresses.IsShippingAddress,
	  cmn_str_office_addresses.IsBillingAddress,
	  cmn_str_office_addresses.IsSpecialAddress,
	  cmn_str_office_addresses.IsDefault,
	  cmn_addresses.CMN_AddressID,
	  cmn_addresses.Street_Name,
	  cmn_addresses.Street_Number,
	  cmn_addresses.City_Name,
	  cmn_addresses.City_PostalCode,
	  cmn_addresses.Country_Name,
	  cmn_addresses.Country_ISOCode,
	  log_shp_shipment_headers.Creation_Timestamp As ShipmentCreationDate,
	  ord_cuo_customerorder_positions.Position_Quantity,
	  ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID,
	  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
	  ord_cuo_customerorder_headers.CustomerOrder_Number,
	  ord_cuo_customerorder_headers.CustomerOrder_Date,
	  cmn_bpt_businessparticipants.DisplayName
	From
	  log_shp_shipment_positions Inner Join
	  cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
	    log_shp_shipment_positions.CMN_PRO_Product_RefID Inner Join
	  cmn_pro_product_variants On cmn_pro_product_variants.CMN_PRO_Product_VariantID
	    = log_shp_shipment_positions.CMN_PRO_ProductVariant_RefID Right Join
	  log_shp_shipment_headers On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
	    = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID Inner Join
	  ord_cuo_customerorder_position_2_shipmentposition
	    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
	    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID Inner Join
	  ord_cuo_customerorder_positions
	    On ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID =
	    ord_cuo_customerorder_position_2_shipmentposition.ORD_CUO_CustomerOrder_Position_RefID Inner Join
	  ord_cuo_customerorder_headers
	    On ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
	    ord_cuo_customerorder_positions.CustomerOrder_Header_RefID Left Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
	    ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID,
	  cmn_str_office_addresses Left Join
	  cmn_addresses On cmn_addresses.CMN_AddressID =
	    cmn_str_office_addresses.CMN_Address_RefID
	Where
	  log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = @ShipmentHeaderID
	  And
	  log_shp_shipment_positions.IsDeleted = 0 And
	  log_shp_shipment_positions.Tenant_RefID = @TenantID
  