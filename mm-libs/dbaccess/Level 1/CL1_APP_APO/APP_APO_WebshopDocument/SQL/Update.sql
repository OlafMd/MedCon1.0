UPDATE 
	app_apo_webshopdocuments
SET 
	Document_RefID=@Document_RefID,
	IsVisibleInWebshop=@IsVisibleInWebshop,
	Tenant_RefID=@Tenant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted
WHERE 
	APP_APO_WebshopDocumentID = @APP_APO_WebshopDocumentID