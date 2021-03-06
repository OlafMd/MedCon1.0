INSERT INTO 
	res_str_facade_requiredactions
	(
		RES_STR_Facade_RequiredActionID,
		FacadePropertyAssestment_RefID,
		SelectedActionVersion_RefID,
		EffectivePrice_RefID,
		Action_PricePerUnit_RefID,
		Action_Unit_RefID,
		Action_UnitAmount,
		IsCustom,
		IfCustom_Name,
		IfCustom_Description,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID,
		Action_Timeframe_RefID,
		Comment
	)
VALUES 
	(
		@RES_STR_Facade_RequiredActionID,
		@FacadePropertyAssestment_RefID,
		@SelectedActionVersion_RefID,
		@EffectivePrice_RefID,
		@Action_PricePerUnit_RefID,
		@Action_Unit_RefID,
		@Action_UnitAmount,
		@IsCustom,
		@IfCustom_Name,
		@IfCustom_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID,
		@Action_Timeframe_RefID,
		@Comment
	)