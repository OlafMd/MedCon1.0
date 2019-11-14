UPDATE 
	cmn_str_pps_workarea_2_costcenter
SET 
	CostCenter_RefID=@CostCenter_RefID,
	WorkArea_RefID=@WorkArea_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID