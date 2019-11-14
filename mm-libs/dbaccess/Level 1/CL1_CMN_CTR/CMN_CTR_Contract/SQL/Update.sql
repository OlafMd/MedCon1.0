UPDATE 
	cmn_ctr_contracts
SET 
	ContractName=@ContractName,
	ContractDescription=@ContractDescription,
	ValidFrom=@ValidFrom,
	ValidThrough=@ValidThrough,
	IsTerminated=@IsTerminated,
	IfTerminated_TerminationDate=@IfTerminated_TerminationDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_CTR_ContractID = @CMN_CTR_ContractID