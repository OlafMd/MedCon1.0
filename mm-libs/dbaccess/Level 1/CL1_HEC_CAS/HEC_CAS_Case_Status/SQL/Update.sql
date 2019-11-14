UPDATE 
	hec_cas_case_statuses
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Status_Code=@Status_Code,
	Status_Name_DictID=@Status_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CAS_Case_StatusID = @HEC_CAS_Case_StatusID