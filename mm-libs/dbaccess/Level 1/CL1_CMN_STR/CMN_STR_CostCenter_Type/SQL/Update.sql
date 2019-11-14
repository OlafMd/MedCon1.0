UPDATE 
	cmn_str_costcenter_types
SET 
	CostCenterType_Name_DictID=@CostCenterType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_CostCenter_TypeID = @CMN_STR_CostCenter_TypeID