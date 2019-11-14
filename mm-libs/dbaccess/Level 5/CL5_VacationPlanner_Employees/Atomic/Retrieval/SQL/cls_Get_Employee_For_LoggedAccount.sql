
    
 Select
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
  cmn_bpt_emp_employees.Staff_Number,
  cmn_bpt_emp_employees.StandardFunction
From
  cmn_bpt_emp_employees Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_emp_employees.BusinessParticipant_RefID
Where
  usr_accounts.USR_AccountID = @AccountID And
  cmn_bpt_emp_employees.IsDeleted = 0 and
  usr_accounts.IsDeleted = 0
    