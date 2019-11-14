UPDATE 
	mrs_rut_routecycles
SET 
	Route_RefID=@Route_RefID,
	ValidFrom=@ValidFrom,
	ValidThrough=@ValidThrough,
	CronExpressions=@CronExpressions,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUT_RouteCycleID = @MRS_RUT_RouteCycleID