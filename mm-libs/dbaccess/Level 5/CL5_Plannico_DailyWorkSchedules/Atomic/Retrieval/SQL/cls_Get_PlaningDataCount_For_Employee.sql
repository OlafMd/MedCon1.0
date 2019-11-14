
Select
  Count(cmn_str_pps_dailyworkschedules.CMN_STR_PPS_DailyWorkScheduleID) As
  itemCount
From
  cmn_str_pps_dailyworkschedules
Where
  cmn_str_pps_dailyworkschedules.Employee_RefID = @EmployeeID
Union
Select
  Count(cmn_bpt_emp_effectiveworktime_headers.CMN_STR_PPS_EffectiveWorkTime_HeaderID) As itemCount
From
  cmn_bpt_emp_effectiveworktime_headers
Where
  cmn_bpt_emp_effectiveworktime_headers.Employee_RefID = @EmployeeID
  