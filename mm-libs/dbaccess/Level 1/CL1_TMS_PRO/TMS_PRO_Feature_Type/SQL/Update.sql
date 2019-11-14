UPDATE 
	tms_pro_feature_type
SET 
	Label_DictID=@Label,
	Description_DictID=@Description,
	IsPersistent=@IsPersistent,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_Feature_TypeID = @TMS_PRO_Feature_TypeID