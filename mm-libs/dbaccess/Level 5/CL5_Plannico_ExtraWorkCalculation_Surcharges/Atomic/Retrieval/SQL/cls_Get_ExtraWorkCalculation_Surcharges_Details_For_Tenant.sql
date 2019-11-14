
	Select
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.CMN_BPT_EMP_ExtraWorkCalculation_Surcharges_DetailsID,
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.ExtraWorkCalculation_Surcharge_RefID,
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.TimeFrom_in_mins,
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.TimeTo_in_mins,
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.Surcharge_Standard_PercentValue,
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.Surcharge_StartedBeforeMidnight_PercentValue,
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.BoundTo_StructureCalendarEvent_Type_RefID,
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.BoundTo_StructureCalendarEvent_RefID
	From
	  cmn_bpt_emp_extraworkcalculation_surcharges_details
	Where
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.IsDeleted = 0 And
	  cmn_bpt_emp_extraworkcalculation_surcharges_details.Tenant_RefID = @TenantID
  