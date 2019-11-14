INSERT INTO 
	res_realestateproperty_sourceofinformation
	(
		RES_RealestateProperty_SourceOfInformationID,
		SourceOfInformation_Name_DictID,
		SourceOfInformation_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_RealestateProperty_SourceOfInformationID,
		@SourceOfInformation_Name,
		@SourceOfInformation_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)