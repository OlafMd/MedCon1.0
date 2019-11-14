INSERT INTO 
	app_apo_webshopdocuments
	(
		APP_APO_WebshopDocumentID,
		Document_RefID,
		IsVisibleInWebshop,
		Tenant_RefID,
		Creation_Timestamp,
		IsDeleted
	)
VALUES 
	(
		@APP_APO_WebshopDocumentID,
		@Document_RefID,
		@IsVisibleInWebshop,
		@Tenant_RefID,
		@Creation_Timestamp,
		@IsDeleted
	)