
Select
  cmn_str_offices.CMN_STR_OfficeID,
  cmn_str_offices.Parent_RefID,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Office_Description_DictID,
  cmn_str_offices.Office_InternalName,
  cmn_bpt_emp_employee_2_office.AssignmentID,
  cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID,
  cmn_bpt_emp_employee_2_office.IsDeleted AS IsOfficeToAccountDeleted,
  usr_accounts.USR_AccountID
From
  cmn_str_offices Left Join
  cmn_bpt_emp_employee_2_office On cmn_str_offices.CMN_STR_OfficeID =
    cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID And
    cmn_bpt_emp_employee_2_office.Tenant_RefID =
    @TenantID Left Join
  cmn_bpt_emp_employees
    On cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID Left Join
  usr_accounts On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    usr_accounts.BusinessParticipant_RefID
Where
  (usr_accounts.USR_AccountID = @UserAccountID Or
  usr_accounts.USR_AccountID Is Null) And
  cmn_str_offices.Tenant_RefID = @TenantID And
  cmn_str_offices.IsDeleted = 0
  