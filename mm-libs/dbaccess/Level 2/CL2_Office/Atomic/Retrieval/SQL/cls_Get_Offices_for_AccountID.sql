
	SELECT
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Office_InternalName,
  cmn_str_offices.Office_InternalNumber,
  cmn_str_offices.Parent_RefID,
  cmn_str_offices.Office_Description_DictID,
  cmn_str_offices.IsDeleted,
  usr_accounts.USR_AccountID,
  cmn_str_offices.CMN_STR_OfficeID
FROM
  cmn_str_offices
  INNER JOIN cmn_bpt_emp_employee_2_office
    ON cmn_str_offices.CMN_STR_OfficeID = cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID AND
       cmn_bpt_emp_employee_2_office.IsDeleted = 0
  INNER JOIN cmn_bpt_emp_employees
    ON cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID = cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID AND
       cmn_bpt_emp_employees.IsDeleted = 0
  INNER JOIN cmn_bpt_businessparticipants
    ON cmn_bpt_emp_employees.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID AND
       cmn_bpt_businessparticipants.IsDeleted = 0
  INNER JOIN usr_accounts
    ON usr_accounts.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
    AND usr_accounts.IsDeleted = 0
WHERE
  cmn_str_offices.IsDeleted = 0 AND
  cmn_str_offices.Tenant_RefID = @TenantID AND
  usr_accounts.USR_AccountID = @AccountID AND
  usr_accounts.Tenant_RefID = @TenantID
  