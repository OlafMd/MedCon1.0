UPDATE 
	cmn_pro_subscribedcatalogs
SET 
	CatalogCodeITL=@CatalogCodeITL,
	SubscribedCatalog_Language_RefID=@SubscribedCatalog_Language_RefID,
	SubscribedCatalog_Currency_RefID=@SubscribedCatalog_Currency_RefID,
	SubscribedCatalog_Name=@SubscribedCatalog_Name,
	SubscribedCatalog_Description=@SubscribedCatalog_Description,
	SubscribedCatalog_CurrentRevision=@SubscribedCatalog_CurrentRevision,
	PublishingSupplier_RefID=@PublishingSupplier_RefID,
	SubscribedBy_BusinessParticipant_RefID=@SubscribedBy_BusinessParticipant_RefID,
	SubscribedCatalog_PricelistRelease_RefID=@SubscribedCatalog_PricelistRelease_RefID,
	SubscribedCatalog_ValidFrom=@SubscribedCatalog_ValidFrom,
	SubscribedCatalog_ValidThrough=@SubscribedCatalog_ValidThrough,
	IsCatalogValid=@IsCatalogValid,
	IsCatalogPublic=@IsCatalogPublic,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_SubscribedCatalogID = @CMN_PRO_SubscribedCatalogID