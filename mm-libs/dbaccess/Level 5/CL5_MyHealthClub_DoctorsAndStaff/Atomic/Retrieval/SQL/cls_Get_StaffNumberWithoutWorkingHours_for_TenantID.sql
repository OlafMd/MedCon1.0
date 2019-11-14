
Select
  Count(Distinct cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID) As StaffNumber
From
  cmn_bpt_emp_employees Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipant_availabilities
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_availabilities.BusinessParticipant_RefID And
    cmn_bpt_businessparticipant_availabilities.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipant_availabilities.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 Inner Join
  cmn_bpt_emp_employee_2_office On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID
    = cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID  And
  cmn_bpt_emp_employee_2_office.Tenant_RefID = @TenantID And
  cmn_bpt_emp_employee_2_office.IsDeleted = 0
Where
  cmn_bpt_emp_employees.IsDeleted = 0 And
  cmn_bpt_emp_employees.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipant_availabilities.CMN_BPT_BusinessParticipant_AvailabilityID Is Null
  