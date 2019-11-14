INSERT INTO 
	cmn_unit_conversionformulas
	(
		CMN_Unit_ConversionFormulaID,
		PrimaryUnit_RefID,
		SecondaryUnit_RefID,
		ConversionFormula,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_Unit_ConversionFormulaID,
		@PrimaryUnit_RefID,
		@SecondaryUnit_RefID,
		@ConversionFormula,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)