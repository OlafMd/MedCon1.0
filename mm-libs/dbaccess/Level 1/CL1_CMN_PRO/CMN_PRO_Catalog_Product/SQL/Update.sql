UPDATE 
	cmn_pro_catalog_products
SET 
	CMN_PRO_Catalog_Revision_RefID=@CMN_PRO_Catalog_Revision_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_Catalog_ProductID = @CMN_PRO_Catalog_ProductID