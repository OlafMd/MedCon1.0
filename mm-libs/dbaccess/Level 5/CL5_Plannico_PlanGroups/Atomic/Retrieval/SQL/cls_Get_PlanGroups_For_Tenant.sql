
Select
  cmn_bpt_emp_employee_plangroups.CMN_BPT_EMP_Employee_PlanGroupID,
  cmn_bpt_emp_employee_plangroups.PlanGroup_Name_DictID,
  cmn_bpt_emp_employee_plangroups.PlanGroup_Description_DictID,
  cmn_bpt_emp_employee_plangroups.BoundTo_Office_RefID,
  cmn_bpt_emp_employee_plangroups.BoundTo_WorkArea_RefID,
  cmn_bpt_emp_employee_plangroups.BoundTo_WorkPlace_RefID
From
  cmn_bpt_emp_employee_plangroups
Where
  cmn_bpt_emp_employee_plangroups.IsDeleted = 0 And
  cmn_bpt_emp_employee_plangroups.Tenant_RefID = @TenantID
  