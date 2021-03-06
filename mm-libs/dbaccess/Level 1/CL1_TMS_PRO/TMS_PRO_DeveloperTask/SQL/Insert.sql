INSERT INTO 
	tms_pro_developertasks
	(
		TMS_PRO_DeveloperTaskID,
		IdentificationNumber,
		DOC_Structure_Header_RefID,
		CreatedBy_ProjectMember_RefID,
		Priority_RefID,
		Project_RefID,
		DeveloperTask_Type_RefID,
		IsTaskEstimable,
		DeveloperTime_RequiredEstimation_min,
		DeveloperTime_CurrentInvestment_min,
		GrabbedByMember_RefID,
		Completion_Deadline,
		Completion_Timestamp,
		PercentageComplete,
		Name,
		Description,
		Developer_Points,
		IsComplete,
		IsIncompleteInformation,
		IsArchived,
		IsBeingPrepared,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_DeveloperTaskID,
		@IdentificationNumber,
		@DOC_Structure_Header_RefID,
		@CreatedBy_ProjectMember_RefID,
		@Priority_RefID,
		@Project_RefID,
		@DeveloperTask_Type_RefID,
		@IsTaskEstimable,
		@DeveloperTime_RequiredEstimation_min,
		@DeveloperTime_CurrentInvestment_min,
		@GrabbedByMember_RefID,
		@Completion_Deadline,
		@Completion_Timestamp,
		@PercentageComplete,
		@Name,
		@Description,
		@Developer_Points,
		@IsComplete,
		@IsIncompleteInformation,
		@IsArchived,
		@IsBeingPrepared,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)