INSERT INTO 
	cmn_con_communicationcontact_types
	(
		CMN_CON_CommunicationContact_TypeID,
		Type,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_CON_CommunicationContact_TypeID,
		@Type,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)