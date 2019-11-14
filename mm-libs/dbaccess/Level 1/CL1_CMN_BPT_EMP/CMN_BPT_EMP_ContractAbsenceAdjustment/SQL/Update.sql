UPDATE 
	cmn_bpt_emp_contractabsenceadjustments
SET 
	EmploymentRelationship_Timeframe_RefID=@EmploymentRelationship_Timeframe_RefID,
	AbsenceReason_RefID=@AbsenceReason_RefID,
	ContractAbsenceAdjustment_Group_RefID=@ContractAbsenceAdjustment_Group_RefID,
	AbsenceTime_InMinutes=@AbsenceTime_InMinutes,
	AdjustmentComment=@AdjustmentComment,
	TriggeringAccount_RefID=@TriggeringAccount_RefID,
	IsManual=@IsManual,
	InternalAdjustmentType=@InternalAdjustmentType,
	AdjustmentDate=@AdjustmentDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_ContractAbsenceAdjustmentID = @CMN_BPT_EMP_ContractAbsenceAdjustmentID