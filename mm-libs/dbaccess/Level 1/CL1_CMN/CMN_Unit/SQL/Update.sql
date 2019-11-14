UPDATE 
	cmn_units
SET 
	Label_DictID=@Label,
	Abbreviation_DictID=@Abbreviation,
	ISOCode=@ISOCode,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_UnitID = @CMN_UnitID