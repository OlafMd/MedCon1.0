UPDATE 
	hec_sub_substance_2_substancegroup
SET 
	HEC_SUB_Substance_RefID=@HEC_SUB_Substance_RefID,
	HEC_SUB_Substance_Group_RefID=@HEC_SUB_Substance_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID