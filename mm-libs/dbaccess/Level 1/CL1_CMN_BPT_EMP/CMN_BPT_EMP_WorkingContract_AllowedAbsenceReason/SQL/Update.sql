UPDATE 
	cmn_bpt_emp_workingcontract_allowedabsencereasons
SET 
	WorkingContract_RefID=@WorkingContract_RefID,
	STA_AbsenceReason_RefID=@STA_AbsenceReason_RefID,
	IsAbsenceCalculated_InHours=@IsAbsenceCalculated_InHours,
	IsAbsenceCalculated_InDays=@IsAbsenceCalculated_InDays,
	ContractAllowedAbsence_per_Month=@ContractAllowedAbsence_per_Month,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID = @CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID