UPDATE 
	hec_bil_potentialcode_2_healthcareproduct
SET 
	HEC_BIL_PotentialCode_RefID=@HEC_BIL_PotentialCode_RefID,
	HEC_Product_RefID=@HEC_Product_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID