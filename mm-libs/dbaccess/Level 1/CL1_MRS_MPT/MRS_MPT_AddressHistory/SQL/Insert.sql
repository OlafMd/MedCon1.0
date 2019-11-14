INSERT INTO 
	mrs_mpt_addresshistory
	(
		MRS_MPT_AddressHistoryID,
		MeasuringPoint_RefID,
		Address_RefID,
		ActiveFrom,
		ActiveThrough,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@MRS_MPT_AddressHistoryID,
		@MeasuringPoint_RefID,
		@Address_RefID,
		@ActiveFrom,
		@ActiveThrough,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)