UPDATE 
	hec_medicalservices
SET 
	MedicalServiceITL=@MedicalServiceITL,
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	ServiceName_DictID=@ServiceName,
	ServiceDescription_DictID=@ServiceDescription,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_MedicalServiceID = @HEC_MedicalServiceID