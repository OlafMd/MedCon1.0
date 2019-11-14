UPDATE 
	cmn_con_communicationcontacts
SET 
	Contact_RefID=@Contact_RefID,
	ConcatctType_RefID=@ConcatctType_RefID,
	Content=@Content,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CON_CommunicationContactID = @CMN_CON_CommunicationContactID