UPDATE 
	tmp_pro_milestones
SET 
	DOC_Structure_Header_RefID=@DOC_Structure_Header_RefID,
	BusinessTaskPackage_RefID=@BusinessTaskPackage_RefID,
	BusinessTask_RefID=@BusinessTask_RefID,
	Description_DictID=@Description,
	DateReached=@DateReached,
	TargetDate=@TargetDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMP_PRO_MilestoneID = @TMP_PRO_MilestoneID