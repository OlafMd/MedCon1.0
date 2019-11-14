
Select
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Title,
  hec_doctors.IsTreatingChildren,
  cmn_per_personinfo.Gender,
  hec_doctors.DoctorIDNumber,
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
  cmn_bpt_emp_employees.Staff_Number,
  cmn_str_professions.CMN_STR_ProfessionID,
  cmn_str_professions.ProfessionName_DictID,
  cmn_bpt_businessparticipants.DisplayImage_RefID,
  cmn_bpt_emp_employee_2_profession.IsPrimary,
  cmn_per_personinfo.Gender,
  cmn_per_personinfo.Initials,
  hec_doctors.Account_RefID,
  
  hec_cmt_memberships.HEC_CMT_MembershipID,
  hec_cmt_groupsubscriptions.HEC_CMT_GroupSubscriptionID,
  hec_cmt_communitygroups.HEC_CMT_CommunityGroupID,
  hec_cmt_communitygroups.CommunityGroupCode
From
  cmn_bpt_businessparticipants Inner Join
  cmn_bpt_emp_employees On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_bpt_emp_employee_2_profession
    On cmn_bpt_emp_employee_2_profession.Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID Inner Join
  cmn_str_professions On cmn_bpt_emp_employee_2_profession.Profession_RefID =
    cmn_str_professions.CMN_STR_ProfessionID Left Join
  hec_cmt_memberships On hec_cmt_memberships.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    (hec_cmt_memberships.IsDeleted Is Null Or hec_cmt_memberships.IsDeleted = 0)
  Left Join
  hec_cmt_groupsubscriptions On hec_cmt_groupsubscriptions.Membership_RefID =
    hec_cmt_memberships.HEC_CMT_MembershipID And
    (hec_cmt_groupsubscriptions.IsDeleted Is Null Or
      hec_cmt_groupsubscriptions.IsDeleted = 0) Left Join
  hec_cmt_communitygroups On hec_cmt_groupsubscriptions.CommunityGroup_RefID =
    hec_cmt_communitygroups.HEC_CMT_CommunityGroupID
    and ( hec_cmt_communitygroups.IsDeleted is null or  hec_cmt_communitygroups.IsDeleted = 0)
Where
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_emp_employees.IsDeleted = 0 And
  cmn_bpt_emp_employee_2_profession.IsDeleted = 0 And
  cmn_str_professions.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1
 
  