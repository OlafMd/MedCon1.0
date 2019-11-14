UPDATE 
	hec_dosages
SET 
	DosageText=@DosageText,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_DosageID = @HEC_DosageID