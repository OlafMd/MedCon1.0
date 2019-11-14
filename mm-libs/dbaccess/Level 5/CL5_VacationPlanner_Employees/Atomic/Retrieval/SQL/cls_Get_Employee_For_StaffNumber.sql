
    
Select
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID
From
  cmn_bpt_emp_employees
Where
  cmn_bpt_emp_employees.IsDeleted = 0 And
  cmn_bpt_emp_employees.Staff_Number = @Staff_Number And
  cmn_bpt_emp_employees.Tenant_RefID = @TenantID
    