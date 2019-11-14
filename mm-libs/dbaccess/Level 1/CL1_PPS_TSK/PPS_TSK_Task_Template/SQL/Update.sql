UPDATE 
	pps_tsk_task_templates
SET 
	TaskTemplateNumber=@TaskTemplateNumber,
	TaskTemplateDisplayName=@TaskTemplateDisplayName,
	TaskTemplateName_DictID=@TaskTemplateName,
	TaskTemplateDescription_DictID=@TaskTemplateDescription,
	Duration_EstimatedMin_in_sec=@Duration_EstimatedMin_in_sec,
	Duration_Recommended_in_sec=@Duration_Recommended_in_sec,
	Duration_EstimatedMax_in_sec=@Duration_EstimatedMax_in_sec,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_TemplateID = @PPS_TSK_Task_TemplateID