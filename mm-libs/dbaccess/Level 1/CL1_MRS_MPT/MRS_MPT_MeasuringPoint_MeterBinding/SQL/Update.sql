UPDATE 
	mrs_mpt_measuringpoint_meterbindings
SET 
	MeasuringPoint_RefID=@MeasuringPoint_RefID,
	Meter_RefID=@Meter_RefID,
	ActiveFrom=@ActiveFrom,
	ActiveThrough=@ActiveThrough,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	MRS_MPT_MeasuringPoint_MeterBindingID = @MRS_MPT_MeasuringPoint_MeterBindingID