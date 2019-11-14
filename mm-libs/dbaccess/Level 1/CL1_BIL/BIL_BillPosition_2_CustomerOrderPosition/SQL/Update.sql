UPDATE 
	bil_billposition_2_customerorderposition
SET 
	BIL_BillPosition_RefID=@BIL_BillPosition_RefID,
	ORD_CUO_CustomerOrder_Position_RefID=@ORD_CUO_CustomerOrder_Position_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID