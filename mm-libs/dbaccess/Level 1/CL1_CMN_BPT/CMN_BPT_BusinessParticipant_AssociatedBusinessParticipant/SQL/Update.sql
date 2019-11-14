UPDATE 
	cmn_bpt_businessparticipant_associatedbusinessparticipants
SET 
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	AssociatedBusinessParticipant_RefID=@AssociatedBusinessParticipant_RefID,
	AssociatedParticipant_FunctionName=@AssociatedParticipant_FunctionName,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = @CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID