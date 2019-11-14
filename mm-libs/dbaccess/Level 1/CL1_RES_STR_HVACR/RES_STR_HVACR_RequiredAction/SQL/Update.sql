UPDATE 
	res_str_hvacr_requiredactions
SET 
	HVACRPropertyAssestment_RefID=@HVACRPropertyAssestment_RefID,
	SelectedActionVersion_RefID=@SelectedActionVersion_RefID,
	EffectivePrice_RefID=@EffectivePrice_RefID,
	Action_Timeframe_RefID=@Action_Timeframe_RefID,
	Action_PricePerUnit_RefID=@Action_PricePerUnit_RefID,
	Action_Unit_RefID=@Action_Unit_RefID,
	Action_UnitAmount=@Action_UnitAmount,
	IsCustom=@IsCustom,
	IfCustom_Name=@IfCustom_Name,
	IfCustom_Description=@IfCustom_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_HVACR_RequiredActionID = @RES_STR_HVACR_RequiredActionID