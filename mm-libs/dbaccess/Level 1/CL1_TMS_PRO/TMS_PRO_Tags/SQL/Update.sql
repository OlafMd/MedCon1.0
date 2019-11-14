UPDATE 
	tms_pro_tags
SET 
	TagValue=@TagValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMS_PRO_TagID = @TMS_PRO_TagID