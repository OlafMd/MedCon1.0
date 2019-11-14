UPDATE 
	bil_billstatuses
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	BillStatus_Name_DictID=@BillStatus_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	BIL_BillStatusID = @BIL_BillStatusID