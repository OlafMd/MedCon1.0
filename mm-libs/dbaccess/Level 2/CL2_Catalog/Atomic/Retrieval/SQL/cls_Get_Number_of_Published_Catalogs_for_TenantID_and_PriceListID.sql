
	SELECT count(cmn_pro_catalog_revisions.CMN_PRO_Catalog_RevisionID) as PublishedCatalogsNumber
	FROM cmn_pro_catalog_revisions
	WHERE PublishedBy_BusinessParticipant_RefID!=0x00000000000000000000000000000000
	  AND cmn_pro_catalog_revisions.IsDeleted=FALSE
	  AND Tenant_RefID=@TenantID
	  AND Default_PricelistRelease_RefID=@PriceListID
  