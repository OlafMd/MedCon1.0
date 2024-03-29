UPDATE 
	tms_pro_developertasks
SET 
	IdentificationNumber=@IdentificationNumber,
	DOC_Structure_Header_RefID=@DOC_Structure_Header_RefID,
	CreatedBy_ProjectMember_RefID=@CreatedBy_ProjectMember_RefID,
	Priority_RefID=@Priority_RefID,
	Project_RefID=@Project_RefID,
	DeveloperTask_Type_RefID=@DeveloperTask_Type_RefID,
	IsTaskEstimable=@IsTaskEstimable,
	DeveloperTime_RequiredEstimation_min=@DeveloperTime_RequiredEstimation_min,
	DeveloperTime_CurrentInvestment_min=@DeveloperTime_CurrentInvestment_min,
	GrabbedByMember_RefID=@GrabbedByMember_RefID,
	Completion_Deadline=@Completion_Deadline,
	Completion_Timestamp=@Completion_Timestamp,
	PercentageComplete=@PercentageComplete,
	Name=@Name,
	Description=@Description,
	Developer_Points=@Developer_Points,
	IsComplete=@IsComplete,
	IsIncompleteInformation=@IsIncompleteInformation,
	IsArchived=@IsArchived,
	IsBeingPrepared=@IsBeingPrepared,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_DeveloperTaskID = @TMS_PRO_DeveloperTaskID