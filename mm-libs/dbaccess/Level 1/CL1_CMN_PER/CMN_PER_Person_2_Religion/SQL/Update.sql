UPDATE 
	cmn_per_person_2_religion
SET 
	CMN_PER_PersonInfo_RefID=@CMN_PER_PersonInfo_RefID,
	CMN_PER_Religion_RefID=@CMN_PER_Religion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID