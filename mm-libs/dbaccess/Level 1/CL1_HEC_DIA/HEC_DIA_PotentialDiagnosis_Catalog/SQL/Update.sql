UPDATE 
	hec_dia_potentialdiagnosis_catalogs
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Catalog_DisplayName=@Catalog_DisplayName,
	Catalog_Name_DictID=@Catalog_Name,
	IsUsingSelfLearningPriorities=@IsUsingSelfLearningPriorities,
	SelfLearningPriorities_InitializationTreshold=@SelfLearningPriorities_InitializationTreshold,
	IsPrivateCatalog=@IsPrivateCatalog,
	R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed=@R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed,
	SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount=@SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_PotentialDiagnosis_CatalogID = @HEC_DIA_PotentialDiagnosis_CatalogID