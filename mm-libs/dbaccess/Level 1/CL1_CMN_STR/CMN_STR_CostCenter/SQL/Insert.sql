INSERT INTO 
	cmn_str_costcenters
	(
		CMN_STR_CostCenterID,
		InternalID,
		Name_DictID,
		Description_DictID,
		CostCenterType_RefID,
		ResponsiblePerson_RefID,
		Currency_RefID,
		CostCenter_Parent_RefID,
		R_CostCenter_HasChildren,
		OpenForBooking,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_CostCenterID,
		@InternalID,
		@Name,
		@Description,
		@CostCenterType_RefID,
		@ResponsiblePerson_RefID,
		@Currency_RefID,
		@CostCenter_Parent_RefID,
		@R_CostCenter_HasChildren,
		@OpenForBooking,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)