UPDATE 
	hec_tre_potentialprocedure_localizations
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Localization_Name_DictID=@Localization_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_TRE_PotentialProcedure_LocalizationID = @HEC_TRE_PotentialProcedure_LocalizationID