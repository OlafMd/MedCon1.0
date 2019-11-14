INSERT INTO 
	mrs_mpt_meters
	(
		MRS_MPT_MeterID,
		SerialNumber,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@MRS_MPT_MeterID,
		@SerialNumber,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)