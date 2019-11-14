UPDATE 
	mrs_rut_routes
SET 
	DisplayName=@DisplayName,
	IsTemporaryRoute=@IsTemporaryRoute,
	Default_RouteReaderAccount_RefID=@Default_RouteReaderAccount_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUT_RouteID = @MRS_RUT_RouteID