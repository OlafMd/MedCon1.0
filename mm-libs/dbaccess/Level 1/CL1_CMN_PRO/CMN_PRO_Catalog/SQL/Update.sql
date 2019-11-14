UPDATE 
	cmn_pro_catalogs
SET 
	CatalogCodeITL=@CatalogCodeITL,
	CMN_PRO_MasterCatalog_RefID=@CMN_PRO_MasterCatalog_RefID,
	Catalog_Currency_RefID=@Catalog_Currency_RefID,
	Catalog_Language_RefID=@Catalog_Language_RefID,
	IsPublicCatalog=@IsPublicCatalog,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_CatalogID = @CMN_PRO_CatalogID