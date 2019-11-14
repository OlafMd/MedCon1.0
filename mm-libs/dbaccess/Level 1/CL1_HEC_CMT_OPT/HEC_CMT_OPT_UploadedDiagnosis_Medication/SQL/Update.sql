UPDATE 
	hec_cmt_opt_uploadeddiagnosis_medications
SET 
	UploadedDiagnosis_RefID=@UploadedDiagnosis_RefID,
	IsProduct=@IsProduct,
	IfProduct_UploadedProductITL=@IfProduct_UploadedProductITL,
	IsSubstance=@IsSubstance,
	IfSubstance_Unit_ISOCode=@IfSubstance_Unit_ISOCode,
	IfSubstance_UploadedSubstanceITL=@IfSubstance_UploadedSubstanceITL,
	IfSubstance_Strength=@IfSubstance_Strength,
	DosageText=@DosageText,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_OPT_UploadedDiagnosis_MedicationID = @HEC_CMT_OPT_UploadedDiagnosis_MedicationID