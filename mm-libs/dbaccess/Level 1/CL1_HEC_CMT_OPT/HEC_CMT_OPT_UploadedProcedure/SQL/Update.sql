UPDATE 
	hec_cmt_opt_uploadedprocedures
SET 
	UploadedBy_Member_RefID=@UploadedBy_Member_RefID,
	Uploaded_PotentialProcedureITL=@Uploaded_PotentialProcedureITL,
	Uploaded_PotentialProcedureCatalogITL=@Uploaded_PotentialProcedureCatalogITL,
	PotentialProcedure_DisplayName=@PotentialProcedure_DisplayName,
	PotentialProcedureCatalog_DisplayName=@PotentialProcedureCatalog_DisplayName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_OPT_UploadedProcedureID = @HEC_CMT_OPT_UploadedProcedureID