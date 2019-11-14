UPDATE 
	hec_bil_potentialcode_2_potentialdiagnosis
SET 
	HEC_BIL_PotentialCode_RefID=@HEC_BIL_PotentialCode_RefID,
	HEC_DIA_PotentialDiagnosis_RefID=@HEC_DIA_PotentialDiagnosis_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID