UPDATE 
	hec_cmt_opt_community_potentialdiagnosiscatalogs
SET 
	Community_RefID=@Community_RefID,
	Version_Internal=@Version_Internal,
	Version_Display=@Version_Display,
	PublishDate=@PublishDate,
	PublicDownloadURL=@PublicDownloadURL,
	HEC_DIA_PotentialDiagnosis_Catalog_RefID=@HEC_DIA_PotentialDiagnosis_Catalog_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_OPT_Community_PotentialDiagnosisCatalogID = @HEC_CMT_OPT_Community_PotentialDiagnosisCatalogID