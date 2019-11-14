UPDATE 
	mrs_run_measurementrun_routes
SET 
	Route_RefID=@Route_RefID,
	MeasurementRun_RefID=@MeasurementRun_RefID,
	BoundTo_Account_RefID=@BoundTo_Account_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_MeasurementRun_RouteID = @MRS_RUN_MeasurementRun_RouteID