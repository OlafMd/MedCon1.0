UPDATE 
	cmn_str_office_2_officetype
SET 
	Office_Type_RefID=@Office_Type_RefID,
	Office_RefID=@Office_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID