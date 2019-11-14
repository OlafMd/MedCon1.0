UPDATE 
	cmn_per_communicationcontacts
SET 
	PersonInfo_RefID=@PersonInfo_RefID,
	Contact_Type=@Contact_Type,
	Content=@Content,
	IsDefaultForContactType=@IsDefaultForContactType,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PER_CommunicationContactID = @CMN_PER_CommunicationContactID