UPDATE 
	mrs_mpt_measuringpoints
SET 
	LocatedAt_Location_RefID=@LocatedAt_Location_RefID,
	ExternalMeasuringPointID=@ExternalMeasuringPointID,
	Lattitude=@Lattitude,
	Longitude=@Longitude,
	CurrentAddress_RefID=@CurrentAddress_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	MRS_MPT_MeasuringPointID = @MRS_MPT_MeasuringPointID