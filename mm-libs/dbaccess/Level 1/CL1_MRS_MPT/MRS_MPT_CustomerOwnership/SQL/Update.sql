UPDATE 
	mrs_mpt_customerownerships
SET 
	MeasuringPoint_RefID=@MeasuringPoint_RefID,
	Customer_RefID=@Customer_RefID,
	ContractNumber=@ContractNumber,
	ValidFrom=@ValidFrom,
	ValidThrough=@ValidThrough,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	MRS_MPT_CustomerOwnershipID = @MRS_MPT_CustomerOwnershipID