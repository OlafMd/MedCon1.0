INSERT INTO 
	hec_cmt_opt_uploadeddiagnoses
	(
		HEC_CMT_OPT_UploadedDiagnosisID,
		UploadedBy_Member_RefID,
		Uploaded_PotentialDiagnosisITL,
		Uploaded_PotentialDiagnosisCatalogITL,
		PotentialDiagnosis_DisplayName,
		PotentialDiagnosisCatalog_DisplayName,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CMT_OPT_UploadedDiagnosisID,
		@UploadedBy_Member_RefID,
		@Uploaded_PotentialDiagnosisITL,
		@Uploaded_PotentialDiagnosisCatalogITL,
		@PotentialDiagnosis_DisplayName,
		@PotentialDiagnosisCatalog_DisplayName,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)