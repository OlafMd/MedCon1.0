
Select
  cmn_pro_catalogs.CMN_PRO_CatalogID,
  cmn_pro_catalogs.Catalog_Currency_RefID,
  cmn_pro_catalogs.Catalog_Language_RefID,
  cmn_pro_catalogs.IsPublicCatalog,
  cmn_pro_catalogs.CatalogCodeITL,
  cmn_pro_catalog_revisions.CMN_PRO_Catalog_RevisionID,
  cmn_pro_catalog_revisions.Valid_From,
  cmn_pro_catalog_revisions.Valid_Through,
  cmn_pro_catalog_revisions.PublishedBy_BusinessParticipant_RefID,
  cmn_pro_catalog_revisions.Default_PricelistRelease_RefID,
  cmn_pro_catalog_revisions.PublishedOn_Date,
  cmn_pro_catalog_revisions.CatalogRevision_Name,
  cmn_pro_catalog_revisions.CatalogRevision_Description,
  cmn_pro_catalog_revisions.RevisionNumber,
  cmn_pro_mastercatalogs.Catalog_Name_DictID
From
  cmn_pro_catalog_revisions Right Join
  cmn_pro_catalogs On cmn_pro_catalogs.CMN_PRO_CatalogID =
    cmn_pro_catalog_revisions.CMN_PRO_Catalog_RefID Inner Join
  cmn_pro_mastercatalogs On cmn_pro_catalogs.CMN_PRO_MasterCatalog_RefID =
    cmn_pro_mastercatalogs.CMN_PRO_MasterCatalogID
Where
  cmn_pro_catalogs.IsDeleted = 0 And
  cmn_pro_catalog_revisions.IsDeleted = 0 And
  cmn_pro_catalogs.Tenant_RefID = @TenantID And
  cmn_pro_mastercatalogs.IsDeleted = 0
  