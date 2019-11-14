UPDATE 
	cmn_unit_conversionformulas
SET 
	PrimaryUnit_RefID=@PrimaryUnit_RefID,
	SecondaryUnit_RefID=@SecondaryUnit_RefID,
	ConversionFormula=@ConversionFormula,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_Unit_ConversionFormulaID = @CMN_Unit_ConversionFormulaID