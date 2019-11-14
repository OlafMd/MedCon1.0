UPDATE 
	hec_act_usedproduct_2_procurementorderposition
SET 
	HEC_ACT_UsedProduct_RefID=@HEC_ACT_UsedProduct_RefID,
	ORD_PRC_ProcurementOrder_Position_RefID=@ORD_PRC_ProcurementOrder_Position_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID