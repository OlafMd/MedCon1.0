UPDATE 
	cmn_pro_mastercatalog_products
SET 
	CMN_PRO_MasterCatalog_RefID=@CMN_PRO_MasterCatalog_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_MasterCatalog_ProductID = @CMN_PRO_MasterCatalog_ProductID