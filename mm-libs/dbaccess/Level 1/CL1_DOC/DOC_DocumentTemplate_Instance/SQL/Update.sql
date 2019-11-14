UPDATE 
	doc_documenttemplate_instances
SET 
	Source_DocumentTemplate_RefID=@Source_DocumentTemplate_RefID,
	DisplayName=@DisplayName,
	InstanceContent=@InstanceContent,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	DOC_DocumentTemplate_InstanceID = @DOC_DocumentTemplate_InstanceID