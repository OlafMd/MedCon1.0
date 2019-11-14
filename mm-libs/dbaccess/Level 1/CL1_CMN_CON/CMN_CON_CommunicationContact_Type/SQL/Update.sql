UPDATE 
	cmn_con_communicationcontact_types
SET 
	Type=@Type,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CON_CommunicationContact_TypeID = @CMN_CON_CommunicationContact_TypeID