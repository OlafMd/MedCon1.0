UPDATE 
	mrs_mpt_addresshistory
SET 
	MeasuringPoint_RefID=@MeasuringPoint_RefID,
	Address_RefID=@Address_RefID,
	ActiveFrom=@ActiveFrom,
	ActiveThrough=@ActiveThrough,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	MRS_MPT_AddressHistoryID = @MRS_MPT_AddressHistoryID