UPDATE 
	app_initializations
SET 
	Application_RefID=@Application_RefID,
	Module_RefID=@Module_RefID,
	Version=@Version,
	Initialization_StartedAtDate=@Initialization_StartedAtDate,
	Initialiaztion_CompletedAtDate=@Initialiaztion_CompletedAtDate,
	IsInitializationComplete=@IsInitializationComplete,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	APP_InitializationID = @APP_InitializationID