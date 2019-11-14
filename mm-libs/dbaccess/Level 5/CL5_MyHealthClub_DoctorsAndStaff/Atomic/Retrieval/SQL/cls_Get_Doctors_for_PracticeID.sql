
	Select
  hec_doctors.HEC_DoctorID As doctor_id,
  Concat_Ws(' ', cmn_per_personinfo.Title,cmn_per_personinfo.FirstName, cmn_per_personinfo.LastName) As doctor
From
  cmn_str_offices Inner Join
  cmn_bpt_emp_employee_2_office On cmn_str_offices.CMN_STR_OfficeID =
    cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID And
    cmn_bpt_emp_employee_2_office.Tenant_RefID = @TenantID And
    cmn_bpt_emp_employee_2_office.IsDeleted = 0 Inner Join
  cmn_bpt_emp_employees On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
    cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID And
    cmn_bpt_emp_employees.IsDeleted = 0 And cmn_bpt_emp_employees.Tenant_RefID =
    @TenantID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_emp_employees.BusinessParticipant_RefID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID And
    cmn_per_personinfo.IsDeleted = 0 And cmn_per_personinfo.Tenant_RefID =
    @TenantID Inner Join
  hec_doctors On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_doctors.BusinessParticipant_RefID And hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID
Where
  cmn_str_offices.CMN_STR_OfficeID = @OfficeID And
  cmn_str_offices.IsDeleted = 0 And
  cmn_str_offices.Tenant_RefID = @TenantID
  