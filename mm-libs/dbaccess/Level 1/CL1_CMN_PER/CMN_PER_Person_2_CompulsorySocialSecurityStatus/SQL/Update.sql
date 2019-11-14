UPDATE 
	cmn_per_person_2_compulsorysocialsecuritystatus
SET 
	CMN_PER_PersonInfo_RefID=@CMN_PER_PersonInfo_RefID,
	CMN_PER_CompulsorySocialSecurityStatus_RefID=@CMN_PER_CompulsorySocialSecurityStatus_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID