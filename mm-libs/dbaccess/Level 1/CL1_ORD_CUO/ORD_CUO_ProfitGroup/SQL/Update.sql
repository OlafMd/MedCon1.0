UPDATE 
	ord_cuo_profitgroups
SET 
	ShortName=@ShortName,
	ProfitGroup_Name_DictID=@ProfitGroup_Name,
	ProfitGroup_Description_DictID=@ProfitGroup_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_ProfitGroupID = @ORD_CUO_ProfitGroupID