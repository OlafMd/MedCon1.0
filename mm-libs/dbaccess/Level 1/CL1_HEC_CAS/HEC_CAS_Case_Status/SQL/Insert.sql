INSERT INTO 
	hec_cas_case_statuses
	(
		HEC_CAS_Case_StatusID,
		GlobalPropertyMatchingID,
		Status_Code,
		Status_Name_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CAS_Case_StatusID,
		@GlobalPropertyMatchingID,
		@Status_Code,
		@Status_Name,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)