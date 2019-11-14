UPDATE 
	cmn_per_personinfo_2_address
SET 
	AddressLabel=@AddressLabel,
	CMN_Address_RefID=@CMN_Address_RefID,
	CMN_PER_PersonInfo_RefID=@CMN_PER_PersonInfo_RefID,
	SequenceNumber=@SequenceNumber,
	IsPrimary=@IsPrimary,
	IsAddress_Contact=@IsAddress_Contact,
	IsAddress_Billing=@IsAddress_Billing,
	IsAddress_Shipping=@IsAddress_Shipping,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID