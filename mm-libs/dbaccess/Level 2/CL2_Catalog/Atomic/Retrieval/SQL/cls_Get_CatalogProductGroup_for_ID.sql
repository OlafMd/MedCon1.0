
	SELECT
	  cmn_pro_catalog_productgroups.CMN_PRO_Catalog_ProductGroupID,
	  cmn_pro_catalog_productgroups.Catalog_Revision_RefID,
	  cmn_pro_catalog_productgroups.CatalogProductGroup_Name,
	  cmn_pro_catalog_productgroups.CatalogProductGroup_Parent_RefID
	FROM
	  CMN_PRO_Catalog_ProductGroups
	WHERE
	  IsDeleted = 0 AND
	  Tenant_RefID = @TenantID AND
	  CMN_PRO_Catalog_ProductGroupID = @CatalogGroupID
  