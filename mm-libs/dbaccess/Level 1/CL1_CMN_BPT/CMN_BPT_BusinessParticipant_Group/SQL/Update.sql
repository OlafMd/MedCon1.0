UPDATE 
	cmn_bpt_businessparticipant_groups
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	BusinessParticipantGroup_Parent_RefID=@BusinessParticipantGroup_Parent_RefID,
	BusinessParticipantGroup_Alias=@BusinessParticipantGroup_Alias,
	BusinessParticipantGroup_Name_DictID=@BusinessParticipantGroup_Name,
	BusinessParticipantGroup_Description_DictID=@BusinessParticipantGroup_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_BusinessParticipant_GroupID = @CMN_BPT_BusinessParticipant_GroupID