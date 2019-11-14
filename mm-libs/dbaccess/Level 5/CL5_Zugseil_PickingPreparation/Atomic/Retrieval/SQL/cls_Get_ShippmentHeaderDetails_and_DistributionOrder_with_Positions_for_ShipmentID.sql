
	Select
	  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
	  log_shp_shipment_headers.ShipmentHeader_Number,
	  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
	  cmn_pro_products.CMN_PRO_ProductID,
	  cmn_pro_products.Product_Name_DictID,
	  cmn_pro_products.Product_Number,
	  cmn_pro_product_variants.CMN_PRO_Product_VariantID,
	  cmn_pro_product_variants.VariantName_DictID,
	  ord_dis_distributionorder_positions.Quantity,
	  ord_dis_distributionorder_positions.ORD_DIS_DistributionOrder_PositionID,
	  ord_dis_distributionorder_positions.DistributionOrder_Header_RefID,
	  ord_dis_distributionorder_headers.ORD_DIS_DistributionOrder_HeaderID,
	  ord_dis_distributionorder_headers.DistributionOrderDate,
	  ord_dis_distributionorder_headers.DistributionOrderNumber,
	  cmn_str_costcenters.CMN_STR_CostCenterID,
	  cmn_str_costcenters.Name_DictID,
	  cmn_str_offices.CMN_STR_OfficeID,
	  cmn_str_offices.Office_Name_DictID,
	  cmn_str_offices.Office_InternalName,
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
      log_shp_shipment_headers.Creation_Timestamp as ShipmentCreationDate
	From
	  log_shp_shipment_positions Inner Join
	  cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
	    log_shp_shipment_positions.CMN_PRO_Product_RefID Inner Join
	  cmn_pro_product_variants On cmn_pro_product_variants.CMN_PRO_Product_VariantID
	    = log_shp_shipment_positions.CMN_PRO_ProductVariant_RefID Inner Join
	  ord_dis_distributionorderposition_2_shipmentorderposition
	    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
	    ord_dis_distributionorderposition_2_shipmentorderposition.LOG_SHP_Shipment_Position_RefID Inner Join
	  ord_dis_distributionorder_positions
	    On ord_dis_distributionorder_positions.ORD_DIS_DistributionOrder_PositionID
	    =
	    ord_dis_distributionorderposition_2_shipmentorderposition.ORD_DIS_DistributionOrder_Position_RefID Inner Join
	  ord_dis_distributionorder_headers
	    On ord_dis_distributionorder_headers.ORD_DIS_DistributionOrder_HeaderID =
	    ord_dis_distributionorder_positions.DistributionOrder_Header_RefID Left Join
	  cmn_str_costcenters On cmn_str_costcenters.CMN_STR_CostCenterID =
	    ord_dis_distributionorder_headers.Charged_CostCenter_RefID Inner Join
	  cmn_str_office_2_costcenter On cmn_str_costcenters.CMN_STR_CostCenterID =
	    cmn_str_office_2_costcenter.CostCenter_RefID Inner Join
	  cmn_str_offices On cmn_str_offices.CMN_STR_OfficeID =
	    cmn_str_office_2_costcenter.Office_RefID Left Join
	  cmn_str_office_addresses On cmn_str_offices.CMN_STR_OfficeID =
	    cmn_str_office_addresses.Office_RefID Left Join
	  cmn_addresses On cmn_addresses.CMN_AddressID =
	    cmn_str_office_addresses.CMN_Address_RefID Right Join
	  log_shp_shipment_headers On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
	    = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID
	Where
	  log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = @ShipmentHeaderID
	  And
	  log_shp_shipment_positions.IsDeleted = 0 And
	  log_shp_shipment_positions.Tenant_RefID = @TenantID
  