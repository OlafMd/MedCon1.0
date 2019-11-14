Select
  cmn_pro_catalogs.CMN_PRO_CatalogID,
  cmn_pro_catalogs.Catalog_Currency_RefID,
  cmn_pro_catalogs.Catalog_Language_RefID,
  cmn_pro_catalogs.IsPublicCatalog,
  cmn_pro_catalogs.CatalogCodeITL,
  cmn_pro_mastercatalogs.Catalog_Name_DictID
From
  cmn_pro_catalogs Inner Join
  cmn_pro_mastercatalogs On cmn_pro_catalogs.CMN_PRO_MasterCatalog_RefID =
    cmn_pro_mastercatalogs.CMN_PRO_MasterCatalogID Left Join
  cmn_pro_mastercatalogs_de On cmn_pro_mastercatalogs.Catalog_Name_DictID =
    cmn_pro_mastercatalogs_de.DictID
Where
  cmn_pro_catalogs.IsDeleted = 0 And
  cmn_pro_mastercatalogs.IsDeleted = 0 And
  cmn_pro_catalogs.Tenant_RefID = @TenantID And
  cmn_pro_mastercatalogs_de.Language_RefID = @LanguageID And
  (@SearchCriteria Is Null Or
    Upper(cmn_pro_mastercatalogs_de.Content) Like @SearchCriteria)
Order By
  cmn_pro_mastercatalogs_de.Content      
  LIMIT @PageSize OFFSET @ActivePage
   