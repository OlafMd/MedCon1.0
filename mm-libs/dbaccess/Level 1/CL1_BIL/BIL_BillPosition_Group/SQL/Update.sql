UPDATE 
	bil_billposition_groups
SET 
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	PositionGroup_Title=@PositionGroup_Title,
	PositionGroup_Description=@PositionGroup_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	BIL_BillPosition_GroupID = @BIL_BillPosition_GroupID