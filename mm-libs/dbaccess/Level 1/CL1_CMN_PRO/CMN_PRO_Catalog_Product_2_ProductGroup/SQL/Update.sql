UPDATE 
	cmn_pro_catalog_product_2_productgroup
SET 
	CMN_PRO_Catalog_Product_RefID=@CMN_PRO_Catalog_Product_RefID,
	CMN_PRO_Catalog_ProductGroup_RefID=@CMN_PRO_Catalog_ProductGroup_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID