UPDATE 
	tms_pro_acc_rights
SET 
	Right_Name_DictID=@Right_Name,
	Right_Description_DictID=@Right_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_ACC_RightID = @TMS_PRO_ACC_RightID