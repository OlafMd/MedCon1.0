
Select
  cmn_str_pps_workareas.CMN_STR_PPS_WorkAreaID,
  cmn_str_pps_workareas.Parent_RefID,
  cmn_str_pps_workareas.Office_RefID,
  cmn_str_pps_workareas.Name_DictID As WorkAreaName_DictID,
  cmn_str_pps_workareas.Description_DictID As WorkAreaDescription_DictID,
  cmn_str_pps_workareas.Default_StartWorkingHour,
  cmn_str_pps_workareas.ShortName,
  WorkAreaTypes.CMN_STR_PPS_WorkArea_TypeID,
  WorkAreaTypes.Name_DictID As WorkAreaTypeName_DictID,
  WorkAreaTypes.Description_DictID As WorkAreaTypeDescription_DictID,
  cmn_str_pps_workareas.CMN_BPT_STA_SettingProfile_RefID,
  cmn_str_pps_workareas.CMN_CAL_CalendarInstance_RefID,
  cmn_str_pps_workarea_2_costcenter.AssignmentID,
  cmn_str_costcenters.CMN_STR_CostCenterID,
  cmn_str_costcenters.Name_DictID,
  cmn_str_costcenters.InternalID,
  ResponsiblePersons.WorkArea_RefID,
  ResponsiblePersons.CMN_STR_PPS_WorkArea_ResponsiblePersonID,
  ResponsiblePersons.CMN_BPT_EMP_EmployeeID,
  ResponsiblePersons.CMN_BPT_BusinessParticipantID,
  ResponsiblePersons.FirstName,
  ResponsiblePersons.LastName,
  ResponsiblePersons.CMN_PER_PersonInfoID
From
  cmn_str_pps_workareas Left Join
  (Select
    cmn_str_pps_workarea_types.CMN_STR_PPS_WorkArea_TypeID,
    cmn_str_pps_workarea_types.Name_DictID,
    cmn_str_pps_workarea_types.Description_DictID
  From
    cmn_str_pps_workarea_types
  Where
    cmn_str_pps_workarea_types.IsDeleted = 0) WorkAreaTypes
    On cmn_str_pps_workareas.WorkArea_Type_RefID =
    WorkAreaTypes.CMN_STR_PPS_WorkArea_TypeID Left Join
  cmn_str_pps_workarea_2_costcenter
    On cmn_str_pps_workarea_2_costcenter.WorkArea_RefID =
    cmn_str_pps_workareas.CMN_STR_PPS_WorkAreaID Left Join
  cmn_str_costcenters On cmn_str_pps_workarea_2_costcenter.CostCenter_RefID =
    cmn_str_costcenters.CMN_STR_CostCenterID Left Join
  (Select
    cmn_str_pps_workarea_responsiblepersons.WorkArea_RefID,
    cmn_str_pps_workarea_responsiblepersons.CMN_STR_PPS_WorkArea_ResponsiblePersonID,
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    cmn_per_personinfo.CMN_PER_PersonInfoID
  From
    cmn_str_pps_workarea_responsiblepersons Inner Join
    cmn_bpt_emp_employees On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
      cmn_str_pps_workarea_responsiblepersons.CMN_BPT_EMP_Employee_RefID
    Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_emp_employees.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
    cmn_per_personinfo
      On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID
  Where
    cmn_str_pps_workarea_responsiblepersons.IsDeleted = 0 And
    cmn_bpt_emp_employees.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0) ResponsiblePersons
    On ResponsiblePersons.WorkArea_RefID =
    cmn_str_pps_workareas.CMN_STR_PPS_WorkAreaID
Where
  cmn_str_pps_workareas.ShortName = @ShortName And
  cmn_str_pps_workareas.IsDeleted = 0 And
  cmn_str_pps_workareas.Tenant_RefID = @TenantID And
  (cmn_str_pps_workarea_2_costcenter.IsDeleted = 0 Or
    cmn_str_pps_workarea_2_costcenter.IsDeleted Is Null) And
  (cmn_str_costcenters.IsDeleted = 0 Or
    cmn_str_costcenters.IsDeleted Is Null)
	