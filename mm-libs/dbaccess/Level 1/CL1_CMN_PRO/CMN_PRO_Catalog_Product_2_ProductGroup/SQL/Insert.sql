INSERT INTO 
	cmn_pro_catalog_product_2_productgroup
	(
		AssignmentID,
		CMN_PRO_Catalog_Product_RefID,
		CMN_PRO_Catalog_ProductGroup_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@CMN_PRO_Catalog_Product_RefID,
		@CMN_PRO_Catalog_ProductGroup_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)