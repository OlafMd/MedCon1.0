UPDATE 
	ocl_ordercollectives
SET 
	OrderCollectiveITL=@OrderCollectiveITL,
	OrderCollective_Name_DictID=@OrderCollective_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	OCL_OrderCollectiveID = @OCL_OrderCollectiveID