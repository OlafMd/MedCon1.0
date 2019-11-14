UPDATE 
	hec_pat_specimen_groups
SET 
	HEC_Patient_Event_RefID=@HEC_Patient_Event_RefID,
	R_HEC_Patient_RefID=@R_HEC_Patient_RefID,
	UploadedBy_Account_RefID=@UploadedBy_Account_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_PAT_Specimen_GroupID = @HEC_PAT_Specimen_GroupID