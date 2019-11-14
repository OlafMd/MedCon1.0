UPDATE 
	cmn_pro_catalog_productgroups
SET 
	Catalog_Revision_RefID=@Catalog_Revision_RefID,
	CatalogProductGroup_Name=@CatalogProductGroup_Name,
	CatalogProductGroup_Parent_RefID=@CatalogProductGroup_Parent_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_Catalog_ProductGroupID = @CMN_PRO_Catalog_ProductGroupID