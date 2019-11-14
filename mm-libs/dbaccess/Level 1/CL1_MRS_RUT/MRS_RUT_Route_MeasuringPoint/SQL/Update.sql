UPDATE 
	mrs_rut_route_measuringpoints
SET 
	Route_RefID=@Route_RefID,
	MeasuringPoint_RefID=@MeasuringPoint_RefID,
	OrderSequence=@OrderSequence,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUT_Route_MeasuringPointID = @MRS_RUT_Route_MeasuringPointID