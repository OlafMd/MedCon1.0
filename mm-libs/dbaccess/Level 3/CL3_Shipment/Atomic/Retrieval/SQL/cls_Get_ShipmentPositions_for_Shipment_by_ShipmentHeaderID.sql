

  Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Number,
  cmn_pro_products_de.Content As ProductName,
  cmn_pro_product_variants_de.Content As Variant,
  log_shp_shipment_positions.QuantityToShip
From
  log_shp_shipment_positions Inner Join
  log_shp_shipment_headers On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
    = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID Inner Join
  cmn_pro_products On log_shp_shipment_positions.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
    cmn_pro_products_de.DictID Inner Join
  cmn_pro_product_variants
    On log_shp_shipment_positions.CMN_PRO_ProductVariant_RefID =
    cmn_pro_product_variants.CMN_PRO_Product_VariantID Inner Join
  cmn_pro_product_variants_de On cmn_pro_product_variants.VariantName_DictID =
    cmn_pro_product_variants_de.DictID
Where
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
  @ShipmentHeaderID And
  cmn_pro_products_de.Language_RefID = @LanguageID And
  log_shp_shipment_headers.IsDeleted = 0 And
  log_shp_shipment_headers.Tenant_RefID =
  @TenantID And log_shp_shipment_positions.IsDeleted = 0 And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_product_variants.IsDeleted = 0 And
  cmn_pro_product_variants_de.Language_RefID =
  @LanguageID
    
    
