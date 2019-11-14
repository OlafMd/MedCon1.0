UPDATE 
	cmn_str_costcenters
SET 
	InternalID=@InternalID,
	Name_DictID=@Name,
	Description_DictID=@Description,
	CostCenterType_RefID=@CostCenterType_RefID,
	ResponsiblePerson_RefID=@ResponsiblePerson_RefID,
	Currency_RefID=@Currency_RefID,
	CostCenter_Parent_RefID=@CostCenter_Parent_RefID,
	R_CostCenter_HasChildren=@R_CostCenter_HasChildren,
	OpenForBooking=@OpenForBooking,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_CostCenterID = @CMN_STR_CostCenterID