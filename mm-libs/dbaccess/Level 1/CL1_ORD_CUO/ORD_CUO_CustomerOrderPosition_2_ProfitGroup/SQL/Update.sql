UPDATE 
	ord_cuo_customerorderposition_2_profitgroup
SET 
	CMN_CUO_CustomerOrder_Position_RefID=@CMN_CUO_CustomerOrder_Position_RefID,
	CMN_ORD_PRCfitGroup_RefID=@CMN_ORD_PRCfitGroup_RefID,
	AttributablePercentageShare=@AttributablePercentageShare,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID