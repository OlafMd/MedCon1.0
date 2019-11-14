
	SELECT
	  CMN_PRO_Catalog_RevisionID,
	  max( RevisionNumber)
	FROM
	  CMN_PRO_Catalog_Revisions
	WHERE
	  Tenant_RefID = @TenantID AND
	  CMN_PRO_Catalog_RefID = @CatalogID AND
	  IsDeleted = 0
	GROUP BY
	  RevisionNumber
  