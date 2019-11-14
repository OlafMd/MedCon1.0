UPDATE 
	hec_pro_component_substanceingredients
SET 
	Component_RefID=@Component_RefID,
	Substance_RefID=@Substance_RefID,
	Unit_RefID=@Unit_RefID,
	QuantityValue=@QuantityValue,
	Suffix=@Suffix,
	SubstanceIngredientTypeStatus=@SubstanceIngredientTypeStatus,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_PRO_Component_SubstanceIngredientID = @HEC_PRO_Component_SubstanceIngredientID