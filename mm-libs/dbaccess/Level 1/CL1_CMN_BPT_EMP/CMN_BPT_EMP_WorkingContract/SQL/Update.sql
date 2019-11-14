UPDATE 
	cmn_bpt_emp_workingcontracts
SET 
	ExtraWorkCalculation_RefID=@ExtraWorkCalculation_RefID,
	WorkingContract_InCurrency_RefID=@WorkingContract_InCurrency_RefID,
	Contract_StartDate=@Contract_StartDate,
	Contract_EndDate=@Contract_EndDate,
	IsContractEndDateDefined=@IsContractEndDateDefined,
	IsWorkTimeCalculated_InHours=@IsWorkTimeCalculated_InHours,
	IsWorkTimeCalculated_InDays=@IsWorkTimeCalculated_InDays,
	R_WorkTime_DaysPerWeek=@R_WorkTime_DaysPerWeek,
	R_WorkTime_HoursPerWeek=@R_WorkTime_HoursPerWeek,
	IsWorktimeChecked_Weekly=@IsWorktimeChecked_Weekly,
	IsWorktimeChecked_Monthly=@IsWorktimeChecked_Monthly,
	SurchargeCalculation_UseMaximum=@SurchargeCalculation_UseMaximum,
	SurchargeCalculation_UseAccumulated=@SurchargeCalculation_UseAccumulated,
	IsMealAllowanceProvided=@IsMealAllowanceProvided,
	WorkingContract_Comment=@WorkingContract_Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_WorkingContractID = @CMN_BPT_EMP_WorkingContractID