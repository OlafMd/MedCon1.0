INSERT INTO 
	cmn_pro_catalogs
	(
		CMN_PRO_CatalogID,
		CatalogCodeITL,
		CMN_PRO_MasterCatalog_RefID,
		Catalog_Currency_RefID,
		Catalog_Language_RefID,
		IsPublicCatalog,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_PRO_CatalogID,
		@CatalogCodeITL,
		@CMN_PRO_MasterCatalog_RefID,
		@Catalog_Currency_RefID,
		@Catalog_Language_RefID,
		@IsPublicCatalog,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)