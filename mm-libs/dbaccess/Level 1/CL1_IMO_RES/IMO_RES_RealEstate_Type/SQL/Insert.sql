INSERT INTO 
	imo_res_realestate_types
	(
		IMO_RES_RealEstate_TypeID,
		Label_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_RES_RealEstate_TypeID,
		@Label,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)