INSERT INTO 
	tms_pro_tags
	(
		TMS_PRO_TagID,
		TagValue,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@TMS_PRO_TagID,
		@TagValue,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)