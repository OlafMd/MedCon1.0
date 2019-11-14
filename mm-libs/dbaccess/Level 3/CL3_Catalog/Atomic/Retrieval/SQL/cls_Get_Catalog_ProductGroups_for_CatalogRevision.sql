
	Select
	  cmn_pro_catalog_productgroups.Catalog_Revision_RefID,
	  cmn_pro_catalog_productgroups.CMN_PRO_Catalog_ProductGroupID,
	  cmn_pro_catalog_productgroups.CatalogProductGroup_Name,
	  cmn_pro_catalog_productgroups.CatalogProductGroup_Parent_RefID
	From
	  cmn_pro_catalog_productgroups
	Where
	  cmn_pro_catalog_productgroups.Tenant_RefID = @TenantID And
	  cmn_pro_catalog_productgroups.Catalog_Revision_RefID = @CatalogRevisionID And
	  cmn_pro_catalog_productgroups.IsDeleted = 0
  