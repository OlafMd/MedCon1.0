UPDATE 
	ord_cuo_customerorder_statuses
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Status_Code=@Status_Code,
	Status_Name_DictID=@Status_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_CustomerOrder_StatusID = @ORD_CUO_CustomerOrder_StatusID