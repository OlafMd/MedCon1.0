UPDATE 
	cmn_bpt_emp_extraworkcalculation_surcharges_details
SET 
	ExtraWorkCalculation_Surcharge_RefID=@ExtraWorkCalculation_Surcharge_RefID,
	TimeFrom_in_mins=@TimeFrom_in_mins,
	TimeTo_in_mins=@TimeTo_in_mins,
	Surcharge_Standard_PercentValue=@Surcharge_Standard_PercentValue,
	Surcharge_StartedBeforeMidnight_PercentValue=@Surcharge_StartedBeforeMidnight_PercentValue,
	BoundTo_StructureCalendarEvent_Type_RefID=@BoundTo_StructureCalendarEvent_Type_RefID,
	BoundTo_StructureCalendarEvent_RefID=@BoundTo_StructureCalendarEvent_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_DetailsID = @CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_DetailsID