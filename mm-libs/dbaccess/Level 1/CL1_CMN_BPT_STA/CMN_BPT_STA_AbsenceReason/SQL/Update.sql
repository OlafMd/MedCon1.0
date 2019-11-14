UPDATE 
	cmn_bpt_sta_absencereasons
SET 
	ShortName=@ShortName,
	Name_DictID=@Name,
	Description_DictID=@Description,
	AbsenceReason_Type_RefID=@AbsenceReason_Type_RefID,
	ColorCode=@ColorCode,
	Parent_RefID=@Parent_RefID,
	IsAuthorizationRequired=@IsAuthorizationRequired,
	IsIncludedInCapacityCalculation=@IsIncludedInCapacityCalculation,
	IsAllowedAbsence=@IsAllowedAbsence,
	IsDeactivated=@IsDeactivated,
	IsCarryOverEnabled=@IsCarryOverEnabled,
	IsCaryOverLimited=@IsCaryOverLimited,
	IfCarryOverLimited_MaximumAmount_Hrs=@IfCarryOverLimited_MaximumAmount_Hrs,
	IsLeaveTimeReducing_WorkingHours=@IsLeaveTimeReducing_WorkingHours,
	IsLeaveTimeReducing_OverHours=@IsLeaveTimeReducing_OverHours,
	IsLeaveTimeReducing_OverDays=@IsLeaveTimeReducing_OverDays,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_STA_AbsenceReasonID = @CMN_BPT_STA_AbsenceReasonID