INSERT INTO 
	mrs_mpt_measuringpoints
	(
		MRS_MPT_MeasuringPointID,
		LocatedAt_Location_RefID,
		ExternalMeasuringPointID,
		Lattitude,
		Longitude,
		CurrentAddress_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@MRS_MPT_MeasuringPointID,
		@LocatedAt_Location_RefID,
		@ExternalMeasuringPointID,
		@Lattitude,
		@Longitude,
		@CurrentAddress_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)