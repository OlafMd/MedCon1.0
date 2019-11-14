INSERT INTO 
	tms_pro_feature
	(
		TMS_PRO_FeatureID,
		IdentificationNumber,
		DOC_Structure_Header_RefID,
		Project_RefID,
		Component_RefID,
		Parent_RefID,
		Type_RefID,
		Status_RefID,
		Name_DictID,
		Description_DictID,
		Feature_Deadline,
		IsArchived,
		CreatedByAccount_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_FeatureID,
		@IdentificationNumber,
		@DOC_Structure_Header_RefID,
		@Project_RefID,
		@Component_RefID,
		@Parent_RefID,
		@Type_RefID,
		@Status_RefID,
		@Name,
		@Description,
		@Feature_Deadline,
		@IsArchived,
		@CreatedByAccount_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)