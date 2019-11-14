UPDATE 
	hec_pat_specimens
SET 
	Specimen_Name=@Specimen_Name,
	Specimen_Group_RefID=@Specimen_Group_RefID,
	SpecimenImage_Document_RefID=@SpecimenImage_Document_RefID,
	OriginalImage_Width_px=@OriginalImage_Width_px,
	OriginalImage_Height_px=@OriginalImage_Height_px,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_PAT_SpecimenID = @HEC_PAT_SpecimenID