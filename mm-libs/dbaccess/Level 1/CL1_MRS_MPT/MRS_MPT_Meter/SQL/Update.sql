UPDATE 
	mrs_mpt_meters
SET 
	SerialNumber=@SerialNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	MRS_MPT_MeterID = @MRS_MPT_MeterID