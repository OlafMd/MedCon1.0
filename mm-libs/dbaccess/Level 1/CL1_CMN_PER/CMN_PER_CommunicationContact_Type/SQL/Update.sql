UPDATE 
	cmn_per_communicationcontact_types
SET 
	CommunicationContact_Name_DictID=@CommunicationContact_Name,
	Type=@Type,
	IsPersistent=@IsPersistent,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PER_CommunicationContact_TypeID = @CMN_PER_CommunicationContact_TypeID