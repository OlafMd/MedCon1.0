UPDATE 
	cmn_bpt_businessparticipant_2_businessparticipantgroup
SET 
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	CMN_BPT_BusinessParticipant_Group_RefID=@CMN_BPT_BusinessParticipant_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID