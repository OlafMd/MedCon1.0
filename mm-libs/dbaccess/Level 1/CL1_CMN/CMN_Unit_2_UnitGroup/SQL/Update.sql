UPDATE 
	cmn_unit_2_unitgroup
SET 
	CMN_Unit_RefID=@CMN_Unit_RefID,
	CMN_Unit_Group_RefID=@CMN_Unit_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID