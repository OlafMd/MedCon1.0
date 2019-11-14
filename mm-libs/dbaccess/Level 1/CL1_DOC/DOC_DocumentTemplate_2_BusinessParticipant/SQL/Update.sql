UPDATE 
	doc_documenttemplate_2_businessparticipant
SET 
	DOC_DocumentTemplate_Instance_RefID=@DOC_DocumentTemplate_Instance_RefID,
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID