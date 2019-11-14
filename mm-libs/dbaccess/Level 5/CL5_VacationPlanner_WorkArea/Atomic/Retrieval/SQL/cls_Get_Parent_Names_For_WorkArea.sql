
Select
  cmn_str_offices.Office_Name_DictID,
  cmn_str_pps_workareas1.Name_DictID As WorkAreaParentName_DictID,
  cmn_str_pps_workareas.CMN_STR_PPS_WorkAreaID
From
  cmn_str_pps_workareas Inner Join
  cmn_str_offices On cmn_str_pps_workareas.Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID Left Join
  cmn_str_pps_workareas cmn_str_pps_workareas1
    On cmn_str_pps_workareas.Parent_RefID =
    cmn_str_pps_workareas1.CMN_STR_PPS_WorkAreaID
Where
  cmn_str_pps_workareas.CMN_STR_PPS_WorkAreaID = @WorkAreaID
  