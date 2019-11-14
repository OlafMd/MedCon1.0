UPDATE 
	cmn_pro_catalog_revisions
SET 
	CMN_PRO_Catalog_RefID=@CMN_PRO_Catalog_RefID,
	CatalogRevision_Name=@CatalogRevision_Name,
	CatalogRevision_Description=@CatalogRevision_Description,
	RevisionNumber=@RevisionNumber,
	Valid_From=@Valid_From,
	Valid_Through=@Valid_Through,
	PublishedBy_BusinessParticipant_RefID=@PublishedBy_BusinessParticipant_RefID,
	Default_PricelistRelease_RefID=@Default_PricelistRelease_RefID,
	PublishedOn_Date=@PublishedOn_Date,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_Catalog_RevisionID = @CMN_PRO_Catalog_RevisionID