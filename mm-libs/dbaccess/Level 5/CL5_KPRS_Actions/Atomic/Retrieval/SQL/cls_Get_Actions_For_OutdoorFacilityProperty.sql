
Select
  res_act_action_version.Action_Name_DictID,
  res_act_action_version.RES_ACT_Action_VersionID,
  res_act_action_version.Default_UnitAmount,
  res_act_action_version.Default_PricePerUnit_RefID,
  res_act_action_version.Default_Unit_RefID,
  res_act_action_version.Action_Description_DictID
From
  res_act_action Inner Join
  res_act_action_version On res_act_action.CurrentVersion_RefID =
    res_act_action_version.RES_ACT_Action_VersionID Inner Join
  res_str_outdoorfacility_property_availableactions
    On res_act_action.RES_ACT_ActionID =
    res_str_outdoorfacility_property_availableactions.RES_ACT_Action_RefID
Where
  res_str_outdoorfacility_property_availableactions.RES_STR_OutdoorFacility_Property_RefID = @PropertyID And
  res_str_outdoorfacility_property_availableactions.IsDeleted = 0 And
  res_act_action_version.IsDeleted = 0 And
  res_act_action_version.Tenant_RefID = @TenantID And
  res_act_action.IsDeleted = 0
  