
	Select
	  cmn_pro_catalogs.CMN_PRO_CatalogID As CatalogID,
	  cmn_pro_catalogs.CatalogCodeITL,
	  cmn_pro_catalogs.IsPublicCatalog,
	  cmn_pro_catalogs.Catalog_Language_RefID,
	  cmn_pro_catalogs.Catalog_Currency_RefID
	From
	  cmn_pro_catalogs
	Where
	  cmn_pro_catalogs.IsDeleted = 0 And
	  cmn_pro_catalogs.Tenant_RefID = @TenantID
  