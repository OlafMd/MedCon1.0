
	Select
	  pps_tsk_tasks.DisplayName
	From
	  pps_tsk_tasks Inner Join
	  pprs_tsk_task_selectedavailabilitytypes
	    On pprs_tsk_task_selectedavailabilitytypes.PPS_TSK_Task_RefID =
	    pps_tsk_tasks.PPS_TSK_TaskID And
	    pprs_tsk_task_selectedavailabilitytypes.Tenant_RefID = @TenantID And
	    pprs_tsk_task_selectedavailabilitytypes.IsDeleted = 0 Inner Join
	  pps_tsk_task_staffbookings On pps_tsk_tasks.PPS_TSK_TaskID =
	    pps_tsk_task_staffbookings.PPS_TSK_Task_RefID And
	    pps_tsk_task_staffbookings.Tenant_RefID = @TenantID And
	    pps_tsk_task_staffbookings.IsDeleted = 0 Inner Join
	  cmn_bpt_emp_employees On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
	    pps_tsk_task_staffbookings.CMN_BPT_EMP_Employee_RefID And
	  cmn_bpt_emp_employees.IsDeleted = 0 And
	  cmn_bpt_emp_employees.Tenant_RefID = @TenantID
	Where
	  pps_tsk_tasks.IsDeleted = 0 And
	  pps_tsk_tasks.Tenant_RefID = @TenantID And
	  cmn_bpt_emp_employees.BusinessParticipant_RefID = @BusinessParticipantID
  