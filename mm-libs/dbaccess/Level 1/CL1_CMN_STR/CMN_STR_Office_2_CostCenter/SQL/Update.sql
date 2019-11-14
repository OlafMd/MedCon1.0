UPDATE 
	cmn_str_office_2_costcenter
SET 
	CostCenter_RefID=@CostCenter_RefID,
	Office_RefID=@Office_RefID,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID