UPDATE 
	cmn_pro_mastercatalogs
SET 
	Catalog_Name_DictID=@Catalog_Name,
	Catalog_Description_DictID=@Catalog_Description,
	CatalogPublishing_DefaultCurrency_RefID=@CatalogPublishing_DefaultCurrency_RefID,
	CatalogPublishing_DefaultLanguage_RefID=@CatalogPublishing_DefaultLanguage_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_MasterCatalogID = @CMN_PRO_MasterCatalogID